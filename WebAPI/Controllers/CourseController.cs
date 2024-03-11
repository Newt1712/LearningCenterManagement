using Data.Entities;
using Data.Service;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class CourseController : BaseController<Course>
{
    private readonly CourseService service;

    public CourseController(CourseService service) : base(service)
    {
        this.service = service;
    }
}