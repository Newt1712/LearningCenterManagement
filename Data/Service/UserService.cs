using Data.Context.MSSQLContext;
using Data.Entities;

namespace Data.Service;

public class UserService : BaseEntityService<Users>
{
    private readonly ApplicationDbContext dbContext;

    public UserService(ApplicationDbContext dbContext) : base(dbContext)
    {
        this.dbContext = dbContext;
    }
}