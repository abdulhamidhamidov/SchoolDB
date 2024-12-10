using Domain.Models;

namespace Infrastructure.SubjectServices;

public interface ISubjectService
{
    bool Create(Subject subject);
    List<Subject> GetAll();
    Subject GetById(int id);
    bool Update(Subject subject);
    bool Delete(int id);
}