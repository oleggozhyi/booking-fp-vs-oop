module Domain

open System
open Dtos

type Failure =
    | Validation of string
    | NoSeats
type Table = { Id: Guid; SeatsCount: int }
let createTable seats = { Id = Guid.NewGuid(); SeatsCount = seats }

type ValidatedBookingRequest = {
    Date: DateTimeOffset;
    DurationHours: int;
    ContactName: string;
    Phone: string;
    SeatsRequested: int
}

type Booking = { Id: Guid; Request: ValidatedBookingRequest; Table: Table }

type Audit<'a> = { entity: 'a; createBy: string; createdAt: DateTimeOffset }

let validateRequest (dto: BookingRequestDto) = 
    match DateTimeOffset.TryParse dto.Date with
    | false, _ -> Error <| Validation "Date can't be parsed"
    | true, date -> 
        if date < DateTimeOffset.Now  then Error <|Validation "Date can't be at past"
        else Ok { Date = date; 
                  DurationHours = dto.DurationHours; 
                  ContactName = dto.ContactName;
                  Phone = dto.Phone;
                  SeatsRequested = dto.SeatsRequested }

let createBookingOrReject tables bookings request = 
    let isTableAppropriate table = 
        bookings  |> List.exists (fun b -> b.Table = table) |> not
    match tables |> List.tryFind isTableAppropriate with
    | None -> Error NoSeats
    | Some table -> Ok { Id = Guid.NewGuid(); 
                            Request = request;
                            Table = table }