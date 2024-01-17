using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WeeklyTestDapperDbContext.Entity
{
    internal class Supplier
    {
        private int supplierID;
        private string companyName;
        private string contactName;
        private string contactTitle;
        private string phone;

        public Supplier()
        {
        }

        public Supplier(int supplierID, string companyName, string contactName, string contactTitle, string phone)
        {
            this.supplierID = supplierID;
            this.companyName = companyName;
            this.contactName = contactName;
            this.contactTitle = contactTitle;
            this.phone = phone;
        }

        public int SupplierID { get => supplierID; set => supplierID = value; }
        public string CompanyName { get => companyName; set => companyName = value; }
        public string ContactName { get => contactName; set => contactName = value; }
        public string ContactTitle { get => contactTitle; set => contactTitle = value; }
        public string Phone { get => phone; set => phone = value; }

        public override string? ToString()
        {
            return $"Supplier ID : {SupplierID} \nCompany Name : {CompanyName} \nContact Name : {ContactName} \nContact Title : {ContactTitle} \nPhone : {Phone}\n";
        }
    }
}