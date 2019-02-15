module HttpHandlers

open Microsoft.AspNetCore.Http
open Giraffe.Core
open FSharp.Control.Tasks.V2.ContextInsensitive
open Giraffe

   let burgerMenuHandler =
        fun (next : HttpFunc) (ctx : HttpContext) ->
            task {
                let response = Data.DummyData.burgerMenu
                return! json response next ctx
            }

