using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace SerkoApi.Utilities
{
    public class Utility
    {
        public static S Deserialize<S>(string content)
        {
            var serializer = new XmlSerializer(typeof(S));
            object returnData;
            using (TextReader reader = new StringReader(content))
            {
                returnData = serializer.Deserialize(reader);
            }
            return (S)returnData;
        }
    }
}