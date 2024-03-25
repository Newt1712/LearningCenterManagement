using Data.Context.MSSQLContext;
using Data.Entities;

namespace Data.Service;

public class StudentService : BaseEntityService<Students>
{
    private readonly ApplicationDbContext dbContext;

    public StudentService(ApplicationDbContext dbContext) : base(dbContext)
    {
        this.dbContext = dbContext;
    }
}