using Booking.Oop.Imperative.DataLayer;
using Booking.Oop.Imperative.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Oop.Imperative.DomainLogic
{
    public interface IBookingService
    {
        TableBooking CreateBooking(BookingRequestDto bookingRequestDto);
    }
    public class BookingService : IBookingService
    {
        private readonly IAvailableTableFinder _availableTableFinder;
        private readonly IDataService _dataService;

        public BookingService(IAvailableTableFinder availableTableFinder,
                              IDataService dataService)
        {
            _availableTableFinder = availableTableFinder;
            _dataService = dataService;
        }

        public TableBooking CreateBooking(BookingRequestDto bookingRequestDto)
        {
            var booking = TableBooking.CreateNew(bookingRequestDto);
            var firstAppropriateTable = _availableTableFinder.Find(booking.SeatsRequested, booking.Date, booking.DurationHours);

            if (firstAppropriateTable == null)
                throw new NoSeatsException();

            booking.AssignTable(firstAppropriateTable);
            _dataService.SaveBooking(booking);

            return booking;
        }
    }
}
