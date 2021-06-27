module Client.Styling

open Feliz

module Colors =

    [<Literal>]
    let public lightGrey = "#EEEEEE"

    [<Literal>]
    let public  white = "white"

    [<Literal>]
    let public purple = "purple"

    [<Literal>]
    let public green = "green"

    [<Literal>]
    let public red = "red"

module AppStyles =

        open Sutil.Bulma
        open Sutil.DOM
        open Sutil.Styling

        let public mainStyle =
            withBulmaHelpers [ rule ".body" [  length.px 1000 |> Css.height  ]
                               rule ".full-height" [ Css.heightInheritFromParent ]
                               rule ".title" []
                               rule ".bloc" [length.px 5 |> Css.margin]
                               rule ".light-grey-bloc" [Css.backgroundColor Colors.lightGrey]
                               rule ".pnl-percent" [ length.em 1.2 |> Css.fontSize]
                               rule ".pnl-title" [length.em 1.3 |> Css.fontSize; Css.fontWeightBold]
                               rule ".success" [Css.color Colors.green]
                               rule ".danger" [Css.color Colors.red]
                               rule ".selected" [Css.backgroundColor Colors.purple; Css.color Colors.white]]

        let public navbarStyle =
            withBulmaHelpers [ rule ".navbar" [ Css.backgroundColor Colors.purple ]
                               rule
                                   ".navbar-item"
                                   [ Css.color Colors.white
                                     Css.fontWeightBold ] ]
        let public menubarStyle =
            [ rule
                  ".menubar"
                  [ Css.backgroundColor Colors.lightGrey
                    Css.heightInheritFromParent ] ]
