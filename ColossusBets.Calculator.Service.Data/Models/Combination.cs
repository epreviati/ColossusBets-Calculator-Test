using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace ColossusBets.Calculator.Service.Data.Models
{
    /// <summary>
    ///     Object that contains all the combination required to split the amount
    /// </summary>
    public class Combination
    {
        [JsonProperty("combination")] private readonly IList<Result> _results;

        /// <summary>
        ///     Combination base constructor
        /// </summary>
        public Combination()
            : this(new List<Result>())
        {
        }

        /// <summary>
        ///     Combination constructor
        /// </summary>
        /// <param name="results"></param>
        public Combination(IList<Result> results)
        {
            _results = results;
        }

        /// <summary>
        ///     Adds a Result value in the list of values starting from the quantity and the IMoney parameters
        /// </summary>
        /// <param name="quantity">
        ///     The quantity of the IMoney
        /// </param>
        /// <param name="money">
        ///     The IMoney to add
        /// </param>
        public void Add(int quantity, IMoney money)
        {
            var result = new Result(quantity, money);
            _results.Add(result);
        }

        /// <summary>
        ///     Returns the number of Results added
        /// </summary>
        /// <returns>
        ///     Integer
        /// </returns>
        public int Count()
        {
            return _results.Count;
        }

        /// <summary>
        ///     Retruns the list of all Results
        /// </summary>
        /// <returns>
        ///     IList of Result
        /// </returns>
        public IList<Result> Result()
        {
            return _results;
        }

        /// <summary>
        ///     Returns the Result at the index parameter or null
        /// </summary>
        /// <param name="index">
        ///     The index of the required item
        /// </param>
        /// <returns>
        ///     Results or null
        /// </returns>
        public Result ElementAt(int index)
        {
            Result result = null;
            if (Count() - 1 <= index) result = _results.ElementAt(index);
            return result;
        }

        /// <summary>
        ///     Returns if the is at least one Result
        /// </summary>
        /// <returns>
        ///     true or false
        /// </returns>
        public bool HasResult()
        {
            return Count() > 0;
        }

        /// <summary>
        ///     Returns a string tha rappresent the curent object
        /// </summary>
        /// <returns>
        ///     The current object in string
        /// </returns>
        public override string ToString()
        {
            var toString = string.Empty;
            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (var result in Result())
            {
                toString = toString == string.Empty
                    ? result.ToString()
                    : string.Format("{0} + {1}", toString, result);
            }
            return toString;
        }
    }
}