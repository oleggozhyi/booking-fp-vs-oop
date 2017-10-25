using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Booking.Oop.Functional.Exceptions;

namespace Booking.Oop.Functional.DomainLogic
{
    public interface IRequestValidator
    {
        Result<ValidatedBookingRequest, string> Validate(BookingRequestDto dto);
    }

    public class RequestValidator : IRequestValidator
    {
        public Result<ValidatedBookingRequest, string> Validate(BookingRequestDto dto)
        {
            if (!DateTimeOffset.TryParse(dto.Date, out DateTimeOffset date))
                return new Result<ValidatedBookingRequest, string>("Date can't be parsed");
            if (date < DateTimeOffset.Now)
                return new Result<ValidatedBookingRequest, string>("Date can't be at past");

            return new Result<ValidatedBookingRequest, string>(
                new ValidatedBookingRequest(dto.SeatsRequested, dto.PersonName, date, dto.DurationHours, dto.Phone));
        }
    }
}
