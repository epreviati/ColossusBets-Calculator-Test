using System.Globalization;
using Newtonsoft.Json;

namespace ColossusBets.Calculator.Service.Data
{
    /// <summary>
    ///     Abstraztion of an IMoney used to rappresent an abstract values
    /// </summary>
    public abstract class AMoney : IMoney
    {
        public const string DefaultCurrency = "GBP";
        public const string DefaultIntegerSymbol = "£";
        public const string DefaultDecimalSymbol = "p";

        /// <summary>
        ///     AMoney base constructor
        /// </summary>
        protected AMoney()
            : this(MoneyType.Unknown)
        {
        }

        /// <summary>
        ///     AMoney constructor
        /// </summary>
        /// <param name="moneyType"></param>
        protected AMoney(MoneyType moneyType)
            : this(moneyType, 0, null)
        {
        }

        /// <summary>
        ///     AMoney constructor
        /// </summary>
        /// <param name="moneyType"></param>
        /// <param name="value"></param>
        protected AMoney(MoneyType moneyType, int value)
            : this(moneyType, value, null)
        {
        }

        /// <summary>
        ///     AMoney constructor
        /// </summary>
        /// <param name="moneyType"></param>
        /// <param name="value"></param>
        /// <param name="symbol"></param>
        protected AMoney(MoneyType moneyType, int value, string symbol)
            : this(moneyType, value, symbol, null)
        {
        }

        /// <summary>
        ///     AMoney constructor
        /// </summary>
        /// <param name="moneyType"></param>
        /// <param name="value"></param>
        /// <param name="symbol"></param>
        /// <param name="currencyCode"></param>
        protected AMoney(MoneyType moneyType, int value, string symbol, string currencyCode)
        {
            MoneyType = moneyType;
            Value = value;
            Symbol = symbol;
            CurrencyCode = currencyCode;

            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (moneyType)
            {
                case MoneyType.Note:
                case MoneyType.IntegerCoin:
                    Amount = value;
                    break;

                case MoneyType.DecimalCoin:
                    // ReSharper disable once PossibleLossOfFraction
                    Amount = (decimal) value/100;
                    break;
            }
        }

        /// <summary>
        ///     Type of the money
        /// </summary>
        [JsonProperty("type")]
        public MoneyType MoneyType { get; set; }

        /// <summary>
        ///     Value of the money
        ///     With the Money Type define the Amount
        /// </summary>
        [JsonProperty("value")]
        public int Value { get; set; }

        /// <summary>
        ///     Real amount of the money
        /// </summary>
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        /// <summary>
        ///     Currency Code of the money
        /// </summary>
        [JsonProperty("currency")]
        public string CurrencyCode { get; set; }

        /// <summary>
        ///     Symbol of the money
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        /// <summary>
        ///     Returns a string tha rappresent the curent object
        /// </summary>
        /// <returns>
        ///     The current object in string
        /// </returns>
        public override string ToString()
        {
            var amount = MoneyType == MoneyType.DecimalCoin
                ? Amount.ToString("0.00")
                : Amount.ToString(CultureInfo.InvariantCulture);

            return string.Format("{0}{1}", Symbol, amount);
        }
    }
}