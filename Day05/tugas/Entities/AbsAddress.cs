using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05.tugas.Entities
{
    public abstract class AbsAddress
    {
        private string address;
        private string city;
        private string region;
        private string postalCode;
        private string country;

        protected AbsAddress(string address, string city, string region, string postalCode, string country)
        {
            this.address = address;
            this.city = city;
            this.region = region;
            this.postalCode = postalCode;
            this.country = country;
        }

        public string Address { get => address; set => address = value; }
        public string City { get => city; set => city = value; }
        public string Region { get => region; set => region = value; }
        public string PostalCode { get => postalCode; set => postalCode = value; }
        public string Country { get => country; set => country = value; }

        public override string? ToString()
        {
            return $"Address = {Address}\nCity = {City}\nRegion = {Region}\nPostal Code = {PostalCode}\nCountry = {Country}\n";
        }
    }
}