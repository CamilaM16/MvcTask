
namespace MvcTask.Models
{
    public class TodoDataBaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string TaskCollectionName { get; set; } = null!;
    }
}