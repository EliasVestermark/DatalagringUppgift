using DatalagringUppgift.Interfaces.IModels.IEntities;

namespace DatalagringUppgift.Repositories;

public class BookingRepository : Repository<IBookingEntity>
{
    public BookingRepository(string connectionString) : base(connectionString)
    {
    }
}
