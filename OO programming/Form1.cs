using System;
using System.Windows.Forms;
using System.Collections.Generic;

using System.IO;
using System.Globalization;
using CsvHelper;


using System.Security.Cryptography.X509Certificates;
using System.Linq;

using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using System.Net.Configuration;
using System.Net.NetworkInformation;
using ServiceStack;
using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;






namespace OO_programming
{
    public partial class Form1 : Form
    {









        public Form1()
        {
            InitializeComponent();

            // Add code below to complete the implementation to populate the listBox
            // by reading the employee.csv file into a List of PaySlip objects, then binding this to the ListBox.
            // CSV file format: <employee ID>, <first name>, <last name>, <hourly rate>,<taxthreshold>












            TextBox1_Load();





        }





        private void TextBox1_Load()
        {

            string Path = @"C:\Users\alex4\Downloads\employee.csv";
            StreamReader reader = null;

            string employeeID = "Employee ID";
            string firstname = "First Name";
            string lastname = "Last Name";
            int hourlyrate = Convert.ToInt32(Path[3]);
            int taxthreshold = Convert.ToInt32(Path[4]);



            PaySlip EmployeeDetailList = new PaySlip(employeeID, firstname, lastname, hourlyrate, taxthreshold);
            EmployeeDetailList._EmployeeID = employeeID;
            EmployeeDetailList._FirstName = firstname;
            EmployeeDetailList._LastName = lastname;
            EmployeeDetailList._HourlyRate = hourlyrate;
            EmployeeDetailList._TaxThreshold = taxthreshold;



            if (File.Exists(Path))
            {
                reader = new StreamReader(Path);

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var Values = line.Split(',');
                    listBox1.Items.Add(employeeID);
                    listBox1.Items.Add(Values[0]);
                    listBox1.Items.Add(firstname);
                    listBox1.Items.Add(Values[1]);
                    listBox1.Items.Add(lastname);
                    listBox1.Items.Add(Values[2]);
                    listBox1.Items.Add(hourlyrate);
                    listBox1.Items.Add(Values[3]);
                    listBox1.Items.Add(taxthreshold);
                    listBox1.Items.Add(Values[4]);





                }



            }



        }











        private void button1_Click(object sender, EventArgs e)
        {



            //StreamReader used as reusable component - can use for other files//


            string Path = @"C:\Users\alex4\Downloads\employee.csv";
            StreamReader reader = null;

            string employeeID = "Employee ID";
            string firstname = "First Name";
            string lastname = "Last Name";



            if (File.Exists(Path))
            {


                reader = new StreamReader(Path);

                while (!reader.EndOfStream)
                {



                    var line = reader.ReadLine();

                    var Values = line.Split(',');




                    string Path2 = @"C:\Users\alex4\Downloads\Form1-master\Form1-master\taxrate-nothreshold.csv";
                    StreamReader reader1 = null;

                    // PayCalculator class with objects for taxrate-nothreshold//

                    // PayCalculator class with objects for taxrate-nothreshold//
                    int hoursworked = Convert.ToInt32(Path2[0]);
                    int hourlyrate = Convert.ToInt32(Path2[1]);
                    string taxthreshold = "Tax Theshold";
                    string grosspay = "Gross Pay";
                    string tax = "Tax";
                    string netpay = "Net Pay";
                    string superannuation = "Superannuation";

                    // PayCalculator class with objects for taxrate-nothreshold//




                    reader1 = new StreamReader(Path2);

                    if (File.Exists(Path2))
                    {



                        while (!reader1.EndOfStream)
                        {


                            var line1 = reader1.ReadLine();
                            var Values1 = line1.Split(',');



                            //Method for working out gross pay and net pay//
                            //Hourly rate multiplied by hours worked = gross pay//
                            //Gross pay - tax = net pay//

                            //HoursWorked and HourlyRate and tax as a double converted into intergers as//
                            //csv data could not be converted from file//



                            int CsvDataHoursWorked = Convert.ToInt32(Values1[0]);
                            int CsvDataHourlyRate = Convert.ToInt32(Values1[1]);
                            double CsvTaxData = Convert.ToDouble(Values1[3]);
                            double superannuationRate = 0.095;


                            textBox2.Text += ($"{employeeID} {firstname} {lastname} Hours Worked: {Values1[0]} Hourly Rate: {hourlyrate} {Values1[1]} {taxthreshold} {Values1[2]} {grosspay} = {CsvDataHoursWorked * CsvDataHourlyRate} {tax} {Values1[3]} {netpay} = {CsvDataHoursWorked * CsvDataHourlyRate - CsvTaxData} {superannuation} = {CsvDataHoursWorked * superannuationRate}\t\t\t\t\t");



                        }





                        string Path3 = @"C:\Users\alex4\Downloads\Form1-master\Form1-master\taxrate-withthreshold.csv";
                        StreamReader reader2 = null;



                        if (File.Exists(Path3))
                        {
                            reader2 = new StreamReader(Path3);


                            while (!reader2.EndOfStream)
                            {

                                var line2 = reader2.ReadLine();

                                var Values2 = line2.Split(',');



                                int CsvDataHoursWorked1 = Convert.ToInt32(Values2[0]);
                                int CsvDataHourlyRate1 = Convert.ToInt32(Values2[1]);
                                double CsvTaxData1 = Convert.ToDouble(Values2[3]);
                                double superannuationRate1 = 0.095;



                                textBox2.Text += ($"Hours Worked: {hoursworked} {Values2[0]} Hourly Rate: {hourlyrate} {Values2[1]} {taxthreshold} {Values2[2]} {grosspay} = {CsvDataHoursWorked1 * CsvDataHourlyRate1} {tax} {Values2[3]} {netpay} = {CsvDataHoursWorked1 * CsvDataHourlyRate1 - CsvTaxData1} {superannuation} {CsvDataHoursWorked1 * CsvDataHourlyRate1 * superannuationRate1}\t\t\t\t\t");

                            }

                        }

                    }

                }

            }
        }




        private void button2_Click(object sender, EventArgs e)
        {
            // Add code below to complete the implementation for saving the
            // calculated payment data into a csv file.

            // File naming convention: Pay_<full name>_<datetimenow>.csv
            // Data fields expected - EmployeeId, Full Name, Hours Worked, Hourly Rate, Tax Threshold, Gross Pay, Tax, Net Pay, Superannuation

            TextWriter writer = new StreamWriter(@"C:\Users\alex4\Downloads\Form1-master\Form1-master\OO programming\Pay-EmployeeID-Fullname-{DateTImeNow}.csv");

            writer.WriteLine(textBox2.Text);
            writer.Close();


            if (writer != null)
            {


                MessageBox.Show("File saved!");

            }

            else
            {

                MessageBox.Show("Save failed!");


            }



        }

     
    }
}



               


            
        

    





