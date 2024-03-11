using Data.Entities;
using Data.Service;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class TeacherController : BaseController<Teacher>
{
    private readonly TeacherService service;

    public TeacherController(TeacherService service) : base(service)
    {
        this.service = service;
    }
}