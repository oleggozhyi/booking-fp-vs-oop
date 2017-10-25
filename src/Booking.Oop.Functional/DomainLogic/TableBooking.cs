using System;
using Booking.Oop.Functional.Exceptions;

namespace Booking.Oop.Functional.DomainLogic
{
    public class TableBooking
    {
        public TableBooking(Guid id, int seatsRequested, Guid tableId, string requestedBy, string phone, DateTimeOffset date, int durationHours)
        {
            Id = id;
            SeatsRequested = seatsRequested;
            TableId = tableId;
            RequestedBy = requestedBy ?? throw new ArgumentNullException(nameof(requestedBy));
            Phone = phone ?? throw new ArgumentNullException(nameof(phone));
            Date = date;
            DurationHours = durationHours;
        }

        public Guid Id { get; }
        public int SeatsRequested { get; }
        public Guid TableId { get; private set; }
        public string RequestedBy { get; }
        public string Phone { get; }
        public DateTimeOffset Date { get; }
        public int DurationHours { get; }
    }
}
