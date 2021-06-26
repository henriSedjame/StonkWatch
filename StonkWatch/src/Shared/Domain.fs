module Shared.Domain

(* Measures types *)
[<Measure>]
type percent

[<Measure>]
type price

(* Single discriminated types *)
type Symbol = Symbol of string

type StockPrice = StockPrice of decimal<price>
type CurrentStockPrice = CurrentStockPrice of StockPrice
type LastClosePrice = LastClosePrice of StockPrice

type AveragePrice = AveragePrice of decimal<price>
type AverageOpenPrice = AverageOpenPrice of AveragePrice

type Quantity = Quantity of uint
type ShareQuantity = ShareQuantity of Quantity

type PnL = PnL of decimal<percent>

type OpenPnL = OpenPnL of PnL
type PositionOpenPnL = PositionOpenPnL of OpenPnL
type PortfolioOpenPnL = PortfolioOpenPnL of OpenPnL

type DayPnL = DayPnL of PnL
type PositionDayPnL = PositionDayPnL of DayPnL
type PortfolioDayPnL = PortfolioDayPnL of DayPnL

(* Records types *)
type Stock = {
    Symbol: Symbol
    CurrentPrice: CurrentStockPrice
    LastClosePrice: LastClosePrice
}

type PositionInfo = {
    Stock: Stock
    OpenQty: ShareQuantity
    AverageOpenPrice: AverageOpenPrice
}

type Balances = Undefined

type Portfolio = {
    Positions: PositionInfo list
    Balances: Balances
}

(* modules *)

[<RequireQualifiedAccess>]
module Positions =
    let symbol {Stock = {Symbol = (Symbol s)}} = s

    let openQty {OpenQty = (ShareQuantity (Quantity qty))} = qty

    let currentPrice {Stock = {CurrentPrice = (CurrentStockPrice (StockPrice price))}} = price

    let averageOpenPrice {AverageOpenPrice = AverageOpenPrice (AveragePrice price)} = price

    let positionOpenPnl (positionInfo: PositionInfo) =
        let currentPrice = currentPrice positionInfo
        let openPrice = averageOpenPrice positionInfo

        ((currentPrice - openPrice)/openPrice) * 100m<percent>
        |> PnL
        |> OpenPnL
        |> PositionOpenPnL

    let openPnl (positionInfo: PositionInfo) =
       match positionOpenPnl positionInfo with
       |PositionOpenPnL (OpenPnL  (PnL p)) -> p


