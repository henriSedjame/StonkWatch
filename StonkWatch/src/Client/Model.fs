module Client.Model

open Client.Utils.Percentage

type SummaryInfo =
    | Positions
    | Balances
    member public this.name
        with get(): string =
            match this with
            | Positions -> "Positions"
            | Balances -> "Balances"

type Model =
    { OpenPnl: decimal<percent>
      DayPnl: decimal<percent>
      SelectedPane: SummaryInfo }

type Message =
    |SelectedPaneChanged of SummaryInfo
