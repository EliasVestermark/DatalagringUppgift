using DatalagringUppgift.Interfaces;

namespace DatalagringUppgift.Models.Entities;

public class LocationEntity : ILocationEntity
{
    public int Id { get; set; }
    public string Address { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string City { get; set; } = null!;
}
