module BookingService

open Dtos
open System
open Infrastructure

let createBooking requestDto (context: Context) = result {
    let! validatedRequest = Domain.validateRequest requestDto
    let! tables = Database.getTables()
    let! bookings = Database.getBookings validatedRequest.Date 
    let! newBooking = Domain.createBookingOrReject tables bookings validatedRequest
    let createAt = DateTimeOffset.Now

    let! bookingWithAudit = Database.saveBooking newBooking context.User createAt
    return bookingWithAudit
}