using System.Collections.Generic;
using System.Threading.Tasks;
using HiddenSolutionsAPI.Persistence.Dao;
using HiddenSolutionsAPI.Persistence.Model;

namespace HiddenSolutionsAPI.Service
{
    public class TagService:ICrudService<Tag>
    {
        public IDaoAsync<Tag> Dao { get; set; }

        public TagService(IDaoAsync<Tag> p_dao)
        {
            Dao = p_dao;
        }

        public async Task<Tag> Create(Tag p_entity)
        {
            return await Dao.CreateAsync(p_entity);
        }

        public async Task<Tag> Get(string p_id)
        {
            return await Dao.GetAsync(p_id);
        }

        public async Task<IEnumerable<Tag>> GetAll()
        {
            return await Dao.GetAllAsync();
        }

        public void Update(Tag p_entity)
        {
            Dao.UpdateAsync(p_entity);
        }

        public void Delete(string p_id)
        {
            Dao.DeleteAsync(p_id);
        }
    }
}