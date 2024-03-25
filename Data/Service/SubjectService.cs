using Data.Context.MSSQLContext;
using Data.Entities;

namespace Data.Service;

public class SubjectService : BaseEntityService<Subjects>
{
    private readonly ApplicationDbContext dbContext;

    public SubjectService(ApplicationDbContext dbContext) : base(dbContext)
    {
        this.dbContext = dbContext;
    }
}