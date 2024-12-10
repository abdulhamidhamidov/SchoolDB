namespace Infrastructure.DataConText;
using Npgsql;
using Dapper;
public class DapperConText
{
    public string connection = "Server=localhost;Port=5432;Database=SchoolDb;Username=postgres;Password=12345";

    public NpgsqlConnection Connection()
    {
        return new NpgsqlConnection(connection);
    }
}