open System.Net
open System.IO
open System.Text.RegularExpressions

let getURLInfo(url : string) =
    let fetchAsync(url : string) =
        async {
            let request = WebRequest.Create(url)
            let! response = request.AsyncGetResponse()
            let stream = response.GetResponseStream()
            let reader = new StreamReader(stream)
            let html = reader.ReadToEndAsync()
            let! htmlTask = Async.AwaitTask(html)
            do printfn "%s --- %d" url htmlTask.Length
        }

    let readHtml(url: string) =
        let request = WebRequest.Create(url)
        let response = request.GetResponse()
        let stream = response.GetResponseStream()
        let reader = new StreamReader(stream)
        let html = reader.ReadToEnd()
        html

    let regexExpression = new System.Text.RegularExpressions.Regex("<a.*href=\"http.*\">")
    let webPages = regexExpression.Matches(readHtml(url))
    let proc = [for url in webPages -> 
                     let value = url.Value
                     //printfn "%A" value
                     fetchAsync(value.Substring(value.IndexOf("f=") + 3 , value.IndexOf("\">") - value.IndexOf("=\"") - 2))
                     //fetchAsync(value)
                     ]    
    Async.Parallel proc |> Async.RunSynchronously |> ignore

getURLInfo("http://hwproj.me/courses/20")