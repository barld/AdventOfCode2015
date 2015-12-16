let goToNewcordinate ((x,y), (set:Set<int*int>)) (direction:char) = //x,y is oldcordinate
    let nc = 
        match direction with
        | '^' -> (x,y+1)
        | 'v' -> (x,y-1)
        | '<' -> (x-1,y)
        | '>' -> (x+1,y)
        | _ -> (x,y)
    (nc, set.Add(nc))


let directions = System.IO.File.ReadAllText(__SOURCE_DIRECTORY__ + "\Day3.txt")
  
let coordinatesSet = Set.empty.Add(0,0)

let answer1 = directions |> Seq.fold goToNewcordinate ((0,0), coordinatesSet) |> snd |> Seq.length
    