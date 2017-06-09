namespace CMNNPM
{
    partial class ThemDichVu
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
            this.textBoxGiaDichVu = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxTenDichVu = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonHuyBo
            // 
            this.buttonHuyBo.Location = new System.Drawing.Point(162, 120);
            this.buttonHuyBo.Name = "buttonHuyBo";
            this.buttonHuyBo.Size = new System.Drawing.Size(75, 23);
            this.buttonHuyBo.TabIndex = 30;
            this.buttonHuyBo.Text = "Hủy bỏ";
            this.buttonHuyBo.UseVisualStyleBackColor = true;
            this.buttonHuyBo.Click += new System.EventHandler(this.buttonThoatForm_Click);
            // 
            // buttonChapNhan
            // 
            this.buttonChapNhan.Location = new System.Drawing.Point(42, 120);
            this.buttonChapNhan.Name = "buttonChapNhan";
            this.buttonChapNhan.Size = new System.Drawing.Size(75, 23);
            this.buttonChapNhan.TabIndex = 29;
            this.buttonChapNhan.Text = "Chấp nhận";
            this.buttonChapNhan.UseVisualStyleBackColor = true;
            this.buttonChapNhan.Click += new System.EventHandler(this.buttonChapNhan_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(243, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "VNĐ";
            // 
            // textBoxGiaDichVu
            // 
            this.textBoxGiaDichVu.Location = new System.Drawing.Point(108, 75);
            this.textBoxGiaDichVu.Name = "textBoxGiaDichVu";
            this.textBoxGiaDichVu.Size = new System.Drawing.Size(129, 20);
            this.textBoxGiaDichVu.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Giá";
            // 
            // textBoxTenDichVu
            // 
            this.textBoxTenDichVu.Location = new System.Drawing.Point(108, 25);
            this.textBoxTenDichVu.Name = "textBoxTenDichVu";
            this.textBoxTenDichVu.Size = new System.Drawing.Size(129, 20);
            this.textBoxTenDichVu.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Tên dịch vụ";
            // 
            // ThemDichVu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 178);
            this.Controls.Add(this.buttonHuyBo);
            this.Controls.Add(this.buttonChapNhan);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxGiaDichVu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxTenDichVu);
            this.Controls.Add(this.label1);
            this.Name = "ThemDichVu";
            this.Text = "Thêm dịch vụ";
            this.Load += new System.EventHandler(this.ThemDichVu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonHuyBo;
        private System.Windows.Forms.Button buttonChapNhan;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxGiaDichVu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxTenDichVu;
        private System.Windows.Forms.Label label1;
    }
}