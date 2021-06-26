module Shared.Tests

#if FABLE_COMPILER
open Fable.Mocha
#else
open Expecto
#endif

open Shared
open Shared.Domain

let pnl = testList "PnL" [
    testCase "Position Open Pnl calculates correctly" <| fun _ ->
        let stock: Stock = {
            Symbol = Symbol "GME"
            CurrentPrice = CurrentStockPrice(StockPrice(5.00m<price>))
            LastClosePrice = LastClosePrice(StockPrice(3.00m<price>)) }

        let position = {
            Stock = stock
            AverageOpenPrice = AverageOpenPrice(AveragePrice(2.50m<price>))
            OpenQty = ShareQuantity(Quantity 100u) }

        let expected = PositionOpenPnL (OpenPnL (PnL (100m<percent>)))
        let actual = Positions.positionOpenPnl position

        Expect.equal actual expected "Open PnL calculates correctly"

]


let shared = testList "Shared" [
    testCase "Empty string is not a valid description" <| fun _ ->
        let expected = false
        let actual = Todo.isValid ""
        Expect.equal actual expected "Should be false"
]