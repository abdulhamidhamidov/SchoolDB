using Dapper;
using Domain.Models;
using Infrastructure.DataConText;

namespace Infrastructure.ClassServices;
using DataConText;
public class ClassService: IClassService
{
     public DapperConText connection;

    public ClassService()
    {
        connection =new DapperConText();
    }

    public bool Create(Class _class)
    {
        try
        {
            var sql = "insert into classes (className, subjectId, teacherId, classroomId, section, createdAt, updateAt) values (@ClassName, @SubjectId, @TeacherId, @ClassroomId, @Section, @CreatedAt, @UpdateAt);\n";
            var res = connection.Connection().Execute(sql, _class);
            if (res > 0) return true;
            return false;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public List<Class> GetAll()
    {
        try
        {
            var sql = "select * from classes";
            var res = connection.Connection().Query<Class>(sql).ToList();
            return res;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Class GetById(int id)
    {
        try
        {
            var sql = "select * from classes where id=@Id";
            var res = connection.Connection().QuerySingle<Class>(sql,new {Id=id});
            return res;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }    
    }

    public bool Update(Class _class)
    {
        try
        {
            var sql = "update classes set className=@ClassName, subjectId=@SubjectId, teacherId=@TeacherId, classroomId=@ClassroomId, section=@Section, createdAt=@CreatedAt, updateAt=@UpdateAt where id=@Id";
            var res = connection.Connection().Execute(sql, _class);
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
            var sql = "delete from classes where id=@Id";
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