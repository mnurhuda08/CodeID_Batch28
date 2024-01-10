using Day05.tugas.Implemetation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05.tugas.Entities
{
    public class Customer : AbsAddress
    {
        private int customerID;
        private string companyName;
        private string contactName;
        private string contactTitle;
        private string phone;
        private string? fax;

        public Customer(int customerID, string companyName, string contactName, string contactTitle, string address, string city, string region, string postalCode, string country, string phone, string? fax) : base(address, city, region, postalCode, country)
        {
            this.customerID = customerID;
            this.companyName = companyName;
            this.contactName = contactName;
            this.contactTitle = contactTitle;
            this.phone = phone;
            this.fax = fax;
            this.customerID = customerID;
            this.companyName = companyName;
            this.contactName = contactName;
            this.contactTitle = contactTitle;
            this.phone = phone;
            this.fax = fax;
        }

        public int CustomerID { get => customerID; set => customerID = value; }
        public string CompanyName { get => companyName; set => companyName = value; }
        public string ContactName { get => contactName; set => contactName = value; }
        public string ContactTitle { get => contactTitle; set => contactTitle = value; }
        public string Phone { get => phone; set => phone = value; }
        public string? Fax { get => fax; set => fax = value; }

        public override string? ToString()
        {
            return $"Customer ID : {CustomerID} \nCompany Name : {CompanyName} \nContact Name : {ContactName} \nContact Title : {ContactTitle} \nHome Phone : {Phone} \nFax:{Fax} \n";
        }
    }
}