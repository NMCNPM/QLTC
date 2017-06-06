namespace CMNNPM
{
    partial class DanhSachThucPham
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.listViewDanhSachThucPham = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mONANBindingSource = new System.Windows.Forms.BindingSource(this.components);
            //this.qLTCDataSet4 = new CMNNPM.QLTCDataSet4();
            //this.mONANTableAdapter = new CMNNPM.QLTCDataSet4TableAdapters.MONANTableAdapter();
            this.dataGridViewDSThucPham = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.mONANBindingSource)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.qLTCDataSet4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDSThucPham)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(56, 306);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 26);
            this.button1.TabIndex = 1;
            this.button1.Text = "Thêm";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(432, 306);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(134, 28);
            this.button2.TabIndex = 2;
            this.button2.Text = "Hoàn Thành";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // listViewDanhSachThucPham
            // 
            this.listViewDanhSachThucPham.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listViewDanhSachThucPham.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewDanhSachThucPham.Location = new System.Drawing.Point(12, 12);
            this.listViewDanhSachThucPham.Name = "listViewDanhSachThucPham";
            this.listViewDanhSachThucPham.Size = new System.Drawing.Size(592, 262);
            this.listViewDanhSachThucPham.TabIndex = 4;
            this.listViewDanhSachThucPham.UseCompatibleStateImageBehavior = false;
            this.listViewDanhSachThucPham.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "STT";
            this.columnHeader1.Width = 55;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên món ăn";
            this.columnHeader2.Width = 144;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Giá";
            this.columnHeader3.Width = 102;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Ghi chú";
            this.columnHeader4.Width = 287;
            // 
            // mONANBindingSource
            // 
            this.mONANBindingSource.DataMember = "MONAN";
            //this.mONANBindingSource.DataSource = this.qLTCDataSet4;
            // 
            // qLTCDataSet4
            // 
            //this.qLTCDataSet4.DataSetName = "QLTCDataSet4";
            //this.qLTCDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mONANTableAdapter
            // 
            //this.mONANTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridViewDSThucPham
            // 
            this.dataGridViewDSThucPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDSThucPham.Location = new System.Drawing.Point(12, 280);
            this.dataGridViewDSThucPham.Name = "dataGridViewDSThucPham";
            this.dataGridViewDSThucPham.Size = new System.Drawing.Size(592, 10);
            this.dataGridViewDSThucPham.TabIndex = 6;
            // 
            // DanhSachThucPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 353);
            this.Controls.Add(this.dataGridViewDSThucPham);
            this.Controls.Add(this.listViewDanhSachThucPham);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "DanhSachThucPham";
            this.Text = "Danh sách thực phẩm";
            this.Load += new System.EventHandler(this.DanhSachThucPham_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mONANBindingSource)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.qLTCDataSet4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDSThucPham)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListView listViewDanhSachThucPham;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        //private QLTCDataSet4 qLTCDataSet4;
        private System.Windows.Forms.BindingSource mONANBindingSource;
        //private QLTCDataSet4TableAdapters.MONANTableAdapter mONANTableAdapter;
        private System.Windows.Forms.DataGridView dataGridViewDSThucPham;
    }
}