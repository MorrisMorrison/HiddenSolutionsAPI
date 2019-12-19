using System.Threading.Tasks;
using HiddenSolutionsAPI.Persistence.Dao;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace HiddenSolutionsAPI.Service
{
    public interface ICrudService<T>
    {
        IDaoAsync<T> Dao { get; set; }
        void Create(T p_entity);
        Task<T> Get(long p_id);
        void Update(T p_entity);
        void Delete(long p_id);
    }

    public interface ICreationService<T>
    {
        IDaoAsync<T> Dao { get; set; }
        void Create(T p_entity);
    }
    
}