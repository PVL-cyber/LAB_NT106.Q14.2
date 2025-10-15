using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LAB1_24522056
{
    public partial class Lab1_bai5 : Form
    {
        // Dữ liệu phim và giá
        Dictionary<string, decimal> giaPhim = new Dictionary<string, decimal>()
        {
            {"Đào, phở và piano", 45000 },
            {"Mai", 100000 },
            {"Gặp lại chị bầu", 70000 },
            {"Tarot", 90000 }
        };

        // Phim nào chiếu ở phòng nào
        Dictionary<string, int[]> phongPhim = new Dictionary<string, int[]>()
        {
            {"Đào, phở và piano", new int[]{1,2,3}},
            {"Mai", new int[]{2,3}},
            {"Gặp lại chị bầu", new int[]{1}},
            {"Tarot", new int[]{3}}
        };

        // Ghế và hệ số giá
        Dictionary<string, decimal> heSoGhe = new Dictionary<string, decimal>()
        {
            {"A1",0.25m},{"A5",0.25m},{"C1",0.25m},{"C5",0.25m},
            {"B2",2},{"B3",2},{"B4",2}
        };

        public Lab1_bai5()
        {
            InitializeComponent();
        }

        // Khi load form
        private void Lab1_bai5_Load(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(giaPhim.Keys.ToArray());
            comboBox1.SelectedIndex = 0;

            comboBox2.Items.AddRange(new string[] { "1", "2", "3" });
            comboBox2.SelectedIndex = 0;
        }

        // Hiển thị ghế theo phim & phòng
        private void HienThiGhe()
        {
            checkedListBox1.Items.Clear();

            if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null)
                return;

            string phim = comboBox1.SelectedItem.ToString();
            int phong = int.Parse(comboBox2.SelectedItem.ToString());

            if (!phongPhim[phim].Contains(phong))
            {
                MessageBox.Show($"Phim {phim} không chiếu ở phòng {phong}");
                return;
            }

            string[] rows = { "A", "B", "C" };
            foreach (var r in rows)
            {
                for (int i = 1; i <= 5; i++)
                {
                    checkedListBox1.Items.Add(r + i);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            HienThiGhe();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            HienThiGhe();
        }

        // Nút Tính tiền
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null)
                return;

            string phim = comboBox1.SelectedItem.ToString();
            decimal giaCoBan = giaPhim[phim];

            decimal tong = 0;
            foreach (var ghe in checkedListBox1.CheckedItems)
            {
                string g = ghe.ToString();
                decimal hs = heSoGhe.ContainsKey(g) ? heSoGhe[g] : 1;
                tong += giaCoBan * hs;
            }

            label1.Text = $"Tổng tiền: {tong:n0} đ";
        }

        // Nút Lưu
        private void button2_Click(object sender, EventArgs e)
        {
            string tenKH = textBox1.Text.Trim();
            if (tenKH == "")
            {
                MessageBox.Show("Nhập tên khách hàng!");
                return;
            }

            string phim = comboBox1.SelectedItem.ToString();
            string phong = comboBox2.SelectedItem.ToString();

            foreach (var ghe in checkedListBox1.CheckedItems)
            {
                listBox1.Items.Add($"{tenKH} - {phim} - Phòng {phong} - Ghế {ghe}");
            }

            checkedListBox1.ClearSelected();
        }

        // Nút Xóa
        private void button3_Click(object sender, EventArgs e)
        {
            while (listBox1.SelectedItems.Count > 0)
            {
                listBox1.Items.Remove(listBox1.SelectedItems[0]);
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }
    }
}
