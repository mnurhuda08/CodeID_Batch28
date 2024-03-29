﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05.tugas.Entities
{
    public class EmployeeOld : AbsAddressOld
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string TitleOfCourtesy { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public string HomePhone { get; set; }
        public int Extension { get; set; }
        public string? Photo { get; set; }
        public string Notes { get; set; }
        public int? ReportTo { get; set; }
        public string? PhotoPath { get; set; }

        public override string? ToString()
        {
            return $"Employee ID : {EmployeeID} \nEmployee Name : {FirstName} {LastName} \nTitle : {Title} \nTitle Of Courtesy : {TitleOfCourtesy} \nBirthDate : {BirthDate} \nHireDate : {HireDate} \nAddress :{Address} \nCity : {City} \nRegion:{Region} \nPostalCode : {PostalCode} \nCountry : {Country} \nHome Phone : {HomePhone} \nExtension:{Extension} \nPhoto :{Photo} \nNotes : {Notes} \nReport To : {ReportTo} \nPhoto url : {PhotoPath}\n";
        }
    }
}