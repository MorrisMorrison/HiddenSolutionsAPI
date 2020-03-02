using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using HiddenSolutionsAPI.Persistence.Dao;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace HiddenSolutionsAPI.Service
{
    public interface ICrudService<T>
    {
        IDaoAsync<T> Dao { get; set; }
        Task<T> Create(T p_entity);
        Task<T> Get(string p_id);
        Task<IEnumerable<T>> GetAll();
        void Update(T p_entity);
        void Delete(string p_id);
    }

    
}