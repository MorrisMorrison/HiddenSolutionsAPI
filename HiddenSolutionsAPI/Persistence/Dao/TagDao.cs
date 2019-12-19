using System;
using MongoDB.Driver;

namespace HiddenSolutionsAPI.Persistence.Dao
{
    
    public class TagDao:ICreationDaoAsync<Tag>
    {
        public IDbAccess DbAccess { get; set; }

        public TagDao(IDbAccess p_dbAccess)
        {
            DbAccess = p_dbAccess;
        }

        public async void CreateAsync(Tag p_tag)
        {
            await DbAccess.GetCollection<Tag>().InsertOneAsync(p_tag);
        }
    }
}