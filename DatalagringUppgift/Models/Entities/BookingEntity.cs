using DatalagringUppgift.Interfaces.IModels.IEntities;

namespace DatalagringUppgift.Models.Entities;

public class BookingEntity : IBookingEntity
{
    public int Id { get; set; }
    public string Date { get; set; } = null!;
    public int ClientId { get; set; }
    public int LocationId { get; set; }
    public int StatusId { get; set; }
    public int ParticipantId { get; set; }
    public int TimeId { get; set; }
}
