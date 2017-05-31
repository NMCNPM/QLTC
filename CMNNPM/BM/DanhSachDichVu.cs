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
    public partial class DanhSachDichVu : Form
    {
        public DanhSachDichVu()
        {
            InitializeComponent();
        }

        private void DanhSachDichVu_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLTCDataSet.DICHVU' table. You can move, or remove it, as needed.
            this.dICHVUTableAdapter.Fill(this.qLTCDataSet.DICHVU);

        }
    }
}
