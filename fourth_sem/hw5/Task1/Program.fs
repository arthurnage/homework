module Program

    module Task1 =
        let bracketCheck (st:string) =
            let getSymmetry ch =
                match ch with
                | ')' -> '('
                | '}' -> '{'
                | ']' -> '['
            let rec brChecker (l:list<char>) (str:string) (i:int) =
                match i with
                | x when x = str.Length -> true
                | _ -> match str.[i] with
                       | ')' | '}' | ']' -> match l with
                                            | [] -> false
                                            | _ -> match l.Head with
                                                   | x when x = getSymmetry str.[i] -> brChecker l.Tail str (i + 1)
                                                   | _ -> false
                       | '(' | '{' | '[' -> brChecker (str.[i] :: l) str (i + 1)
                       | _ -> brChecker l str (i + 1)
            brChecker [] st 0
    
    module Task2 =
        let func x l = List.map (fun y -> y * x) l
        let func1 x = List.map (fun y -> y * x)
        let func2 x = List.map <| (*) x
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
        let ``functionsTest`` () = ((func 2 [1; 2; 3])) |> should equal [2; 4; 6]

        [<Test>]
        let ``functionsTest1`` () = ((pointFreeFunc 2 [1; 2; 3])) |> should equal [2; 4; 6]


