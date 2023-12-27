﻿using CsvHelper.Configuration.Attributes;
using System;
using System.Windows.Forms;
using CsvHelper;
using System.IO;
using static System.Windows.Forms.LinkLabel;
using System.Security.Policy;
using OO_programming;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace OO_programming
{

    static class Program
    {





        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());









        }
    }

    /// <summary>
    /// Class a capture details accociated with an employee's pay slip record
    /// </summary>




    public class PaySlip
    {


        public string _EmployeeID { get; set; }


        public string _FirstName { get; set; }


        public string _LastName { get; set; }


        public int _HourlyRate { get; set; }

        public int _TaxThreshold { get; set; }



        public PaySlip(string employeeID, string firstname, string lastname, int hourlyrate, int taxthreshold)
        {


            _EmployeeID = employeeID;
            _FirstName = firstname;
            _LastName = lastname;
            _HourlyRate = hourlyrate;
            _TaxThreshold = taxthreshold;










        }





    }
















    /// <summary>
    /// Base class to hold all Pay calculation functions
    /// Default class behaviour is tax calculated with tax threshold applied
    /// </summary>
    public class PayCalculator
    {
        public int _HoursWorked { get; set; }

        public int _HourlyRate { get; set; }

        public string _TaxThreshold { get; set; }


        public string _GrossPay { get; set; }

        public string _Tax { get; set; }
        public string _NetPay { get; set; }

        public string _Superannuation { get; set; }




    }





    /// <summary>
    /// Extends PayCalculator class handling No tax threshold
    /// </summary>
    public class PayCalculatorNoThreshold : PayCalculator
    {

        public PayCalculatorNoThreshold(int hoursworked, int hourlyrate, string taxthreshold, string grosspay, string tax, string netpay, string superannuation)
        {
            _HoursWorked = hoursworked;
            _HourlyRate = hourlyrate;
            _TaxThreshold = taxthreshold;
            _GrossPay = grosspay;
            _Tax = tax;
            _NetPay = netpay;
            _Superannuation = superannuation;


        }




        /// <summary>
        /// Extends PayCalculator class handling With tax threshold
        /// </summary>
        public class PayCalculatorWithThreshold : PayCalculator
        {

            public PayCalculatorWithThreshold(int hoursworked, int hourlyrate, string taxthreshold, string grosspay, string tax, string netpay, string superannuation)
            {

                _HoursWorked = hoursworked;
                _HourlyRate = hourlyrate;
                _TaxThreshold = taxthreshold;
                _GrossPay = grosspay;
                _Tax = tax;
                _NetPay = netpay;
                _Superannuation = superannuation;



            }


        }

    }
}


    
