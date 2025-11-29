using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLCTSV.DTO.AdminDTO;
using Newtonsoft.Json;
using System.Net.Http;

namespace QLCTSV.GUI
{
    public partial class AdminDiem: Form
    {
        private static readonly HttpClient client = new HttpClient();
        private string baseUrl = "https://localhost:7135/api/";
        public AdminDiem()
        {
            InitializeComponent();
        }
        
        private void Label_Chung_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void AdminDiem_Load(object sender, EventArgs e)
        {
            LoadTheme();
            SetupComboBox();
            LoadData();
        }
        private void SetupComboBox()
        {
            // Thêm dữ liệu mẫu cho Năm học nếu chưa có
            if (comboBox_Namhoc.Items.Count == 0)
            {
                comboBox_Namhoc.Items.AddRange(new string[] { "2023-2024", "2024-2025", "2025-2026" });
            }

            // Xếp loại có thể để tự động tính toán hoặc cho chọn
            if (comboBox_xeploai.Items.Count == 0)
            {
                comboBox_xeploai.Items.AddRange(new string[] { "Xuất sắc", "Giỏi", "Khá", "Trung bình", "Yếu" });
            }
        }
        private async void LoadData()
        {
            try
            {
                // Gọi API lấy danh sách điểm
                string url = baseUrl + "api/ctsv/danh-sach-diem-sinh-vien";
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = await response.Content.ReadAsStringAsync();
                    List<XemDSachDiemDTO> listDiem = JsonConvert.DeserializeObject<List<XemDSachDiemDTO>>(jsonContent);

                    dataGridView1.DataSource = listDiem;

                    // Đặt tên cột tiếng Việt
                    if (dataGridView1.Columns["MaSV"] != null) dataGridView1.Columns["MaSV"].HeaderText = "Mã SV";
                    if (dataGridView1.Columns["HoTen"] != null) dataGridView1.Columns["HoTen"].HeaderText = "Họ Tên";
                    if (dataGridView1.Columns["HocKy"] != null) dataGridView1.Columns["HocKy"].HeaderText = "Học Kỳ";
                    if (dataGridView1.Columns["NamHoc"] != null) dataGridView1.Columns["NamHoc"].HeaderText = "Năm Học";
                    if (dataGridView1.Columns["DiemRenLuyen"] != null) dataGridView1.Columns["DiemRenLuyen"].HeaderText = "ĐRL";
                }
                else
                {
                    MessageBox.Show("Không thể tải dữ liệu điểm: " + response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
        }
        private XemDSachDiemDTO GetDiemFromUI()
        {
            // Validate dữ liệu số
            if (!double.TryParse(textBox_GPA.Text, out double gpa)) gpa = 0;
            if (!int.TryParse(textBox_Drl.Text, out int drl)) drl = 0;

            return new XemDSachDiemDTO()
            {
                MaSV = textBox_MaSV.Text.Trim(),
                HocKy = textBox_HocKy.Text.Trim(),
                NamHoc = comboBox_Namhoc.Text.Trim(),
                GPA = gpa,
                DiemRenLuyen = drl,
                XepLoai = comboBox_xeploai.Text 
            };
        }
        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
            Label_Chung.ForeColor = ThemeColor.PrimaryColor;
            if (Label_Chung != null) Label_Chung.ForeColor = ThemeColor.PrimaryColor;
        }

        private void button_lammoi_Click(object sender, EventArgs e)
        {
            textBox_MaSV.Clear();
            textBox_HocKy.Clear();
            comboBox_Namhoc.SelectedIndex = -1;
            textBox_GPA.Clear();
            textBox_Drl.Clear();
            comboBox_xeploai.SelectedIndex = -1;

            // Mở khóa lại các ô quan trọng
            textBox_MaSV.Enabled = true;
            textBox_HocKy.Enabled = true;
            comboBox_Namhoc.Enabled = true;
        }

        private async void button_them_Click(object sender, EventArgs e)
        {
            if (textBox_MaSV.Enabled == false)
            {
                MessageBox.Show("Vui lòng bấm 'Hủy chọn' trước khi thêm mới.");
                return;
            }

            try
            {
                XemDSachDiemDTO diem = GetDiemFromUI();

                // Validate cơ bản
                if (string.IsNullOrEmpty(diem.MaSV) || string.IsNullOrEmpty(diem.HocKy))
                {
                    MessageBox.Show("Vui lòng nhập Mã SV và Học kỳ.");
                    return;
                }

                string json = JsonConvert.SerializeObject(diem);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(baseUrl + "api/ctsv/nhap-diem", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Nhập điểm thành công!");
                    LoadData();
                    button_lammoi_Click(sender, e); // Reset form
                }
                else
                {
                    string err = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("Thất bại: " + err);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private async void button_sua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_MaSV.Text))
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần sửa điểm.");
                return;
            }

            try
            {
                XemDSachDiemDTO diem = GetDiemFromUI();
                string json = JsonConvert.SerializeObject(diem);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                // API Update: api/ctsv/update-diem/{maSV}
                // Lưu ý: Logic backend của bạn cần xử lý việc update đúng kỳ/năm học dựa trên body gửi lên
                string url = baseUrl + "api/ctsv/update-diem/" + diem.MaSV;

                HttpResponseMessage response = await client.PutAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Cập nhật điểm thành công!");
                    LoadData();
                }
                else
                {
                    string err = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("Cập nhật thất bại: " + err);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void button_xoa_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            textBox_MaSV.Text = row.Cells["MaSV"].Value?.ToString();
            textBox_HocKy.Text = row.Cells["HocKy"].Value?.ToString();
            comboBox_Namhoc.Text = row.Cells["NamHoc"].Value?.ToString();
            textBox_GPA.Text = row.Cells["GPA"].Value?.ToString();
            textBox_Drl.Text = row.Cells["DiemRenLuyen"].Value?.ToString();
            comboBox_xeploai.Text = row.Cells["XepLoai"].Value?.ToString();

            // Khi sửa điểm, KHÔNG ĐƯỢC sửa Mã SV, Học Kỳ, Năm Học
            textBox_MaSV.Enabled = false;
            textBox_HocKy.Enabled = false;
            comboBox_Namhoc.Enabled = false;
        }
    }
}
