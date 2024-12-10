using Dapper;
using Domain.Models;
using Infrastructure.DataConText;

namespace Infrastructure.TeacherServices;
using Npgsql;
using Dapper;
public class TeacherService : ITeacherService
{
     public DapperConText connection;

    public TeacherService()
    {
        connection =new DapperConText();
    }

    public bool Create(Teacher teacher)
    {
        try
        {
            var sql = "insert into teachers(teacherCode, teacherFullName, gender, dob, email, phone, isActive, joinDate, workingDays, createdAt, updateAt) values (@TeacherCode, @TeacherFullName, @Gender, @Dob, @Email, @Phone, @IsActive, @JoinDate, @WorkingDays, @CreatedAt, @UpdateAt);\n";
            var res = connection.Connection().Execute(sql, teacher);
            if (res > 0) return true;
            return false;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public List<Teacher> GetAll()
    {
        try
        {
            var sql = "select * from teachers";
            var res = connection.Connection().Query<Teacher>(sql).ToList();
            return res;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Teacher GetById(int id)
    {
        try
        {
            var sql = "select * from teachers where id=@Id";
            var res = connection.Connection().QuerySingle<Teacher>(sql,new {Id=id});
            return res;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }    
    }

    public bool Update(Teacher teacher)
    {
        try
        {
            var sql = "update teachers set teacherCode=@TeacherCode, teacherFullName=@TeacherFullName, gender=@Gender, dob=@Dob, email=@Email, phone=@Phone, isActive=@IsActive, joinDate=@JoinDate, workingDays=@WorkingDays, createdAt=@CreatedAt, updateAt=@UpdateAt where id=@Id;\n";
            var res = connection.Connection().Execute(sql, teacher);
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
            var sql = "delete from teachers where id=@Id";
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