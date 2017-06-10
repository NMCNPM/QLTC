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

        // constructor cho form hóa đơn: truyền vào mã tiệc cưới từ form DatTiec
        public HoaDon(String mtc)
        {
            maTiecCuoi = mtc;
            InitializeComponent();
        }

        // sự kiện nhấn nút hủy bỏ: đóng form
        private void buttonHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // load form HoaDon: load các thông tin của tiệc cưới vào form
        // gồm tên cô dâu, tên chú rể, số lượng bàn, đơn giá bàn,
        // danh sách các dịch vụ sử dụng, ngày đặt tiệc, ngày thanh toán, 
        // tổng tiền dịch vụ, tổng tiền bàn, tổng tiền hóa đơn,
        // tiền cọc, Thành tiền phải trả
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
            //textBoxDonGia
           loadListViewDichVu(listViewDSDichVu);
           textBoxNgayDai.Text = table.Rows[0]["NGAYDATTIEC"]
                .ToString()
                .TrimEnd();
            textBoxNgayThanhToan.Text = table.Rows[0]["TENCODAU"]
                .ToString()
                .TrimEnd();

        }

        // load danh sách dịch vụ tiệc đã đặt vào ListView lv
        private void loadListViewDichVu(ListView lv)
        {
            //DatTiecSQL.load
        }
    }
}
