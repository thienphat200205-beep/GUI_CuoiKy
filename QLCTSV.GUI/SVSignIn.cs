using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCTSV.GUI
{
    public partial class SVSignIn: Form
    {
        public SVSignIn()
        {
            InitializeComponent();
            this.AcceptButton = button_DangNhap;
            textBox_MKSV.PasswordChar = '*';
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox_TaiKhoan_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void button_DangNhap_Click(object sender, EventArgs e)
        {
           
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void SVSignIn_Load(object sender, EventArgs e)
        {

        }

        private void button_DangNhap_Click_1(object sender, EventArgs e)
        {
            if (textBox_TaiKhoanSV.Text == "SV01" && textBox_MKSV.Text == "abc123")
            {
                SVinterface svinterface = new SVinterface();
                this.Hide();
                svinterface.Show();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            SignInForm signInForm = new SignInForm();
            this.Hide();
            signInForm.Show();
        }

        private void label_ForgotPass_Click(object sender, EventArgs e)
        {
            ForgotPassword forgotPassword = new ForgotPassword();
            this.Hide();
            forgotPassword.Show();
        }
    }
}
