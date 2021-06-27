module Client.AccountSummaryView

open System
open Client.Model
open Sutil
open Sutil.Bulma
open Sutil.Attr
open Widgets
open Utils.Percentage
open Shared.Domain
open Utils
module Pnl =
    let element (title: string) (percentage: IObservable<decimal<percent>>) =

        let handle (p: decimal<percent>) =
            p
            |> to_string
            |> Html.div
            |> Html.span
            |> withClass $"pnl-percent {p |> classFromPercentage}"

        bulma.container [
                          Html.strong title |> withClass "pnl-title"
                          percentage <=> handle
                          ]

        |> alignCenter

module Btn =
    let button (tab: PortfolioTab) (selectedPane: IObservable<PortfolioTab>) (dispatch: Dispatch<Message>) =

        let isSelected =
            selectedPane
            |> Store.map ((=) tab)
            |> Store.distinct

        bulma.button.button [ Html.text $"{tab.name}"
                              bindClass isSelected "selected"
                              onClick (fun _ -> dispatch (SelectedPaneChanged tab)) [] ]

module Table =

    let positionTable (positions: IObservable<PositionInfo list>) =

        let header =
            Html.thead [
                Html.tr[
                   Table.hCell "Symbols" []
                   Table.hCell "Open price" []
                   Table.hCell "Current price" []
                   Table.hCell "Qty" []
                   Table.hCell "OpenPnl" []
                ]
            ]

        let positionInfoRows (position: PositionInfo) =
            let openPnl = Positions.openPnl position
            Html.tr[
                Table.cell (Positions.symbol position) []
                Table.cell (string (Positions.averageOpenPrice position)) []
                Table.cell (string (Positions.currentPrice position)) []
                Table.cell (string (Positions.openQty position)) []
                Table.cell (openPnl |> to_string) []
                |> withClass $"pnl-percent {openPnl |> classFromPercentage}"
            ]

        let tableFromPositions (ps : PositionInfo list) =
            Table.table <| header:: (ps |> List.map positionInfoRows)

        Html.div [
            positions <=> tableFromPositions
        ]


let public accountSummaryView (model: IObservable<Model>) (dispatch: Dispatch<Message>) =

    let selectedPane = model |>> (fun m -> m.CurrentPortfolioTab)

    let positions = model |>> (fun p -> p.Portfolio.Positions)

    let openPnl = model |>> (fun _ -> 3.2m<percent>)

    let dayPnl =  model |>> (fun _ -> 3.2m<percent>)

    let title = "Account summary" |> blocTitle

    let leftPart =
        Level.left [ Level.item [ Btn.button Positions selectedPane dispatch ]
                     Level.item [ Btn.button Balances selectedPane dispatch ] ]

    let rightPart =
        Level.right [ Level.item [ Pnl.element "Open Pnl" openPnl ]
                      Level.item [ Pnl.element "Day Pnl" dayPnl ] ]

    let levelPart = Level.level [ leftPart; rightPart ]


    let selectedPaneView = function
        | Positions -> Table.positionTable positions
        | Balances -> Html.text "Balances"


    Padding.all 15 [ bulma.container [
        title
        levelPart
        selectedPane <=> selectedPaneView
    ] ]
    |> withClass "bloc light-grey-bloc"
