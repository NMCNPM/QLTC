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
    public partial class DanhSachThucPham : Form
    {
        public DanhSachThucPham()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DanhSachThucPham_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            DataDataContext db = new DataDataContext();
            var dsMonAn = db.MONANs.ToList();
            gridControlDSTP.DataSource = dsMonAn;
        }
    }
}
