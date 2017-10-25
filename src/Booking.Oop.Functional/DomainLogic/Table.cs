using System;

namespace Booking.Oop.Functional.DomainLogic
{
    public class Table
    {
        public Table(Guid id, int seatsCount)
        {
            Id = id;
            SeatsCount = seatsCount;
        }
        public Guid Id { get; }    
        public int SeatsCount { get; }
    }
}
