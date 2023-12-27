using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OO_programming
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();



        }

        private void Login_buttonClick(object sender, EventArgs e)
        {
            string Username = "Admin";
            string Password = "Admin";




            if (textBox1.Text == Username && textBox2.Text == Password)
            {

                MessageBox.Show("Welcome to Coaster Manufacturing employee portal!");

                Form1 form1 = new Form1();
                form1.Show();

                
                
                




            }

            else
            {
                {
                    MessageBox.Show("Invalid login. Please try again");
                }

            }
        }




    }


}

    

