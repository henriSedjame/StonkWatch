module Client.Widgets

open Sutil
open Sutil.Attr
open Sutil.DOM

let createElement el className =
    fun props -> el <| [ class' className ] @ props

let createElementWithStyle (st: (string * obj) list) =
        fun props -> [ style st ] @ props |> Html.div

module Level =

    let public level =
        createElement Html.nav "level"
    let public left =
        createElement Html.div "level-left"
    let public right =
        createElement Html.div "level-right"

module Padding =

    let public all (p : int) =
        createElementWithStyle <| [Css.padding p]

    let public top (p : int) =
        createElementWithStyle <| [Css.paddingTop p]


    let public bottom (p : int) =
        createElementWithStyle <| [Css.paddingBottom p]

    let public left (p : int) =
        createElementWithStyle <| [Css.paddingLeft p]

    let public right (p : int) =
        createElementWithStyle <| [Css.paddingRight p]

    let public vertical (p : int) =
        createElementWithStyle <| [Css.paddingTop p; Css.paddingBottom p]

    let public horizontal (p : int) =
        createElementWithStyle <| [Css.paddingLeft p; Css.paddingRight p]

module Margin =

    let public all (p : int) =
        createElementWithStyle [Css.margin p]

    let public top (p : int) =
        createElementWithStyle [Css.marginTop p]

    let public bottom (p : int) =
        createElementWithStyle [Css.marginBottom p]

    let public left (p : int) =
        createElementWithStyle [Css.marginLeft p]

    let public right (p : int) =
        createElementWithStyle [Css.marginRight p]

    let public vertical (p : int) =
        createElementWithStyle [Css.marginTop p; Css.marginBottom p]

    let public horizontal (p : int) =
        createElementWithStyle [Css.marginLeft p; Css.marginRight p]

let public blocTitle (title: string) =
   Html.div[
        class' "title"
        Html.h4 title
    ]

let public withClass classname node =
    Html.div [class' classname; node]

let public alignCenter node =
    Html.div [style [Css.textAlignCenter]; node]

let public space (d:int) =
    Html.div [style [Css.width d]]