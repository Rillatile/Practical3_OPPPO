open System
open Practical3.Collections
open Practical3.Parser

[<EntryPoint>]
let main argv =
    if argv.Length < 2 then
        1
    else
        let inFilePath = argv.[0]
        let outFilePath = argv.[1]
        let logFilePath = if argv.Length > 2 then argv.[2] else "log.txt"
        let lines =
            try
                IO.File.ReadLines inFilePath
            with
                | ex -> IO.File.AppendAllText(logFilePath, ex.Message + System.Environment.NewLine); Seq.empty

        let list = createCircularList

        for line in lines do
            let value =
                try
                    parse line
                with
                    | ex -> IO.File.AppendAllText(logFilePath, ex.Message + System.Environment.NewLine); Practical3.Films.Film.Incorrect
            if value <> Practical3.Films.Film.Incorrect then
                pushBack value list
    
        sort list
        printList list outFilePath
        remove list
        printList list outFilePath

        0