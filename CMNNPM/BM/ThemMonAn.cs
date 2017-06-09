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
    public partial class ThemMonAn : Form
    {
        private QuanTri qtForm;
        private bool isUpdate = false;

        // constructor ThemMonAn
        public ThemMonAn(QuanTri qt)
        {
            qtForm = qt;
            InitializeComponent();
        }

        // constructor ThemMonAn
        public ThemMonAn(QuanTri qt, String tenmonan)
        {
            qtForm = qt;
            isUpdate = true;
            InitializeComponent();

            textBoxTenMonAn.Enabled = false;

            MonAnSQL.loadMonAnFromTenMonAn(tenmonan,
                textBoxTenMonAn,
                textBoxGia);
        }

        // sự kiện nhấn nút hủy form: đóng form
        private void buttonHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // load form ThemMonAn
        private void ThemMonAn_Load(object sender, EventArgs e)
        {
            this.ActiveControl = textBoxTenMonAn;
        }

        // sự kiện nhấn nút xác nhận: kiểm tra trạng thái thêm mới hoặc trạng thái sửa
        // trạng thái sửa: cập nhật dữ liệu mới và lưu vào database
        // trạng thái thêm mới: thêm dữ liệu vào database
        private void buttonXacNhan_Click(object sender, EventArgs e)
        {
            bool result = false;
            try
            {
                if (isUpdate == false)
                {
                    result = MonAnSQL.insertMonAn(
                    textBoxTenMonAn.Text,
                    textBoxGia.Text);
                }
                else
                {
                    result = MonAnSQL.updateMonAn(
                    textBoxTenMonAn.Text,
                    textBoxGia.Text);
                }
            }
            catch (Exception) { }

            if (result == true)
            {
                qtForm.updateMonAn();
                this.Close();
            }
            else
                MessageBox.Show("Thao tác không thành công", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            qtForm.updateMonAn();
        }
    }
}
