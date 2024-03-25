using Data.Entities;
using Data.Service;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class SubjectController : BaseController<Subjects>
{
    private readonly SubjectService service;

    public SubjectController(SubjectService service) : base(service)
    {
        this.service = service;
    }
}