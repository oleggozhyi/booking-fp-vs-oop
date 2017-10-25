using System;
using System.Collections.Generic;
using System.Linq;
using Booking.Oop.Functional.DataLayer;

namespace Booking.Oop.Functional.DomainLogic
{
    public interface IBookingCreator
    {
        Result<TableBooking, string> Create(ValidatedBookingRequest request, IReadOnlyCollection<Table> tables,
            IReadOnlyCollection<TableBooking> tableBookings);
    }
    public class BookingCreator: IBookingCreator
    {
        public Result<TableBooking, string> Create(ValidatedBookingRequest request, IReadOnlyCollection<Table> tables, IReadOnlyCollection<TableBooking> tableBookings)
        {
            var table = tables.FirstOrDefault(t => tableBookings.All(b => b.Id != t.Id));
            if (table == null)
                return new Result<TableBooking, string>("No free tables");

            return new Result<TableBooking, string>(
                new TableBooking(Guid.NewGuid(),
                    request.SeatsRequested,
                    table.Id, request.PersonName,
                    request.Phone,
                    request.Date,
                    request.DurationHours));
        }
    }
}
