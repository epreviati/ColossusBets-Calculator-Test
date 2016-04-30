using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using ColossusBets.Calculator.Service;
using ColossusBets.Calculator.Service.Data.Models;
using Newtonsoft.Json;

namespace ColossusBets.Calculator.Api.Controllers
{
    public class CalculationController : ApiController
    {
        /// <summary>
        ///     Service that performs the actions
        /// </summary>
        private readonly IServiceCalculator _service;

        /// <summary>
        ///     CalculationController base constructor
        /// </summary>
        public CalculationController(IServiceCalculator service)
        {
            _service = service;
        }

        /// <summary>
        ///     GET api/calculate/1000.00
        ///     Returns a combination that define how the amount could be splitted in the minimun total quantity of all types
        /// </summary>
        /// <param name="amount">
        ///     Amount to manage
        /// </param>
        /// <returns>
        ///     An HttpResponseMessage that contains the JSON value of the calculated combination
        /// </returns>
        public HttpResponseMessage Get(decimal amount)
        {
            HttpResponseMessage response;

            if (amount < 0 || amount > 1000)
            {
                response = GetResponseMessage(
                    HttpStatusCode.BadRequest,
                    new StringContent("The value of amount must be between p0.01 and £1000."));
            }
            else
            {
                var combination = _service.GetSmallestCombination(amount);
                var jsonCombination = JsonConvert.SerializeObject(combination);

                response = GetResponseMessage(
                    HttpStatusCode.OK,
                    new StringContent(jsonCombination, Encoding.UTF8, "application/json"));
            }

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