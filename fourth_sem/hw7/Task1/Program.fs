module Program

module Task1 =
    type RoundBuilder (num:int) =
        member this.Bind ((x:float), f) =
            f (System.Math.Round (x, num))
        member this.Return (x:float) =
            System.Math.Round (x, num)
    
    let test = 
        RoundBuilder 0 {
            let! a = 2.0 / 12.0
            let! b = 3.5
            return a / b
        }
    printfn "task1: %A" <| test

module Task2 =
    let str2int (s:string) =
        let flag, res = System.Int32.TryParse(s)
        match flag with
        | true -> Some res
        | _ -> None

    type CalculateBuilder () =
        member this.Bind ((x:string), f) =
            let num = str2int x
            match num with
            | None -> None
            | Some y -> f y
        member this.Return y = Some y

    let calc = new CalculateBuilder()

    let result1 = 
        calc {
            let! x = "1"
            let! y = "2"
            let z = x + y
            return z
        }
    let result2 = 
        calc {
            let! x = "1"
            let! y = "Ъ"
            let z = x + y
            return z
        }

    printfn "task2:\nvalid string: %A\ninvalid string: %A" result1 result2
module Tests =
    open FsUnit
    open NUnit.Framework
    open Task1
    open Task2

    //task1 tests
    [<Test>]
    let ``accuracyTest1`` () =
            RoundBuilder 3 {
                let! a = 2.0 / 12.0
                let! b = 3.5
                return a / b
            } |> should equal 0.048
    
    [<Test>]
    let ``accuracyTest2`` () =
            RoundBuilder 4 {
                let! a = 2.0 / 12.0
                let! b = 3.5
                return a / b
            } |> should equal 0.0476
    [<Test>]
    let ``accuracyTest3`` () =
            RoundBuilder 0 {
                let! a = 2.0 / 12.0
                let! b = 3.5
                return a / b
            } |> should equal 0.0

    //task2 tests
    [<Test>]
    let ``validStringTest`` () =
        let calc = new CalculateBuilder()
        calc {
            let! x = "13"
            let! y = "2"
            let z = x + y
            return z
        } |> should equal <| Some(15)
    [<Test>]
    let ``invalidStringTest`` () =
        let calc = new CalculateBuilder()
        calc {
            let! x = "1"
            let! y = "2]"
            let z = x + y
            return z
        } |> should equal <| None