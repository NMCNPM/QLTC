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
        private ListView danhSachDichVu;

        public DanhSachDichVu(DatTiec dt, ListView lv)
        {
            dtForm = dt;
            danhSachDichVu = lv;
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

        public void addItem(ListView startList, ListView endList)
        {
            foreach (ListViewItem item in startList.Items)
            {
                if (item.Selected == true)
                {
                    ListViewItem selectedItem = (ListViewItem)item.Clone();
                    selectedItem.Text = (endList.Items.Count + 1).ToString();

                    endList.Items.Add(selectedItem);
                    break;
                }
            }
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            addItem(listViewDichVu, danhSachDichVu);
        }
    }
}
