using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCTSV.GUI
{
    public partial class AdminSV: Form
    {
        public AdminSV()
        {
            InitializeComponent();
        }

        private void AdminSV_Load(object sender, EventArgs e)
        {
            LoadTheme();
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
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Images (*.jpg; *.jpeg; *.png; *.gif; *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string sourceFilePath = openFile.FileName;
                    string fileName = Path.GetFileName(sourceFilePath);
                    string targetFolder = Path.Combine(Application.StartupPath, "Images");
                    if (!Directory.Exists(targetFolder))
                    {
                        Directory.CreateDirectory(targetFolder);
                    }
                    string targetFilePath = Path.Combine(targetFolder, fileName);
                    File.Copy(sourceFilePath, targetFilePath, true);
                    pictureBox_anhSV.Image = Image.FromFile(targetFilePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sao chép và tải ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    pictureBox_anhSV.Text = "";
                }
            }
        }
    }
}
