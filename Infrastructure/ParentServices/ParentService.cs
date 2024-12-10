using Dapper;
using Domain.Models;

namespace Infrastructure.ParentServices;
using DataConText;
public class ParentService: IParentService
{
     public DapperConText connection;

    public ParentService()
    {
        connection =new DapperConText();
    }

    public bool Create(Parent parent)
    {
        try
        {
            var sql = "insert into Parents( parentCode, parentFullName, gender, dob, email, phone, createdAt, updateAt) values ( @ParentCode, @ParentFullName, @Gender, @Dob, @Email, @Phone, @CreatedAt, @UpdateAt);\n";
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

    public List<Parent> GetAll()
    {
        try
        {
            var sql = "select * from Parents";
            var res = connection.Connection().Query<Parent>(sql).ToList();
            return res;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Parent GetById(int id)
    {
        try
        {
            var sql = "select * from Parents where id=@Id";
            var res = connection.Connection().QuerySingle<Parent>(sql,new {Id=id});
            return res;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }    
    }

    public bool Update(Parent parent)
    {
        try
        {
            var sql = "update Parents set parentCode=@ParentCode, parentFullName=@ParentFullName, gender=@Gender, dob=@Dob, email=@Email, phone=@Phone, createdAt=@CreatedAt, updateAt=@UpdateAt where id=@Id;";
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

    public bool Delete(int id)
    {
        try
        {
            var sql = "delete from Parents where id=@Id";
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