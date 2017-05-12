module Program

module Task1 =
    /// a function calculating sum of number's digits
    let sum x =
        let rec loop s l x =
            match l with
            | 0 -> s
            | _ -> loop (s + (x % 10)) (l - 1) (x / 10)
        loop 0 ((string x).Length) x

module Task2 =
    /// let subListChecker list subList =
    let numInListChecker list num =
        let rec loop list n pos =
            match list with
            | [] -> None
            | _ -> if (list.Head = n) then Some(pos) else loop (list.Tail) n (pos + 1)
        loop list num 0

module Task3 =
    /// a function checking is a string palindrome
    let palindromeCheck (s:string) =
      let rec loop (n:int) (s:string) =
        match n with
        | x when x = s.Length / 2 -> true
        | _ ->
          match s.[n] with
          | x when x = s.[s.Length - n - 1] -> loop (n + 1) s
          | _ -> false
      loop 0 s

module Task4 =
    /// mergesort for list
    let rec mergesort (l:list<'A>) =
        let (++) a b = List.rev <| List.fold (fun l t -> t :: l) (List.rev (a)) b
        let rec merge l1 l2 res =
            match l1 with
            | [] -> res @ l2
            | _ -> match l2 with
                   | [] -> res @ l1
                   | _ when (l1.Head < l2.Head) -> merge (l1.Tail) (l2) (res @ ([l1.Head]))
                   | _ -> merge (l1) (l2.Tail) (res @ ([l2.Head]))
        match l with
        | [] -> l
        | [a] -> l
        | _ -> merge (mergesort(fst(List.splitAt(l.Length / 2) l))) (mergesort(snd(List.splitAt(l.Length / 2) l))) []

module Tests =
    open FsUnit
    open NUnit.Framework
    open Task1
    open Task2
    open Task3
    open Task4

    //tests for task 1
    [<Test>]
    let ``digitSumTest1`` () = (sum 12345) |> should equal 15
    [<Test>]
    let ``digitSumTest2`` () = (sum 0) |> should equal 0

    //tests for task 2
    [<Test>]
    let ``numPositionInListTest1`` () = (numInListChecker [1; 2; 3] 3) |> should equal 2
    [<Test>]
    let ``numPositionInListTest2`` () = (numInListChecker [1; 2; 3] 1) |> should equal 0
    [<Test>]
    let ``numPositionInListTest3`` () = (numInListChecker [1; 2; 3] 4) |> should equal -1

    //tests for task 3
    [<Test>]
    let ``polyndromeCheckTest1`` () = (palindromeCheck "[]][") |> should be True
    [<Test>]
    let ``polyndromeCheckTest2`` () = (palindromeCheck "abccbad") |> should be False

    //tests for task 4
    [<Test>]
    let ``mergeSortTest1`` () = (mergesort [1; 3; 2]) |> should equal [1; 2; 3]
    [<Test>]
    let ``mergeSortTest2`` () = (mergesort [3; 2; 1; 0]) |> should equal [0; 1; 2; 3]
    [<Test>]
    let ``mergeSortEmptyListTest`` () = (mergesort []) |> should equal []








