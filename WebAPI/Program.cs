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

builder.Services.AddScoped<BaseEntityService<Parents>>();
builder.Services.AddScoped<ParentService>();
builder.Services.AddScoped<BaseEntityService<Classrooms>>();
builder.Services.AddScoped<ClassroomService>();
builder.Services.AddScoped<BaseEntityService<Subjects>>();
builder.Services.AddScoped<SubjectService>();
builder.Services.AddScoped<BaseEntityService<Students>>();
builder.Services.AddScoped<StudentService>();
builder.Services.AddScoped<BaseEntityService<Users>>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<BaseEntityService<Schedules>>();
builder.Services.AddScoped<ScheduleService>();
builder.Services.AddScoped<BaseEntityService<Teachers>>();
builder.Services.AddScoped<TeacherService>();

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