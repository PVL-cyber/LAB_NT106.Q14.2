using System;
using System.Numerics;
using System.Windows.Forms;

namespace LAB1_24522056
{
    public partial class Lab1_bai6 : Form
    {
        public Lab1_bai6()
        {
            InitializeComponent();
        }

        private void Lab1_bai6_Load(object sender, EventArgs e)
        {
            // Nếu comboBox1 chưa có Items, thêm vào
            if (comboBox1.Items.Count == 0)
            {
                comboBox1.Items.Add("Bảng cửu chương");
                comboBox1.Items.Add("Tính toán giá trị");
                comboBox1.Items.Add("Cả hai");
                comboBox1.SelectedIndex = 0;
            }
        }

        // Hàm tính giai thừa (dùng BigInteger để tránh tràn số)
        private BigInteger Factorial(int n)
        {
            if (n < 0) throw new ArgumentException("Không tính giai thừa cho số âm");
            BigInteger res = 1;
            for (int i = 2; i <= n; i++)
                res *= i;
            return res;
        }

        // Nút "Tính các giá trị"
        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Clear(); // xóa vùng kết quả trước

            // Đọc dữ liệu A và B
            if (!int.TryParse(textBox1.Text.Trim(), out int A))
            {
                MessageBox.Show("Vui lòng nhập số nguyên hợp lệ cho A!");
                textBox1.Focus();
                return;
            }
            if (!int.TryParse(textBox2.Text.Trim(), out int B))
            {
                MessageBox.Show("Vui lòng nhập số nguyên hợp lệ cho B!");
                textBox2.Focus();
                return;
            }

            string choice = (comboBox1.SelectedItem ?? "").ToString();

            // Nếu chọn Bảng cửu chương hoặc Cả hai
            if (choice == "Bảng cửu chương" || choice == "Cả hai")
            {
                int t = B - A;
                textBox3.AppendText($"--- Bảng cửu chương {t} ---\r\n");
                for (int i = 1; i <= 10; i++)
                {
                    textBox3.AppendText($"{t} x {i} = {t * i}\r\n");
                }
                textBox3.AppendText("\r\n");
            }

            // Nếu chọn Tính toán giá trị hoặc Cả hai
            if (choice == "Tính toán giá trị" || choice == "Cả hai")
            {
                int diff = A - B;
                textBox3.AppendText($"--- Tính toán giá trị ---\r\n");

                // (A - B)!
                if (diff < 0)
                {
                    textBox3.AppendText($"(A - B) = {diff} => Không tính được giai thừa số âm\r\n");
                }
                else
                {
                    BigInteger gt = Factorial(diff);
                    textBox3.AppendText($"({A} - {B})! = {gt}\r\n");
                }

                // S = A^1 + A^2 + ... + A^B
                if (B <= 0)
                {
                    textBox3.AppendText($"Không thể tính tổng S vì B = {B} <= 0\r\n");
                }
                else
                {
                    BigInteger S = 0;
                    BigInteger pow = 1;
                    for (int i = 1; i <= B; i++)
                    {
                        pow *= A; // pow = A^i
                        S += pow;
                    }
                    textBox3.AppendText($"S = A^1 + A^2 + ... + A^{B} = {S}\r\n");
                }
                textBox3.AppendText("\r\n");
            }
        }

        // Nút Xóa
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.SelectedIndex = 0;
            textBox1.Focus();
        }

        // Nút Thoát
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
