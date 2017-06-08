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
    public partial class HoaDon : Form
    {
        private String maTiecCuoi;

        public HoaDon(String mtc)
        {
            maTiecCuoi = mtc;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HoaDon_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Top;
            DataTable table = DatTiecSQL.getTiecCuoiInfo(maTiecCuoi);

            if (table.Rows.Count < 1)
                return;

            textBoxTenChuRe.Text = table.Rows[0]["TENCHURE"]
                .ToString()
                .TrimEnd();
            textBoxTenCoDau.Text = table.Rows[0]["TENCODAU"]
                .ToString()
                .TrimEnd();
            textBoxSLBan.Text = table.Rows[0]["SLBAN"]
                .ToString()
                .TrimEnd();
            //textBoxDonGia.Text =;
            loadListViewDichVu(listViewDSDichVu);
            textBoxNgayDai.Text = table.Rows[0]["NGAYDATTIEC"]
                .ToString()
                .TrimEnd();
            textBoxNgayThanhToan.Text = table.Rows[0]["TENCODAU"]
                .ToString()
                .TrimEnd();

        }

        private void loadListViewDichVu(ListView lv)
        {

        }
    }
}
