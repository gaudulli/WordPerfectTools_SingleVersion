using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeCompany
{
    public class Company
    {

        // uses reflection to set property values by a string value
        public object this[string propertyName]
        {
            get { return this.GetType().GetProperty(propertyName).GetValue(this, null); }
            set { this.GetType().GetProperty(propertyName).SetValue(this, value, null); }
        }

        public string name { get; set; }
        public Address address { get; set; }
        public Product product { get; set; }
        public string motivationalTool { get; set; }

        public string masthead { get; set; }
        public string date { get; set; }
        public string enforcementOfficer { get; set; }
        public string salesOfficer { get; set; }

        public string salesOfficerSenderInfo { get; set; }
        public string enforcementOfficerSenderInfo { get; set; }

        public Company(string _name, Address _address, Product _product, string tool,
            string _salesOfficer, string _enforcementOfficer)
        {

            name = _name;
            address = _address;
            product = _product;
            motivationalTool = tool;
            date = DateTime.Now.ToString("MMMM d, yyyy");
            masthead = getMasthead();
            salesOfficer = _salesOfficer;
            enforcementOfficer = _enforcementOfficer;
            salesOfficerSenderInfo = getSenderInfo(salesOfficer, "Sales Officer");
            enforcementOfficerSenderInfo = getSenderInfo(enforcementOfficer, "Enforcement Officer");

        }

        private string getMasthead()
        {
            return string.Format("{0} Corporation\n{1}", name, address.ToString());  
        }

        private string getSenderInfo(string officerName, string title)
        {
            return string.Format("{0}\n{1}\n{2} Corporation", officerName, title, name);
        }
    }

    

    

}
