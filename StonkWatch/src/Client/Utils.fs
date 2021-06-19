module Client.Utils

open Sutil.DOM

module Percentage =
    let PERCENT_SYMBOL: string = "%"

    [<Measure>]
    type percent

    let to_string (percentage: decimal<percent>) =
        $"{percentage}{PERCENT_SYMBOL}"

    let classFromPercentage (percentage: decimal<percent>) =
        if percentage > 0.0m<percent> then "success" else "danger"


