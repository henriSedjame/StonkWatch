module Client.AccountSummaryView

open System
open Client.Model
open Sutil
open Sutil.Bulma
open Sutil.Attr
open Widgets
open Utils.Percentage

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
                          bindFragment percentage handle
                          ]

        |> alignCenter

module Btn =
    let button (info: SummaryInfo) (selectedPane: IObservable<SummaryInfo>) (dispatch: Dispatch<Message>) =

        let isSelected =
            selectedPane
            |> Store.map ((=) info)
            |> Store.distinct

        bulma.button.button [ Html.text $"{info.name}"
                              bindClass isSelected "selected"
                              onClick (fun _ -> dispatch (SelectedPaneChanged info)) [] ]

let public accountSummaryView (model: IObservable<Model>) (dispatch: Dispatch<Message>) =

    let selectedPane =
        model
        |> Store.map (fun m -> m.SelectedPane)
        |> Store.distinct

    let openPnl =
        model
        |> Store.map (fun m -> m.OpenPnl)
        |> Store.distinct

    let dayPnl =
        model
        |> Store.map (fun m -> m.DayPnl)
        |> Store.distinct

    let title = "Account summary" |> blocTitle

    let leftPart =
        Level.left [ Level.item [ Btn.button Positions selectedPane dispatch ]
                     Level.item [ Btn.button Balances selectedPane dispatch ] ]

    let rightPart =
        Level.right [ Level.item [ Pnl.element "Open Pnl" openPnl ]
                      Level.item [ Pnl.element "Day Pnl" dayPnl ] ]

    let levelPart = Level.level [ leftPart; rightPart ]

    Margin.all 15 [ bulma.container [ title; levelPart ] ]
    |> withClass "bloc light-grey-bloc"
