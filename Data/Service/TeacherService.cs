using Data.Context.MSSQLContext;
using Data.Entities;

namespace Data.Service;

public class TeacherService : BaseEntityService<Teacher>
{
    private readonly ApplicationDbContext dbContext;

    public TeacherService(ApplicationDbContext dbContext) : base(dbContext)
    {
        this.dbContext = dbContext;
    }
}