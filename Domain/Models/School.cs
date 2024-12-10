namespace Domain.Models;

public class School
{
    public int Id { get; set; }
    public string SchoolTitle { get; set; }
    public int LevelCount { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdateAt { get; set; }
}