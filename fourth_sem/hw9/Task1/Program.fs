module Program
module Task1 =
    open System
    open System.Threading

    type CountdownEvent(num) =

        let event = new ManualResetEvent(false)

        let mutable count =
            if (num >= 0) then num
            else failwith "num < 0"

        member this.Wait() =
            if (count > 0) then event.WaitOne()
            else false
        
        member this.Signal() =
            count <- Interlocked.Decrement(&count)
            if (count <= 0) then
                count <- 0
                event.Set()
            else false

module Tests =
    open System
    open System.Threading
    open Task1
    open NUnit.Framework
    open FsUnit

    [<Test>]
    let ``zeroCountTest`` () =
        let event = new CountdownEvent(0)
        event.Signal() |> should be True
    
    [<Test>]
    let ``oneCountTest`` () =
        let event = new CountdownEvent(1)
        event.Signal() |> should be True
    
    [<Test>]
    let ``twoCountTest`` () =
        let event = new CountdownEvent(2)
        event.Signal() |> should be False
        event.Signal() |> should be True
    
    [<Test>]
    let ``asyncTest`` () =
        let event = new CountdownEvent(2)  
        let mutable num = 0
        Async.Start(
            async{
                num <- num + 2
                event.Wait()
                num <- num + 1
            }
        )
        Thread.Sleep 100
        event.Signal()
        Thread.Sleep 100
        event.Signal()
        num |> should equal 2
        Thread.Sleep 100
        num |> should equal 3
