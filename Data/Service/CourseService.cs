using Data.Context.MSSQLContext;
using Data.Entities;

namespace Data.Service;

public class CourseService : BaseEntityService<Course>
{
    private readonly ApplicationDbContext dbContext;

    public CourseService(ApplicationDbContext dbContext) : base(dbContext)
    {
        this.dbContext = dbContext;
    }
}