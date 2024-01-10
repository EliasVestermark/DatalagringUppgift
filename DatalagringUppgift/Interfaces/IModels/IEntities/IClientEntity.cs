namespace DatalagringUppgift.Interfaces
{
    public interface IClientEntity
    {
        string Email { get; set; }
        string FirstName { get; set; }
        int Id { get; set; }
        string LastName { get; set; }
        string PhoneNumber { get; set; }
    }
}