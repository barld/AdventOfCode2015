let checks =
    let containsVowels (s:string) =
        let vowels = "aeiou"
        s |> Seq.filter (fun c -> vowels |> Seq.contains c) |> Seq.length >= 3

    let twiceInRow (s:string) =
        s |> Seq.pairwise |> Seq.exists (fun (a,b) -> a=b)

    let notContain (s:string) =
        let forbiddenPairs = ["ab";"cd";"pq";"xy";]
        not (s |> Seq.pairwise |> Seq.exists (fun (a,b) -> forbiddenPairs |> List.contains (new System.String([|a;b|]))))

    [containsVowels;twiceInRow;notContain]

let words = System.IO.File.ReadAllLines((__SOURCE_DIRECTORY__ + "\Day5.txt"))

let answer1 = words |> Seq.filter (fun word -> checks |> List.forall(fun c -> c word)) |> Seq.length
