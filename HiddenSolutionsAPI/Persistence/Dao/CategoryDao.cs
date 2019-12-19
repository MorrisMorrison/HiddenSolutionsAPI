using HiddenSolutionsAPI.Persistence.Model;

namespace HiddenSolutionsAPI.Persistence.Dao
{
    public class CategoryDao:ICreationDaoAsync<Category>
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
    }
}