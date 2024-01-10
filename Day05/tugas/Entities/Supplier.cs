using Day05.tugas.Implemetation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05.tugas.Entities
{
    public class Supplier
    {
        public int SupplierID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string? Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string? Fax { get; set; }
        public string? Homepage { get; set; }

        public override string? ToString()
        {
            return $"Supplier ID : {SupplierID} \nCompany Name : {CompanyName} \nContact Name : {ContactName} \nContact Title : {ContactTitle} \nAddress :{Address} \nCity : {City} \nRegion:{Region} \nPostalCode : {PostalCode} \nCountry : {Country} \nHome Phone : {Phone} \nFax:{Fax} \nHome Page:{Homepage} \n";
        }
    }
}