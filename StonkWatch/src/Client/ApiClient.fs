module Client.ApiClient

open Fable.Remoting.Client
open Shared


let portfolioClient =
    Remoting.createApi ()
    |> Remoting.withRouteBuilder Route.builder
    |> Remoting.buildProxy<PortfolioApi>