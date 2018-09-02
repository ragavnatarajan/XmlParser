using IParserService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserService.Tests
{
    [TestClass()]
    public class XmlParserTests
    {
        private readonly IXmlParser xmlParser;

        public XmlParserTests()
        {
            xmlParser = new XmlParser();
        }

        [TestMethod()]
        public void GetExpenseTestSuccess()
        {
            var s = "Hi Yvaine, Please create an expense claim for the below. Relevant details are marked up as requested... <expense><cost_centre>DEV002</cost_centre> <total>1024.01</total><payment_method>personal card</payment_method> </expense> From: Ivan Castle Sent: Friday, 16 February 2018 10:32 AM To: Antoine Lloyd <Antoine.Lloyd@example.com> Subject: test Hi Antoine, Please create a reservation at the <vendor>Viaduct Steakhouse</vendor> our <description>development team’s project end celebration dinner</description> on <date>Tuesday 27 April 2017</date>. We expect to arrive around 7.15pm. Approximately 12 people but I’ll confirm exact numbers closer to the day. Regards,";
            Assert.AreEqual(xmlParser.GetExpense(s).Success, true);
        }

        [TestMethod()]
        public void GetExpenseTestFailure()
        {
            var s = "Hi Yvaine, Please create an expense claim for the below. Relevant details are marked up as requested... <expense><cost_centre>DEV002</cost_centre> <payment_method>personal card</payment_method> </expense> From: Ivan Castle Sent: Friday, 16 February 2018 10:32 AM To: Antoine Lloyd <Antoine.Lloyd@example.com> Subject: test Hi Antoine, Please create a reservation at the <vendor>Viaduct Steakhouse</vendor> our <description>development team’s project end celebration dinner</description> on <date>Tuesday 27 April 2017</date>. We expect to arrive around 7.15pm. Approximately 12 people but I’ll confirm exact numbers closer to the day. Regards,";
            Assert.AreEqual(xmlParser.GetExpense(s).Success, false);
        }

        [TestMethod()]
        public void GetExpenseTestCostCenter()
        {
            var s = "Hi Yvaine, Please create an expense claim for the below. Relevant details are marked up as requested... <expense> <total>1024.01</total><payment_method>personal card</payment_method> </expense> From: Ivan Castle Sent: Friday, 16 February 2018 10:32 AM To: Antoine Lloyd <Antoine.Lloyd@example.com> Subject: test Hi Antoine, Please create a reservation at the <vendor>Viaduct Steakhouse</vendor> our <description>development team’s project end celebration dinner</description> on <date>Tuesday 27 April 2017</date>. We expect to arrive around 7.15pm. Approximately 12 people but I’ll confirm exact numbers closer to the day. Regards,";
            Assert.AreEqual(xmlParser.GetExpense(s).Response.CostCentre.ToLower(), "unknown");
        }

    }
}