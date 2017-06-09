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
        private BaoCaoDoanhSo bcdsForm;

        // constructor cho form QuanTri
        public QuanTri()
        {
            InitializeComponent();
        }
  
        // sự kiện nhấn nút thêm sảnh: mở form thêm sảnh
        private void buttonThemSanh_Click(object sender, EventArgs e)
        {
            tsForm = new ThemSanh();
            tsForm.Show();
        }

        // cập nhật danh sách sảnh
        public void updateSanh()
        {
            SanhSQL.loadListViewDSSanh(listViewDSSanh);
        }

        // cập nhật danh sách loại sảnh
        public void updateLoaiSanh()
        {
            LoaiSanhSQL.loadListViewDSLoaiSanh(listViewLoaiSanh);
        }

        // cập nhật danh sách món ăn
        public void updateMonAn()
        {
            MonAnSQL.loadListViewMonAn(listViewMonAn);
        }

        // cập nhật danh sách dịch vụ
        public void updateDichVu()
        {
            DichVuSQL.loadListViewDichVu(listViewDichVu);
        }

        // cập nhật danh sách báo cáo
        public void updateBaoCao()
        {
            BaoCaoSQL.loadListViewBaoCao(listViewBaoCao);
        }

        // load form QuanTri
        private void QuanTri_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        //cập nhật các danh sách có trong form
        private void LoadData()
        {
            updateMonAn();
            updateDichVu();
            updateLoaiSanh();
            updateSanh();
            updateBaoCao();
        }

        // sự kiện nhấn nút thêm món ăn: mở form thêm món ăn
        private void buttonThemMonAn_Click(object sender, EventArgs e)
        {
            maForm = new ThemMonAn(this);
            maForm.Show();
        }

        // sự kiện nhấn nút thêm loại sảnh: mở form thêm loại sảnh
        private void buttonThemLoaiSanh_Click(object sender, EventArgs e)
        {
            lsForm = new ThemLoaiSanh(this);
            lsForm.Show();
        }

        // sự kiện nhấn nút thêm dịch vụ: mở form thêm dịch vụ
        private void buttonThemDichVu_Click(object sender, EventArgs e)
        {
            dvForm = new ThemDichVu(this);
            dvForm.Show();
        }

        // sự kiện nhấn nút thêm báo cáo: mở form thêm báo cáo
        private void buttonThemBaoCao_Click(object sender, EventArgs e)
        {
            bcdsForm = new BaoCaoDoanhSo(this);
            bcdsForm.Show();
        }

        // sự kiện xóa danh sách sảnh: kiểm tra có sảnh đc chọn, 
        // nếu sảnh không có tiệc nào đang đặt xóa sảnh đc chọn,
        // nếu có xuất thông báo
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

        // sự kiện sửa danh sách sảnh: kiểm tra có sảnh đc chọn, 
        // nếu có, mở form ThemSanh để sửa sảnh đc chọn,
        // nếu không xuất thông báo
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

        // sự kiện sửa danh sách loại sảnh: kiểm tra có loại sảnh đc chọn, 
        // nếu có mở form ThemLoaiSanh sửa sảnh đc chọn,
        // nếu không xuất thông báo
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

        // sự kiện xóa danh sách loại sảnh: kiểm tra có loại sảnh đc chọn, 
        // nếu loại sảnh không trùng với sảnh, xóa sảnh đc chọn,
        // nếu có xuất thông báo
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

        // sự kiện xóa danh sách món ăn: kiểm tra có món ăn đc chọn, 
        // nếu món ăn không có tiệc nào đang đặt xóa món ăn đc chọn,
        // nếu có xuất thông báo
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

        // sự kiện sửa danh sách món ăn: kiểm tra có món ăn đc chọn, 
        // nếu có, mở form ThemMonAn sửa món đc chọn,
        // nếu không xuất thông báo
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

        // sự kiện xóa danh sách dịch vụ: kiểm tra có dịch vụ đc chọn, 
        // nếu dịch vụ không có tiệc nào đang đặt xóa dịch vụ đc chọn,
        // nếu có xuất thông báo
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

        // sự kiện sửa danh sách dịch vụ: kiểm tra có dịch vụ đc chọn, 
        // nếu có mở form ThemDichVu sửa dịch vụ đc chọn,
        // nếu không xuất thông báo
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
                MessageBox.Show("Vui lòng chọn dịch vụ", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // sự kiện xóa danh sách báo cáo: kiểm tra có báo cáo đc chọn, 
        // nếu có xóa báo cáo đc chọn,
        // nếu không xuất thông báo
        private void buttonXoaBaoCao_Click(object sender, EventArgs e)
        {
            bool result = false;

            foreach (ListViewItem item in listViewBaoCao.Items)
            {
                if (item.Selected == true)
                {
                    result = BaoCaoSQL.deleteBaoCao(item.SubItems[1].Text.TrimEnd());
                    break;
                }
            }
            if (result == false)
            {
                MessageBox.Show("Thao tác không thành công", "Lỗi!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            updateBaoCao();
        }

        // sự kiện sửa danh sách báo cáo: kiểm tra có báo cáo đc chọn, 
        // nếu có mở form ThemBaoCao sửa báo cáo đc chọn,
        // nếu không xuất thông báo
        private void buttonSuaBaoCao_Click(object sender, EventArgs e)
        {
            bool result = false;
            foreach (ListViewItem item in listViewBaoCao.Items)
            {
                if (item.Selected == true)
                {
                    bcdsForm = new BaoCaoDoanhSo(this,
                        item.SubItems[1]
                        .Text
                        .TrimEnd());

                    bcdsForm.Show();
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
