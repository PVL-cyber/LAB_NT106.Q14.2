using System;
using System.Windows.Forms;

namespace LAB1_24522056
{
    public partial class Lab1_bai4 : Form
    {
        public Lab1_bai4()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy chuỗi nhập vào
                string input = textBox1.Text.Trim();

                // Kiểm tra rỗng
                if (input == "")
                {
                    MessageBox.Show("Vui lòng nhập số!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra có phải số nguyên không
                if (!long.TryParse(input, out long so))
                {
                    MessageBox.Show("Vui lòng nhập đúng định dạng số nguyên!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Giới hạn 12 chữ số
                if (so < 0 || so > 999999999999)
                {
                    MessageBox.Show("Chỉ hỗ trợ đọc số từ 0 đến 999,999,999,999 (12 chữ số)!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Gọi hàm đọc số
                string ketqua = DocSoTiengViet(so);
                textBox2.Text = ketqua;
            }
            catch
            {
                MessageBox.Show("Đã xảy ra lỗi khi đọc số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có chắc muốn thoát không?",
                                             "Xác nhận thoát",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
                this.Close();
        }

        // ===========================
        // 🧠 Hàm đọc số tiếng Việt
        // ===========================
        private string DocSoTiengViet(long so)
        {
            if (so == 0) return "Không";

            string[] hang = { "", "ngàn", "triệu", "tỷ" };
            string ketqua = "";
            int i = 0;

            while (so > 0)
            {
                int baSoCuoi = (int)(so % 1000);
                if (baSoCuoi != 0)
                {
                    string chuoiCon = DocBaChuSo(baSoCuoi);
                    if (i > 0 && chuoiCon != "")
                        ketqua = chuoiCon + " " + hang[i] + " " + ketqua;
                    else
                        ketqua = chuoiCon + " " + ketqua;
                }
                so /= 1000;
                i++;
            }

            ketqua = ketqua.Trim();
            return char.ToUpper(ketqua[0]) + ketqua.Substring(1);
        }

        private string DocBaChuSo(int so)
        {
            string[] donvi = { "", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            int tram = so / 100;
            int chuc = (so % 100) / 10;
            int dv = so % 10;

            string kq = "";

            if (tram != 0)
            {
                kq += donvi[tram] + " trăm";
                if (chuc == 0 && dv != 0)
                    kq += " lẻ";
            }

            if (chuc != 0 && chuc != 1)
            {
                kq += " " + donvi[chuc] + " mươi";
                if (dv == 1)
                    kq += " mốt";
                else if (dv == 5)
                    kq += " lăm";
                else if (dv != 0)
                    kq += " " + donvi[dv];
            }
            else if (chuc == 1)
            {
                kq += " mười";
                if (dv == 1)
                    kq += " một";
                else if (dv == 5)
                    kq += " lăm";
                else if (dv != 0)
                    kq += " " + donvi[dv];
            }
            else if (chuc == 0 && tram == 0 && dv != 0)
            {
                kq += donvi[dv];
            }
            else if (chuc == 0 && dv != 0)
            {
                kq += " " + donvi[dv];
            }

            return kq.Trim();
        }
    }
}
