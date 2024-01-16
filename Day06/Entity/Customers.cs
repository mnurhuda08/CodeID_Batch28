using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Day06.Entity
{
    public class Customers
    {
        private string customerID;
        private string companyName;
        private string contactName;
        private string contactTitle;
        private string address;
        private string city;
        private string region;
        private string postalCode;
        private string country;
        private string phone;
        private string fax;

        public Customers()
        {
        }

        public Customers(string customerID, string contactName)
        {
            this.customerID = customerID;
            this.contactName = contactName;
        }

        public Customers(string customerID, string companyName, string contactName, string contactTitle, string address, string city, string region, string postalCode, string country, string phone, string fax)
        {
            this.customerID = customerID;
            this.companyName = companyName;
            this.contactName = contactName;
            this.contactTitle = contactTitle;
            this.address = address;
            this.city = city;
            this.region = region;
            this.postalCode = postalCode;
            this.country = country;
            this.phone = phone;
            this.fax = fax;
        }

        public string CustomerID { get => customerID; set => customerID = value; }
        public string CompanyName { get => companyName; set => companyName = value; }
        public string ContactName { get => contactName; set => contactName = value; }
        public string ContactTitle { get => contactTitle; set => contactTitle = value; }
        public string Address { get => address; set => address = value; }
        public string City { get => city; set => city = value; }
        public string Region { get => region; set => region = value; }
        public string PostalCode { get => postalCode; set => postalCode = value; }
        public string Country { get => country; set => country = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Fax { get => fax; set => fax = value; }

        public override string? ToString()
        {
            return $"Customer ID : {CustomerID} \nCompany Name : {CompanyName} \nContact Name : {ContactName} \nContact Title : {ContactTitle} \nAddress :{Address} \nCity : {City} \nRegion:{Region} \nPostalCode : {PostalCode} \nCountry : {Country} \nHome Phone : {Phone} \nFax:{Fax} \n";
        }
    }
}