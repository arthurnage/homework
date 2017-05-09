module Program

    module Task1 =
        let bracketCheck (st:string) =
            let brPush (l:list<char>) (ch:char) =
                let brChecker (ch:char) =
                    match ch with
                    | '(' | '{' | '[' | ']' | '}' | ')' -> true
                    | _ -> false
                match l with
                | [] -> if brChecker ch then (ch :: l) else l
                | _ -> match ch with
                       | ')' -> match l.Head with 
                                | '(' -> l.Tail
                                | _ -> (')' :: l)
                       | '}' -> match l.Head with
                                | '{' -> l.Tail
                                | _ -> ('}' :: l)
                       | ']' -> match l.Head with
                                | '[' -> l.Tail
                                | _ -> (']' :: l)
                       | _ -> if brChecker ch then (ch :: l) else l
            let rec loop l (str:string) i =
                match i with 
                | x when x = (str.Length) -> (List.length l = 0)
                | _ -> loop (brPush l st.[i]) str (i + 1)
            loop [] st 0
    
    module Task2 =
        let func x l = List.map (fun y -> y * x) l
        let pointFreeFunc = (*) >> List.map

    module Tests =
        open Task1
        open Task2
        open NUnit.Framework
        open FsUnit

        //tests for task 1
        [<Test>]
        let ``bracketTest1`` () = (bracketCheck "()()()") |> should equal true
        [<Test>]
        let ``bracketTest2`` () = (bracketCheck "({[}])({}[])") |> should equal false
        [<Test>]
        let ``bracketTest3`` () = (bracketCheck "()[({})]()") |> should equal true

        //test for task 2
        [<Test>]
        let ``functionsTest`` () = ((func 2 [1; 2; 3])) |> should equal [2;4;6]

        [<Test>]
        let ``functionsTest1`` () = ((pointFreeFunc 2 [1; 2; 3])) |> should equal [2;4;6]


