module Practical3.Parser

open Practical3.Films

let getType (source : string) =
    match source.ToLower() with
        | "drawn" -> CartoonType.Drawn
        | "dollish" -> CartoonType.Dollish
        | "plasticine" -> CartoonType.Plasticine
        | _ -> invalidArg "source" "Incorrect type of cartoon"

let parse (source : string) : Film =
    let split = source.ToString().Split ';'
    let paramsCount = 3

    if split.Length < paramsCount then
        invalidArg "source" "Too few input parameters"

    match split.[1].ToLower() with
        | "feature" -> Feature({ m_title = split.[0]; m_producer = split.[2] })
        | "cartoon" -> Cartoon({ m_title = split.[0]; m_type = getType split.[2] })
        | "horror" -> Horror({ m_title = split.[0]; m_producer = split.[2] })
        | _ -> invalidArg "source" "Incorrect type of film"
