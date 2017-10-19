[<AutoOpen>]
module ResultBuilder

type ResultBuilder() =
    member __.Bind(x,f) = match x with
                          | Ok s -> f s
                          | Error e -> Error e
    member __.Return(x) = Ok x

let result = new ResultBuilder()

