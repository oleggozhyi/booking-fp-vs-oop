using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Oop.Functional.DomainLogic
{
    public class ValidatedBookingRequest
    {
        public ValidatedBookingRequest(int seatsRequested, string personName, DateTimeOffset date, int durationHours, string phone)
        {
            SeatsRequested = seatsRequested;
            PersonName = personName ?? throw new ArgumentNullException(nameof(personName));
            Date = date;
            DurationHours = durationHours;
            Phone = phone ?? throw new ArgumentNullException(nameof(phone));
        }

        public int SeatsRequested { get; }
        public string PersonName { get; }
        public DateTimeOffset Date { get; }
        public int DurationHours { get; }
        public string Phone { get; }
    }
}
