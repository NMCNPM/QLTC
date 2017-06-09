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
    public partial class ThemDichVu : Form
    {
        private QuanTri qtForm;
        private bool isUpdate = false;
        
        public ThemDichVu(QuanTri qt)
        {
            qtForm = qt;
            InitializeComponent();
        }

        // constructor ThemDichVu: truyền vào form QuanTri và tên dịch vụ từ form QuanTri
        public ThemDichVu(QuanTri qt, String tendichvu)
        {
            qtForm = qt;
            isUpdate = true;
            InitializeComponent();

            textBoxTenDichVu.Enabled = false;

            DichVuSQL.loadDichVuFromTenDichVu(tendichvu,
                textBoxTenDichVu,
                textBoxGiaDichVu);
        }       

        // sự kiện nhấn nút thoát form: đóng form
        private void buttonThoatForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // load form 
        private void ThemDichVu_Load(object sender, EventArgs e)
        {
            this.ActiveControl = textBoxTenDichVu;
        }

        // sự kiện nhấn nút chấp nhận: kiểm tra trạng thái thêm mới hoặc
        // trạng thái sửa
        // trạng thái sửa: cập nhật dữ liệu mới và lưu vào database
        // trạng thái thêm mới: thêm dữ liệu vào database
        private void buttonChapNhan_Click(object sender, EventArgs e)
        {
            bool result = false;
            try
            {
                if (isUpdate == false)
                {
                    result = DichVuSQL.insertDichVu(
                    textBoxTenDichVu.Text,
                    textBoxGiaDichVu.Text);
                }
                else
                {
                    result = DichVuSQL.updateDichVu(
                    textBoxTenDichVu.Text,
                    textBoxGiaDichVu.Text);
                }
            }
            catch (Exception) { }

            if (result == true)
            {
                qtForm.updateDichVu();
                this.Close();
            }
            else
                MessageBox.Show("Thao tác không thành công", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            qtForm.updateDichVu();
        }
    }
}
