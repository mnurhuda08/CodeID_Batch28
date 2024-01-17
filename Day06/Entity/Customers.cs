using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Day06.Entity
{
    internal class Customers : Company
    {
        private string customerID;
        private string phone;
        private string fax;

        public Customers()
        {
        }

        public Customers(int v, string companyName, string contactName, string contactTitle, string customerID, string phone, string fax, string v1) : base(companyName, contactName, contactTitle)
        {
            this.customerID = customerID;
            this.phone = phone;
            this.fax = fax;
        }

        public string CustomerID { get => customerID; set => customerID = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Fax { get => fax; set => fax = value; }

        public override string? ToString()
        {
            return $"Customer ID : {CustomerID} \nCompany Name : {CompanyName} \nContact Name : {ContactName} \nContact Title : {ContactTitle} \nHome Phone : {Phone} \nFax:{Fax} \n";
        }
    }
}