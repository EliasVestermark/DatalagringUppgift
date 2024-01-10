namespace DatalagringUppgift.Interfaces.IModels.IEntities
{
    public interface IBookingEntity
    {
        int ClientId { get; set; }
        string Date { get; set; }
        int Id { get; set; }
        int LocationId { get; set; }
        int ParticipantId { get; set; }
        int StatusId { get; set; }
        int TimeId { get; set; }
    }
}