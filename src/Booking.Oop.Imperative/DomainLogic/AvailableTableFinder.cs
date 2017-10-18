using Booking.Oop.Imperative.DataLayer;
using System;
using System.Linq;

namespace Booking.Oop.Imperative.DomainLogic
{
    public interface IAvailableTableFinder
    {
        Table Find(int seats, DateTimeOffset date, int duration);
    }
    public class AvailableTableFinder : IAvailableTableFinder
    {
        private IDataService _dataService;
        public AvailableTableFinder(IDataService dataService) => _dataService = dataService;

        public Table Find(int seats, DateTimeOffset date, int duration)
        {
            var tables = _dataService.GetTables();
            var bookings = _dataService.FindBookings(date);

            var appropriateTables = tables.Where(t => t.SeatsCount >= seats).OrderBy(t => t.SeatsCount);
            foreach (var table in appropriateTables)
            {
                if (!bookings.Any(b => b.TableId == table.Id))
                {
                    // TODO: skipping fancy logic for checking time slot
                    return table;
                }
            }
            return null;
        }
    }
}
