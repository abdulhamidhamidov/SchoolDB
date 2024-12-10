using Domain.Models;

namespace Infrastructure.StudentParentServices;

public interface IStudentParentService
{
    bool Create(StudentParent studentParent);
    List<StudentParent> GetAll();
    StudentParent GetById(int id);
    bool Update(StudentParent studentParent);
    bool Delete(int id);
}