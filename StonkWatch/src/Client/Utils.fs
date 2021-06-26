module Client.Utils

open Shared.Domain
open Sutil

[<AutoOpen>]
module ObserveOps =
    let (|>>) model f =
        model
        |> Store.map f
        |> Store.distinct

    let (<=>) model f =
        Bind.fragment model f

module Percentage =
    let PERCENT_SYMBOL: string = "%"

    let to_string (percentage: decimal<percent>) =
        $"{percentage}{PERCENT_SYMBOL}"

    let classFromPercentage (percentage: decimal<percent>) =
        if percentage > 0.0m<percent> then "success" else "danger"


