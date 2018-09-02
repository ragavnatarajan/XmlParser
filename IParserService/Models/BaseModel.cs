using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IParserService.Models
{
    public class BaseModel<T>
    {
        public bool Success { get; set; }
        public string ErrorDescription { get; set; }
        public T Response { get; set; }
    }
}
