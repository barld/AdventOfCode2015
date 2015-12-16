printfn "input day1:"
let input = System.Console.ReadLine()

let answer = input |> Seq.fold(fun s c -> if c = '(' then s+1 else s-1) 0

printfn "the solution for day one is %i" answer