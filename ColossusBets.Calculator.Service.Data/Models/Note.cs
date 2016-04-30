namespace ColossusBets.Calculator.Service.Data.Models
{
    /// <summary>
    ///     Implementation of an IMoney used to rappresent the note values
    /// </summary>
    public class Note : AMoney
    {
        /// <summary>
        ///     Note base constructor
        /// </summary>
        public Note()
            : this(0)
        {
        }

        /// <summary>
        ///     Note base constructor
        /// </summary>
        /// <param name="value"></param>
        public Note(int value)
            : base(MoneyType.Note, value, DefaultIntegerSymbol, DefaultCurrency)
        {
        }
    }
}