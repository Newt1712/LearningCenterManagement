using System.Text.Json.Serialization;
using Data;
using Data.Context.Memory;
using Data.Context.MSSQLContext;
using Data.Entities;
using Data.Redises;
using Data.Redises.Distributed;
using Data.Redises.ExchangeAPI;
using Data.Service;
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using WebAPI.AttributeFilter;
using WebAPI.ServiceExtensions;

var builder = WebApplication.CreateBuilder(args);
// config
var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", false)
    .Build();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
        policy.WithOrigins("http://localhost:8000").AllowAnyHeader().AllowAnyHeader());
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader().DisallowCredentials();
            //.AllowCredentials();
        });
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1.1",
        Title = "API",
        Description = "LearningCenter",
        Contact = new OpenApiContact
        {
            Name = "LearningCenter"
        }
    });
    c.OperationFilter<AddRequiredHeaderParameter>();
    // Set the comments path for the Swagger JSON and UI.    
    var xmlFile = "API.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

// config service context
builder.Services.AddJwt(builder.Configuration);
builder.Services.AddMemoryCache();
builder.Services.AddSingleton<IMemoryService, MemoryManager>();

builder.Services.AddStackExchangeRedisCache(options => { options.Configuration = "localhost:6379"; });
builder.Services.AddSingleton<IRedisDistributedService, RedisDistributedManager>();
builder.Services.AddSingleton<IRedisStackExchangeAPI, RedisStackExchangeAPI>();
builder.Services.Configure<RedisSettings>(builder.Configuration.GetSection(nameof(RedisSettings)));
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(AppSettings.MSSQLSettings.SQLConn));

builder.Services.AddScoped<BaseEntityService<Parent>>();
builder.Services.AddScoped<ParentService>();
builder.Services.AddScoped<BaseEntityService<Course>>();
builder.Services.AddScoped<CourseService>();
builder.Services.AddScoped<BaseEntityService<Classroom>>();
builder.Services.AddScoped<ClassroomService>();
builder.Services.AddScoped<BaseEntityService<Student>>();
builder.Services.AddScoped<StudentService>();
builder.Services.AddScoped<BaseEntityService<Teacher>>();
builder.Services.AddScoped<TeacherService>();
builder.Services.AddScoped<BaseEntityService<Grade>>();
builder.Services.AddScoped<GradeService>();

AppSettings.Init(builder.Services, builder.Configuration);

//TODO: Service

// hangfire
builder.Services.AddHangfire(configuration => configuration
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UseSqlServerStorage(AppSettings.MSSQLSettings.SQLConn, new SqlServerStorageOptions
    {
        CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
        SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
        QueuePollInterval = TimeSpan.Zero,
        UseRecommendedIsolationLevel = true,
        DisableGlobalLocks = true
    }));
builder.Services.AddHangfireServer();
builder.Services.AddMvc().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
});

builder.Services.AddSignalR(o =>
{
    o.EnableDetailedErrors = true;
    o.KeepAliveInterval = TimeSpan.FromMinutes(1);
}).AddJsonProtocol(options =>
{
    options.PayloadSerializerOptions.PropertyNamingPolicy = null;
    options.PayloadSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});


// setup sentry and app
//using (SentrySdk.Init(o =>
//{
//    string dsn = config.GetValue<string>("Sentry:Dsn");
//    string release = config.GetValue<string>("Sentry:Release");
//    string enviroment = config.GetValue<string>("Sentry:Environment");

//    o.Dsn = dsn;
//    o.Release = release;
//    o.Environment = enviroment;
//}))
{
    var app = builder.Build();
    app.UseCors("AllowAllOrigins");
    // Configure the HTTP request pipeline.
    // if (app.Environment.IsDevelopment())
    // {
    //     app.UseSwagger();
    //     app.UseSwaggerUI();
    // }
    app.UseHangfireDashboard("/jobs", new DashboardOptions
    {
        Authorization = new[] { new HangfireFilter() }
    });

    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();


    app.Run();
}