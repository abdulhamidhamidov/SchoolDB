namespace Domain.Models;

public class Student
{
    public int Id { get; set; }
    public string StudentCode { get; set; }
    public string StudentFullName { get; set; }
    public string Gender { get; set; }
    public DateTime Dob { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public int SchoolId { get; set; }
    public int Stage { get; set; }
    public string Section { get; set; }
    public bool IsActive { get; set; }
    public DateTime JoinDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdateAt { get; set; }
}