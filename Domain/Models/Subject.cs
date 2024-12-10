namespace Domain.Models;

public class Subject
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int SchoolId { get; set; }
    public int Stage { get; set; }
    public int Team { get; set; }
    public int CarryMark { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdateAt { get; set; }
}