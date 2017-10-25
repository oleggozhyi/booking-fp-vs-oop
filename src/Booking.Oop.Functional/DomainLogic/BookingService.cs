using System;
using System.Data;
using Booking.Oop.Functional.DataLayer;
using Booking.Oop.Functional.Exceptions;

namespace Booking.Oop.Functional.DomainLogic
{
    public interface IBookingService
    {
        Audit<TableBooking> CreateBooking(BookingRequestDto bookingRequestDto);
    }
    public class BookingService : IBookingService
    {
        private readonly IRequestValidator _requestValidator;
        private readonly IDataService _dataService;
        private readonly IBookingCreator _bookingCreator;

        public BookingService(IRequestValidator requestValidator,
                              IDataService dataService,
                              IBookingCreator bookingCreator)
        {
            _requestValidator = requestValidator;
            _dataService = dataService;
            _bookingCreator = bookingCreator;
        }

        public Audit<TableBooking> CreateBooking(BookingRequestDto bookingRequestDto)
        {
            var validationResult = _requestValidator.Validate(bookingRequestDto);
            if(!validationResult.IsSucces)
                throw new ValidationException(validationResult.Error);

            var validatedRequest = validationResult.Ok;
            var tables = _dataService.GetTables();
            var bookingsForToday = _dataService.FindBookings(validatedRequest.Date);

            var bookingCreationResult = _bookingCreator.Create(validatedRequest, tables, bookingsForToday);
            if(!bookingCreationResult.IsSucces)
                throw new NoSeatsException(bookingCreationResult.Error);

            var createBy = CurrentContext.CurrentUser;
            var createAt = DateTimeOffset.Now;
            var auditedBooking = _dataService.SaveBooking(bookingCreationResult.Ok, createBy, createAt);
            return auditedBooking;
        }
    }
}
