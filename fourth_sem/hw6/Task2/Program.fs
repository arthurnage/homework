module Program
module Task2 =
    open System
    open System.Collections
    open System.Collections.Generic

    type Tree<'a> =
        | Empty
        | Tip of 'a
        | Tree of 'a * Tree<'a> * Tree<'a>

    type Enumerator<'a> (root: Tree<'a>) = 
        let mutable index = -1

        let rec listTree tree list = 
            match tree with 
            | Empty -> list
            | Tip x -> [x]
            | Tree(x, l, r) -> x :: ((listTree l list) @ (listTree r list))

        let mutable list = listTree root []

        interface IEnumerator<'a> with
            member this.Reset() =
                index <- -1
            member this.MoveNext() =
                index <- index + 1
                list.Length > index
            member this.Current = list.[index]
            member this.Dispose() = ()
            member this.get_Current() = (this :> IEnumerator<'a>).Current :> obj

    type BinaryTree<'a when 'a : comparison>() =
        let mutable tree : Tree<'a> = Empty

        let rec mostRightNode tree =
           match tree with
           | Empty -> Empty
           | Tip a -> Tip a
           | Tree(x, l, r) -> match r with
                              | Empty -> Tip x
                              | _ -> mostRightNode r

        member this.Insert x =
            let rec recInsert x value =
                match value with
                | Empty -> Tip x
                | Tip current ->
                     if (x < current) then
                          Tree(current, Tip x, Empty)
                     elif (x > current) then
                          Tree(current, Empty, Tip x)  
                     else
                          Tree (x, Empty, Empty)
                 | Tree(current, l, r) ->
                     if (x < current) then
                         Tree(current, recInsert x l, r) 
                     elif (x > current) then
                         Tree(current, l, recInsert x r) 
                     else 
                         Tree(x, l, r)
            tree <- recInsert x tree

        member this.IsBelong x =
            let rec recIsBelong tree x =
                match tree with
                | Empty -> false
                | Tip a -> x = a
                | Tree(current, l, r) ->
                    if x < current then
                       recIsBelong l x
                    elif x > current then
                       recIsBelong r x
                    else true
            recIsBelong tree x

        member this.Remove x = 
            let rec recRemove tree x = 
                match tree with
                | Empty -> Empty
                | Tip a -> 
                    if (a = x) then Empty
                    else
                        printfn "%A" "doesent exist"
                        tree
                | Tree (current, l, r) ->
                    if x > current then Tree(current, l, recRemove r x)
                    elif x < current then Tree(current, recRemove l x, r)
                    else
                        match r with
                        | Empty -> l
                        | _ ->
                            match l with
                            | Empty -> r
                            | _ ->
                                let forRemove = mostRightNode l
                                match forRemove with
                                | Tip a -> Tree(a, recRemove l a, r)
                                | _ -> Empty
            if (this.IsBelong x) then
                tree <- recRemove tree x
            else 
                printfn "doesent exist"

        member this.IsEmpty = (tree = Empty)

        interface IEnumerable with
            member this.GetEnumerator() = new Enumerator<'a>(tree) :> IEnumerator

module Tests =
    open Task2
    open System
    open System.Collections
    open System.Collections.Generic
    open FsUnit
    open NUnit.Framework

    [<Test>]
    let ``InsertAndDeleteTest`` () =
        let tree = BinaryTree<int>()
        tree.IsEmpty |> should be True
        tree.Insert 10
        tree.IsEmpty |> should be False
        tree.IsBelong 10 |> should be True
        tree.Remove 10
        tree.IsBelong 10 |> should be False

    [<Test>]
    let ``EnumTest`` () =
        let tree = BinaryTree<int>()
        tree.Insert 10
        tree.Insert 13
        tree.Insert 12
        tree.Insert 11
        tree.Insert 9
        tree.Insert 14
        let mutable count = 0
        for i in tree do
            count <- count + 1
        count |> should equal 6