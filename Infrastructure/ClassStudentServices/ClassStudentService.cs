using Domain.Models;
using Infrastructure.DataConText;
using Npgsql;
using Dapper;
namespace Infrastructure.ClassStudentServices;
using DataConText;
public class ClassStudentService: IClassStudentService
{
     public DapperConText connection;

    public ClassStudentService()
    {
        connection =new DapperConText();
    }

    public bool Create(ClassStudent classStudent)
    {
        try
        {
            var sql = "insert into classStudent(studentId, classId) values (@StudentId, @ClassId);";
            var res = connection.Connection().Execute(sql, classStudent);
            if (res > 0) return true;
            return false;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public List<ClassStudent> GetAll()
    {
        try
        {
            var sql = "select * from classStudent";
            var res = connection.Connection().Query<ClassStudent>(sql).ToList();
            return res;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public ClassStudent GetById(int id)
    {
        try
        {
            var sql = "select * from classStudent where id=@Id";
            var res = connection.Connection().QuerySingle<ClassStudent>(sql,new {Id=id});
            return res;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }    
    }

    public bool Update(ClassStudent classStudent)
    {
        try
        {
            var sql = "update classStudent set studentId=@StudentId, classId=@ClassId where id=@Id;";
            var res = connection.Connection().Execute(sql, classStudent);
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
            var sql = "delete from classStudent where id=@Id";
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