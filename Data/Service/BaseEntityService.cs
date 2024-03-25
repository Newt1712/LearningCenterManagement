using Data.Context.MSSQLContext;
using Data.Entities;
using Data.Models.Common;
using Data.Models.RequestModel;
using Data.Models.ResponseModel;
using Data.Utils;
using Microsoft.EntityFrameworkCore;
using Sentry;

namespace Data.Service;
#pragma warning disable CS8618
public class BaseEntityService<TEntity> where TEntity : BaseEntity
{
    public readonly ApplicationDbContext _context;
    private readonly DbSet<TEntity> _entities;

    public BaseEntityService(ApplicationDbContext context)
    {
        _context = context;
        _entities = _context.Set<TEntity>();
    }

    public async Task<ListDataOutput<TEntity>> GetList(Pager pager)
    {
        var response = new ListDataOutput<TEntity>();
        try
        {
            var data = _context.Set<TEntity>().OrderByDescending(o => o.Id).AsQueryable();
            response.TotalRecord = data.Count();
            response.Data = data.Skip((pager.PageIndex - 1) * pager.PageSize).Take(pager.PageSize).ToList();
            response.StatusCode = ResponseStatusCode.Success;
        }
        catch (Exception ex)
        {
            response.StatusCode = ResponseStatusCode.Error;
            response.ErrorMessage = EnumMessage.ERROR.GetDescription();
            SentrySdk.CaptureException(ex);
        }

        return response;
    }

    public async Task<TEntity> GetById(int id)
    {
        try
        {
            return await _context.FindAsync<TEntity>(id);
        }
        catch (Exception ex)
        {
            SentrySdk.CaptureException(ex);
        }

        return null;
    }

    public async Task<Response> InsertMulti(List<TEntity> entities)
    {
        var response = new Response();
        try
        {
            var totalRecord = entities.Count();
            using (var transaction = _context.Database.BeginTransaction())
            {
                var index = 0;
                foreach (var id in entities)
                {
                    var res = await Insert(id);
                    if (res.StatusCode == ResponseStatusCode.Success) index++;
                }

                if (index == totalRecord)
                {
                    response.StatusCode = ResponseStatusCode.Success;
                    transaction.Commit();
                }
                else
                {
                    response.ErrorMessage = EnumMessage.ERROR.GetDescription();
                    response.StatusCode = ResponseStatusCode.Error;
                    transaction.Rollback();
                }
            }
        }
        catch (Exception ex)
        {
            response.StatusCode = ResponseStatusCode.Error;
            response.ErrorMessage = EnumMessage.ERROR.GetDescription();
            SentrySdk.CaptureException(ex);
        }

        return response;
    }

    public async Task<Response> Insert(TEntity entity)
    {
        var response = new Response();
        try
        {
            var property = entity.GetType().GetProperty("CreatedDate");
            if (property != null) property.SetValue(entity, ObjectCodeHelper.ConvertUtcToVnTime());

            var result = await _context.AddAsync(entity);
            var affected = await _context.SaveChangesAsync();
            response.StatusCode = affected > 0 ? ResponseStatusCode.Success : ResponseStatusCode.Error;
            response.Id = entity.Id;
        }
        catch (Exception ex)
        {
            response.StatusCode = ResponseStatusCode.Error;
            response.ErrorMessage = EnumMessage.ERROR.GetDescription();
            SentrySdk.CaptureException(ex);
        }

        return response;
    }

    public async Task<Response> Update(TEntity entity)
    {
        var response = new Response();
        try
        {
            if (!await _entities.AnyAsync(x => x.Id == entity.Id))
            {
                response.StatusCode = ResponseStatusCode.Error;
                response.ErrorMessage = EnumMessage.NOT_EXISTED.GetDescription();
                return response;
            }

            _context.Update(entity);
            var affected = await _context.SaveChangesAsync();
            response.StatusCode = affected > 0 ? ResponseStatusCode.Success : ResponseStatusCode.Error;
        }
        catch (Exception ex)
        {
            response.StatusCode = ResponseStatusCode.Error;
            response.ErrorMessage = EnumMessage.ERROR.GetDescription();
            SentrySdk.CaptureException(ex);
        }

        return response;
    }

    public async Task<Response> Delete(int id)
    {
        var response = new Response();
        try
        {
            var entity = await GetById(id);
            if (entity == null)
            {
                response.StatusCode = ResponseStatusCode.Error;
                response.ErrorMessage = EnumMessage.NOT_EXISTED.GetDescription();
                return response;
            }

            //_context.Remove<TEntity>(entity);
            _context.Remove(entity);
            var affected = await _context.SaveChangesAsync();
            response.StatusCode = affected > 0 ? ResponseStatusCode.Success : ResponseStatusCode.Error;
        }

        catch (Exception ex)
        {
            response.StatusCode = ResponseStatusCode.Error;
            response.ErrorMessage = EnumMessage.ERROR.GetDescription();
            SentrySdk.CaptureException(ex);
        }

        return response;
    }

    public async Task<Response> DeleteMultiById(List<int> ids)
    {
        var response = new Response();
        try
        {
            var totalRecord = ids.Count();
            using (var transaction = _context.Database.BeginTransaction())
            {
                var index = 0;
                foreach (var id in ids)
                {
                    var res = await Delete(id);
                    if (res.StatusCode == ResponseStatusCode.Success) index++;
                }

                if (index == totalRecord)
                {
                    response.StatusCode = ResponseStatusCode.Success;
                    transaction.Commit();
                }
                else
                {
                    response.ErrorMessage = EnumMessage.ERROR.GetDescription();
                    response.StatusCode = ResponseStatusCode.Error;
                    transaction.Rollback();
                }
            }
        }
        catch (Exception ex)
        {
            response.StatusCode = ResponseStatusCode.Error;
            response.ErrorMessage = EnumMessage.ERROR.GetDescription();
            SentrySdk.CaptureException(ex);
        }

        return response;
    }
}