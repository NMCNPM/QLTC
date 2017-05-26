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

namespace CMNNPM
{
    public partial class QuanTri : Form
    {
        public QuanTri()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThemSanh form = new ThemSanh();
            form.Show();
        }

        private void QuanTri_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            DataDataContext db = new DataDataContext();
            var dsDichVu = db.DICHVUs.ToList();
            var dsLoaiSanh = db.LOAISANHs.ToList();
            var dsSanh = db.SANHs.ToList();
            gridControlSanh.DataSource = dsSanh;
            gridControlLoaiSanh.DataSource = dsLoaiSanh;
            gridControlDV.DataSource = dsDichVu;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ThemMonAn form = new ThemMonAn();
            form.Show();
        }
    }
}
