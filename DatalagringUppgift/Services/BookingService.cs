using DatalagringUppgift.Interfaces;
using DatalagringUppgift.Interfaces.IServices;
using DatalagringUppgift.Models;
using DatalagringUppgift.Models.Entities;
using DatalagringUppgift.Repositories;
using System.Diagnostics;

namespace DatalagringUppgift.Services;

public class BookingService :IBookingService
{
    private readonly ClientRepository _clientRepository;
    private readonly LocationRepository _locationRepository;
    private readonly BookingRepository _bookingRepository;

    public BookingService(string connectionString, ClientRepository clientRepository, LocationRepository locationRepository, BookingRepository bookingRepository)
    {
        _clientRepository = clientRepository;
        _locationRepository = locationRepository;
        _bookingRepository = bookingRepository;
    }

    public bool CreateBooking(BookingForm booking)
    {
        try
        {
            var bookingEntity = new BookingEntity
            {
                Date = booking.Date,
                StatusId = booking.StatusId,
                ParticipantId = booking.ParticipantId,
                TimeId = booking.TimeId,

                ClientId = _clientRepository.Execute("INSERT INTO Clients VALUES (@FirstName, @LastName, @PhoneNumber, @Email)", new ClientEntity
                {
                    FirstName = booking.FirstName,
                    LastName = booking.LastName,
                    PhoneNumber = booking.PhoneNumber,
                    Email = booking.Email
                }),

                LocationId = _locationRepository.Execute("INSERT INTO Locations VALUES (@Address, @PostalCode, @City)", new LocationEntity
                {
                    Address = booking.Address,
                    PostalCode = booking.PostalCode,
                    City = booking.City
                })
            };

            int result = _bookingRepository.Execute("INSERT INTO Bookings VALUES (@Date, @StatusId, @ParticipantId @TimeId, @ClientId, @LocationId)", bookingEntity);

            if (result != 0)
            {
                return true;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); } 

        return false;
    }

    public bool NumberValidation(string number)
    {
        if (string.IsNullOrEmpty(number))
        {
            return true;
        }
        else if (number.All(char.IsDigit))
        {
            return true;
        }

        return false;
    }
}
