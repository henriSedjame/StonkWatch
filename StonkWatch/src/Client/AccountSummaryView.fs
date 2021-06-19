module Client.AccountSummaryView

open Sutil
open Sutil.Bulma
open Sutil.Attr
open Widgets
open Utils.Percentage



module Pnl =
    let element (title: string) (percentage: decimal<percent>) =

       bulma.container [

           Html.strong title
           |> withClass "pnl-title"

           percentage
           |> to_string
           |> Html.div
           |> Html.span
           |> withClass $"pnl-percent {percentage |> classFromPercentage}"

       ] |> alignCenter

let public accountSummaryView =

    let title = "Account summary" |> blocTitle

    let leftPart =
        [Margin.left 15 [ Html.text "LEFT" ]] |> Level.left

    let rightPart =
        [Margin.right 15  [
            Level.level [
                Level.left [Pnl.element "Open Pnl" -3.0m<percent>]
                space 10
                Level.right [Pnl.element "Day Pnl" 3.0m<percent>]
            ]

        ] ] |> Level.right

    let levelPart =
        Level.level [leftPart; rightPart]

    let content =
        bulma.container [ class' "bloc light-grey-bloc"; title; levelPart ]

    bulma.column [
        column.is6
        content
    ]
