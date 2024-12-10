namespace Domain.Models;

public class StudentParent
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int ParentId { get; set; }
    public int Pelationship { get; set; }
}