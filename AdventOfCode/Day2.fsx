
let parsePresent (s:string) =
    let values = s.Split('x') |> Array.map int
    (values.[0], values.[1], values.[2])

let calculateWrapper (present:int*int*int) =
    let l, w, h = present
    let areas = [l*w;w*h;h*l]
    (areas |> List.min) + ((areas |> List.sum) * 2)

let presents = System.IO.File.ReadAllLines(__SOURCE_DIRECTORY__ + "\Day2.txt") |> Seq.map parsePresent

let answer = presents |> Seq.map calculateWrapper |> Seq.sum

printfn "answer 1 day2: %i" answer


let calculateRibbon (present:int*int*int) =
    let l, w, h = present
    (l*w*h) + 
    (if l > w && l > h then
        (w+h)*2
    elif w > h then
        (h+l)*2
    else
        (w+l)*2)
    

let answer2 = presents |> Seq.map calculateRibbon |> Seq.sum

printfn "answer 2 day2"
