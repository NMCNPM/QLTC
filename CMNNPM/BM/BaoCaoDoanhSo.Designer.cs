namespace CMNNPM
{
    partial class BaoCaoDoanhSo
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
            this.buttonHoanThanh = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxDoanhThu = new System.Windows.Forms.TextBox();
            this.textBoxSoLuong = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePickerNgayThang = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonHuyBo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonHoanThanh
            // 
            this.buttonHoanThanh.Location = new System.Drawing.Point(57, 102);
            this.buttonHoanThanh.Name = "buttonHoanThanh";
            this.buttonHoanThanh.Size = new System.Drawing.Size(75, 23);
            this.buttonHoanThanh.TabIndex = 16;
            this.buttonHoanThanh.Text = "Hoàn thành";
            this.buttonHoanThanh.UseVisualStyleBackColor = true;
            this.buttonHoanThanh.Click += new System.EventHandler(this.buttonHoanThanh_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(321, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "VNĐ";
            // 
            // textBoxDoanhThu
            // 
            this.textBoxDoanhThu.Location = new System.Drawing.Point(117, 76);
            this.textBoxDoanhThu.Name = "textBoxDoanhThu";
            this.textBoxDoanhThu.Size = new System.Drawing.Size(200, 20);
            this.textBoxDoanhThu.TabIndex = 14;
            // 
            // textBoxSoLuong
            // 
            this.textBoxSoLuong.Location = new System.Drawing.Point(117, 49);
            this.textBoxSoLuong.Name = "textBoxSoLuong";
            this.textBoxSoLuong.Size = new System.Drawing.Size(200, 20);
            this.textBoxSoLuong.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Ngày báo cáo :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Tổng doanh thu :";
            // 
            // dateTimePickerNgayThang
            // 
            this.dateTimePickerNgayThang.Location = new System.Drawing.Point(117, 22);
            this.dateTimePickerNgayThang.Name = "dateTimePickerNgayThang";
            this.dateTimePickerNgayThang.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerNgayThang.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Số lượng tiệc cưới :";
            // 
            // buttonHuyBo
            // 
            this.buttonHuyBo.Location = new System.Drawing.Point(213, 102);
            this.buttonHuyBo.Name = "buttonHuyBo";
            this.buttonHuyBo.Size = new System.Drawing.Size(75, 23);
            this.buttonHuyBo.TabIndex = 17;
            this.buttonHuyBo.Text = "Hủy bỏ";
            this.buttonHuyBo.UseVisualStyleBackColor = true;
            this.buttonHuyBo.Click += new System.EventHandler(this.buttonHuyBo_Click);
            // 
            // BaoCaoDoanhSo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 131);
            this.Controls.Add(this.buttonHuyBo);
            this.Controls.Add(this.buttonHoanThanh);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxDoanhThu);
            this.Controls.Add(this.textBoxSoLuong);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePickerNgayThang);
            this.Controls.Add(this.label2);
            this.Name = "BaoCaoDoanhSo";
            this.Text = "Báo Cáo Doanh Số ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonHoanThanh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxDoanhThu;
        private System.Windows.Forms.TextBox textBoxSoLuong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePickerNgayThang;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonHuyBo;
    }
}