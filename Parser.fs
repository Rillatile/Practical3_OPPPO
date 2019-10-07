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
    let paramsCount = 4

    if split.Length < paramsCount then
        invalidArg "source" "Too few input parameters"

    match split.[1].ToLower() with
        | "feature" -> Feature({ m_title = split.[0]; m_producer = split.[2];
            m_rating =
                try
                    System.Single.Parse split.[3]
                with
                    | ex -> invalidArg "rating" "An incorrect rating" })
        | "cartoon" -> Cartoon({ m_title = split.[0]; m_type = getType split.[2];
            m_rating =
                try
                    System.Single.Parse split.[3]
                with
                    | ex -> invalidArg "rating" "An incorrect rating" })
        | "horror" -> Horror({ m_title = split.[0]; m_producer = split.[2];
            m_rating =
                try
                    System.Single.Parse split.[3]
                with
                    | ex -> invalidArg "rating" "An incorrect rating" })
        | _ -> invalidArg "source" "Incorrect type of film"
