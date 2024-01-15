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
        private int employeeID;
        private string? firstName;
        private string? lastName;
        private string? title;
        private string? titleOfCourtesy;
        private DateTime? birthDate;
        private DateTime? hireDate;
        private string? address;
        private string? city;
        private string? region;
        private string? postalCode;
        private string? country;
        private string? homePhone;
        private string? extension;
        private string? notes;
        private int? reportsTo;
        private string? photoPath;

        public Employees()
        {
        }

        //consturctor for update
        public Employees(int employeeID, string? firstName, string? lastName)
        {
            this.employeeID = employeeID;
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public Employees(int employeeID, string? firstName, string? lastName, string? title, string? titleOfCourtesy, DateTime? birthDate, DateTime? hireDate, string? address, string? city, string? region, string? postalCode, string? country, string? homePhone, string? extension, string? notes, int? reportsTo, string? photoPath)
        {
            this.employeeID = employeeID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.title = title;
            this.titleOfCourtesy = titleOfCourtesy;
            this.birthDate = birthDate;
            this.hireDate = hireDate;
            this.address = address;
            this.city = city;
            this.region = region;
            this.postalCode = postalCode;
            this.country = country;
            this.homePhone = homePhone;
            this.extension = extension;
            this.notes = notes;
            this.reportsTo = reportsTo;
            this.photoPath = photoPath;
        }

        public int EmployeeID { get => employeeID; set => employeeID = value; }
        public string? FirstName { get => firstName; set => firstName = value; }
        public string? LastName { get => lastName; set => lastName = value; }
        public string? Title { get => title; set => title = value; }
        public string? TitleOfCourtesy { get => titleOfCourtesy; set => titleOfCourtesy = value; }
        public DateTime? BirthDate { get => birthDate; set => birthDate = value; }
        public DateTime? HireDate { get => hireDate; set => hireDate = value; }
        public string? Address { get => address; set => address = value; }
        public string? City { get => city; set => city = value; }
        public string? Region { get => region; set => region = value; }
        public string? PostalCode { get => postalCode; set => postalCode = value; }
        public string? Country { get => country; set => country = value; }
        public string? HomePhone { get => homePhone; set => homePhone = value; }
        public string? Extension { get => extension; set => extension = value; }
        public string? Notes { get => notes; set => notes = value; }
        public int? ReportsTo { get => reportsTo; set => reportsTo = value; }
        public string? PhotoPath { get => photoPath; set => photoPath = value; }

        public override string? ToString()
        {
            return $"Employee ID : {EmployeeID} \nEmployee Name : {FirstName} {LastName} \nTitle : {Title} \nTitle Of Courtesy : {TitleOfCourtesy} \nBirthDate : {BirthDate} \nHireDate : {HireDate} \nAddress :{Address} \nCity : {City} \nRegion:{Region} \nPostalCode : {PostalCode} \nCountry : {Country} \nHome Phone : {HomePhone} \nExtension:{Extension} \nNotes: {Notes} \nReport To: {ReportsTo} \nPhoto url: {PhotoPath}\n";
        }
    }
}