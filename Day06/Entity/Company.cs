using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day06.Entity
{
    internal abstract class Company : Addresses
    {
        private string companyName;
        private string contactName;
        private string contactTitle;

        protected Company()
        {
        }

        protected Company(string companyName, string contactName, string contactTitle)
        {
            this.companyName = companyName;
            this.contactName = contactName;
            this.contactTitle = contactTitle;
        }

        protected Company(int addressID, string address, string city, string region, string postalCode, string country, string companyName, string contactName, string contactTitle) : base(addressID, address, city, region, postalCode, country)
        {
            this.companyName = companyName;
            this.contactName = contactName;
            this.contactTitle = contactTitle;
        }

        public string CompanyName { get => companyName; set => companyName = value; }
        public string ContactName { get => contactName; set => contactName = value; }
        public string ContactTitle { get => contactTitle; set => contactTitle = value; }
    }
}