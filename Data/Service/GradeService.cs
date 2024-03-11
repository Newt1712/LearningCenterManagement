using Data.Context.MSSQLContext;
using Data.Entities;

namespace Data.Service;

public class GradeService : BaseEntityService<Grade>
{
    private readonly ApplicationDbContext dbContext;

    public GradeService(ApplicationDbContext dbContext) : base(dbContext)
    {
        this.dbContext = dbContext;
    }
}