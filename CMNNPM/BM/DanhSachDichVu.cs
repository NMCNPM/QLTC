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
    public partial class DanhSachDichVu : Form
    {
        private DatTiec dtForm;
        public DanhSachDichVu(DatTiec dt)
        {
            dtForm = dt;
            InitializeComponent();
        }

        private void DanhSachDichVu_Load(object sender, EventArgs e)
        {
            
            DanhSachDichVuSQL.loadDatabaseDichVu(listViewDichVu);
            listViewDichVu.FullRowSelect = true;
        }

        private void buttonHoanThanh_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {

        }
    }
}
