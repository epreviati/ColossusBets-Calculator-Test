using System.Collections.Generic;
using ColossusBets.Calculator.Service.Data.Models;

namespace ColossusBets.Calculator.Service
{
    public interface IServiceCalculator
    {
        /// <summary>
        ///     Returns a combination that define how the amount could be splitted in the minimun total quantity of all types.
        /// </summary>
        /// <param name="amount">Te amount to evalute</param>
        /// <returns>
        ///     The calculated combination
        /// </returns>
        Combination GetSmallestCombination(decimal amount);

        /// <summary>
        ///    Returns the records paginated
        /// </summary>
        /// <param name="elementsPerPage">
        ///     The number of record to retrieve
        /// </param>
        /// <param name="page">
        ///     The number of the page to retrieve
        /// </param>
        /// <returns>
        ///     IEnumerable of Record
        /// </returns>
        IEnumerable<Record> Gets(int elementsPerPage = 10, int page = 1);
    }
}