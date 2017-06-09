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
    public partial class ThemSanh : Form
    {
        private QuanTri qtForm;
        private bool isUpdate = false;

        // constructor ThemSanh
        public ThemSanh()
        {
            isUpdate = false;
            InitializeComponent();           
        }

        // constructor ThemSanh
        public ThemSanh(QuanTri qt, String tensanh)
        {
            isUpdate = true;
            qtForm = qt;
            InitializeComponent();

            textBoxTenSanh.Enabled = false;

            SanhSQL.loadSanhFromTenSanh(tensanh,
                textBoxTenSanh,
                comboBoxLoaiSanh,
                textBoxSLBanToiDa,
                textBoxGhiChu);
        }
        
        // sự kiện nhấn nút hủy form: đóng form
        private void buttonHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // load form ThemSanh
        private void ThemSanh_Load(object sender, EventArgs e)
        {
            addItemToComboLoaiSanh();
            this.ActiveControl = textBoxTenSanh;
        }

        // thêm item vào combobox comboBoxLoaiSanh
        public void addItemToComboLoaiSanh()
        {
            DataTable lsTable = DatTiecSQL.loadLoaiSanh();
            if (comboBoxLoaiSanh.Items.Count > 0)
                comboBoxLoaiSanh.Items.Clear();

            for (int i = 0; i < lsTable.Rows.Count; i++)
            {
                comboBoxLoaiSanh.Items.Add(
                    lsTable.Rows[i]["TENLOAISANH"].ToString().TrimEnd());

            }

            comboBoxLoaiSanh.Text = comboBoxLoaiSanh.Items[0].ToString();
        }

        // sự kiện nhấn nút thêm: kiểm tra trạng thái thêm mới hoặc trạng thái sửa
        // trạng thái sửa: cập nhật dữ liệu mới và lưu vào database
        // trạng thái thêm mới: thêm dữ liệu vào database
        private void buttonThem_Click(object sender, EventArgs e)
        {
            String tenloaisanh = comboBoxLoaiSanh
                .Items[comboBoxLoaiSanh.SelectedIndex]
                .ToString()
                .TrimEnd();

            bool result = false;

            try
            {
                if (isUpdate == false)
                {
                    result = SanhSQL.insertSanh(
                    tenloaisanh,
                    textBoxTenSanh.Text,
                    int.Parse(textBoxSLBanToiDa.Text),
                    textBoxGhiChu.Text);
                }
                else
                {
                    result = SanhSQL.updateSanh(
                    tenloaisanh,
                    textBoxTenSanh.Text,
                    int.Parse(textBoxSLBanToiDa.Text),
                    textBoxGhiChu.Text);
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
            qtForm.updateSanh();
        }
    }
}
