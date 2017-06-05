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

        public QuanTri()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tsForm = new ThemSanh(this);
            tsForm.Show();
        }

        public void updateSanh()
        {
            gridControlSanh.DataSource = SanhSQL.loadSanh();
        }

        private void QuanTri_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            
            gridControlMonAn.DataSource = DatabaseQuery.queryTable(
                "SELECT MAMONAN, TENMONAN, GIA FROM MONAN ORDER BY TENMONAN;");

            gridControlDV.DataSource = DanhSachDV.loadDichVu();

            gridControlLoaiSanh.DataSource = DatabaseQuery.queryTable(
                "SELECT MALOAISANH, TENLOAISANH, DONGIABANTOITHIEU FROM LOAISANH ORDER BY TENLOAISANH;");

            //gridControlSanh.DataSource = DatabaseQuery.queryTable(
            //    "SELECT MASANH, TENSANH, TENLOAISANH, SLBANTOIDA, GHICHU FROM "
            //    + "SANH LEFT JOIN LOAISANH ON SANH.MALOAISANH = LOAISANH.MALOAISANH "
            //    + "ORDER BY TENSANH;");
            updateSanh();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ThemMonAn form = new ThemMonAn();
            form.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ThemLoaiSanh form = new ThemLoaiSanh();
            form.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ThemDichVu form = new ThemDichVu();
            form.Show();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            BaoCaoDoanhSo form = new BaoCaoDoanhSo();
            form.Show();
        }
    }
}
