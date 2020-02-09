using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiddenSolutionsAPI.Persistence.Dao
{
    public interface IDao<T>
    {
        IDbAccess DbAccess { get; set; }
        
        public void Create(T p_entity);
        public T Get(string p_id);
        public IEnumerable<T> GetAll();
        public void Update(T p_entity);
        public void Delete(T p_entity);
    }
    
    public interface IDaoAsync<T>
    {
        IDbAccess DbAccess { get; set; }
        
        public void CreateAsync(T p_entity);
        public Task<T> GetAsync(string p_id);
        public Task<IEnumerable<T>> GetAllAsync();
        public void UpdateAsync(T p_entity);
        public void DeleteAsync(string p_id);
    }

}