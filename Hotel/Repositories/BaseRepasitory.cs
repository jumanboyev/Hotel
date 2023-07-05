
using Hotel.Constans;
using Npgsql;

namespace Hotel.Repositories;

public abstract class BaseRepasitory
{
    protected readonly NpgsqlConnection _connection;

    public BaseRepasitory()
    {
        _connection= new NpgsqlConnection(DbConstans.DB_CONNECTION_STRING);
    }
}
