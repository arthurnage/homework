module Program

module Task1 =

    let sum1 l = List.fold (fun acc x -> acc + System.Convert.ToInt32(x % 2 = 0)) 0 l // 1

    let sum2 l = List.length (List.filter (fun x -> x % 2 = 0) l) // 2

    let sum3 l = List.sum (List.map (fun x -> abs(x % 2 - 1)) l)

module Task2 =
    type tree<'a> =
        | EmptyTree
        | TreeNode of 'a * 'a tree * 'a tree
    
    let rec treeMap f tree =
        match tree with
        | TreeNode(value, left, right) -> TreeNode(f value, treeMap f left, treeMap f right)
        | _ -> EmptyTree
    
    let tree = TreeNode(3, TreeNode(1, EmptyTree, EmptyTree), TreeNode(2, EmptyTree, EmptyTree))
    let emptyTree = EmptyTree
    let mappedTree = treeMap (fun x -> x * x) EmptyTree

module Task3 =
    type AriphTree =
        | Value of int
        | Sum of AriphTree * AriphTree
        | Difference of AriphTree * AriphTree
        | Product of AriphTree * AriphTree
        | Quotient of AriphTree * AriphTree
    
    let rec parce tree =
        match tree with
        | Value(x) -> x
        | Sum(x, y) -> (+) (parce x) (parce y)
        | Difference(x, y) -> (-) (parce x) (parce y)
        | Product(x, y) -> (*) (parce x) (parce y)
        | Quotient(x, y) -> (/) (parce x) (parce y)
    
    let x = parce (Sum(Product(Value(3), Value(4)), Value(5)))

module Task4 =

    let initPrimes = Seq.initInfinite (fun x -> x) |> Seq.filter (fun x -> (Seq.length (Seq.filter (fun y -> x % y = 0) ([2 .. x]))) = 1)
    let inf () = Seq.initInfinite (fun x -> x) |> Seq.filter (fun x -> (Seq.length (Seq.filter (fun y -> x % y = 0) ([2 .. x]))) = 1)
    let x = Seq.take 9 initPrimes
    let s = Seq.sum x

module Tests =
    open FsUnit
    open NUnit.Framework
    open Task1
    open Task2
    open Task3
    open Task4

    /// Task 1 tests
    [<Test>]
    let ``foldTest1``() = (sum1 [1;2;3;4;5;6]) |> should equal 3
    [<Test>]
    let ``foldTest2``() = (sum1 [1;1;1;1;1;1]) |> should equal 0
    [<Test>]
    let ``foldTest3``() = (sum1 [2;2;2;2;2;2]) |> should equal 6
    [<Test>]
    let ``filterTest1``() = (sum2 [1;2;3;4;5;6]) |> should equal 3
    [<Test>]
    let ``filterTest2``() = (sum2 [1;1;1;1;1;1]) |> should equal 0
    [<Test>]
    let ``filterTest3``() = (sum2 [2;2;2;2;2;2]) |> should equal 6
    [<Test>]
    let ``mapTest1``() = (sum3 [1;2;3;4;5;6]) |> should equal 3
    [<Test>]
    let ``mapTest2``() = (sum3 [1;1;1;1;1;1]) |> should equal 0
    [<Test>]
    let ``mapTest3``() = (sum3 [2;2;2;2;2;2]) |> should equal 6

    ///Task2 tests
    [<Test>]
    let ``treeMapTest1``() = 
        (treeMap (fun x -> x * x) (TreeNode(3, TreeNode(1, EmptyTree, EmptyTree), TreeNode(2, EmptyTree, EmptyTree)))) |>
            should equal (TreeNode(9, TreeNode (1, EmptyTree, EmptyTree), TreeNode (4, EmptyTree, EmptyTree)))
    [<Test>]
    let ``treeMapTest2``() =
        (treeMap (fun x -> x * x - 1) (TreeNode(10, EmptyTree, TreeNode(2, EmptyTree, EmptyTree)))) |>
            should equal (TreeNode(99, EmptyTree, TreeNode(3, EmptyTree, EmptyTree)))
    [<Test>]
    let ``treeMapTest3``() =
        (treeMap (fun x -> x * x) (TreeNode(1, EmptyTree, EmptyTree))) |> should equal (TreeNode(1, EmptyTree, EmptyTree))
    [<Test>]
    let ``emptyTreeTest``() = (treeMap (fun x -> x) (EmptyTree)) |> should equal (EmptyTree)

    ///Task3 Tests
    [<Test>]
    let ``arithTreeSumTest``() = (parce (Sum(Product(Value(3), Value(4)), Value(5)))) |> should equal (17)
    [<Test>]
    let ``arithTreeDifTest``() = (parce (Difference(Product(Value(3), Value(4)), Value(5)))) |> should equal (7)
    [<Test>]
    let ``arithTreeProdTest``() = (parce (Product(Product(Value(3), Value(4)), Value(5)))) |> should equal (60)
    [<Test>]
    let ``arithTreeDivTest``() = (parce (Quotient(Product(Value(3), Value(4)), Value(5)))) |> should equal (2)

    ///Task4 tests
    [<Test>]
    let ``primesTest1`` () = (List.sum (Seq.toList(Seq.take 9 <| inf()))) |> should equal 100
    [<Test>]
    let ``primesTest2`` () = (Seq.toList(Seq.take 20 <| inf())) |> should contain 19
    [<Test>]
    let ``primesTest3`` () = Seq.find (fun x -> x = 23) <| inf() |> should equal 23

