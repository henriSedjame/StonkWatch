module App

open Client
open Client.Model
open Client.Utils.Percentage
open Farmer.Arm.Insights
open Sutil
open Sutil.Bulma
open Sutil.Attr
open Sutil.DOM
open Sutil.Styling

let init () : Model =
    {
        DayPnl = 3.0m<percent>
        OpenPnl = 4.0m<percent>
        SelectedPane = SummaryInfo.Positions
    }

let update (msg: Message) (model: Model) : Model =
    match msg with
    |SelectedPaneChanged info ->
        if model.SelectedPane <> info then
            {model with SelectedPane = info}
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
