

namespace MauiApp1.Model;

public class TodoItem
{
    public Guid Id { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedTime { get; set; } = DateTime.Now;
    public PriorityLevel Priority { get; set; }
    public bool Completed { get; set; } = false;

}
public enum PriorityLevel
{
    High,
    Normal,
    Low
}
