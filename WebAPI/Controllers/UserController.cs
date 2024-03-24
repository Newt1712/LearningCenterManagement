using Data.Entities;
using Data.Service;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class UserController : BaseController<Users>
{
    private readonly UserService service;

    public UserController(UserService service) : base(service)
    {
        this.service = service;
    }
}