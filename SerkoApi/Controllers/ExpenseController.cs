using SerkoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Xml.Linq;
using SerkoApi.Utilities;
using IParserService;
using ParserService;

namespace SerkoApi.Controllers
{
    [RoutePrefix("api/Expense")]
    public class ExpenseController : ApiController
    {
        private readonly IXmlParser _xmlParser;
        public ExpenseController(IXmlParser xmlParser)
        {
            _xmlParser = xmlParser;
        }

        [Route("")]
        public IHttpActionResult Get(string emailContent)
        {

            var response = _xmlParser.GetExpense(emailContent);
            if(!response.Success)
                return BadRequest(response.ErrorDescription);
            return Ok(response.Response);
        }


    }
}