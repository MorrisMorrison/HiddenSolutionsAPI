using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using RepositoryNotifier.Config;

namespace HiddenSolutionsAPI.Persistence
{
    
    public interface IDbAccess
    {
        IMongoDatabase GetDatabase();
        IMongoCollection<T> GetCollection<T>();
    }
    
    public class DbAccess:IDbAccess
    {
        
        private  string _connectionString { get; set; }
        private  MongoClient _client { get; set; }
        private  IMongoDatabase _database { get; set; }
        private IConfiguration _configuration {get;set;}
        private ILogger<DbAccess> _logger {get;set;}

        public DbAccess(IConfiguration p_configuration, ILogger<DbAccess> p_logger){
            _configuration = p_configuration;
            _logger = p_logger;
        }

        public  IMongoDatabase GetDatabase()
        {
            if (_database != null) return _database;
            
            _logger.LogInformation("No database connection exists yet. Initializing new connection.");

            DatabaseConfig config = new DatabaseConfig(_configuration);

            _connectionString = config.CONNECTION_STRING;
            _client = new MongoClient(connectionString: _connectionString + "?retryWrites=false");
            _database = _client.GetDatabase(config.DATABASE);

            return _database;
        }

        public IMongoCollection<T> GetCollection<T>()
        {
           return  GetDatabase().GetCollection<T>(typeof(T).Name);
        }
        
    }
}