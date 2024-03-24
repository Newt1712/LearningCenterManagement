using Data.Entities;
using Data.Service;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ScheduleController : BaseController<Schedules>
{
    private readonly ScheduleService service;

    public ScheduleController(ScheduleService service) : base(service)
    {
        this.service = service;
    }
}