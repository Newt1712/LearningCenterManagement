using Data.Context.MSSQLContext;
using Data.Entities;

namespace Data.Service;

public class ClassroomService : BaseEntityService<Classroom>
{
    private readonly ApplicationDbContext dbContext;

    public ClassroomService(ApplicationDbContext dbContext) : base(dbContext)
    {
        this.dbContext = dbContext;
    }
}