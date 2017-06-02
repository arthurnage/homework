module Program

module Task1 =
    /// operating system class
    type OS(name) =
        /// name of OS
        member val Name = name with get

        /// probability of being infected by a virus
        member val Probability = match name with
                                 | "Windows" -> 0.01
                                 | "Linux" -> 0.018
                                 | "Mac" -> 0.017
                                 | _ -> 0.9
                                 with get
    /// a computer class
    type Computer(newOs) =
        /// gets the operating system
        member val Os : OS = newOs with get

        /// shows is a computer infected
        member val Infected = false with get, set

    /// network class repesenting computer with viruses
    type Network(matrix:int[][], newComputers:Computer[], num:int) =

        let mutable net = matrix

        let mutable infected : int list = []

        let mutable computers = newComputers

        let mutable computersNumber = num

        let random = System.Random()

        /// adds virus to the network
        member this.AddVirus(indexOfPc:int) =
            computers.[indexOfPc].Infected <- true
            infected <- (indexOfPc) :: infected

        /// an attempt to infect a computer
        member this.TryToInfect (comp:Computer) i =
            if (random.NextDouble() <= comp.Os.Probability) then 
                comp.Infected <- true
                infected <- (i) :: infected
        
        /// next interation of network life-cycle
        member this.NextMove() =
            let attack j =
                for i in 0 .. computersNumber - 1 do
                    if (net.[i].[j] = 1) then 
                        this.TryToInfect computers.[i] i
            List.map (fun v -> attack v) infected
        
        /// shows is the network stays in stabilized condition (other moves make nothing)
        member this.IsStabilized() =
            let mutable result = true
            Seq.forall(fun (comp:Computer) -> comp.Infected) <| Array.toSeq computers
        
        /// prints current information about the network
        member this.PrintInfo() =
            for i in 0 .. computersNumber - 1 do
                let res = if (computers.[i].Infected) then "infected" else "clear"
                printfn "%A %A" i res

    //check
    let matrix = [| [|0; 1; 0; 0; 0|]; [|1; 0; 1; 0; 0|]; [|0; 1; 0; 1; 0|]; [|0; 0; 1; 0; 1|]; [|0; 0; 0; 1; 0|] |]
    let computers = [|(new Computer(new OS("Linux"))); (new Computer(new OS("Mac"))); (new Computer(new OS("Windows"))); (new Computer(new OS("Linux"))); (new Computer(new OS("Windows")))|]
    let netw = new Network(matrix, computers, 5)
    netw.AddVirus(3)
    let mutable count = 1
    printfn "%A)" count
    count <- count + 1
    netw.PrintInfo()
    while (not(netw.IsStabilized())) do
        netw.NextMove()
        printfn "%A)" count
        count <- count + 1
        netw.PrintInfo()
        printfn ""

