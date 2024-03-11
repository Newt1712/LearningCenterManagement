using Data.Entities;
using Data.Service;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class ClassroomController : BaseController<Classroom>
{
    private readonly ClassroomService service;

    public ClassroomController(ClassroomService service) : base(service)
    {
        this.service = service;
    }
}