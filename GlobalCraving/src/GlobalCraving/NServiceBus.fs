module NServiceBus

open NServiceBus
open NServiceBus.Logging

let log = LogManager.GetLogger "NServiceBus"
module Messages =
    open NServiceBus

    [<CLIMutable>]
    type Grocery =
        { name: string }
        interface IMessage

open Messages

module Bus =
    open System
    open System.Threading.Tasks

    let bus =
        async {
            let endpointConfiguration = new EndpointConfiguration("groceries")
            let azureConfiguration = endpointConfiguration.UseTransport<AzureServiceBusTransport>()
            azureConfiguration.ConnectionString "Endpoint=sb://GlobalBurgers.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=YuiGusws/1RA085fWTtzbpDCt/9W7ZkY/lK+TT7ifHg="
                |> ignore
            azureConfiguration.Transactions TransportTransactionMode.None |> ignore
            azureConfiguration.TopicName "groceries" |> ignore
            let! result = Endpoint.Start(endpointConfiguration) |> Async.AwaitTask
            return result
        }

    let sendOrder (grocery:Grocery)=
        log.Debug <| sprintf "Requesting %s " grocery.name
        let bus' = bus |> Async.RunSynchronously
        bus'.Publish(grocery) |> Async.AwaitTask |> ignore
        Guid.NewGuid()

        
module Handlers =

    type MyPingHandler =
        interface IHandleMessages<Grocery> with
            member x.Handle(m, c) =
                async {
                    log.Info <| sprintf "Requested %s" m.name
                } |> Async.StartAsTask :> _
