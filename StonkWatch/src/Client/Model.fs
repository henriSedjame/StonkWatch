module Client.Model

open Shared.Domain

type PortfolioTab =
    | Positions
    | Balances
    member public this.name
        with get(): string =
            match this with
            | Positions -> "Positions"
            | Balances -> "Balances"

type Model =
    { Portfolio: Portfolio
      CurrentPortfolioTab: PortfolioTab }

type Message =
    |SelectedPaneChanged of PortfolioTab
    |FetchPortfolio
    |PortfolioFetched of Portfolio


module Models =
    let initial =
        {
            Portfolio = { Positions = [] ; Balances = Undefined }
            CurrentPortfolioTab = PortfolioTab.Positions
        }
