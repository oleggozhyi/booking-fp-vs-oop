using Booking.Oop.Imperative.DomainLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Oop.Imperative.DataLayer
{
    public interface IDataService
    {
        IReadOnlyCollection<Table> GetTables();
        IReadOnlyCollection<TableBooking> FindBookings(DateTimeOffset date);
        void SaveBooking(TableBooking booking);
    }
    public class DataService: IDataService
    {
        private static List<Table> _tables = new List<Table>
        {
            new Table(Guid.NewGuid(), 2),
            new Table(Guid.NewGuid(), 2),
            new Table(Guid.NewGuid(), 4),
            new Table(Guid.NewGuid(), 4),
            new Table(Guid.NewGuid(), 8)
        };
        private List<TableBooking> _bookings = new List<TableBooking>();

        public IReadOnlyCollection<Table> GetTables() => _tables;

        public IReadOnlyCollection<TableBooking> FindBookings(DateTimeOffset date)
            => _bookings
                .Where(b => b.Date.Date == date.Date)
                .ToList();

        public void SaveBooking(TableBooking booking)
        {
            booking.SetAuditInfo(CurrentContext.CurrentUser, DateTimeOffset.Now);
            _bookings.Add(booking);
        }
    }
}
