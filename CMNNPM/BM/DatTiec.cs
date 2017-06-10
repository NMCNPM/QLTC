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
    public partial class DatTiec : Form
    {
        private DataTable sanhTable;
        private DataTable caTable;
        private bool validCheck;
        private String maTiecCuoi = "";

        private QuanLy quanLyForm;
        private DanhSachDichVu dichVuForm;
        private DanhSachThucPham thucPhamForm;

        private bool isUpdate = false;

        // constructor DatTiec
        public DatTiec( QuanLy ql)
        {
            quanLyForm = ql;
            isUpdate = false;
            InitializeComponent();
            addItemToComboSanh();
            addItemToLoaiSanh();

            addItemToComboCa();
        }

        // constructor DatTiec: mtc là mã tiệc cưới lấy từ QuanLy
        public DatTiec(QuanLy ql, String mtc)
        {
            quanLyForm = ql;
            isUpdate = true;
            maTiecCuoi = mtc;

            InitializeComponent();

            addItemToComboSanh();
            addItemToLoaiSanh();
            addItemToComboCa();

            if (!maTiecCuoi.Equals(""))
            {
                DataTable tiec = DatTiecSQL.getTiecCuoiInfo(mtc);
                loadKhachHangInfo(tiec);
                loadTiecCuoiInfo(tiec);
                updateListViews();
            }
        }
              
        //cập nhật dữ liệu ở các list view
        public void updateListViews()
        {
            DatTiecSQL.loadDatabaseDSDichVu(listViewDichVu, maTiecCuoi);
            DatTiecSQL.loadDatabaseDanhSachThucPham(listViewMonAn, maTiecCuoi);
        }

        // load thông tin khách hàng
        private void loadKhachHangInfo(DataTable table)
        {
            textBoxTenChuRe.Text = table.Rows[0]["TENCHURE"]
                .ToString()
                .TrimEnd();
            textBoxTenCoDau.Text = table.Rows[0]["TENCODAU"]
                .ToString()
                .TrimEnd();
            textBoxSDT.Text = table.Rows[0]["SDT"]
                .ToString()
                .TrimEnd();
        }

        // load thông tin tiệc cưới: ngày tháng, sảnh, loại sảnh
        //, ca, số lượng bàn, ...
        private void loadTiecCuoiInfo(DataTable table)
        {
            dateTimePickerNgayDatTiec.Value = DateTime.Parse(
                table.Rows[0]["NGAYDATTIEC"]
                .ToString()
                .TrimEnd());

            comboBoxSanh.Text = table.Rows[0]["TENSANH"]
                .ToString()
                .TrimEnd();
            addItemToComboSanh();

            comboBoxSLBan.Text = table.Rows[0]["SLBAN"]
                .ToString()
                .TrimEnd();
            addItemToComboSLBan();

            textBoxLoaiSanh.Text = table.Rows[0]["TENSANH"]
                .ToString()
                .TrimEnd();

            comboBoxCa.Text = table.Rows[0]["TENCA"]
                .ToString()
                .TrimEnd();
            addItemToComboCa();

            textBoxSoBanDuTru.Text = table.Rows[0]["SLBANDUTRU"]
                .ToString()
                .TrimEnd();

        }

        // sự kiện nhấn nút hủy form: đóng form
        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            try
            {
                thucPhamForm.Close();                
            }
            catch (Exception) { }

            try
            {
                dichVuForm.Close();
            }
            catch (Exception) { }

            this.Close();
        }

        // sự kiện nhấn nút thêm món ăn: mở form DanhSachThucPham
        private void btnThemMonAn_Click(object sender, EventArgs e)
        {
            thucPhamForm = new DanhSachThucPham(this, listViewMonAn);
            thucPhamForm.Show();
            thucPhamForm.Location = new Point(
                this.Location.X + this.Width
                , this.Location.Y);
        }

        // sự kiện nhấn nút thêm dịch vụ: mở form DanhSachDichVu
        private void buttonThemDichVu_Click(object sender, EventArgs e)
        {
            dichVuForm = new DanhSachDichVu(this, listViewDichVu);            
            dichVuForm.Show();
            dichVuForm.Location = new Point(
                this.Location.X + this.Width
                , this.Location.Y);
        }

        // kiểm tra kiểu dữ liệu trong form có phù hợp
        private bool checkNull()
        {
            if (textBoxTenChuRe.Text.Equals("")
                || textBoxTenCoDau.Text.Equals("")
                || textBoxSDT.Text.Equals("")
                || comboBoxSanh.Text.Equals("")
                || comboBoxCa.Text.Equals("")
                || comboBoxSLBan.Text.Equals("")
                || textBoxSoBanDuTru.Text.Equals(""))
                return false;
            return true;
        }

        // sự kiện nhấn nút chấp nhận đặt tiệc: cập nhật dữ liệu 
        // vào csdl và đóng form
        private void buttonChapNhan_Click(object sender, EventArgs e)
        {
            validCheck = checkNull();


            if (validCheck == true)
            {
                try
                {
                    DatTiecSQL.insertDatTiec(
                        textBoxTenChuRe.Text,
                        textBoxTenCoDau.Text,
                        textBoxSDT.Text,
                        dateTimePickerNgayDatTiec.Value,
                        textBoxLoaiSanh.Text,
                        comboBoxSanh.Text,
                        comboBoxCa.Text,
                        int.Parse(comboBoxSLBan.Text),
                        int.Parse(textBoxSoBanDuTru.Text));
                }
                catch (Exception) { };
                quanLyForm.updateQuanLyForm();
                try
                {
                    dichVuForm.Close();
                }
                catch (Exception) { };
                try
                {
                    thucPhamForm.Close();
                }
                catch (Exception) { };                
                this.Close();
            }
            else
            {
                MessageBox.Show("Thao tác không thực hiện được", "Lỗi!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        public bool checkDonGiaBanToiThieu(ListView lv)
        {
            double tongTien = 0;
            
            foreach (ListViewItem item in listViewMonAn.Items)
            {
                tongTien = tongTien
                    + double.Parse(item.SubItems[2].Text.Trim());
            }
            if (tongTien > )
            return false;
        }

        // sự kiện chọn sảnh trong comboBoxSanh: cập nhật loại sảnh
        private void comboBoxSanh_DropDownClosed(object sender, EventArgs e)
        {
            String sanh = comboBoxSanh.SelectedItem.ToString();
            addItemToLoaiSanh();
            addItemToComboSLBan();
        }

        // thêm item vào comboBoxSanh
        public void addItemToComboSanh()
        {
            sanhTable = DatTiecSQL.loadSanh();
            if (comboBoxSanh.Items.Count > 0)
                comboBoxSanh.Items.Clear();

            for(int i = 0; i < sanhTable.Rows.Count; i++)
            {
                comboBoxSanh.Items.Add(
                    sanhTable.Rows[i]["TENSANH"].ToString().TrimEnd());
               
            }

            comboBoxSanh.Text = comboBoxSanh.Items[0].ToString();
        }

        // thêm item vào comboBoxLoaiSanh
        public void addItemToLoaiSanh()
        {
            String loaiSanh = sanhTable
                .Rows[comboBoxSanh.SelectedIndex]["MALOAISANH"]
                .ToString()
                .TrimEnd();

            DataTable lsTable = DatabaseQuery.queryTable("SELECT TENLOAISANH FROM "
                + "LOAISANH WHERE MALOAISANH = '" 
                + loaiSanh + "';");

            if (lsTable.Rows.Count > 0) {
                String tenloaisanh = lsTable.Rows[0]["TENLOAISANH"]
                    .ToString()
                    .TrimEnd();
                textBoxLoaiSanh.Text = tenloaisanh;
            }

                     
        }

        // thêm item vào comboBoxCa
        public void addItemToComboCa()
        {
            caTable = DatTiecSQL.loadCa();
            if (comboBoxCa.Items.Count > 0)
                comboBoxCa.Items.Clear();

            for (int i = 0; i < caTable.Rows.Count; i++)
            {
                comboBoxCa.Items.Add(
                    caTable.Rows[i]["TENCA"].ToString().TrimEnd());

            }

            comboBoxCa.Text = comboBoxCa.Items[0].ToString();
        }

        // thêm item vào comboBoxSLBan
        public void addItemToComboSLBan()
        {
            comboBoxSLBan.Enabled = true;

            if (comboBoxSLBan.Items.Count > 0)
                comboBoxSLBan.Items.Clear();

            int slBanToiDa = int.Parse(sanhTable
                .Rows[comboBoxSanh.SelectedIndex]["SLBANTOIDA"]
                .ToString()
                .TrimEnd());

            for (int i = 0; i < slBanToiDa; i++)
            {
                comboBoxSLBan.Items.Add(i + 1);
            }

            comboBoxCa.Text = comboBoxCa.Items[0].ToString();
        }

        // sự kiện nhấn nút kiểm tra thời gian tiệc:
        // nếu trùng thông báo
        private void buttonKiemTra_Click(object sender, EventArgs e)
        {
            String tensanh = comboBoxSanh.SelectedItem.ToString();
            String tenca = comboBoxCa.SelectedItem.ToString();
            DateTime ngaydattiec = dateTimePickerNgayDatTiec.Value;
            if (DatTiecSQL.checkIfTiecCuoiExisted(tensanh, tenca, ngaydattiec))
            {
                labelKiemTra.Text = "Có thể đặt tiệc";
                labelKiemTra.ForeColor = Color.Green;
                validCheck = true;
            }
            else
            {
                labelKiemTra.Text = "Thời gian đã bị trùng lặp";
                labelKiemTra.ForeColor = Color.Red;
                validCheck = false;
            }
        }

        // load form DatTiec
        private void DatTiec_Load(object sender, EventArgs e)
        {
            comboBoxSanh.DropDownClosed += new EventHandler(
                comboBoxSanh_DropDownClosed);

            comboBoxSLBan.Enabled = false;
            labelKiemTra.Text = "";
            validCheck = false;
        }

        // sự kiện nhấn nút thành tiền: hiển thị số tiền và tiền cọc vào textBox
        private void buttonThanhTien_Click(object sender, EventArgs e)
        {
            double tongTien = 0;
            foreach(ListViewItem item in listViewDichVu.Items)
            {
                tongTien = tongTien
                    + float.Parse(item.SubItems[2].Text.Trim())
                    * float.Parse(item.SubItems[3].Text.Trim());
            }
            foreach (ListViewItem item in listViewMonAn.Items)
            {
                tongTien = tongTien
                    + double.Parse(item.SubItems[2].Text.Trim())
                    * int.Parse(comboBoxSLBan.Text);
            }

            textBoxTongTien.Text = tongTien.ToString();
            textBoxTienCoc.Text = (tongTien * 60 / 100).ToString();
        }

        // sự kiện nhấn nút hủy món ăn: hủy danh sách món ăn
        private void buttonHuyMonAn_Click(object sender, EventArgs e)
        {
            listViewMonAn.Items.Clear();
        }

        // sự kiện nhấn nút hủy dịch vụ: hủy danh sách dịch vụ
        private void buttonHuyDichVu_Click(object sender, EventArgs e)
        {
            listViewDichVu.Items.Clear();
        }
    }
}
