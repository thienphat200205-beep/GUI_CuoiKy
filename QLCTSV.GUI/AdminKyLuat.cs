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
    public partial class AdminKyLuat: Form
    {
        public AdminKyLuat()
        {
            InitializeComponent();
        }

        private void Label_Chung_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void AdminKyLuat_Load(object sender, EventArgs e)
        {
          LoadTheme();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

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
            Label_QLKL.ForeColor = ThemeColor.PrimaryColor;
            label_HTKL.ForeColor = ThemeColor.SecondaryColor;
            label_DSSV.ForeColor = ThemeColor.SecondaryColor;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
