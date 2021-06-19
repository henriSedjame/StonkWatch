module Client.Components

open Sutil
open Sutil.Bulma
open Sutil.Attr
open Styling

module NavBar =
    let navbar props = [ class' "navbar" ] @ props |> Html.nav

    let brand props =
        [ class' "navbar-brand" ] @ props |> Html.div

    let item props =
        [ class' "navbar-item" ] @ props |> Html.a

module Menu =
    let menubar items =
        [ column.is2; class' "menubar" ] @ items
        |> bulma.column

let public navbar =
    Html.div [ NavBar.navbar [ NavBar.brand [ NavBar.item [ Html.text "STONK WATCH" ] ] ] ]
    |> withStyle AppStyles.navbarStyle

let menubar =
    Menu.menubar [ Html.text "Menu" ]
    |> withStyle AppStyles.menubarStyle

let public content =
    bulma.columns [
             class' "full-height"
             menubar
             AccountSummaryView.accountSummaryView
         ]