using System.Data;

namespace DatalagringUppgift.Repositories;

public interface IRepository<TEntity> where TEntity : class
{
    int Execute(string query, TEntity entity);
    IDataReader Read(string query);
}