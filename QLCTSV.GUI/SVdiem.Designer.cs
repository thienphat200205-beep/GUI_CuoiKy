namespace QLCTSV.GUI
{
    partial class SVdiem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label_SV = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBox_namhoc = new System.Windows.Forms.ComboBox();
            this.comboBox_hocky = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_xemds = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_SV
            // 
            this.label_SV.AutoSize = true;
            this.label_SV.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SV.Location = new System.Drawing.Point(67, 177);
            this.label_SV.Name = "label_SV";
            this.label_SV.Size = new System.Drawing.Size(266, 45);
            this.label_SV.TabIndex = 0;
            this.label_SV.Text = "Thông Tin Điểm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Học kỳ :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(548, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Năm Học :";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(75, 235);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1011, 264);
            this.dataGridView1.TabIndex = 6;
            // 
            // comboBox_namhoc
            // 
            this.comboBox_namhoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_namhoc.FormattingEnabled = true;
            this.comboBox_namhoc.Location = new System.Drawing.Point(663, 29);
            this.comboBox_namhoc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox_namhoc.Name = "comboBox_namhoc";
            this.comboBox_namhoc.Size = new System.Drawing.Size(324, 33);
            this.comboBox_namhoc.TabIndex = 22;
            // 
            // comboBox_hocky
            // 
            this.comboBox_hocky.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_hocky.FormattingEnabled = true;
            this.comboBox_hocky.Location = new System.Drawing.Point(127, 29);
            this.comboBox_hocky.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox_hocky.Name = "comboBox_hocky";
            this.comboBox_hocky.Size = new System.Drawing.Size(324, 33);
            this.comboBox_hocky.TabIndex = 23;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox_hocky);
            this.groupBox1.Controls.Add(this.comboBox_namhoc);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(75, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1011, 93);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Điểm";
            // 
            // button_xemds
            // 
            this.button_xemds.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_xemds.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_xemds.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_xemds.Location = new System.Drawing.Point(863, 521);
            this.button_xemds.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_xemds.Name = "button_xemds";
            this.button_xemds.Size = new System.Drawing.Size(223, 59);
            this.button_xemds.TabIndex = 25;
            this.button_xemds.Text = "Xem danh sách";
            this.button_xemds.UseVisualStyleBackColor = true;
            this.button_xemds.Click += new System.EventHandler(this.button_xemds_Click);
            // 
            // SVdiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 623);
            this.Controls.Add(this.button_xemds);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label_SV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SVdiem";
            this.Text = "Điểm";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_SV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBox_namhoc;
        private System.Windows.Forms.ComboBox comboBox_hocky;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_xemds;
    }
}