using Data.Entities;
using Data.Service;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class GradeController : BaseController<Grade>
{
    private readonly GradeService service;

    public GradeController(GradeService service) : base(service)
    {
        this.service = service;
    }
}