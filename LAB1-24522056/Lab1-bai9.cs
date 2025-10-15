using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LAB1_24522056
{
    public partial class Lab1_bai9 : Form
    {
        private List<string> danhSachMon = new List<string>()
        {
            "Bún riêu",
            "Bún thịt nướng",
            "Cơm tấm sườn trứng",
            "Phở",
            "Gỏi cuốn"
        };

        private Random rand = new Random();

        public Lab1_bai9()
        {
            InitializeComponent();
            HienThiDanhSach();
        }

        // Hiển thị danh sách món ăn
        private void HienThiDanhSach()
        {
            listBox1.Items.Clear();
            foreach (var mon in danhSachMon)
            {
                listBox1.Items.Add(mon);
            }
        }

        // Nút Thêm
        private void button1_Click(object sender, EventArgs e)
        {
            string monMoi = textBox1.Text.Trim();
            if (!string.IsNullOrEmpty(monMoi))
            {
                danhSachMon.Add(monMoi);
                HienThiDanhSach();
                textBox1.Clear();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên món ăn!");
            }
        }

        // Nút Tìm món ăn (random)
        private void button2_Click(object sender, EventArgs e)
        {
            if (danhSachMon.Count == 0)
            {
                textBox2.Text = "Danh sách rỗng!";
                return;
            }

            int index = rand.Next(danhSachMon.Count);
            textBox2.Text = danhSachMon[index];
        }

        // Nút Xóa
        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        // Nút Thoát
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
