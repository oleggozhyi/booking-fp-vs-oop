using System;
using System.Collections.Generic;
using System.Linq;
using Booking.Oop.Functional.DomainLogic;

namespace Booking.Oop.Functional.DataLayer
{
    public interface IDataService
    {
        IReadOnlyCollection<Table> GetTables();
        IReadOnlyCollection<TableBooking> FindBookings(DateTimeOffset date);
        Audit<TableBooking> SaveBooking(TableBooking booking, string createdBy, DateTimeOffset createdAt);
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
        private readonly List<Audit<TableBooking>> _bookings = new List<Audit<TableBooking>>();

        public IReadOnlyCollection<Table> GetTables() => _tables;

        public IReadOnlyCollection<TableBooking> FindBookings(DateTimeOffset date)
            => _bookings
                .Where(a=> a.Entity.Date.Date == date.Date)
                .Select(a=>a.Entity)
                .ToList();



        public Audit<TableBooking> SaveBooking(TableBooking booking, string createdBy, DateTimeOffset createdAt)
        {
            var auditedBooking = new Audit<TableBooking>(booking, createdBy, createdAt);
            _bookings.Add(auditedBooking);
            return auditedBooking;
        }
    }
}
