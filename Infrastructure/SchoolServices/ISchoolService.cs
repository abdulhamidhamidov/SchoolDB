using Domain.Models;

namespace Infrastructure.SchoolServices;

public interface ISchoolService
{
    bool Create(School school);
    List<School> GetAll();
    School GetById(int id);
    bool Update(School school);
    bool Delete(int id);
}