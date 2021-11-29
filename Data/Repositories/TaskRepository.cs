using System.Collections.Generic;
using MongoDB.Driver;
using taskMenager.Data.Configurations;
using taskMenager.Models;

namespace taskMenager.Data.Repositories
{
    public class TaskRepository : ITaskRepository
    {

        private readonly IMongoCollection<task> _tasks;

        public TaskRepository(IDataConfig dataConfig)
        {
            var client = new MongoClient(dataConfig.ConnectionString);
            var database = client.GetDatabase(dataConfig.DatabaseName);

            _tasks = database.GetCollection<task>("task");
        }

        public void Create(task task)
        {
            _tasks.InsertOne(task);
        }
    
        public void Update(string id, task taskUpdate)
        {
            _tasks.ReplaceOne(t => t.Id == id, taskUpdate);
        }
        public task list(string id)
        {
            return _tasks.Find(t => t.Id == id).FirstOrDefault();
        }

        public IEnumerable<task> listAll()
        {
            return _tasks.Find(t => true).ToList();
        }

        public void Delete(string id)
        {
            _tasks.DeleteOne( t => t.Id == id);
        }
    }
}