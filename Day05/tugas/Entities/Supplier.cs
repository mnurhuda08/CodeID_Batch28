using Day05.tugas.Implemetation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05.tugas.Entities
{
    public class Supplier : AbsAddress
    {
        private int supplierID;
        private string? companyName;
        private string? contactName;
        private string? contactTitle;
        private string? phone;
        private string? fax;
        private string? homePage;

        public Supplier(int supplierID, string? companyName, string? contactName, string? contactTitle, string address, string city, string region, string postalCode, string country, string? phone, string? fax, string? homePage) : base(address, city, region, postalCode, country)
        {
            this.supplierID = supplierID;
            this.companyName = companyName;
            this.contactName = contactName;
            this.contactTitle = contactTitle;
            this.phone = phone;
            this.fax = fax;
            this.homePage = homePage;
            this.supplierID = supplierID;
            this.companyName = companyName;
            this.contactName = contactName;
            this.contactTitle = contactTitle;
            this.phone = phone;
            this.fax = fax;
            this.homePage = homePage;
        }

        public int SupplierID { get => supplierID; set => supplierID = value; }
        public string CompanyName { get => companyName; set => companyName = value; }
        public string ContactName { get => contactName; set => contactName = value; }
        public string ContactTitle { get => contactTitle; set => contactTitle = value; }
        public string Phone { get => phone; set => phone = value; }
        public string? Fax { get => fax; set => fax = value; }
        public string? HomePage { get => homePage; set => homePage = value; }

        public override string? ToString()
        {
            return $"Supplier ID : {SupplierID} \nCompany Name : {CompanyName} \nContact Name : {ContactName} \nContact Title : {ContactTitle} \nHome Phone : {Phone} \nFax:{Fax} \nHome Page:{HomePage} \n";
        }
    }
}