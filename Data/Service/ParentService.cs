using Data.Context.MSSQLContext;
using Data.Entities;

namespace Data.Service;

public class ParentService : BaseEntityService<Parents>
{
    private readonly ApplicationDbContext dbContext;

    public ParentService(ApplicationDbContext dbContext) : base(dbContext)
    {
        this.dbContext = dbContext;
    }
}