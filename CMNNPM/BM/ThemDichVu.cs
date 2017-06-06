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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ThemDichVu_Load(object sender, EventArgs e)
        {
            this.ActiveControl = textBoxTenDichVu;
        }

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
