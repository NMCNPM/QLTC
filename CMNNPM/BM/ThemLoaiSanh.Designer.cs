namespace CMNNPM
{
    partial class ThemLoaiSanh
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
            this.buttonHuyBo = new System.Windows.Forms.Button();
            this.buttonChapNhan = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxDonGiaBanToiThieu = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxTenLoaiSanh = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonHuyBo
            // 
            this.buttonHuyBo.Location = new System.Drawing.Point(187, 77);
            this.buttonHuyBo.Name = "buttonHuyBo";
            this.buttonHuyBo.Size = new System.Drawing.Size(75, 23);
            this.buttonHuyBo.TabIndex = 23;
            this.buttonHuyBo.Text = "Hủy bỏ";
            this.buttonHuyBo.UseVisualStyleBackColor = true;
            this.buttonHuyBo.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonChapNhan
            // 
            this.buttonChapNhan.Location = new System.Drawing.Point(24, 77);
            this.buttonChapNhan.Name = "buttonChapNhan";
            this.buttonChapNhan.Size = new System.Drawing.Size(75, 23);
            this.buttonChapNhan.TabIndex = 22;
            this.buttonChapNhan.Text = "Chấp nhận";
            this.buttonChapNhan.UseVisualStyleBackColor = true;
            this.buttonChapNhan.Click += new System.EventHandler(this.buttonChapNhan_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(258, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "VNĐ";
            // 
            // textBoxDonGiaBanToiThieu
            // 
            this.textBoxDonGiaBanToiThieu.Location = new System.Drawing.Point(123, 48);
            this.textBoxDonGiaBanToiThieu.Name = "textBoxDonGiaBanToiThieu";
            this.textBoxDonGiaBanToiThieu.Size = new System.Drawing.Size(129, 20);
            this.textBoxDonGiaBanToiThieu.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Đơn giá bàn tối thiểu";
            // 
            // textBoxTenLoaiSanh
            // 
            this.textBoxTenLoaiSanh.Location = new System.Drawing.Point(123, 17);
            this.textBoxTenLoaiSanh.Name = "textBoxTenLoaiSanh";
            this.textBoxTenLoaiSanh.Size = new System.Drawing.Size(129, 20);
            this.textBoxTenLoaiSanh.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Tên loại sảnh";
            // 
            // ThemLoaiSanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 116);
            this.Controls.Add(this.buttonHuyBo);
            this.Controls.Add(this.buttonChapNhan);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxDonGiaBanToiThieu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxTenLoaiSanh);
            this.Controls.Add(this.label1);
            this.Name = "ThemLoaiSanh";
            this.Text = "Thêm loại sảnh";
            this.Load += new System.EventHandler(this.ThemLoaiSanh_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonHuyBo;
        private System.Windows.Forms.Button buttonChapNhan;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxDonGiaBanToiThieu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxTenLoaiSanh;
        private System.Windows.Forms.Label label1;
    }
}