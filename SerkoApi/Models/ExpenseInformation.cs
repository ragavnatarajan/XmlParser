using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SerkoApi.Models
{
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class ExpenseInformation
    {

        private string costcentreField;

        private ushort totalField;
        //private string payment_methodField;

        /// <remarks/>
        public string costcentre
        {
            get
            {
                return this.costcentreField;
            }
            set
            {
                this.costcentreField = value;
            }
        }

        /// <remarks/>
        public ushort total
        {
            get
            {
                return this.totalField;
            }
            set
            {
                this.totalField = value;
            }
        }
        //public string payment_method
        //{
        //    get
        //    {
        //        return this.payment_methodField;
        //    }
        //    set
        //    {
        //        this.payment_methodField = value;
        //    }
        //}
    }
}