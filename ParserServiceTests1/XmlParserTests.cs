﻿using IParserService;
using NUnit.Framework;


namespace ParserService.Tests
{
    [TestFixture()]
    public class XmlParserTests
    {
        private IXmlParser _xmlParser;

        [SetUp]
        public void Init()
        {
            _xmlParser = new XmlParser();
        }

        [TestCase(@"Hi Yvaine, Please create an expense claim for the below. Relevant details are marked up as requested... <expense><cost_centre>DEV002</cost_centre> <total>1024.01</total><payment_method>personal card</payment_method> </expense> From: Ivan Castle Sent: Friday, 16 February 2018 10:32 AM To: Antoine Lloyd <Antoine.Lloyd@example.com> Subject: test Hi Antoine, Please create a reservation at the <vendor>Viaduct Steakhouse</vendor> our <description>development team’s project end celebration dinner</description> on <date>Tuesday 27 April 2017</date>. We expect to arrive around 7.15pm. Approximately 12 people but I’ll confirm exact numbers closer to the day. Regards, Ivan", true)]
        public void GetExpenseTest(string emailContent, bool expectedOutcome)
        {
            var response = _xmlParser.GetExpense(emailContent);
            Assert.AreEqual(response.Success, expectedOutcome);
        }
    }
}