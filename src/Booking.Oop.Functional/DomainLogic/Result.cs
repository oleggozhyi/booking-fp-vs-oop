using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Oop.Functional.DomainLogic
{
    public class Result<TOk, TError> where TOk : class where TError : class
    {
        public bool IsSucces => Ok != null;
        public TOk Ok { get; }
        public TError Error { get; }
        public Result(TOk ok) => Ok = ok ?? throw new ArgumentException(nameof(ok));
        public Result(TError error) => Error = error ?? throw new ArgumentException(nameof(error));
    }
}
