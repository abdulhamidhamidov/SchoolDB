namespace Domain.Models;

public class Teacher
{
    public int Id { get; set; }
    public string TeacherCode { get; set; }
    public string TeacherFullName { get; set; }
    public string Gender { get; set; }
    public DateTime Dob { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public bool IsActive { get; set; }
    public DateTime JoinDate { get; set; }
    public int WorkingDays { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdateAt { get; set; }
}