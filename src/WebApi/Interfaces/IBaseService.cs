using WepApi.DTOs.ResponseModels;
using WepApi.Entities;

namespace WepApi.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
        Task<ListDataOutput<TEntity>> GetAll();
        Task<TEntity> GetByID(int id);
        Task<Response> Insert(TEntity entity);
        Task<Response> Update(TEntity entity);

        Task<Response> Delete(int id);


    }
}
