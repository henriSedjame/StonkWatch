module App

open Client
open Client.Model
open Sutil
open Sutil.Attr
open Sutil.DOM
open Sutil.Styling
open Shared

let init () : Model * Cmd<Message> = Models.initial , Cmd.ofMsg FetchPortfolio

let update (msg: Message) (model: Model) : Model * Cmd<Message> =
    match msg with
    |SelectedPaneChanged tab ->
        let m =
            if model.CurrentPortfolioTab <> tab then
                {model with CurrentPortfolioTab = tab}
            else
                model
        m, Cmd.none

    |FetchPortfolio ->
        let cmd = async {
            do! Async.Sleep 2000
            return Message.PortfolioFetched Mocks.portfolio
        }

        model, Cmd.OfAsync.result cmd

    |PortfolioFetched p ->
        {model with Portfolio = p}, Cmd.none


// In Sutil, the view() function is called *once*
let view () =

    // Create store
    let storedModel, dispatch = Store.makeElmish init update ignore ()

    Html.div [

         disposeOnUnmount [storedModel]

         class' "body"
         Components.navbar
         Components.content storedModel dispatch
    ]
    |> withStyle Styling.AppStyles.mainStyle

// Start the app
view () |> mountElement "sutil-app"
