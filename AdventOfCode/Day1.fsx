printfn "input day1:"
let input = System.Console.ReadLine()

let answer = input |> Seq.fold(fun s c -> if c = '(' then s+1 else s-1) 0

printfn "the solution for day one is %i" answer

//day1 part two

let answer2 = (input |> (Seq.mapFold(fun s c -> if c = '(' then s+1,s+1 else s-1 , s-1) 0) |> fst |> Seq.findIndex (fun i -> i = -1)) + 1

printfn "the solution of day1 part2 is %i" answer2