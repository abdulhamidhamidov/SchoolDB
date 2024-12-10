namespace Domain.Models;

public class Parent
{
    public int Id { get; set; }
    public string ParentCode { get; set; }
    public string ParentFullName { get; set; }
    public string Gender { get; set; }
    public DateTime Dob { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdateAt { get; set; }
}