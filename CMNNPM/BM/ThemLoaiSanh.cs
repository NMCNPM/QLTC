using CMNNPM.SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMNNPM
{
    public partial class ThemLoaiSanh : Form
    {
        private QuanTri qtForm;
        private bool isUpdate = false;

        public ThemLoaiSanh(QuanTri qt)
        {
            qtForm = qt;
            isUpdate = false;
            InitializeComponent();
        }

        // constructor ThemLoaiSanh: truyền vào form QuanTri 
        // và tên loại sảnh từ form QuanTri
        public ThemLoaiSanh(QuanTri qt, String tenloaisanh)
        {            
            qtForm = qt;
            isUpdate = true;
            InitializeComponent();

            textBoxTenLoaiSanh.Enabled = false;

            LoaiSanhSQL.loadLoaiSanhFromTenLoaiSanh(tenloaisanh,
                textBoxTenLoaiSanh,
                textBoxDonGiaBanToiThieu);
        }

        // sự kiện nhấn nút hủy: đóng form       
        private void buttonHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // sự kiện nhấn nút chấp nhận: kiểm tra trạng thái thêm mới hoặc trạng thái sửa
        // trạng thái sửa: cập nhật dữ liệu mới và lưu vào database
        // trạng thái thêm mới: thêm dữ liệu vào database
        private void buttonChapNhan_Click(object sender, EventArgs e)
        {
            bool result = false;
            try
            {
                if (isUpdate == false)
                {
                    result = LoaiSanhSQL.insertLoaiSanh(
                    textBoxTenLoaiSanh.Text,
                    textBoxDonGiaBanToiThieu.Text);
                }
                else
                {
                    result = LoaiSanhSQL.updateLoaiSanh(
                    textBoxTenLoaiSanh.Text,
                    textBoxDonGiaBanToiThieu.Text);
                }
            }
            catch (Exception) { }

            if (result == true)
            {
                qtForm.updateSanh();
                this.Close();
            }
            else
                MessageBox.Show("Thao tác không thành công", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            qtForm.updateLoaiSanh();
        }

        // load form thêm loại sảnh
        private void ThemLoaiSanh_Load(object sender, EventArgs e)
        {
            this.ActiveControl = textBoxTenLoaiSanh;
        }
    }
}
