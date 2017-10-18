using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Oop.Imperative.DomainLogic
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
