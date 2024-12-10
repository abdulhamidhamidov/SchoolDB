using Domain.Models;

namespace Infrastructure.ClassStudentServices;

public interface IClassStudentService
{
    bool Create(ClassStudent classStudent);
    List<ClassStudent> GetAll();
    ClassStudent GetById(int id);
    bool Update(ClassStudent classStudent);
    bool Delete(int id);
}