using DatalagringUppgift.Interfaces;

namespace DatalagringUppgift.Repositories;

public class ClientRepository : Repository<IClientEntity>
{
    public ClientRepository(string connectionString) : base(connectionString)
    {
    }
}
