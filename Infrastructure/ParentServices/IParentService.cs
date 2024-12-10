using Domain.Models;

namespace Infrastructure.ParentServices;

public interface IParentService
{
    bool Create(Parent parent);
    List<Parent> GetAll();
    Parent GetById(int id);
    bool Update(Parent parent);
    bool Delete(int id);
}