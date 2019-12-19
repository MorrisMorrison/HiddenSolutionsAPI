using HiddenSolutionsAPI.Persistence.Dao;
using HiddenSolutionsAPI.Persistence.Model;

namespace HiddenSolutionsAPI.Service
{
    public class TagService:ICreationService<Tag>
    {
        public IDaoAsync<Tag> Dao { get; set; }

        public TagService(IDaoAsync<Tag> p_dao)
        {
            Dao = p_dao;
        }

        public void Create(Tag p_entity)
        {
            Dao.CreateAsync(p_entity);
        }
    }
}