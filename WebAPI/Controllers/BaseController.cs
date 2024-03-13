using Data.Entities;
using Data.Models.Common;
using Data.Models.RequestModel;
using Data.Models.ResponseModel;
using Data.Models.Users;
using Data.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.AttributeFilter;
namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class BaseController<T> : ControllerBase where T : BaseEntity
{
    private readonly BaseEntityService<T> service;

    public BaseController(BaseEntityService<T> service)
    {
        this.service = service;
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<ListDataOutput<T>> GetList(Pager pager)
    {
        var isAdmin = HttpContext.Request.Headers["Admin"] == "true";
        if (isAdmin) pager.IsAdmin = true;
        return await service.GetList(pager);
    }


    [HttpGet]
    [AllowAnonymous]
    public async Task<DataOutput<T>> GetById(int id)
    {
        var response = new DataOutput<T>();
        try
        {
            var data = await service.GetById(id);
            if (data != null)
            {
                response.Data = data;
                response.StatusCode = ResponseStatusCode.Success;
            }
        }
        catch (Exception ex)
        {
            response.StatusCode = ResponseStatusCode.Error;
        }

        return response;
    }

    [HttpPost]
    [BasicAuthorizeFilter]
    public async Task<Response> Insert(T entity)
    {
        return await service.Insert(entity);
    }

    [HttpPost]
    [BasicAuthorizeFilter]
    public async Task<Response> Update(T entity)
    {
        var response = new DataOutput<T>();
        try
        {
            var data = await service.GetById(entity.Id);
            if (data == null)
            {
                response.Data = data;
                response.StatusCode = ResponseStatusCode.Success;
                return response;
            }
        }
        catch(Exception ex)
        {
            response.ErrorMessage = ex.Message;
            response.StatusCode = ResponseStatusCode.Error;
            return response;
        }

        return await service.Update(entity);
    }

    [HttpPost]
    [BasicAuthorizeFilter]
    public async Task<Response> Delete(int id)
    {
        return await service.Delete(id);
    }
}