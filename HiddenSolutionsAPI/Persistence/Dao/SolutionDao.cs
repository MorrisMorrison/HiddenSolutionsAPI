using System.Collections.Generic;
using System.Threading.Tasks;
using HiddenSolutionsAPI.Persistence.Model;
using MongoDB.Driver;

namespace HiddenSolutionsAPI.Persistence.Dao
{

    public class SolutionDao:IDaoAsync<Solution>
    {
        public IDbAccess DbAccess { get; set; }

        public SolutionDao(IDbAccess p_dbAccess)
        {
            DbAccess = p_dbAccess;
        }

        public void CreateAsync(Solution p_entity)
        {
            DbAccess.GetCollection<Solution>().InsertOne(p_entity);
        }

        public async Task<Solution> GetAsync(long p_id)
        {
            return await DbAccess.GetCollection<Solution>().Find(p_solution => p_solution.Id == p_id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Solution>> GetAllAsync()
        {
            return await DbAccess.GetCollection<Solution>().Find(_ => true).ToListAsync();
        }

        public async void UpdateAsync(Solution p_entity)
        {
            await DbAccess.GetCollection<Solution>().ReplaceOneAsync(p_solution => p_solution.Id == p_entity.Id, p_entity);
        }

        public void DeleteAsync(long p_id)
        {
            DbAccess.GetCollection<Solution>().DeleteOneAsync(p_solution => p_solution.Id == p_id);
        }
    }
}