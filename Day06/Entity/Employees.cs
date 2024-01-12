using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Day06.Entity
{
    public class Employees
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string TitleOfCourtesy { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }

        public string Country { get; set; }
        public string HomePhone { get; set; }
        public string Extension { get; set; }
        public string Notes { get; set; }
        public int? ReportsTo { get; set; }
        public string? PhotoPath { get; set; }

        public override string? ToString()
        {
            return $"Employee ID : {EmployeeID} \nEmployee Name : {FirstName} {LastName} \nTitle : {Title} \nTitle Of Courtesy : {TitleOfCourtesy} \nBirthDate : {BirthDate} \nHireDate : {HireDate} \nAddress :{Address} \nCity : {City} \nRegion:{Region} \nPostalCode : {PostalCode} \nCountry : {Country} \nHome Phone : {HomePhone} \nExtension:{Extension} \nNotes: {Notes} \nReport To: {ReportsTo} \nPhoto url: {PhotoPath}\n";
        }
    }
}