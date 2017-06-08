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

        public BaoCaoDoanhSo(QuanTri qt)
        {
            qtForm = qt;
            InitializeComponent();
        }

        public BaoCaoDoanhSo(QuanTri qt, String ngaybaocao)
        {
            qtForm = qt;
            isUpdate = true;
            InitializeComponent();

            dateTimePickerNgayThang.Enabled = false;

            BaoCaoSQL.loadBaoCaoFromNgayBaoCao(ngaybaocao,
                dateTimePickerNgayThang,
                textBoxSoLuong,
                textBoxDoanhThu);
        }

        private void buttonHoanThanh_Click(object sender, EventArgs e)
        {
            bool result = false;
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

        private void buttonHuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
