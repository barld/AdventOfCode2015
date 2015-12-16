
let parsePresent (s:string) =
    let values = s.Split('x') |> Array.map int
    (values.[0], values.[1], values.[2])

let calculateWrapper (present:int*int*int) =
    let l, w, h = present
    let areas = [l*w;w*h;h*l]
    (areas |> List.min) + ((areas |> List.sum) * 2)

let presents = System.IO.File.ReadAllLines(__SOURCE_DIRECTORY__ + "\Day2.txt") |> Seq.map parsePresent

let answer = presents |> Seq.map calculateWrapper |> Seq.sum