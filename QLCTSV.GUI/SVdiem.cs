using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using QLCTSV.DTO.SinhVienDTO;

namespace QLCTSV.GUI
{
    public partial class SVdiem: Form
    {
        private static readonly HttpClient client = new HttpClient();
        // Nhớ có dấu / ở cuối
        private string baseUrl = "https://localhost:7135/";

        // GIẢ LẬP MÃ SINH VIÊN ĐANG ĐĂNG NHẬP
        // Sau này bạn thay bằng: SVSignIn.MaSVDangNhap
        private string maSVHienTai = SVSignIn.TaiKhoanDangNhap;
        public SVdiem()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadTheme();
            SetupComboBox();
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
            label_SV.ForeColor = ThemeColor.PrimaryColor;
        }
        private void SetupComboBox()
        {
            if (comboBox_hocky.Items.Count == 0)
            {
                comboBox_hocky.Items.AddRange(new string[] { "1", "2", "3" });
                comboBox_hocky.SelectedIndex = 0;
            }
            if (comboBox_namhoc.Items.Count == 0)
            {
                comboBox_namhoc.Items.AddRange(new string[] { "2023-2024", "2024-2025", "2025-2026" });
                comboBox_namhoc.SelectedIndex = 0;
            }
        }

        private async void button_xemds_Click(object sender, EventArgs e)
        {
            string hk = comboBox_hocky.Text;
            string nh = comboBox_namhoc.Text;

            try
            {
                // 1. Tạo URL đúng chuẩn Backend yêu cầu
                // API: GET api/student/academic-result/{MaSV}?HocKy=...&NamHoc=...
                string url = $"{baseUrl}api/student/academic-result/{maSVHienTai}?HocKy={hk}&NamHoc={nh}";

                // 2. Gọi API
                HttpResponseMessage response = await client.GetAsync(url);
                string jsonContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    // 3. Deserialize dữ liệu về DTO
                    XemDSachDiemDTO kq = JsonConvert.DeserializeObject<XemDSachDiemDTO>(jsonContent);

                    // 4. Kiểm tra xem Backend có trả về dữ liệu thật hay chỉ là thông báo "Chưa có dữ liệu"
                    // Backend của bạn trả về: { message = "Chưa có dữ liệu..." } nếu không tìm thấy
                    if (!string.IsNullOrEmpty(kq.message) || kq.GPA == null)
                    {
                        MessageBox.Show($"Chưa có điểm tổng kết cho kỳ {hk}, năm {nh}.", "Thông báo");
                        dataGridView1.DataSource = null; // Xóa trắng bảng
                    }
                    else
                    {
                        // 5. Gán lại Kỳ và Năm để hiển thị lên bảng cho đẹp (vì API không trả về 2 cái này)
                        kq.HocKy = hk;
                        kq.NamHoc = nh;

                        // Vì GridView cần 1 List danh sách, mà API chỉ trả về 1 đối tượng
                        // Nên ta tạo 1 List chứa đúng 1 đối tượng đó
                        List<XemDSachDiemDTO> listHienThi = new List<XemDSachDiemDTO>();
                        listHienThi.Add(kq);

                        dataGridView1.DataSource = listHienThi;
                        SetupGridView();
                    }
                }
                else
                {
                    MessageBox.Show("Lỗi: " + response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message);
            }
        }
        private void SetupGridView()
        {
            // Ẩn cột message thừa
            if (dataGridView1.Columns["message"] != null) dataGridView1.Columns["message"].Visible = false;

            // Đặt tên cột tiếng Việt
            if (dataGridView1.Columns["HocKy"] != null) dataGridView1.Columns["HocKy"].HeaderText = "Học Kỳ";
            if (dataGridView1.Columns["NamHoc"] != null) dataGridView1.Columns["NamHoc"].HeaderText = "Năm Học";
            if (dataGridView1.Columns["GPA"] != null) dataGridView1.Columns["GPA"].HeaderText = "Điểm GPA";
            if (dataGridView1.Columns["DiemRenLuyen"] != null) dataGridView1.Columns["DiemRenLuyen"].HeaderText = "ĐRL";
            if (dataGridView1.Columns["XepLoai"] != null) dataGridView1.Columns["XepLoai"].HeaderText = "Xếp Loại";
        }
    }
}
