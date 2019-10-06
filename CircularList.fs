module Practical3.Collections

open Practical3.Films

type Node = { mutable m_next: Node option; m_value: Film }

type CircularList = { mutable m_first: Node option; mutable m_last: Node option; mutable m_size: int }

let createCircularList = { m_first = None; m_last = None; m_size = 0 }

let pushBack (value: Film) (list: CircularList) =
    match list.m_first with
        | None ->
            let mutable node = Some { m_next = None; m_value = value }
            node <- Some { m_next = node; m_value = value }
            list.m_first <- node
            list.m_last <- node
        | _ ->
            let mutable node = Some { m_next = list.m_first; m_value = value }
            list.m_last.Value.m_next <- node
            list.m_last <- node
    list.m_size <- list.m_size + 1

let printList (list: CircularList) =
    let mutable current = list.m_first
    for i in 0..list.m_size - 1 do
        printfn "%d: %s" (i + 1) (current.Value.m_value.ToString())
        current <- current.Value.m_next
    printfn "Number of elements: %d" list.m_size