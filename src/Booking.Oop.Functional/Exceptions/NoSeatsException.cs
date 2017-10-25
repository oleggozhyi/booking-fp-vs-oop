﻿using System;

namespace Booking.Oop.Functional.Exceptions
{
    public class NoSeatsException : Exception
    {
        public NoSeatsException() { }
        public NoSeatsException(string message) : base(message) { }
        public NoSeatsException(string message, Exception inner) : base(message, inner) { }
        protected NoSeatsException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
