module Program

module Task =
    type Variable = string

    type Term =
        | Var of Variable
        | App of Term * Term
        | Abs of Variable * Term

    let rec betaReduction (term:Term) (var:Variable) value =

        match term with
        | Var(w) when w = var -> value
        | App (x, y) -> App(betaReduction x var value, betaReduction y var value)
        | Abs (x, y) -> Abs(x, betaReduction y var value)
        | _ -> term

    let rec containAbs term =
        match term with
        | Var(_) -> false
        | Abs(y, z) -> true
        | App(y, z) -> (containAbs y) || (containAbs z)
    
    let rec reduction term =
        //printfn "%A" term
        match term with
        | Var (_) -> term
        | App (x, y) -> 
            match x with 
            | Abs(t, u) -> reduction <| betaReduction u t y
            | Var(_) -> 
                match y with
                | Var(_) -> App(x, y)
                | _ -> App(x, y)
            | _ -> if (containAbs term) then reduction <| App(reduction x, reduction y) else App(reduction x, reduction y)
        | Abs (a, b) -> 
            match b with
            | Var (_) -> term
            | _ -> Abs(a, reduction b)


module Tests =
    open Task
    open FsUnit
    open NUnit.Framework

    //зависающий    
    //printfn "%A" <| reduction (App(Abs("x",App(Var "x", Var "x")),Abs("x",App(Var "x", Var "x"))))

    //((λa.(λb.b b) (λb.b b)) b) ((λc.(c b)) (λa.a))
    [<Test>]
    let ``test1`` () = (reduction (App(App(App(Abs("a", Abs("b", App(Var "b", Var "b"))), Abs("b", App(Var "b", Var "b"))), Var "b"), App(Abs("c", App(Var "c", Var "b")), Abs("a", Var "a"))))) |> should equal (App (App (Var "b",Var "b"),Var "b"))

    //S K K = I
    [<Test>]
    let ``test2`` () =  (reduction (App(App(Abs("x", Abs("y", Abs("z", App(App(Var("x"), Var("z")), App(Var("y"), Var("z")))))), Abs("x1", Abs("y1", Var("x1")))),Abs("x2", Abs("y2", Var("x2")))))) |> should equal (Abs ("z",Var "z"))
