using Data.Entities;
using Data.Service;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class ParentController : BaseController<Parent>
{
    private readonly ParentService service;

    public ParentController(ParentService service) : base(service)
    {
        this.service = service;
    }
}