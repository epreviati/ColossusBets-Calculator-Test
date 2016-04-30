namespace ColossusBets.Calculator.Service.Data
{
    /// <summary>
    ///     Interface IMoney used to rappresent a money value
    /// </summary>
    public interface IMoney
    {
        /// <summary>
        ///     Type of the money
        /// </summary>
        MoneyType MoneyType { get; set; }

        /// <summary>
        ///     Value of the money
        /// </summary>
        int Value { get; set; }

        /// <summary>
        ///     Real amount of the money
        /// </summary>
        decimal Amount { get; set; }

        /// <summary>
        ///     Currency Code of the money
        /// </summary>
        string CurrencyCode { get; set; }

        /// <summary>
        ///     Symbol of the money
        /// </summary>
        string Symbol { get; set; }
    }
}