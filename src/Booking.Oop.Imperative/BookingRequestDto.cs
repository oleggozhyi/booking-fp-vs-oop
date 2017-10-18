using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Oop.Imperative
{
    public class BookingRequestDto
    {
        public int SeatsRequested { get; }
        public string PersonName { get; }
        public string Date { get; }
        public int DurationHours { get; }
        public string Phone { get; set; }
    }
}
