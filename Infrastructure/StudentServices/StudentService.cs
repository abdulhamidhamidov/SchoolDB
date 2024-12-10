using Domain.Models;

namespace Infrastructure.StudentServices;
using DataConText;
using Npgsql;
using Dapper;
public class StudentService: IStudentService
{
         public DapperConText connection;

    public StudentService()
    {
        connection =new DapperConText();
    }

    public bool Create(Student student)
    {
        try
        {
            var sql = "insert into students(studentCode, studentFullName, gender, dob, email, phone, schoolId, stage, section, isActive, joinDate, createdAt, updateAt) values (@StudentCode, @StudentFullName, @Gender, @Dob, @Email, @Phone, @SchoolId, @Stage, @Section, @IsActive, @JoinDate, @CreatedAt, @UpdateAt);";
            var res = connection.Connection().Execute(sql, student);
            if (res > 0) return true;
            return false;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public List<Student> GetAll()
    {
        try
        {
            var sql = "select * from students";
            var res = connection.Connection().Query<Student>(sql).ToList();
            return res;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Student GetById(int id)
    {
        try
        {
            var sql = "select * from students where id=@Id";
            var res = connection.Connection().QuerySingle<Student>(sql,new {Id=id});
            return res;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }    
    }

    public bool Update(Student student)
    {
        try
        {
            var sql = "update students set studentCode=@StudentCode, studentFullName=@StudentFullName, gender=@Gender, dob=@Dob, email=@Email, phone=@Phone, schoolId=@SchoolId, stage@Stage, section=@Section, isActive=@IsActive, joinDate@JoinDate, createdAt=@CreatedAt, updateAt=@UpdateAt where id=@Id;";
            var res = connection.Connection().Execute(sql, student);
            if (res > 0) return true;
            return false;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }    
    }

    public bool Delete(int id)
    {
        try
        {
            var sql = "delete from students where id=@Id";
            var res = connection.Connection().Execute(sql, new {Id=id});
            if (res > 0) return true;
            return false;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        } 
    }
}