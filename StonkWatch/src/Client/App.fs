module App

open Client
open Client.Model
open Sutil
open Sutil.Attr
open Sutil.DOM
open Sutil.Styling
open Shared.Domain

let init () : Model =
    {
        Portfolio = {
            Positions = [
                {
                    Stock = {
                        Symbol = Symbol "GCE"
                        CurrentPrice = CurrentStockPrice (StockPrice 5.0m<price>)
                        LastClosePrice = LastClosePrice (StockPrice 1.0m<price>)
                    }
                    OpenQty = ShareQuantity (Quantity 2u)
                    AverageOpenPrice = AverageOpenPrice (AveragePrice 2.5m<price> )
                }
            ]
            Balances = Undefined
        }
        CurrentPortfolioTab = PortfolioTab.Positions
    }

let update (msg: Message) (model: Model) : Model =
    match msg with
    |SelectedPaneChanged info ->
        if model.CurrentPortfolioTab <> info then
            {model with CurrentPortfolioTab = info}
        else
            model

// In Sutil, the view() function is called *once*
let view () =

    // Create store
    let storedModel, dispatch = Store.makeElmishSimple init update ignore ()

    Html.div [

         disposeOnUnmount [storedModel]

         class' "body"
         Components.navbar
         Components.content storedModel dispatch
    ]
    |> withStyle Styling.AppStyles.mainStyle

// Start the app
view () |> mountElement "sutil-app"
