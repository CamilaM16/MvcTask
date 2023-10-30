using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MvcTask.Models;

public class TaskItem
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("taskTitle")]
    public string? TaskTitle { get; set; }

    [BsonElement("startDate")]
    [DataType(DataType.Date)]
    public DateTime? StartDate { get; set; }

    [BsonElement("endDate")]
    [DataType(DataType.Date)]
    public DateTime? EndDate { get; set; }
}
