

using Domain.Models;
using Infrastructure.SchoolServices;

SchoolService schoolService = new SchoolService();
School school = new ();
school.SchoolTitle="asdfg";
school.UpdateAt = new DateTime(1, 1, 1);
school.CreatedAt = new DateTime(1, 1, 1);
school.IsActive = true;
school.LevelCount = 23;
Console.WriteLine(schoolService.Create(school));
Console.WriteLine(schoolService.GetAll());
Console.WriteLine(schoolService.GetById(1));
school.Id = 1;
Console.WriteLine(schoolService.Update(school));
Console.WriteLine(schoolService.Delete(1));