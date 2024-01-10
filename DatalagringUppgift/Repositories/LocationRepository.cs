using DatalagringUppgift.Interfaces;

namespace DatalagringUppgift.Repositories;

public class LocationRepository : Repository<ILocationEntity>
{
    public LocationRepository(string connectionString) : base(connectionString)
    {
    }
}
