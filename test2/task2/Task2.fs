module Program

module Task1 =
    let polyndromeNum () =
        let stringBack (s:string) =
            let rec loop (n:int) (s:string) =
                match n with
                | x when x = s.Length / 2 -> true
                | _ ->
                    match s.[n] with
                    | x when x = s.[s.Length - n - 1] -> loop (n + 1) s
                    | _ -> false
            loop 0 s
        let maxPolynCheck max (newValue:int) =
            if (stringBack(System.Convert.ToString(newValue)) && newValue > max) then newValue else max
        let rec loop2 i j max =
            match j with
            | 1000 -> max
            | _ -> loop2 i (j + 1) (maxPolynCheck max (i * j))
        let rec loop1 i max =
            match i with
            | 1000 -> max
            | _ -> 
                loop1 (i + 1) (loop2 i 100 max)
        loop1 100 1
    let x = polyndromeNum ()
    printf "%A" x

module Tests =
    open FsUnit
    open NUnit.Framework
    open Task1

    [<Test>]
    let ``polyndromeTest``() = polyndromeNum () |> should equal 906609
