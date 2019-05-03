module HttpHandlers

open Microsoft.AspNetCore.Http
open Giraffe.Core
open FSharp.Control.Tasks.V2.ContextInsensitive
open Giraffe
open Models
open System

   let burgerMenuHandler =
        fun (next : HttpFunc) (ctx : HttpContext) ->
            task {
                let response = Data.DummyData.burgerMenu
                return! json response next ctx
            }

    let burgerOrderHandler =
        fun (next : HttpFunc) (ctx : HttpContext) ->
            task {
                let! order = ctx.BindJsonAsync<BurgerOrder>()
                 
                let response =
                    NServiceBus.Bus.sendOrder {name=order.burgerKey}
                return! json response next ctx
            }
