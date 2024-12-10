using Domain.Models;

namespace Infrastructure.SchoolServices;
using DataConText;
using Npgsql;
using Dapper;
public class SchoolService : ISchoolService
{
    public DapperConText connection;

    public SchoolService()
    {
        connection =new DapperConText();
    }

    public bool Create(School school)
    {
        try
        {
            var sql = "insert into schools( schoolTitle, levelCount, isActive, createdAt, updateAt) values ( @SchoolTitle, @LevelCount, @IsActive, @CreatedAt, @UpdateAt);";
            var res = connection.Connection().Execute(sql, school);
            if (res > 0) return true;
            return false;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public List<School> GetAll()
    {
        try
        {
            var sql = "select * from schools";
            var res = connection.Connection().Query<School>(sql).ToList();
            return res;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public School GetById(int id)
    {
        try
        {
            var sql = "select * from schools where id=@Id";
            var res = connection.Connection().QuerySingle<School>(sql,new {Id=id});
            return res;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }    
    }

    public bool Update(School school)
    {
        try
        {
            var sql = "update schools set schoolTitle=@SchoolTitle, levelCount=@LevelCount, isActive=@IsActive, createdAt=@CreatedAt, updateAt=@UpdateAt where id=@Id;\n";
            var res = connection.Connection().Execute(sql, school);
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
            var sql = "delete from schools where id=@Id";
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