using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using ColossusBets.Calculator.Service;
using Newtonsoft.Json;

namespace ColossusBets.Calculator.Api.Controllers
{
    public class RecordsController : ApiController
    {
        /// <summary>
        ///     Service that performs the actions
        /// </summary>
        private readonly IServiceCalculator _service;

        /// <summary>
        ///     CalculationController base constructor
        /// </summary>
        public RecordsController(IServiceCalculator service)
        {
            _service = service;
        }

        /// <summary>
        ///     Returns the records paginated
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
        public HttpResponseMessage Gets(int elementsPerPage = 10, int page = 1)
        {
            var results = _service.Gets(elementsPerPage, page);
            var jsonCombination = JsonConvert.SerializeObject(results);

            var response = GetResponseMessage(
                HttpStatusCode.OK,
                new StringContent(jsonCombination, Encoding.UTF8, "application/json"));

            return response;
        }

        /// <summary>
        ///     Helper method that create an HttpResponseMessage for the request
        /// </summary>
        /// <param name="httpStatusCode"></param>
        /// <param name="stringContent"></param>
        /// <returns>
        ///     An HttpResponseMessage object
        /// </returns>
        protected HttpResponseMessage GetResponseMessage(HttpStatusCode httpStatusCode, StringContent stringContent)
        {
            var response = Request.CreateResponse(httpStatusCode);
            response.Content = stringContent;
            return response;
        }
    }
}