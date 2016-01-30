using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeCompany
{
    public class Customer
    {
        // uses reflection to set property values by a string value
        public object this[string propertyName]
        {
            get { return this.GetType().GetProperty(propertyName).GetValue(this, null); }
            set { this.GetType().GetProperty(propertyName).SetValue(this, value, null); }
        }

        public string lastName { get; set; }
        public string firstName { get; set; }
        public Gender gender { get; set; }
        public Address address { get; set; }
        public string product { get; set; }
        public DateTime dateOfPurchase { get; set; }
       
        // these are all generated properties from the main ones listed above
        public string name { get; set; }    // firstName + lastName
        public string salutation { get; set; }
        public int daysSincePurchase { get; set; }
        public string deadlineToPurchase { get; set; }

        public Customer()
        {

        }

        public void getGeneratedProperties()
        {
            getName();
            getSalutation();
            getDeadlineToPurchase();
        }

        private void getName()
        {
            name = firstName + " " + lastName;
        }

        private void getSalutation()
        {
            salutation = string.Format("{0} {1}", CreateDataSets.salutation[gender], lastName);
        }

        private void getDeadlineToPurchase()
        {
            DateTime now = DateTime.Now;
            daysSincePurchase = (now - dateOfPurchase).Days;
            DateTime deadline;
            if (daysSincePurchase > 365)
            {
                deadline = now.AddDays(30);
            }
            else
            {
                deadline = now.AddDays(60);
            }
            deadlineToPurchase = deadline.ToString("MMMM d, yyyy");

        }

    }


}
