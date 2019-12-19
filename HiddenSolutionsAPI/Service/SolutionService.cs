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

        public void Create(Solution p_entity)
        {
            Dao.CreateAsync(p_entity);
        }

        public async Task<Solution> Get(long p_id)
        {
            return await Dao.GetAsync(p_id);
        }

        public void Update(Solution p_entity)
        {
            Dao.UpdateAsync(p_entity);
        }

        public void Delete(long p_id)
        {
            Dao.DeleteAsync(p_id);
        }
    }
}