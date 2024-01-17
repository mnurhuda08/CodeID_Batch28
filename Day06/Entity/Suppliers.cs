using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Day06.Entity
{
    internal class Suppliers : Company
    {
        private int supplierID;
        private string phone;
        private string? fax;
        private string? homePage;

        public Suppliers()
        {
        }

        public Suppliers(string companyName, string contactName, string contactTitle, int supplierID, string phone, string? fax, string? homePage) : base(companyName, contactName, contactTitle)
        {
            this.supplierID = supplierID;
            this.phone = phone;
            this.fax = fax;
            this.homePage = homePage;
        }

        public int SupplierID { get => supplierID; set => supplierID = value; }
        public string Phone { get => phone; set => phone = value; }
        public string? Fax { get => fax; set => fax = value; }
        public string? HomePage { get => homePage; set => homePage = value; }

        public override string? ToString()
        {
            return $"Supplier ID : {SupplierID} \nCompany Name : {CompanyName} \nContact Name : {ContactName} \nContact Title : {ContactTitle} \nAddress :{Address} \nCity : {City} \nRegion:{Region} \nPostalCode : {PostalCode} \nCountry : {Country} \nHome Phone : {Phone} \nFax:{Fax} \nHome Page:{HomePage} \n";
        }
    }
}