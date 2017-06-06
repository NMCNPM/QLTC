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

        private QuanLy quanLyForm;

        public DatTiec( QuanLy ql)
        {
            quanLyForm = ql;
          
            InitializeComponent();
            addItemToComboSanh();
            addItemToLoaiSanh();

            addItemToComboCa();
        }

        public DatTiec(QuanLy ql, ListViewItem item)
        {
            quanLyForm = ql;

            InitializeComponent();
            addItemToComboSanh();
            addItemToLoaiSanh();
            addItemToComboCa();

            initExistedComponent(item);

        }

        private void initExistedComponent(ListViewItem item)
        {

        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DanhSachThucPham mForm = new DanhSachThucPham();
            mForm.Show();
            mForm.Location = new Point(this.Location.X + this.Width, this.Location.Y);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DanhSachDichVu mForm = new DanhSachDichVu();
            mForm.Show();
            mForm.Location = new Point(this.Location.X + this.Width, this.Location.Y);
        }

        private void buttonChapNhan_Click(object sender, EventArgs e)
        {
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
            //addItemToComboSanh();
            //addItemToLoaiSanh();
            //addItemToComboCa();
        }

        
    }
}
