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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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

        private void ThemLoaiSanh_Load(object sender, EventArgs e)
        {
            this.ActiveControl = textBoxTenLoaiSanh;
        }
    }
}
