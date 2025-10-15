using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace LAB1_24522056
{
    public partial class Lab1_bai8 : Form
    {
        public Lab1_bai8()
        {
            InitializeComponent();
        }

        // Nút Xử lý
        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            string raw = (textBox1.Text ?? "").Trim();
            if (string.IsNullOrEmpty(raw))
            {
                MessageBox.Show("Vui lòng nhập dữ liệu!", "Thông báo");
                return;
            }

            string[] parts = raw.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(p => p.Trim())
                                .ToArray();

            if (parts.Length < 2)
            {
                textBox2.Text = "Sai format: Cần có Họ tên và ít nhất 1 điểm.";
                return;
            }

            string hoTen = parts[0];
            var scores = new List<double>();

            for (int i = 1; i < parts.Length; i++)
            {
                if (double.TryParse(parts[i], NumberStyles.Any, CultureInfo.InvariantCulture, out double val))
                    scores.Add(val);
                else
                {
                    textBox2.Text = "Sai format điểm. Hãy nhập số hợp lệ (ví dụ: 7.5, 8, 9)";
                    return;
                }
            }

            // Xuất kết quả
            textBox2.AppendText($"Họ và tên: {hoTen}\r\n\r\n");

            for (int i = 0; i < scores.Count; i++)
                textBox2.AppendText($"Môn {i + 1}: {scores[i]}\r\n");

            double avg = scores.Average();
            textBox2.AppendText($"\r\nĐiểm trung bình: {avg:0.##}\r\n");

            double max = scores.Max();
            double min = scores.Min();
            var maxMons = scores.Select((v, idx) => new { v, idx }).Where(x => x.v == max).Select(x => x.idx + 1);
            var minMons = scores.Select((v, idx) => new { v, idx }).Where(x => x.v == min).Select(x => x.idx + 1);

            textBox2.AppendText($"Điểm cao nhất: {max} (Môn {string.Join(", ", maxMons)})\r\n");
            textBox2.AppendText($"Điểm thấp nhất: {min} (Môn {string.Join(", ", minMons)})\r\n");

            int pass = scores.Count(s => s >= 5.0);
            int fail = scores.Count - pass;
            textBox2.AppendText($"Số môn đậu: {pass}\r\n");
            textBox2.AppendText($"Số môn không đậu: {fail}\r\n");

            string xepLoai;
            if (avg >= 8 && scores.All(s => s >= 6.5))
                xepLoai = "Giỏi";
            else if (avg >= 6.5 && scores.All(s => s >= 5))
                xepLoai = "Khá";
            else if (avg >= 5 && scores.All(s => s >= 3.5))
                xepLoai = "Trung Bình";
            else if (avg >= 3.5 && scores.All(s => s >= 2))
                xepLoai = "Yếu";
            else
                xepLoai = "Kém";

            textBox2.AppendText($"\r\nXếp loại: {xepLoai}");
        }

        // Nút Xóa
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        // Nút Thoát
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
