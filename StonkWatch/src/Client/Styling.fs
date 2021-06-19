module Client.Styling

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
            withBulmaHelpers [ rule ".body" [ Css.height 1000 ]
                               rule ".full-height" [ Css.heightInheritFromParent ]
                               rule ".title" [Css.padding 10]
                               rule ".bloc" [Css.margin 5]
                               rule ".light-grey-bloc" [Css.backgroundColor Colors.lightGrey]
                               rule ".pnl-percent" [Css.fontSize 15]
                               rule ".pnl-title" [Css.fontSize 18; Css.fontWeightBold]
                               rule ".success" [Css.color Colors.green]
                               rule ".danger" [Css.color Colors.red]]

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
