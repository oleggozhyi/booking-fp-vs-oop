using Booking.Oop.Imperative.Exceptions;
using System;

namespace Booking.Oop.Imperative.DomainLogic
{
    public class TableBooking
    {
        public TableBooking(Guid id, int seatsRequested, Guid tableId, string requestedBy, string phone, DateTimeOffset date, int durationHours, string createdBy, DateTimeOffset createdAt)
            :this(id, seatsRequested, requestedBy, phone, date, durationHours)
        {
            TableId = tableId;
            CreatedBy = createdBy;
            CreatedAt = createdAt;
        }
        public TableBooking(Guid id, int seatsRequested, string requestedBy, string phone, DateTimeOffset date, int durationHours)
        {
            Id = id;
            Phone = phone;
            SeatsRequested = seatsRequested;
            RequestedBy = requestedBy;
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
        public string CreatedBy { get; private set; }
        public DateTimeOffset CreatedAt { get; private set; }

        public static TableBooking CreateNew(BookingRequestDto dto)
        {
            if (!DateTimeOffset.TryParse(dto.Date, out DateTimeOffset date))
                throw new ValidationException("Date can't be parsed");
            if(date < DateTimeOffset.Now)
                throw new ValidationException("Date can't be at past");

            return new TableBooking(
                Guid.NewGuid(),
                dto.SeatsRequested,
                dto.PersonName,
                dto.Phone,
                date,
                dto.DurationHours
                );
        }

        public void AssignTable(Table t)
        {
            if (t.SeatsCount < SeatsRequested)
                throw new ArgumentException("Inappropiate table");

            TableId = t.Id;
        }

        public void SetAuditInfo(string userName, DateTimeOffset createdAt)
        {
            CreatedBy = userName;
            CreatedAt = createdAt;
        }
    }
}
