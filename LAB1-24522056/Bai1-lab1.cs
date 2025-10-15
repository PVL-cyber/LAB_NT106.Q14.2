using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB1_24522056
{
    public partial class Bai1_lab1 : Form
    {
        public Bai1_lab1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a, b;
            if (!int.TryParse(textBox1.Text, out a))
            {
                MessageBox.Show("Số thứ nhất không hợp lệ!");
                textBox1.Focus();
                return;
            }

            if (!int.TryParse(textBox2.Text, out b))
            {
                MessageBox.Show("Số thứ hai không hợp lệ!");
                textBox2.Focus();
                return;
            }

            int tong = a + b;
            textBox3.Text = tong.ToString();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
