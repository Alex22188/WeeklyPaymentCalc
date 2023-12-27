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
using System.Runtime.Remoting.Messaging;






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












            TextBox1_OnLoad();

            
            

        }



        private void TextBox1_OnLoad()
        {



          

            string[] Path = System.IO.File.ReadAllLines(@"C:\Users\alex4\Downloads\Form1-master\Form1-master\employee.csv");

            string employeeID = "Employee ID:";
            string firstname = "First Name:";
            string lastname = "Last Name:";
            string hourlyrate = "Hourly Rate";
            string taxthreshold = "Tax Threshold";

            PaySlip EmployeeDetailsList = new PaySlip(employeeID, firstname, lastname, hourlyrate, taxthreshold);
            EmployeeDetailsList._EmployeeID = employeeID;
            EmployeeDetailsList._FirstName = firstname;
            EmployeeDetailsList._LastName = lastname;
            EmployeeDetailsList._HourlyRate = hourlyrate;
            EmployeeDetailsList._TaxThreshold = taxthreshold;



            for (int i = 0; i < Path.Length; i++)
            {

                string[] Values = Path[i].Split(',');





                listBox1.Items.Add(employeeID + Values[0]);

                listBox1.Items.Add(firstname + Values[1]);

                listBox1.Items.Add(lastname + Values[2]);

                listBox1.Items.Add(hourlyrate + Values[3]);

                listBox1.Items.Add(taxthreshold + Values[4]);
              

                
            }
        }






        private void button1_Click(object sender, EventArgs e)
        {






            //StreamReader used as reusable component - can use for other files//



            string employeeID = "Employee ID:";
            string firstname = "First Name:";
            string lastname = "Last Name:";
            string hourlyrate = "Hourly Rate";
            string taxthreshold = "Tax Threshold";


            PaySlip EmployeeDetailsList = new PaySlip(employeeID, firstname, lastname, hourlyrate, taxthreshold);
            EmployeeDetailsList._EmployeeID = employeeID;
            EmployeeDetailsList._FirstName = firstname;
            EmployeeDetailsList._LastName = lastname;
            EmployeeDetailsList._HourlyRate = hourlyrate;


















            string hoursworked = "Hours Worked";
           
           
            string grosspay = "Grosspay";
            string tax = "Tax";
            string netpay = "Netpay";
            string superannuation = "Superannuation";



            // PayCalculator class with objects for taxrate-nothreshold//

            PayCalculator payCalculator = new PayCalculator();
    
            payCalculator._GrossPay = grosspay;
            payCalculator._Tax = tax;
            payCalculator._NetPay = netpay;
            payCalculator._Superannuation = superannuation;









            string[] Path = System.IO.File.ReadAllLines(@"C:\Users\alex4\Downloads\Form1-master\Form1-master\employee.csv");










            string Path2 = @"C:\Users\alex4\Downloads\Form1-master\Form1-master\taxrate-nothreshold.csv";
            StreamReader reader1 = null;












            //Method for working out gross pay and net pay//
            //Hourly rate (from PaySlip class) multiplied by hours worked = gross pay
            //Gross pay - tax = net pay//
            //Superannuation = Gross pay (hoursworked * hourlyrate * CsvSuperannuation(0.095)//


            //Have to convert hoursworked values1[0], hourlyrate values[3] and tax values2[3]//
            //to intergers as it won't allow conversion of string to intergers//
            //and values didn't match up with csv data//

            if (File.Exists(Path2))
            {
                reader1 = new StreamReader(Path2);


                while (!reader1.EndOfStream)
                {


                    //Using a for loop to iterate through employee.csv values//

                    for (int i = 0; i < Path.Length; i++)
                    {

                        string[] Values = Path[i].Split(',');




                        var line1 = reader1.ReadLine();
                        var outputData = new List<PayCalculator>();

                       

                        var Values2 = line1.Split(',');

                      
                        int CsvHoursWorked = Convert.ToInt32(Values2[0]);                                               
                        int CsvHourlyRate = Convert.ToInt32(Values[3]);
                        double CsvTax = Convert.ToDouble(Values2[3]);                                                                                                                                                  
                        double CsvSuperannuation = 0.11;

                        textBox2.Text += ($"{employeeID} {Values[0]} {firstname}{Values[1]} {lastname}{Values[2]} {hoursworked} {Values2[0]} {hourlyrate} {Values[3]} {taxthreshold} {Values[4]} {tax} {Values2[3]} {grosspay} = {CsvHoursWorked * CsvHourlyRate} {netpay} = {CsvHoursWorked * CsvHourlyRate - CsvTax} {superannuation} = {CsvHoursWorked * CsvHourlyRate * CsvSuperannuation} \t\t\t\t");

                    }

                    break;
                }




                    string Path3 = @"C:\Users\alex4\Downloads\Form1-master\Form1-master\taxrate-withthreshold.csv";
                    StreamReader reader2 = null;






                    if (File.Exists(Path3))
                    {
                        reader2 = new StreamReader(Path3);


                        while (!reader2.EndOfStream)
                        {

                            for (int i = 0; i < Path.Length; i++)
                            {

                                string[] Values = Path[i].Split(',');




                                var line3 = reader2.ReadLine();

                                var Values3 = line3.Split(',');





                                int CsvHoursWorked1 = Convert.ToInt32(Values3[0]);
                                int CsvHourlyRate1 = Convert.ToInt32(Values[3]);
                                double CsvTax1 = Convert.ToDouble(Values3[3]);
                                double CsvSuperannuation1 = 0.11;
                            



                                textBox2.Text += ($"{employeeID} {Values[0]} {firstname}{Values[1]} {lastname}{Values[2]} {hoursworked}{Values3[0]} {hourlyrate} {Values[3]} {taxthreshold} {Values[4]} {tax} {Values3[3]} {grosspay} = {CsvHoursWorked1 * CsvHourlyRate1} {netpay} = {CsvHoursWorked1 * CsvHourlyRate1 - CsvTax1} {superannuation} = {CsvHoursWorked1  * CsvHourlyRate1 * CsvSuperannuation1} \t\t\t\t");

                             
                          

                            }
                            break;
                        }


                    }
                }
            }

        
                private void button2_Click(object sender, EventArgs e)
            {
               
               
                //This is to write data to the file(TextWriter) and save with button2_Click//
            
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
    




               


            
        

    





