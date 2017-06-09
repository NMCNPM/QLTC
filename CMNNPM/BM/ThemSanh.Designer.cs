namespace CMNNPM
{
    partial class ThemSanh
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonThem = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxLoaiSanh = new System.Windows.Forms.ComboBox();
            this.textBoxTenSanh = new System.Windows.Forms.TextBox();
            this.textBoxSLBanToiDa = new System.Windows.Forms.TextBox();
            this.textBoxGhiChu = new System.Windows.Forms.TextBox();
            this.buttonHuy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên sảnh";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Loại sảnh";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Lượng bàn tối đa";
            // 
            // buttonThem
            // 
            this.buttonThem.Location = new System.Drawing.Point(36, 161);
            this.buttonThem.Name = "buttonThem";
            this.buttonThem.Size = new System.Drawing.Size(75, 23);
            this.buttonThem.TabIndex = 4;
            this.buttonThem.Text = "Thêm";
            this.buttonThem.UseVisualStyleBackColor = true;
            this.buttonThem.Click += new System.EventHandler(this.buttonThem_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Ghi chú";
            // 
            // comboBoxLoaiSanh
            // 
            this.comboBoxLoaiSanh.FormattingEnabled = true;
            this.comboBoxLoaiSanh.Location = new System.Drawing.Point(144, 51);
            this.comboBoxLoaiSanh.Name = "comboBoxLoaiSanh";
            this.comboBoxLoaiSanh.Size = new System.Drawing.Size(129, 21);
            this.comboBoxLoaiSanh.TabIndex = 1;
            // 
            // textBoxTenSanh
            // 
            this.textBoxTenSanh.Location = new System.Drawing.Point(144, 25);
            this.textBoxTenSanh.Name = "textBoxTenSanh";
            this.textBoxTenSanh.Size = new System.Drawing.Size(129, 20);
            this.textBoxTenSanh.TabIndex = 0;
            // 
            // textBoxSLBanToiDa
            // 
            this.textBoxSLBanToiDa.Location = new System.Drawing.Point(144, 78);
            this.textBoxSLBanToiDa.Name = "textBoxSLBanToiDa";
            this.textBoxSLBanToiDa.Size = new System.Drawing.Size(129, 20);
            this.textBoxSLBanToiDa.TabIndex = 2;
            // 
            // textBoxGhiChu
            // 
            this.textBoxGhiChu.Location = new System.Drawing.Point(144, 107);
            this.textBoxGhiChu.Multiline = true;
            this.textBoxGhiChu.Name = "textBoxGhiChu";
            this.textBoxGhiChu.Size = new System.Drawing.Size(129, 48);
            this.textBoxGhiChu.TabIndex = 3;
            // 
            // buttonHuy
            // 
            this.buttonHuy.Location = new System.Drawing.Point(188, 161);
            this.buttonHuy.Name = "buttonHuy";
            this.buttonHuy.Size = new System.Drawing.Size(75, 23);
            this.buttonHuy.TabIndex = 5;
            this.buttonHuy.Text = "Hủy";
            this.buttonHuy.UseVisualStyleBackColor = true;
            this.buttonHuy.Click += new System.EventHandler(this.buttonHuy_Click);
            // 
            // ThemSanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 193);
            this.Controls.Add(this.buttonHuy);
            this.Controls.Add(this.textBoxGhiChu);
            this.Controls.Add(this.textBoxSLBanToiDa);
            this.Controls.Add(this.textBoxTenSanh);
            this.Controls.Add(this.comboBoxLoaiSanh);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonThem);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ThemSanh";
            this.Text = "Thêm Sảnh";
            this.Load += new System.EventHandler(this.ThemSanh_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonThem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxLoaiSanh;
        private System.Windows.Forms.TextBox textBoxTenSanh;
        private System.Windows.Forms.TextBox textBoxSLBanToiDa;
        private System.Windows.Forms.TextBox textBoxGhiChu;
        private System.Windows.Forms.Button buttonHuy;
    }
}