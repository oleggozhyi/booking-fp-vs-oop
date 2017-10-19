using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Oop.Imperative
{
    public class BookingRequestDto
    {
        public int SeatsRequested { get; set; }
        public string PersonName { get; set; }
        public string Date { get; set; }
        public int DurationHours { get; set; }
        public string Phone { get; set; }
    }
}
