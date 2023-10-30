using MvcTask.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MvcTask.Services
{
    public class TaskService
    {
        private readonly IMongoCollection<TaskItem> _taskCollection;

        public TaskService(IOptions<TodoDataBaseSettings> todoSettings)
        {
            var settings = todoSettings.Value;
            var mongoClient = new MongoClient(settings.ConnectionString);
            var mongoDataBase = mongoClient.GetDatabase(settings.DatabaseName);
            _taskCollection = mongoDataBase.GetCollection<TaskItem>(settings.TaskCollectionName);
        }

        public async Task<List<TaskItem>> GetAllAsync() =>
            await _taskCollection.Find(_ => true).ToListAsync();

        public async Task<TaskItem?> GetAsync(string id) =>
            await _taskCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(TaskItem newTask) =>
            await _taskCollection.InsertOneAsync(newTask);

        public async Task UpdateAsync(string id, TaskItem updatedTask) =>
            await _taskCollection.ReplaceOneAsync(x => x.Id == id, updatedTask);

        public async Task RemoveAsync(string id) =>
            await _taskCollection.DeleteOneAsync(x => x.Id == id);
    }
}
