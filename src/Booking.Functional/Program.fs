// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open Dtos

[<EntryPoint>]
let main argv =
    let context = Infrastructure.getCurrentContext()
    let validDto = {
        Date = "2017-11-11"
        DurationHours = 3;
        ContactName = "Oleg";
        Phone  = "1342";
        SeatsRequested = 2 }
    let invalidDto = {
        Date = "2017-01-11"
        DurationHours = 3;
        ContactName = "Oleg";
        Phone  = "1342";
        SeatsRequested = 2 }

    let resultv= BookingService.createBooking validDto context
    printfn "%A" resultv

    let resultv= BookingService.createBooking invalidDto context
    printfn "%A" resultv
    0 // return an integer exit code
