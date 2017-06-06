namespace CMNNPM
{
    partial class DanhSachDichVu
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
            this.listViewDichVu = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonHoanThanh = new System.Windows.Forms.Button();
            this.buttonThem = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewDichVu
            // 
            this.listViewDichVu.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listViewDichVu.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewDichVu.Location = new System.Drawing.Point(12, 12);
            this.listViewDichVu.Name = "listViewDichVu";
            this.listViewDichVu.Size = new System.Drawing.Size(594, 288);
            this.listViewDichVu.TabIndex = 7;
            this.listViewDichVu.UseCompatibleStateImageBehavior = false;
            this.listViewDichVu.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "STT";
            this.columnHeader1.Width = 55;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên dịch vụ";
            this.columnHeader2.Width = 266;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Số lượng";
            this.columnHeader3.Width = 102;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Giá";
            this.columnHeader4.Width = 167;
            // 
            // buttonHoanThanh
            // 
            this.buttonHoanThanh.Location = new System.Drawing.Point(432, 306);
            this.buttonHoanThanh.Name = "buttonHoanThanh";
            this.buttonHoanThanh.Size = new System.Drawing.Size(134, 28);
            this.buttonHoanThanh.TabIndex = 6;
            this.buttonHoanThanh.Text = "Hoàn Thành";
            this.buttonHoanThanh.UseVisualStyleBackColor = true;
            this.buttonHoanThanh.Click += new System.EventHandler(this.buttonHoanThanh_Click);
            // 
            // buttonThem
            // 
            this.buttonThem.Location = new System.Drawing.Point(56, 306);
            this.buttonThem.Name = "buttonThem";
            this.buttonThem.Size = new System.Drawing.Size(134, 26);
            this.buttonThem.TabIndex = 5;
            this.buttonThem.Text = "Thêm";
            this.buttonThem.UseVisualStyleBackColor = true;
            this.buttonThem.Click += new System.EventHandler(this.buttonThem_Click);
            // 
            // DanhSachDichVu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 345);
            this.Controls.Add(this.listViewDichVu);
            this.Controls.Add(this.buttonHoanThanh);
            this.Controls.Add(this.buttonThem);
            this.Name = "DanhSachDichVu";
            this.Text = "Danh Sách Dịch Vụ";
            this.Load += new System.EventHandler(this.DanhSachDichVu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewDichVu;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button buttonHoanThanh;
        private System.Windows.Forms.Button buttonThem;
        //private QLTCDataSetTableAdapters.DICHVUTableAdapter dICHVUTableAdapter;
    }
}