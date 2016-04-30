using System;
using System.Collections.Generic;
using ColossusBets.Calculator.DataService;
using ColossusBets.Calculator.Service.Data.Models;
using Record = ColossusBets.Calculator.DataService.Ef6Model.Record;

namespace ColossusBets.Calculator.Service.Implementation
{
    public class ServiceCalculator : IServiceCalculator
    {
        private readonly IDataServiceCalculator _dataService;

        /// <summary>
        ///     ServiceCalculator base constructor
        /// </summary>
        /// <param name="dataService"></param>
        public ServiceCalculator(IDataServiceCalculator dataService)
        {
            _dataService = dataService;
        }

        /// <summary>
        ///     Returns a combination that define how the amount could be splitted in the minimun total quantity of all types.
        /// </summary>
        /// <param name="amount">Te amount to evalute</param>
        /// <returns>
        ///     The calculated combination
        /// </returns>
        public Combination GetSmallestCombination(decimal amount)
        {
            var record = new Record {Amount = amount};
            var result = new Combination();

            if (amount < 0 || amount > 1000) return result;

            foreach (var money in Configuration.AllMoneyValues)
            {
                if (money.Amount > amount) continue;

                result.Add(
                    decimal.ToInt32(amount/money.Amount),
                    money);

                amount = amount%money.Amount;
            }

            try
            {
                record.Combination = result.ToString();
                _dataService.Store(record);
            }
            catch (Exception e)
            {
                // ignore it
                // error should be logged or managed in a differnt way
            }

            return result;
        }

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
        public IEnumerable<Data.Models.Record> Gets(int elementsPerPage = 10, int page = 1)
        {
            var records = new List<Data.Models.Record>();

            try
            {
                var dbRecords = _dataService.Gets(elementsPerPage, page);
                // ReSharper disable once LoopCanBeConvertedToQuery
                foreach (var dbRecord in dbRecords)
                {
                    var record = new Data.Models.Record
                    {
                        Id = dbRecord.Id,
                        Amount = dbRecord.Amount,
                        Combination = dbRecord.Combination
                    };

                    records.Add(record);
                }
            }
            catch (Exception e)
            {
                // ignore it
                // error should be logged or managed in a differnt way
            }

            return records;
        }
    }
}