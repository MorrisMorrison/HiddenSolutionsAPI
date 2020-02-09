using System.Collections.Generic;
using System.Threading.Tasks;
using HiddenSolutionsAPI.Persistence.Dao;
using HiddenSolutionsAPI.Persistence.Model;

namespace HiddenSolutionsAPI.Service
{
    public class CategoryService:ICrudService<Category>
    {
        public IDaoAsync<Category> Dao { get; set; }

        public CategoryService(IDaoAsync<Category> p_dao)
        {
            Dao = p_dao;
        }

        public void Create(Category p_entity)
        {
            Dao.CreateAsync(p_entity);
        }

        public async Task<Category> Get(string p_id)
        {
            return await Dao.GetAsync(p_id);
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await Dao.GetAllAsync();
        }

        public void Update(Category p_entity)
        {
            Dao.UpdateAsync(p_entity);
        }

        public void Delete(string p_id)
        {
            Dao.DeleteAsync(p_id);
        }
    }
}