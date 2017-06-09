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

        // constructor cho form DanhSachThucPham: truyền vào form DatTiec,
        // ListView lv từ form DatTiec
        public DanhSachThucPham(DatTiec dt, ListView lv)
        {
            dtForm = dt;
            danhSachMonAn = lv;
            InitializeComponent();
        }

        // sự kiện nhấn nút hoàn thành: đóng form
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // load form DanhSachThucPham
        private void DanhSachThucPham_Load(object sender, EventArgs e)
        {
            DanhSachThucPhamSQL.loadListViewDanhSachThucPham(listViewDanhSachThucPham);
            listViewDanhSachThucPham.FullRowSelect = true;
        }
        
        // thêm item được chọn từ startList vào endList
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

        // sự kiện nhấn nút thêm
        private void buttonThem_Click(object sender, EventArgs e)
        {
            addItem(listViewDanhSachThucPham, danhSachMonAn);
        }
    }
}
