using Newtonsoft.Json;

namespace ColossusBets.Calculator.Service.Data.Models
{
    /// <summary>
    ///     Model object to store a result
    /// </summary>
    public class Record
    {
        /// <summary>
        ///     The ID of the record
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        ///     The amount evaluated
        /// </summary>
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        /// <summary>
        ///     The result obtained
        /// </summary>
        [JsonProperty("combination")]
        public string Combination { get; set; }

        /// <summary>
        ///     Returns a string tha rappresent the curent object
        /// </summary>
        /// <returns>
        ///     The current object in string
        /// </returns>
        public override string ToString()
        {
            return string.Format("{0} - {1} -> {2}", Id, Amount, Combination);
        }
    }
}