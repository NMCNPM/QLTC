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

        public DatTiec( QuanLy ql)
        {
            quanLyForm = ql;
            isUpdate = false;
            InitializeComponent();
            addItemToComboSanh();
            addItemToLoaiSanh();

            addItemToComboCa();
        }

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
              
        public void updateListViews()
        {
            DatTiecSQL.loadDatabaseDSDichVu(listViewDichVu, maTiecCuoi);
            DatTiecSQL.loadDatabaseDanhSachThucPham(listViewMonAn, maTiecCuoi);
        }

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

        private void btnThemMonAn_Click(object sender, EventArgs e)
        {
            thucPhamForm = new DanhSachThucPham(this, listViewMonAn);
            thucPhamForm.Show();
            thucPhamForm.Location = new Point(
                this.Location.X + this.Width
                , this.Location.Y);
        }
        private void buttonThemDichVu_Click(object sender, EventArgs e)
        {
            dichVuForm = new DanhSachDichVu(this, listViewDichVu);            
            dichVuForm.Show();
            dichVuForm.Location = new Point(
                this.Location.X + this.Width
                , this.Location.Y);
        }

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

        private void buttonChapNhan_Click(object sender, EventArgs e)
        {
            validCheck = checkNull();
            if (validCheck == true)
            {
                DatTiecSQL.insertDatTiec(
                    textBoxTenChuRe.Text,
                    textBoxTenCoDau.Text,
                    textBoxSDT.Text,
                    dateTimePickerNgayDatTiec.Value,
                    textBoxLoaiSanh.Text,
                    comboBoxSanh.SelectedItem.ToString(),
                    comboBoxCa.SelectedItem.ToString(),
                    int.Parse(comboBoxSLBan.SelectedItem.ToString()),
                    int.Parse(textBoxSoBanDuTru.Text));

                quanLyForm.updateQuanLyForm();
                dichVuForm.Close();
                thucPhamForm.Close();
                this.Close();
            }
            else
            {
                MessageBox.Show("Thao tác không thực hiện được", "Lỗi!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }


        private void comboBoxSanh_DropDownClosed(object sender, EventArgs e)
        {
            String sanh = comboBoxSanh.SelectedItem.ToString();
            addItemToLoaiSanh();
            addItemToComboSLBan();
        }

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

        private void DatTiec_Load(object sender, EventArgs e)
        {
            comboBoxSanh.DropDownClosed += new EventHandler(
                comboBoxSanh_DropDownClosed);

            comboBoxSLBan.Enabled = false;
            labelKiemTra.Text = "";
            validCheck = false;
        }

        private void buttonThanhTien_Click(object sender, EventArgs e)
        {
            float tongTien = 0;
            foreach(ListViewItem item in listViewDichVu.Items)
            {
                tongTien = tongTien
                    + float.Parse(item.SubItems[2].Text.Trim())
                    * float.Parse(item.SubItems[3].Text.Trim());
            }
            foreach (ListViewItem item in listViewMonAn.Items)
            {
                tongTien = tongTien
                    + float.Parse(item.SubItems[2].Text.Trim())
                    * int.Parse(comboBoxSLBan.Text);
            }

            textBoxTongTien.Text = tongTien.ToString();
            textBoxTienCoc.Text = (tongTien * 60 / 100).ToString();
        }

        private void buttonHuyMonAn_Click(object sender, EventArgs e)
        {
            listViewMonAn.Items.Clear();
        }

        private void buttonHuyDichVu_Click(object sender, EventArgs e)
        {
            listViewDichVu.Items.Clear();
        }
    }
}
