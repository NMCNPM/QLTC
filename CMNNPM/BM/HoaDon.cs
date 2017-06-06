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
    }
}
