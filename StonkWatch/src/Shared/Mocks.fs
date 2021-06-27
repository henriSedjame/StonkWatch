module Shared.Mocks

open Domain

let portfolio : Portfolio = {
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
