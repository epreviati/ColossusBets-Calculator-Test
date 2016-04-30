using System.Collections.Generic;
using System.Linq;
using ColossusBets.Calculator.DataService.Ef6Model;

namespace ColossusBets.Calculator.DataService.Ef6
{
    public class DataServiceCalculator : IDataServiceCalculator
    {
        private readonly IDbContext _context;

        /// <summary>
        ///     DataServiceCalculator base constructor
        /// </summary>
        public DataServiceCalculator(IDbContext context)
        {
            _context = context;
        }

        /// <summary>
        ///     Insert a new record into the storage and returns it's ID
        /// </summary>
        /// <param name="record">
        ///     The record to add
        /// </param>
        /// <returns>
        ///     Integer
        /// </returns>
        public long Store(Record record)
        {
            _context.Records.Add(record);
            _context.SaveChanges();

            return record.Id;
        }

        /// <summary>
        ///     Insert a new record into the storage and returns it's ID
        /// </summary>
        /// <param name="elementsPerPage">
        ///     The number record to retrieve
        /// </param>
        /// <param name="page">
        ///     The number of the page to retrieve
        /// </param>
        /// <returns>
        ///     IEnumerable of Record
        /// </returns>
        public IEnumerable<Record> Gets(int elementsPerPage = 10, int page = 1)
        {
            if (elementsPerPage < 1) return default(IEnumerable<Record>);

            if (page < 1) page = 1;

            return _context.Records
                .OrderByDescending(x => x.Id)
                .Skip(elementsPerPage*(page - 1))
                .Take(elementsPerPage)
                .ToList();
        }
    }
}