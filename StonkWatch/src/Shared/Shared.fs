namespace Shared

open Shared.Domain

module Route =
    let builder typeName methodName =
        sprintf "/api/%s/%s" typeName methodName

type PortfolioApi = {
    getPortfolio: unit -> Async<Portfolio>
}