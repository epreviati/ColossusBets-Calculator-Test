namespace ColossusBets.Calculator.Service.Data.Models
{
    /// <summary>
    ///     Implementation of an IMoney used to rappresent the coin values
    /// </summary>
    public class Coin : AMoney
    {
        /// <summary>
        ///     Coin base constructor
        /// </summary>
        /// <param name="moneyType"></param>
        /// <param name="symbol"></param>
        public Coin(MoneyType moneyType, string symbol)
            : this(moneyType, 0, symbol)
        {
        }

        /// <summary>
        ///     Coin constructor
        /// </summary>
        /// <param name="moneyType"></param>
        /// <param name="value"></param>
        public Coin(MoneyType moneyType, int value)
            : this(moneyType, value, null)
        {
            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (moneyType)
            {
                case MoneyType.IntegerCoin:
                    Symbol = DefaultIntegerSymbol;
                    break;

                case MoneyType.DecimalCoin:
                    Symbol = DefaultDecimalSymbol;
                    break;
            }
        }

        /// <summary>
        ///     Coin constructor
        /// </summary>
        /// <param name="moneyType"></param>
        /// <param name="value"></param>
        /// <param name="symbol"></param>
        public Coin(MoneyType moneyType, int value, string symbol)
            : base(moneyType, value, symbol, DefaultCurrency)
        {
        }
    }
}