module Program

module hw1 =
    /// factorial
    let rec fact n =
        match n with
        | _ when n <= 0 -> 1
        | _ -> n * fact (n - 1)

    /// fibonacci
    let fib n =
        let rec loop a b c =
            match c with
            | 0 -> b
            | _ -> loop (a + b) a (c - 1)
        loop 1 0 n

    ///reverse list functiton
    let reverse list =
        let rec loop list revList =
            match list with
            | [] -> revList
            | _ -> loop (list.Tail) (list.Head :: revList)
        loop list []

    /// make list with values lise 2^n, 2^(n+1), ... , 2^(n+m)
    let listMaker n m =
        let rec loop list m =
            match m with
            | -1 -> list
            | _ -> loop ((pown 2 (n + m)) :: list) (m - 1)
        loop [] m

module Tests =
    open NUnit.Framework
    open FsUnit
    open hw1

    [<Test>]
    let ``factorialTest`` () = (fact 5) |> should equal 120

    [<Test>]
    let ``fibonacciTest`` () = (fib 5) |> should equal 5

    [<Test>]
    let ``reverseListTest`` () = (reverse [1; 2; 3]) |> should equal [3; 2; 1]

    [<Test>]
    let ``listMakerTest`` () = (listMaker 2 3) |> should equal [4; 8; 16; 32]