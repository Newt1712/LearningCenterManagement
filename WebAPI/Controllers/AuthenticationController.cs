using Data.Models.RequestModel;
using Data.Models.ResponseModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        [HttpPost]
        public async Task<Response> Login([FromBody] LoginModel model)
        {
            var response = new DataOutput<dynamic>();
            return response;
        }

    }
}
