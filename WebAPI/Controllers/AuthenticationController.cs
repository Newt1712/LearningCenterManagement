using Data.Models.RequestModel;
using Data.Models.ResponseModel;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    [HttpPost("login")]
    public async Task<Response> Login([FromBody] LoginModel model)
    {
        var response = new DataOutput<dynamic>();
        return response;
    }


    [HttpPost("refresh")]
    public async Task<Response> RefreshToken(string token)
    {
        var response = new DataOutput<dynamic>();
        return response;
    }


    [HttpPost("register")]
    public async Task<Response> Register([FromBody] LoginModel model)
    {
        var response = new DataOutput<dynamic>();
        return response;
    }
}