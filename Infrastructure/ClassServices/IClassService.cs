using Domain.Models;

namespace Infrastructure.ClassServices;

public interface IClassService
{
    bool Create(Class _class);
    List<Class> GetAll();
    Class GetById(int id);
    bool Update(Class _class);
    bool Delete(int id);
}