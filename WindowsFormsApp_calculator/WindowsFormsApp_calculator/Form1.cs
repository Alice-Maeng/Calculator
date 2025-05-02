using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox_result.Text += "1";
            int number = int.Parse(textBox_result.Text);
            textBox_result.Text = number.ToString();

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox_result.Text += "2";
            int number = int.Parse(textBox_result.Text);
            textBox_result.Text = number.ToString();
        }

        private void button_plus_Click(object sender, EventArgs e)
        {
            textBox_result.Text += "+";
 
        }

        private void button_eq_Click(object sender, EventArgs e)
        {

        }
    }
}
