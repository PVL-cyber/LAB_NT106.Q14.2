using System;
using System.Windows.Forms;

namespace LAB1_24522056
{
    public partial class Lab1_bai7 : Form
    {
        public Lab1_bai7()
        {
            InitializeComponent();
        }

        private void Lab1_bai7_Load(object sender, EventArgs e)
        {
            // Khởi tạo mặc định (nếu cần)
            label1.Text = "Cung hoàng đạo: ";
        }

        // Hàm xác định cung hoàng đạo theo ngày và tháng (switch-case)
        private string GetZodiac(int day, int month)
        {
            switch (month)
            {
                case 1:  // Jan
                    return (day >= 21) ? "Bảo Bình" : "Ma Kết";
                case 2:  // Feb
                    return (day >= 20) ? "Song Ngư" : "Bảo Bình";
                case 3:  // Mar
                    return (day >= 21) ? "Bạch Dương" : "Song Ngư";
                case 4:  // Apr
                    return (day >= 21) ? "Kim Ngưu" : "Bạch Dương";
                case 5:  // May
                    return (day >= 22) ? "Song Tử" : "Kim Ngưu";
                case 6:  // Jun
                    return (day >= 22) ? "Cự Giải" : "Song Tử";
                case 7:  // Jul
                    return (day >= 23) ? "Sư Tử" : "Cự Giải";
                case 8:  // Aug
                    return (day >= 23) ? "Xử Nữ" : "Sư Tử";
                case 9:  // Sep
                    return (day >= 24) ? "Thiên Bình" : "Xử Nữ";
                case 10: // Oct
                    return (day >= 24) ? "Thần Nông" : "Thiên Bình";
                case 11: // Nov
                    return (day >= 23) ? "Nhân Mã" : "Thần Nông";
                case 12: // Dec
                    return (day >= 22) ? "Ma Kết" : "Nhân Mã";
                default:
                    return "Không xác định";
            }
        }

        // ================== NÚT: Xác định cung ==================
        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text.Trim(), out int day) ||
                !int.TryParse(textBox2.Text.Trim(), out int month) ||
                !int.TryParse(textBox3.Text.Trim(), out int year))
            {
                MessageBox.Show("Vui lòng nhập số hợp lệ cho ngày/tháng/năm.");
                return;
            }

            try
            {
                DateTime dt = new DateTime(year, month, day); // validate ngày hợp lệ
            }
            catch
            {
                MessageBox.Show("Ngày tháng năm không hợp lệ!");
                return;
            }

            string zodiac = GetZodiac(day, month);
            label4.Text = $"Cung hoàng đạo: {zodiac}";
        }


        // ================== NÚT: Xóa (reset) ==================
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            label1.Text = "Cung hoàng đạo: ";
            textBox1.Focus();
        }

        // ================== NÚT: Thoát ==================
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ======= Các handler rỗng để tránh lỗi nếu Designer gán sự kiện =======
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }

        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        // =======================================================================
    }
}
