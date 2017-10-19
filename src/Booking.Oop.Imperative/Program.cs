using Autofac;
using Booking.Oop.Imperative.DomainLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Oop.Imperative
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = IoC.Container.Resolve<IBookingService>();
            try
            {
                var booking = service.CreateBooking(new BookingRequestDto
                {
                    Phone = "1234",
                    Date = "2017-11-01",
                    DurationHours = 2,
                    PersonName = "Oleg",
                    SeatsRequested = 2
                });
                Console.WriteLine(booking.Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            
        }
    }
}
