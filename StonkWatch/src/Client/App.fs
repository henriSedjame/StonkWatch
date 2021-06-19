module App

open Client
open Farmer.Arm.Insights
open Sutil
open Sutil.Bulma
open Sutil.Attr
open Sutil.DOM
open Sutil.Styling

type Model = Empty

type Message = Noop

let update (msg: Message) (model: Model) : Model = model

// In Sutil, the view() function is called *once*
let view () =
    Html.div [
         class' "body"
         Components.navbar
         Components.content
    ]
    |> withStyle Styling.AppStyles.mainStyle

// Start the app
view () |> mountElement "sutil-app"
