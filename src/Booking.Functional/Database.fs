module Database

open Domain
open System

let private tables: Table list = 
    createTable(2)::createTable(2)::createTable(4)::createTable(4)::[]

let mutable private bookings: Audit<Booking> list = []

let getTables() = Ok tables

let getBookings (date: DateTimeOffset) = 
    bookings
    |> List.map (fun a -> a.entity)
    |> List.filter (fun b -> b.Request.Date.Date = date.Date) 
    |> Ok

let saveBooking booking createdBy createdAt = 
    Ok { entity= booking; createBy = createdBy; createdAt = createdAt }