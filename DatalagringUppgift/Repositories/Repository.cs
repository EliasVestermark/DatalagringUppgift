using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace DatalagringUppgift.Repositories;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly string _connectionString;

    protected Repository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public virtual int Execute(string query, TEntity entity)
    {
        try
        {
            using var conn = new SqlConnection(_connectionString);

            var result = conn.ExecuteScalar<int>(query, entity);
            return result;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return 0;
    }

    public virtual IDataReader Read(string query)
    {
        try
        {
            using var conn = new SqlConnection(_connectionString);

            var result = conn.ExecuteReader(query);

            if (result != null)
            {
                return result;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }
}
