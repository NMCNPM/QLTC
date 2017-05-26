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
            // TODO: This line of code loads data into the 'qLTCDataSet4.MONAN' table. You can move, or remove it, as needed.
            this.mONANTableAdapter.Fill(this.qLTCDataSet4.MONAN);

        }
    }
}
