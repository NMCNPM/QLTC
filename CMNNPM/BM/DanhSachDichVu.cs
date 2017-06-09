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

        // constructor cho form DanhSachDichVu: truyền vào form DatTiec, ListView lv
        // từ form DatTiec
        public DanhSachDichVu(DatTiec dt, ListView lv)
        {
            dtForm = dt;
            danhSachDichVu = lv;
            InitializeComponent();
        }

        // load form DanhSachDichVu
        private void DanhSachDichVu_Load(object sender, EventArgs e)
        {
            
            DanhSachDichVuSQL.loadDatabaseDichVu(listViewDichVu);
            listViewDichVu.FullRowSelect = true;
        }

        // sự kiện nhấn nút hoàn thành form: đóng form
        private void buttonHoanThanh_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // thêm Item được chọn từ startList vào endList
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

        // sự kiện nhấn nút thêm: thêm hàng được chọn từ listViewDichVu
        // sang danhSachDichVu ở form DatTiec
        private void buttonThem_Click(object sender, EventArgs e)
        {
            addItem(listViewDichVu, danhSachDichVu);
        }
    }
}
