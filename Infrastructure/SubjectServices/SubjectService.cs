using Domain.Models;

namespace Infrastructure.SubjectServices;
using DataConText;
using Npgsql;
using Dapper;
public class SubjectService:ISubjectService
{
     public DapperConText connection;

    public SubjectService()
    {
        connection =new DapperConText();
    }

    public bool Create(Subject subject)
    {
        try
        {
            var sql = "insert into subjects( title, schoolId, stage, team, carryMark, createdAt, updateAt) values ( @Title, @SchoolId, @Stage, @Team, @CarryMark, @CreatedAt, @UpdateAt);";
            var res = connection.Connection().Execute(sql, subject);
            if (res > 0) return true;
            return false;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public List<Subject> GetAll()
    {
        try
        {
            var sql = "select * from Subjects";
            var res = connection.Connection().Query<Subject>(sql).ToList();
            return res;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Subject GetById(int id)
    {
        try
        {
            var sql = "select * from Subjects where id=@Id";
            var res = connection.Connection().QuerySingle<Subject>(sql,new {Id=id});
            return res;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }    
    }

    public bool Update(Subject subject)
    {
        try
        {
            var sql = "update subjects set title=@Title, schoolId=@SchoolId, stage=@Stage, team=@Team, carryMark=@CarryMark, createdAt=@CreatedAt, updateAt=@UpdateAt where id=@Id;";
            var res = connection.Connection().Execute(sql, subject);
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
            var sql = "delete from Subjects where id=@Id";
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