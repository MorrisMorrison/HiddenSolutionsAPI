using HiddenSolutionsAPI.Persistence.Dao;
using HiddenSolutionsAPI.Persistence.Model;

namespace HiddenSolutionsAPI.Service
{
    public class CategoryService:ICreationService<Category>
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
    }
}