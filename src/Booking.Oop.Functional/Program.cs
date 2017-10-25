using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Booking.Oop.Functional.DomainLogic;

namespace Booking.Oop.Functional
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
                Console.WriteLine(booking.Entity.Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
