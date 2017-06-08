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
    public partial class DanhSachThucPham : Form
    {
        private DatTiec dtForm;
        ListView danhSachMonAn;

        public DanhSachThucPham(DatTiec dt, ListView lv)
        {
            dtForm = dt;
            danhSachMonAn = lv;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DanhSachThucPham_Load(object sender, EventArgs e)
        {
            LoadData();
            listViewDanhSachThucPham.FullRowSelect = true;
        }
        private void LoadData()
        {
            DanhSachThucPhamSQL.loadListViewDanhSachThucPham(listViewDanhSachThucPham);
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
            dtForm.updateListViews();
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            addItem(listViewDanhSachThucPham, danhSachMonAn);
        }
    }
}
