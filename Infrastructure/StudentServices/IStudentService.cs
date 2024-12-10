using Domain.Models;

namespace Infrastructure.StudentServices;

public interface IStudentService
{
    bool Create(Student student);
    List<Student> GetAll();
    Student GetById(int id);
    bool Update(Student student);
    bool Delete(int id);
}