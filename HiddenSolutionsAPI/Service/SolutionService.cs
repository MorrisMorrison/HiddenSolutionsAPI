using System.Collections.Generic;
using System.Threading.Tasks;
using HiddenSolutionsAPI.Persistence.Dao;
using HiddenSolutionsAPI.Persistence.Model;

namespace HiddenSolutionsAPI.Service
{
    public class SolutionService:ICrudService<Solution>
    {
        public IDaoAsync<Solution> Dao { get; set; }

        public SolutionService(IDaoAsync<Solution> p_dao)
        {
            Dao = p_dao;
        }

        public async Task<Solution> Create(Solution p_solution)
        {
            return await Dao.CreateAsync(p_solution);
        }

        public async Task<Solution> Get(string p_id)
        {
            return await Dao.GetAsync(p_id);
        }

        public async Task<IEnumerable<Solution>> GetAll()
        {
            return await Dao.GetAllAsync();
        }

        public void Update(Solution p_entity)
        {
            Dao.UpdateAsync(p_entity);
        }

        public void Delete(string p_id)
        {
            Dao.DeleteAsync(p_id);
        }
    }
}