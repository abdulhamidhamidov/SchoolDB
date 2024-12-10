using Domain.Models;

namespace Infrastructure.ClassroomServices;

public interface IClassroomService
{
    bool Create(Classroom classroom);
    List<Classroom> GetAll();
    Classroom GetById(int id);
    bool Update(Classroom classroom);
    bool Delete(int id);
}