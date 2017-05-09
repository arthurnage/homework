type PriorQueElement<'a> = {value : 'a; priority : int}

type Queue<'a>() = 
    let mutable que : List<PriorQueElement<'a>> = []

    member this.Pop =
        let reverse list =
            let rec loop list revList =
                match list with
                | [] -> revList
                | _ -> loop (list.Tail) (list.Head :: revList)
            loop list []
        match que with
        | [] -> failwith "Popping from empty queue!"
        | l ->
            let list = reverse l
            let head = list.Head
            que <- reverse (list.Tail)
            head

    member this.IsEmpty = List.isEmpty que

    member this.Push (value : 'a) =
        match que with
        | [] -> [value]
        | _ -> 
