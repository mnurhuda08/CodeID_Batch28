using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day06.Entity
{
    internal abstract class Addresses
    {
        private int addressID;
        private string address;
        private string city;
        private string region;
        private string postalCode;
        private string country;

        protected Addresses()
        {
        }

        protected Addresses(int addressID, string address, string city, string region, string postalCode, string country)
        {
            this.addressID = addressID;
            this.address = address;
            this.city = city;
            this.region = region;
            this.postalCode = postalCode;
            this.country = country;
            this.addressID = addressID;
        }

        public int AddressID { get => addressID; set => addressID = value; }
        public string Address { get => address; set => address = value; }
        public string City { get => city; set => city = value; }
        public string Region { get => region; set => region = value; }
        public string PostalCode { get => postalCode; set => postalCode = value; }
        public string Country { get => country; set => country = value; }

        public override string? ToString()
        {
            return $"Address :{Address} \nCity : {City} \nRegion:{Region} \nPostalCode : {PostalCode} \nCountry : {Country} \n";
        }
    }
}