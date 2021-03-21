using System;
using IParserService;
using IParserService.Models;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Xml;

namespace ParserService
{
    public class XmlParser : IXmlParser
    {

        public XmlParser()
        {

        }

        public BaseModel<Expense> GetExpense(string emailContent)
        {
            return ExtractExpense(emailContent);
        }

        private XElement GetXmlDocByTag(string content, string tagName)
        {
            //comments
            Regex regex = new Regex($@"<{tagName}>([\s\S]*)<\/{tagName}>");
            var match = regex.Match(content);
            return XElement.Parse(match.ToString());
        }

        private BaseModel<Expense> ExtractExpense(string emailContent)
        {
            var response = new BaseModel<Expense>();

            try
            {
                var expenseElements = GetXmlDocByTag(emailContent, "expense");
                var totalElement = expenseElements.Element("total");
                
                if(string.IsNullOrWhiteSpace(totalElement?.Value))
                {
                    response.ErrorDescription = "Total is missing.";
                    return response;
                }

                var total = 0.0M;
                if(!decimal.TryParse(totalElement.Value, out total))
                {
                    response.ErrorDescription = "Incorrect Total value.";
                    return response;
                }

                response.Success = true;
                response.Response = new Expense
                {
                    TotalInclGst = total,
                    CostCentre = expenseElements.Element("cost_centre")?.Value ?? "UNKNOWN"
                };
            }
            catch(XmlException ex)
            {
                //bad XML
                response.ErrorDescription = "XML not in right format.";
            }
            catch(Exception ex)
            {
                response.ErrorDescription = "";
            }

            return response;
            
        }
    }
}
