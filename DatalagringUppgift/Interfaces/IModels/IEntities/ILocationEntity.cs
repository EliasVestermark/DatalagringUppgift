namespace DatalagringUppgift.Interfaces
{
    public interface ILocationEntity
    {
        string Address { get; set; }
        string City { get; set; }
        int Id { get; set; }
        string PostalCode { get; set; }
    }
}