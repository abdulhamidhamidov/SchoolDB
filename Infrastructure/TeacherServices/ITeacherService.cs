using Domain.Models;

namespace Infrastructure.TeacherServices;

public interface ITeacherService
{
    bool Create(Teacher teacher);
    List<Teacher> GetAll();
    Teacher GetById(int id);
    bool Update(Teacher teacher);
    bool Delete(int id);
}