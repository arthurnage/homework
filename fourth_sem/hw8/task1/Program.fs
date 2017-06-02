open System.Net
open System.IO
open System.Text.RegularExpressions

let getURLInfo(url : string) =
    let fetchAsync(url : string) =
        async {
            let request = WebRequest.Create(url)
            use! response = request.AsyncGetResponse()
            use stream = response.GetResponseStream()
            use reader = new StreamReader(stream)
            let str = reader.ReadToEnd()
            printfn "%s --- %d" url str.Length
            return str
        }

    let readHtml(url:string) =
        async {
            let! html = fetchAsync url
            return html
            }

    let regexExpression = new Regex("<a.*href=\"http.*\">")
    let html = Async.RunSynchronously <| readHtml url
    let webPages = regexExpression.Matches(html)
    let proc = [for url in webPages -> 
                     let value = url.Value
                     fetchAsync(value.Substring(value.IndexOf("f=") + 3 , value.IndexOf("\">") - value.IndexOf("=\"") - 2))
                     ]    
    Async.Parallel proc |> Async.RunSynchronously |> ignore

getURLInfo "http://hwproj.me/courses/20"