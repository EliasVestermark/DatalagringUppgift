using DatalagringUppgift.Interfaces;

namespace DatalagringUppgift.Services;

public class ProductService : IProductService
{
    private readonly string _connectionString;

    public ProductService(string connectionString)
    {
        _connectionString = connectionString;
    }
}
