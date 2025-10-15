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
    public partial class Lab1_bai3 : Form
    {
        public Lab1_bai3()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_FontChanged(object sender, EventArgs e)
        {

        }

        private void button3_FontChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy số người dùng nhập
                int so = int.Parse(textBox1.Text.Trim());

                // Kiểm tra điều kiện
                if (so < 0 || so > 9)
                {
                    MessageBox.Show("Vui lòng nhập số nguyên từ 0 đến 9!",
                                    "Lỗi nhập liệu",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                // Mảng đọc số
                string[] docSo = { "Không", "Một", "Hai", "Ba", "Bốn", "Năm", "Sáu", "Bảy", "Tám", "Chín" };

                // Hiển thị kết quả
                textBox2.Text = docSo[so];
            }
            catch
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng số nguyên!",
                                "Lỗi nhập liệu",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox1.Focus(); // Đưa con trỏ về ô nhập
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn thoát không?",
                                                  "Xác nhận thoát",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                this.Close();
        }

    }
}
