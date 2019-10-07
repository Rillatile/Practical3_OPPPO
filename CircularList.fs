module Practical3.Collections

open Practical3.Films

type Node = { mutable m_next: Node option; mutable m_value: Film }

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
        printfn "%d: %s" (i + 1) (current.Value.m_value :> IGeneral).Print
        current <- current.Value.m_next
    printfn "Number of elements: %d" list.m_size

let sort (list: CircularList) =
    if list.m_size > 1 then
        let mutable flag = true
        let mutable i = 0
        while flag && i < list.m_size do
            flag <- false
            let mutable n1: Node option = list.m_first
            let mutable n2: Node option = list.m_first.Value.m_next
            for j in 0..list.m_size - 2 do
                if (n1.Value.m_value :> IGeneral).getRating < (n2.Value.m_value :> IGeneral).getRating then
                    let temp: Film = n1.Value.m_value
                    n1.Value.m_value <- n2.Value.m_value
                    n2.Value.m_value <- temp
                    flag <- true
                n1 <- n2
                n2 <- n2.Value.m_next
            i <- i + 1