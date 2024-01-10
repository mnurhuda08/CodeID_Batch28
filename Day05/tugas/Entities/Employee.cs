using Day05.tugas.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05.tugas.Entities
{
    public class Employee : AbsAddress
    {
        private int employeeID;
        private string? firstName;
        private string? lastName;
        private string? title;
        private string? titleOfCourtesy;
        private DateTime? birthDate;
        private DateTime? hireDate;
        private string? homePhone;
        private int? extension;
        private string? photo;
        private string? notes;
        private int? reportTo;
        private string? photoPath;

        public Employee(int employeeID, string firstName, string lastName, string title, string titleOfCourtesy, DateTime birthDate, DateTime hireDate, string address, string city, string region, string postalCode, string country, string homePhone, int extension, string photo, string notes, int? reportTo, string? photoPath) : base(address, city, region, postalCode, country)
        {
            this.employeeID = employeeID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.title = title;
            this.titleOfCourtesy = titleOfCourtesy;
            this.birthDate = birthDate;
            this.hireDate = hireDate;
            this.homePhone = homePhone;
            this.extension = extension;
            this.photo = photo;
            this.notes = notes;
            this.reportTo = reportTo;
            this.photoPath = photoPath;
        }

        public int EmployeeID { get => employeeID; set => employeeID = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Title { get => title; set => title = value; }
        public string TitleOfCourtesy { get => titleOfCourtesy; set => titleOfCourtesy = value; }
        public DateTime BirthDate { get => birthDate; set => birthDate = value; }
        public DateTime HireDate { get => hireDate; set => hireDate = value; }
        public string HomePhone { get => homePhone; set => homePhone = value; }
        public int Extension { get => extension; set => extension = value; }
        public string? Photo { get => photo; set => photo = value; }
        public string Notes { get => notes; set => notes = value; }
        public int? ReportTo { get => reportTo; set => reportTo = value; }
        public string? PhotoPath { get => photoPath; set => photoPath = value; }

        public override string? ToString()
        {
            return $"Employee ID : {EmployeeID} \nEmployee Name : {FirstName} {LastName} \nTitle : {Title} \nTitle Of Courtesy : {TitleOfCourtesy} \nBirthDate : {BirthDate} \nHireDate : {HireDate} \nHome Phone : {HomePhone} \nExtension:{Extension} \nPhoto :{Photo} \nNotes : {Notes} \nReport To : {ReportTo} \nPhoto url : {PhotoPath}\n";
        }
    }
}