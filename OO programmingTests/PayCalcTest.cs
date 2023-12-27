using Microsoft.VisualStudio.TestTools.UnitTesting;
using OO_programming;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OO_programming.Tests
{




    [TestClass]







    public class PayCalculator
    {

        public string _HoursWorked { get; set; }
        public string _GrossPay { get; set; }

        public string _Tax { get; set; }
        public string _NetPay { get; set; }

        public string _Superannuation { get; set; }



        public PayCalculator()
        {



        }





        public class PayCalculatorNoThreshold : PayCalculator
        {

            public PayCalculatorNoThreshold(string hoursworked, string grosspay, string tax, string netpay, string superannuation)
            {
                _HoursWorked = hoursworked;

                _GrossPay = grosspay;
                _Tax = tax;
                _NetPay = netpay;
                _Superannuation = superannuation;


            }



            [TestMethod]

            public void PayCalcTest1()
            {




                var Path2 = @"C:\Users\alex4\Downloads\Form1-master\Form1-master\taxrate-nothreshold.csv";


                var payCalculator = new PayCalculator();




                string hoursworked = Convert.ToString(Path2[0]);
                string grosspay = Convert.ToString(Path2[3]);
                string tax = Convert.ToString(Path2[4]);
                string netpay = Convert.ToString(Path2[5]);
                string superannuation = Convert.ToString(Path2[6]);


                payCalculator._HoursWorked = hoursworked;
                payCalculator._GrossPay = grosspay;
                payCalculator._Tax = tax;
                payCalculator._NetPay = netpay;
                payCalculator._Superannuation = superannuation;


            }



            [TestClass]


            public class PayCalculator
            {

                public string _HoursWorked { get; set; }




                public string _GrossPay { get; set; }

                public string _Tax { get; set; }
                public string _NetPay { get; set; }

                public string _Superannuation { get; set; }





                public class PayCalculatorWithThreshold : PayCalculator
                {

                    public PayCalculatorWithThreshold(string hoursworked, string grosspay, string tax, string netpay, string superannuation)
                    {
                        _HoursWorked = hoursworked;

                        _GrossPay = grosspay;
                        _Tax = tax;
                        _NetPay = netpay;
                        _Superannuation = superannuation;


                    }



                    [TestMethod]

                    public void PayCalcTest2()
                    {

                        var Path3 = @"C:\Users\alex4\Downloads\Form1-master\Form1-master\taxrate-withthreshold.csv";


                        var payCalculator = new PayCalculator();


                        string hoursworked = Convert.ToString(Path3[0]);
                        string grosspay = Convert.ToString(Path3[3]);
                        string tax = Convert.ToString(Path3[4]);
                        string netpay = Convert.ToString(Path3[5]);
                        string superannuation = Convert.ToString(Path3[6]);



                        payCalculator._HoursWorked = hoursworked;
                        payCalculator._GrossPay = grosspay;
                        payCalculator._Tax = tax;
                        payCalculator._NetPay = netpay;
                        payCalculator._Superannuation = superannuation;



                    }







                }

            }
        }
    }
}



    































