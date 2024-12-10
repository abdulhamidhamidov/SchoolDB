using Domain.Models;

namespace Infrastructure.StudentParentServices;
using DataConText;
using Npgsql;
using Dapper;
public class StudentParentService : IStudentParentService
{
             public DapperConText connection;

    public StudentParentService()
    {
        connection =new DapperConText();
    }

    public bool Create(StudentParent parent)
    {
        try
        {
            var sql = "insert into StudentParents( studentId, parentId, relationship) values ( @StudentId, @ParentId, @Relationship);";
            var res = connection.Connection().Execute(sql, parent);
            if (res > 0) return true;
            return false;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public List<StudentParent> GetAll()
    {
        try
        {
            var sql = "select * from StudentParents";
            var res = connection.Connection().Query<StudentParent>(sql).ToList();
            return res;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public StudentParent GetById(int id)
    {
        try
        {
            var sql = "select * from StudentParents where id=@Id";
            var res = connection.Connection().QuerySingle<StudentParent>(sql,new {Id=id});
            return res;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }    
    }

    public bool Update(StudentParent studentParent)
    {
        try
        {
            var sql = "update StudentParents set studentId=@StudentId, parentId=@ParentId, relationship=@Relationship where id=@Id;";
            var res = connection.Connection().Execute(sql, studentParent);
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
            var sql = "delete from StudentParents where id=@Id";
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