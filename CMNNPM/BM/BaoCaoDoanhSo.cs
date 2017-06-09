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
    public partial class BaoCaoDoanhSo : Form
    {
        private QuanTri qtForm;
        private bool isUpdate = false;

        // constructor cho form BaoCaoDoanhSo: truyền vào form QuanTri
        public BaoCaoDoanhSo(QuanTri qt)
        {
            qtForm = qt;
            InitializeComponent();
        }

        // constructor cho form BaoCaoDoanhSo: truyền vào form QuanTri và ngayBaoCao
        public BaoCaoDoanhSo(QuanTri qt, String ngayBaoCao)
        {
            qtForm = qt;
            isUpdate = true;
            InitializeComponent();

            dateTimePickerNgayThang.Enabled = false;

            BaoCaoSQL.loadBaoCaoFromNgayBaoCao(ngayBaoCao,
                dateTimePickerNgayThang,
                textBoxSoLuong,
                textBoxDoanhThu);
        }

        // sự kiện nhấn nút hoàn thành lập báo cáo: thêm các thông tin vừa nhập 
        // vào CSDL khi hoàn thành form
        private void buttonHoanThanh_Click(object sender, EventArgs e)
        {
            bool result = false;
            if(textBoxSoLuong.Text.Equals("")
                || textBoxDoanhThu.Text.Equals(""))
            {
                MessageBox.Show("Thao tác không thành công", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                
            try
            {
                if (isUpdate == false)
                {
                    result = BaoCaoSQL.insertBaoCao(
                        dateTimePickerNgayThang.Value.ToString(),
                        int.Parse(textBoxSoLuong.Text),
                        textBoxDoanhThu.Text);
                }
                else
                {
                    result = BaoCaoSQL.updateBaoCao(
                        dateTimePickerNgayThang.Value.ToString(),
                        int.Parse(textBoxSoLuong.Text),
                        textBoxDoanhThu.Text);
                }
            }
            catch (Exception) { }

            if (result == true)
            {
                qtForm.updateBaoCao();
                this.Close();
            }
            else
                MessageBox.Show("Thao tác không thành công", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            qtForm.updateBaoCao();
        }

        // sự kiện nhấn nút hủy form: hủy form lập báo cáo
        private void buttonHuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
