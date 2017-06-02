module Task3

open System
open System.IO

type data = { name : string; phone : string }

let rec dictionary (list:list<data>) =
    Console.WriteLine("\n1. leave\n2. add new record\n3. find phone number using name\n4. find name using phone number\n5. print the database\n6. save current data to file\n7. read data from file\n")
    let n = Console.ReadLine() |> int
    match n with
    | 2 -> 
        printf "enter name: "
        let newName = Console.ReadLine()
        printf "enter phone number: "
        let newPhone = Console.ReadLine()
        let newRecord = { name = newName; phone = newPhone }
        dictionary (newRecord :: list)
    | 3 ->
        printf "enter name: "
        let newName = Console.ReadLine()
        printf "phone: %s\n" <| (List.head <| List.filter (fun x -> x.name = newName) list).phone
        dictionary list
    | 4 -> 
        printf "enter phone number: "
        let newPhone = Console.ReadLine()
        printf "name: %s\n" <| (List.head <| List.filter (fun x -> x.phone = newPhone) list).name
        dictionary list
    | 5 -> 
        printf "data:\n"
        List.iter (fun x -> printf "%A\n" x) list
        dictionary list
    | 6 ->
        System.IO.File.WriteAllLines("database.txt", List.map (fun x -> x.name + " " + x.phone) list)
        printf "data added to file database.txt\n"
        dictionary list
    | 7 ->
        try
            let addRecord (arr:array<string>) = { name = arr.[0]; phone = arr.[1] }
            printf "data updated \n"
            dictionary (List.map (fun (x:string) -> addRecord (x.Split[| |])) (Seq.toList (System.IO.File.ReadAllLines("database.txt"))))
        with
        | :? FileNotFoundException -> 
            printfn "no file found"
            dictionary list
        | _ -> 
            printfn "reeding error"
            dictionary list
    | _ -> printf "byebye"
[<EntryPoint>]
dictionary []