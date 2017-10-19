module Infrastructure

type Context = { User: string } 
let getCurrentContext() = {  User = "Jon Skeet" }