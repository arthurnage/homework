module prog =
    let mySeq =
        let rec numbers n =
            seq {
                yield n
                yield! numbers n }
        let rec loop i =
            seq {
                yield! Seq.take i (numbers i)
                yield! loop (i + 1) }
        loop 1
    let z = Seq.take 50 mySeq
    Seq.iter (fun a -> printf "%A " a) z
