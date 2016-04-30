using System.Collections.Generic;
using ColossusBets.Calculator.DataService.Ef6Model;

namespace ColossusBets.Calculator.DataService
{
    public interface IDataServiceCalculator
    {
        /// <summary>
        ///     Insert a new record into the storage and returns it's ID
        /// </summary>
        /// <param name="record">
        ///     The record to add
        /// </param>
        /// <returns>
        ///     Integer
        /// </returns>
        long Store(Record record);

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