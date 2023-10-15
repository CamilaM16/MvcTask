using System.ComponentModel.DataAnnotations;

namespace MvcTask.Models;

public class TaskItem
{
    public int Id { get; set; }
    public string? TaskTitle { get; set; }
    [DataType(DataType.Date)]
    public DateTime? StartDate { get; set; }
    [DataType(DataType.Date)]
    public DateTime? EndDate { get; set; }
}