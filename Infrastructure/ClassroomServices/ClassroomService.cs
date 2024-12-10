using Domain.Models;
using Infrastructure.DataConText;

namespace Infrastructure.ClassroomServices;
using Npgsql;
using Dapper;
public class ClassroomService: IClassroomService
{
    public DapperConText connection;

    public ClassroomService()
    {
        connection =new DapperConText();
    }

    public bool Create(Classroom classroom)
    {
        try
        {
            var sql = "insert into classrooms(capacity, roomType, description, createdAt, updateAt) values (@Capacity, @RoomType, @Description, @CreatedAt, @UpdateAt);";
            var res = connection.Connection().Execute(sql, classroom);
            if (res > 0) return true;
            return false;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public List<Classroom> GetAll()
    {
        try
        {
            var sql = "select * from classrooms";
            var res = connection.Connection().Query<Classroom>(sql).ToList();
            return res;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Classroom GetById(int id)
    {
        try
        {
            var sql = "select * from classrooms where id=@Id";
            var res = connection.Connection().QuerySingle<Classroom>(sql,new {Id=id});
            return res;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }    
    }

    public bool Update(Classroom classroom)
    {
        try
        {
            var sql = "update classrooms set capacity=@Capacity, roomType=@RoomType, description=@Description,createdAt=@CreatedAt, updateAt=@UpdateAt where id=@Id;";
            var res = connection.Connection().Execute(sql, classroom);
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
            var sql = "delete from classrooms where id=@Id";
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