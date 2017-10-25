using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Oop.Functional.DomainLogic
{
    public class Audit<T> where T: class
    {
        public Audit(T entity, string createdBy, DateTimeOffset createdAt)
        {
            CreatedAt = createdAt;
            CreatedBy = createdBy ?? throw new ArgumentNullException(nameof(createdBy));
            Entity = entity ?? throw new ArgumentNullException(nameof(entity));
        }

        public DateTimeOffset CreatedAt { get; }
        public string CreatedBy { get; }
        public T Entity { get; }
    }
}
