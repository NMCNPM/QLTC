using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CMNNPM.SQL;

namespace CMNNPM
{
    public partial class QuanTri : Form
    {
        private ThemSanh tsForm;
        private ThemLoaiSanh lsForm;
        private ThemMonAn maForm;
        private ThemDichVu dvForm;

        public QuanTri()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tsForm = new ThemSanh();
            tsForm.Show();
        }

        public void updateSanh()
        {
            SanhSQL.loadListViewDSSanh(listViewDSSanh);
        }
        public void updateLoaiSanh()
        {
            LoaiSanhSQL.loadListViewDSLoaiSanh(listViewLoaiSanh);
        }
        public void updateMonAn()
        {
            MonAnSQL.loadListViewMonAn(listViewMonAn);
        }
        public void updateDichVu()
        {
            DichVuSQL.loadListViewDichVu(listViewDichVu);
        }

        private void QuanTri_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            updateMonAn();
            updateDichVu();
            updateLoaiSanh();
            updateSanh();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            maForm = new ThemMonAn(this);
            maForm.Show();
        }

        private void buttonThemLoaiSanh_Click(object sender, EventArgs e)
        {
            lsForm = new ThemLoaiSanh(this);
            lsForm.Show();
        }

        private void buttonThemDichVu_Click(object sender, EventArgs e)
        {
            dvForm = new ThemDichVu(this);
            dvForm.Show();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            BaoCaoDoanhSo form = new BaoCaoDoanhSo();
            form.Show();
        }

        private void buttonXoaDSSanh_Click(object sender, EventArgs e)
        {
            bool result = false;

            foreach (ListViewItem item in listViewDSSanh.Items)
            {
                if (item.Selected == true)
                {
                    result = SanhSQL.deleteDSSanh(item.SubItems[1].Text.TrimEnd());
                    break;
                }
            }
            if (result == false)
            {
                MessageBox.Show("Có tiệc cưới đang dùng sảnh!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            updateSanh();
        }

        private void buttonSuaDSSanh_Click(object sender, EventArgs e)
        {
            bool result = false;
            foreach (ListViewItem item in listViewDSSanh.Items)
            {
                if (item.Selected == true)
                {
                    tsForm = new ThemSanh(this, item.SubItems[1].Text.TrimEnd());
                    tsForm.Show();
                    result = true;
                    break;
                }
            }

            if(result == false)
            {
                MessageBox.Show("Vui lòng chọn sảnh", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void buttonSuaLoaiSanh_Click(object sender, EventArgs e)
        {
            bool result = false;
            foreach (ListViewItem item in listViewLoaiSanh.Items)
            {
                if (item.Selected == true)
                {
                    lsForm = new ThemLoaiSanh(this, item.SubItems[1].Text.TrimEnd());
                    lsForm.Show();
                    result = true;
                    break;
                }
            }

            if (result == false)
            {
                MessageBox.Show("Vui lòng chọn sảnh", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonXoaLoaiSanh_Click(object sender, EventArgs e)
        {
            bool result = false;

            foreach (ListViewItem item in listViewLoaiSanh.Items)
            {
                if (item.Selected == true)
                {
                    result = LoaiSanhSQL.deleteDSLoaiSanh(item.SubItems[1].Text.TrimEnd());
                    break;
                }
            }
            if (result == false)
            {
                MessageBox.Show("Có sảnh đang dùng loại sảnh này!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            updateLoaiSanh();
        }

        private void buttonXoaMonAn_Click(object sender, EventArgs e)
        {
            bool result = false;

            foreach (ListViewItem item in listViewMonAn.Items)
            {
                if (item.Selected == true)
                {
                    result = MonAnSQL.deleteMonAn(item.SubItems[1].Text.TrimEnd());
                    break;
                }
            }

            if (result == false)
            {
                MessageBox.Show("Có tiệc cưới đang đăng ký món ăn này!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            updateMonAn();
        }

        private void buttonSuaMonAn_Click(object sender, EventArgs e)
        {
            bool result = false;
            foreach (ListViewItem item in listViewMonAn.Items)
            {
                if (item.Selected == true)
                {
                    maForm = new ThemMonAn(this, 
                        item.SubItems[1]
                        .Text
                        .TrimEnd());
                    maForm.Show();
                    result = true;
                    break;
                }
            }

            if (result == false)
            {
                MessageBox.Show("Vui lòng chọn món ăn", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonXoaDichVu_Click(object sender, EventArgs e)
        {
            bool result = false;

            foreach (ListViewItem item in listViewDichVu.Items)
            {
                if (item.Selected == true)
                {
                    result = DichVuSQL.deleteDichVu(item.SubItems[1]
                        .Text
                        .TrimEnd());
                    break;
                }
            }

            if (result == false)
            {
                MessageBox.Show("Có tiệc cưới đang đăng ký dịch vụ này!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            updateDichVu();
        }

        private void buttonSuaDichVu_Click(object sender, EventArgs e)
        {
            bool result = false;
            foreach (ListViewItem item in listViewDichVu.Items)
            {
                if (item.Selected == true)
                {
                    dvForm = new ThemDichVu(this,
                        item.SubItems[1]
                        .Text
                        .TrimEnd());

                    dvForm.Show();
                    result = true;
                    break;
                }
            }

            if (result == false)
            {
                MessageBox.Show("Vui lòng chọn món ăn", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
