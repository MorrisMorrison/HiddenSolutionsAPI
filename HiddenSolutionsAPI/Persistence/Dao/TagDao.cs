using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using Tag = HiddenSolutionsAPI.Persistence.Model.Tag;

namespace HiddenSolutionsAPI.Persistence.Dao
{
    public class TagDao:IDaoAsync<Tag>
    {
        public IDbAccess DbAccess { get; set; }

        public TagDao(IDbAccess p_dbAccess)
        {
            DbAccess = p_dbAccess;
        }

        public async Task<Tag> CreateAsync(Tag p_tag)
        {
            await DbAccess.GetCollection<Tag>().InsertOneAsync(p_tag);

            return p_tag;
        }

        public async Task<Tag> GetAsync(string p_id)
        {
            return await DbAccess.GetCollection<Tag>().Find<Tag>(p_tag => p_tag.Id == p_id).FirstOrDefaultAsync();

        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            return await DbAccess.GetCollection<Tag>().Find(_ => true).ToListAsync();

        }

        public async void UpdateAsync(Tag p_entity)
        {
            await DbAccess.GetCollection<Tag>().ReplaceOneAsync(p_tag => p_tag.Id.Equals(p_entity.Id), p_entity);

        }

        public void DeleteAsync(string p_id)
        {
            DbAccess.GetCollection<Tag>().DeleteOneAsync(p_tag => p_tag.Id.Equals(p_id));

        }
    }
}