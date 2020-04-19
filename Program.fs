open System
open FSharp.Data.Sql
open System.Data

let x = SQLitePCL.collation_hook_info
type T = SQLitePCL.collation_hook_info

let skipLine = Array.skipWhile (fun b -> b <> 10uy) >> Array.skip 1

let readLine byteArray =
    // let x = 
        byteArray
        |> skipLine
        |> skipLine
        |> Array.skip 595
        |> skipLine
        |> skipLine
        |> Array.take 3445760
    // let y = Array.map char x
    // x, y, String y

[<Literal>]
let DB = @"moneyPro.db"
let [<Literal>] ResolutionPath = __SOURCE_DIRECTORY__ + @"sqlite" 
[<Literal>]
let ConnectionString = 
    "Data Source=" + __SOURCE_DIRECTORY__ + DB + "Version=3;foreign keys=true"
type Sql = SqlDataProvider<
                Common.DatabaseProviderTypes.SQLITE, 
                ResolutionPath = ResolutionPath,
                ConnectionString = ConnectionString>

let ctx = Sql.GetDataContext()

let customers = 
    ctx.Main.Customers
    |> Seq.map(fun c -> c.ContactName)
    |> Seq.toList
[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    // let x =
    //     IO.File.ReadAllBytes "User_20200403104406.back"
    //     |> readLine
    // do IO.File.WriteAllBytes (DB, x)
    // do printfn "%A" x
    0 // return an integer exit code
