module Program

module Task1 =
    let noSameElementsInListCheck l =
        let rec loop (list:list<'A>) (temp:list<'A>) =
            if (list.Length = 0) then true else
            let predicate x = x = list.Head 
            match List.tryFind predicate temp with
            | None -> loop list.Tail (list.Head :: temp)
            | _ -> false
        loop l []
    let list = [1; 2; 3]
    let res = noSameElementsInListCheck list
    printf "%A" res

module Task2 =
    let maxNeighbourElementPosition (l:list<int>) =
        let rec s (l:list<int>) =
            seq {
                match l.Length with
                | 2 -> yield l.Head + l.Tail.Head
                | _ -> yield l.Head + l.Tail.Head
                       yield! s l.Tail
                }
        if (l.Length <= 2) then -1 else 
            let seq = s l
            Seq.findIndex (fun x -> x = Seq.max seq) seq + 1

module Tests =
    open NUnit.Framework
    open FsUnit
    open Task1
    open Task2

    [<Test>]
    let ``NoSameElementsInListTest1`` () = (noSameElementsInListCheck [1; 2; 3]) |> should be True
    [<Test>]
    let ``NoSameElementsInListTest2`` () = (noSameElementsInListCheck [1; 2; 2]) |> should be False

    [<Test>]
    let ``maxNeighbourElementPosisionTest1`` () = (maxNeighbourElementPosition [1; 2000; 10; 5]) |> should equal 2
    [<Test>]
    let ``maxNeighbourElementPosisionEmptyListTest`` () = (maxNeighbourElementPosition []) |> should equal -1

