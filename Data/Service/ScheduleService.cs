using Data.Context.MSSQLContext;
using Data.Entities;

namespace Data.Service;

public class ScheduleService : BaseEntityService<Schedules>
{
    private readonly ApplicationDbContext dbContext;

    public ScheduleService(ApplicationDbContext dbContext) : base(dbContext)
    {
        this.dbContext = dbContext;
    }
}