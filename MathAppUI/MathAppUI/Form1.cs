using System;
using System.Windows.Forms;

namespace TestAppUI
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }

        double value1,value2,result;
        string a,b,c;


        private void button1_Click(object sender, EventArgs e)
        {
            result = value1 + value2;
            label1.Text = result.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = String.Empty;
            richTextBox2.Text = String.Empty;
            richTextBox3.Text = String.Empty;
            richTextBox4.Text = String.Empty;
            richTextBox5.Text = String.Empty;

            label1.Text = "0";
            label3.Text = "X1:";
            label4.Text = "X2:";

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            result = value1 / value2;
            label1.Text = result.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            result = value1 * value2;
            label1.Text = result.ToString();
        }

        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {
                b = richTextBox4.Text;
        }

        private void richTextBox5_TextChanged(object sender, EventArgs e)
        {
                c = richTextBox5.Text;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            double d1 = double.Parse(b) * double.Parse(b);
            double d2 = - 4 * double.Parse(a) * double.Parse(c);
            double d = d1 + d2;
            double x1, x2;

            if (d >= 0)
            {
                x1 = (-(double.Parse(b)) + Math.Sqrt(d)) / (2 * double.Parse(a));
                x2 = (-(double.Parse(b)) - Math.Sqrt(d)) / (2 * double.Parse(a));

                label3.Text = "X1: " + x1.ToString();
                label4.Text = "X2: " + x2.ToString();
            }
            else
            {
                label3.Text = "no solution";
                label4.Text = "no solution";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            result = value1 - value2;
            label1.Text = result.ToString();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Text != String.Empty)
            {
                value1 = double.Parse(richTextBox1.Text);
            }
            else
            {
                value1 = 0;
            }
            
        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {
                a = richTextBox3.Text;
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Text != String.Empty)
            {
                value2 = double.Parse(richTextBox2.Text);
            }
            else
            {
                value2 = 0;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
