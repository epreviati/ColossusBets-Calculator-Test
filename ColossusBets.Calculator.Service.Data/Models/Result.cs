using Newtonsoft.Json;

namespace ColossusBets.Calculator.Service.Data.Models
{
    /// <summary>
    ///     Object that defines how many IMoney objects are required for the final result
    /// </summary>
    public class Result
    {
        /// <summary>
        ///     Result base constructor
        /// </summary>
        /// <param name="quantity"></param>
        /// <param name="money"></param>
        public Result(int quantity, IMoney money)
        {
            Quantity = quantity;
            Money = money;
        }

        /// <summary>
        ///     Define hot many IMoney are required for the final results
        /// </summary>
        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        /// <summary>
        ///     Define which one IMoney is required
        /// </summary>
        [JsonProperty("money")]
        public IMoney Money { get; set; }

        /// <summary>
        ///     Returns a string tha rappresent the curent object
        /// </summary>
        /// <returns>
        ///     The current object in string
        /// </returns>
        public override string ToString()
        {
            return string.Format("{0} X {1}", Money, Quantity);
        }
    }
}