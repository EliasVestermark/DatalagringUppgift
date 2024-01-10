using DatalagringUppgift.Models;

namespace DatalagringUppgift.Interfaces.IServices;

public interface IBookingService
{
    bool CreateBooking(BookingForm booking);
    bool NumberValidation(string number);
}