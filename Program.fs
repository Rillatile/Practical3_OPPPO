open System
open Practical3.Collections
open Practical3.Parser

[<EntryPoint>]
let main argv =
    let inFilePath = "in.txt"
    let outFilePath = "out.txt"
    let logFilePath = "log.txt"
    let lines =
        try
            IO.File.ReadLines inFilePath
        with
            | ex -> printfn "Error: %s" ex.Message; Seq.empty

    let list = createCircularList

    for line in lines do
        let value =
            try
                parse line
            with
                | ex -> printfn "Error: %s" ex.Message; Practical3.Films.Film.Incorrect
        if value <> Practical3.Films.Film.Incorrect then
            pushBack value list
    
    sort list
    printList list

    0
