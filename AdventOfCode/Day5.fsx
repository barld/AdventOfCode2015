let words = System.IO.File.ReadAllLines((__SOURCE_DIRECTORY__ + "\Day5.txt"))

let answer1 = 
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

    words |> Seq.filter (fun word -> checks |> List.forall(fun c -> c word)) |> Seq.length

let answer2 =
    let checks = 
        let pairsRepeating (s:string) =
            let pairs = s |> Seq.pairwise
            let rec pairsDoublExists pairs =
                if pairs |> Seq.length >= 3 then
                    let h = pairs |> Seq.head
                    if pairs |> Seq.skip 2 |> Seq.exists (fun p -> p = h) then
                        true
                    else
                        pairsDoublExists (pairs |> Seq.tail)
                else
                    false

            pairsDoublExists pairs

        let rec letterRepeating (s:string) =
            if s |> Seq.length >= 3 then                
                if s.[0] = s.[2] then
                    true
                else
                    letterRepeating (s.[1..])
            else
                false
        [pairsRepeating;letterRepeating]

    words |> Seq.filter (fun word -> checks |> List.forall(fun c -> c word)) |> Seq.length