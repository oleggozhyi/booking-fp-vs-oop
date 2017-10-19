module Dtos

open System

type BookingRequestDto = {
    Date: string;
    DurationHours: int;
    ContactName: string;
    Phone: string;
    SeatsRequested: int;
}

