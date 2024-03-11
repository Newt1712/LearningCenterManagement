using Data.Entities;
using Data.Service;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class StudentController : BaseController<Student>
{
    private readonly StudentService service;

    public StudentController(StudentService service) : base(service)
    {
        this.service = service;
    }
}