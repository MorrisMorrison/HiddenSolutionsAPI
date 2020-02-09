using System.Collections.Generic;
using System.Threading.Tasks;
using HiddenSolutionsAPI.Persistence.Model;
using MongoDB.Driver;

namespace HiddenSolutionsAPI.Persistence.Dao
{
    
    public class CategoryDao:IDaoAsync<Category>
    {
        public IDbAccess DbAccess { get; set; }

        public CategoryDao(IDbAccess p_dbAccess)
        {
            DbAccess = p_dbAccess;
        }

        public async void CreateAsync(Category p_category)
        {
            await DbAccess.GetCollection<Category>().InsertOneAsync(p_category);
        }

        public async Task<Category> GetAsync(string p_id)
        {
            return await DbAccess.GetCollection<Category>().Find(p_category => p_category.Id.Equals(p_id)).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await DbAccess.GetCollection<Category>().Find(_ => true).ToListAsync();

        }

        public async void UpdateAsync(Category p_entity)
        {
            await DbAccess.GetCollection<Category>().ReplaceOneAsync(p_category => p_category.Id.Equals(p_entity.Id), p_entity);

        }

        public void DeleteAsync(string p_id)
        {
            DbAccess.GetCollection<Category>().DeleteOneAsync(p_category => p_category.Id.Equals(p_id));

        }
    }
}