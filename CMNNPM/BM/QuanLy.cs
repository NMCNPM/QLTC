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
    public partial class QuanLy : Form
    {
        private DataTable danhSachTiecCuoi;
        private DatTiec dtForm;

        // constructor form quản lý: cài đặt công cụ nhập xuất 
        //ngày, tháng
        public QuanLy()
        {
            InitializeComponent();
            setDefault();
            setMonthComboBox();
            setYearComboBox();
            setDateComboBox();
        }

        // cập nhật lại danh sách tiệc cưới vào listViewDanhSachTiecCuoi
        public void updateQuanLyForm()
        {
            DatTiecSQL.loadDanhSachTiecCuoi(listViewDanhSachTiecCuoi);
        }

        // sự kiện nhấn nút thêm tiệc cưới: mở form DatTiec thêm tiệc cưới
        private void buttonThemTiecCuoi_Click(object sender, EventArgs e)
        {
            dtForm = new DatTiec(this);
            dtForm.Show();
            dtForm.Location = new Point(50, 50);
            DatTiecSQL.loadDanhSachTiecCuoi(listViewDanhSachTiecCuoi);
        }

        // sự kiện chọn ngày trong montCalendar1
        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            string date = monthCalendar1.SelectionRange.Start.ToString("dd");
            string month = monthCalendar1.SelectionRange.Start.ToString("MM");
            string year = monthCalendar1.SelectionRange.Start.ToString("yyyy");
            cbDate.Text = date;
            cbMonth.Text = month;
            cbYear.Text = year;
        }

        // sự kiện sửa dữ liệu tại cbDate
        private void cbDate_TextUpdate(object sender, EventArgs e)
        {
            int[] dateOfMonth = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            try
            {
                monthCalendar1.SetDate(new DateTime(int.Parse(cbYear.Text), int.Parse(cbMonth.Text), int.Parse(cbDate.Text)));
            }
            catch
            {
                try
                {
                    if (int.Parse(cbDate.Text) < 1)
                        cbDate.Text = "1";
                    else
                    {
                        if ((((int.Parse(cbYear.Text) % 4 == 0) &&
                             !(int.Parse(cbYear.Text) % 100 == 0))
                             || (int.Parse(cbYear.Text) % 400 == 0)))
                        {
                            dateOfMonth[2] = 29;
                            cbDate.Text = dateOfMonth[int.Parse(cbMonth.Text)].ToString();
                        }
                        else
                        {
                            if (int.Parse(cbDate.Text) > dateOfMonth[int.Parse(cbMonth.Text)])
                                cbDate.Text = dateOfMonth[int.Parse(cbMonth.Text)].ToString();
                        }
                    }
                }
                catch
                {
                    return;
                }
            }
        }

        // sự kiện sửa dữ liệu tại cbMonth
        private void cbMonth_TextUpdate(object sender, EventArgs e)
        {
            try
            {
                monthCalendar1.SetDate(new DateTime(int.Parse(cbYear.Text), int.Parse(cbMonth.Text), int.Parse(cbDate.Text)));
            }
            catch
            {
                try
                {
                    if (int.Parse(cbMonth.Text) < 1)
                        cbMonth.Text = "1";
                    if (int.Parse(cbMonth.Text) > 12)
                        cbMonth.Text = "12";
                }
                catch
                {
                    return;
                }
                
            }
        }

        // sự kiện sửa dữ liệu tại cbYear
        private void cbYear_TextUpdate(object sender, EventArgs e)
        {
            cbDate.Items.Clear();
            cbDate.ResetText();
            resetDateComboBox();
            monthCalendar1.SetDate(new DateTime(int.Parse(cbYear.Text), int.Parse(cbMonth.Text), int.Parse(cbDate.Text)));
        }
        //add năm
        private void setDefault()
        {
            string date = monthCalendar1.SelectionRange.Start.ToString("dd");
            string month = monthCalendar1.SelectionRange.Start.ToString("MM");
            string year = monthCalendar1.SelectionRange.Start.ToString("yyyy");
            cbDate.Text = date;
            cbMonth.Text = month;
            cbYear.Text = year;
        }
        //add năm
        private void setYearComboBox()
        {
            string strThisYear = monthCalendar1.SelectionRange.Start.ToString("yyyy");
            int intThisYear = int.Parse(strThisYear);
            int count = -1; ;
            for (int i = 2000; i <= intThisYear; i++)
            {
                cbYear.Items.Add(i);
                count++;
            }
        }
        //add tháng
        private void setMonthComboBox()
        {
            string strThisMonth = monthCalendar1.SelectionRange.Start.ToString("MM");
            int intThisMonth = int.Parse(strThisMonth);
            int monthIndex = intThisMonth - 1;
            for (int i = 1; i <= 12; i++)
            {
                cbMonth.Items.Add(i);
            }
        }
        //add ngày
        private void setDateComboBox()
        {
            string strThisYear = monthCalendar1.SelectionRange.Start.ToString("yyyy");
            int intThisYear = int.Parse(strThisYear);
            string strThisMonth = monthCalendar1.SelectionRange.Start.ToString("MM");
            int intThisMonth = int.Parse(strThisMonth);
            string strThisDate = monthCalendar1.SelectionRange.Start.ToString("dd");
            int intThisDate = int.Parse(strThisDate);
            int numDays = 0;
            int dateIndex;
            switch (intThisMonth)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    numDays = 31;
                    break;
                case 2:
                    if (((intThisYear % 4 == 0) &&
                         !(intThisYear % 100 == 0))
                         || (intThisYear % 400 == 0))
                        numDays = 29;
                    else
                        numDays = 28;
                    break;
                default:
                    numDays = 30;
                    break;
            }
            for (int i = 1; i <= numDays; i++)
            {
                cbDate.Items.Add(i);
            }
            dateIndex = intThisDate - 1;
            cbDate.SelectedIndex = dateIndex;
        }

        //reset combobox theo giá trị mới của tháng
        private void resetDateComboBox() 
        {
            string strThisYear = monthCalendar1.SelectionRange.Start.ToString("yyyy");
            int intThisYear = int.Parse(strThisYear);
            string strThisDate = monthCalendar1.SelectionRange.Start.ToString("dd");
            int intThisDate = int.Parse(strThisDate);
            int numDays = 0;
            int dateIndex;
            int selectedYear = int.Parse(cbYear.Text);
            switch (int.Parse(cbMonth.Text))
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    numDays = 31;
                    break;
                case 2:
                    if (((selectedYear % 4 == 0) &&
                         !(selectedYear % 100 == 0))
                         || (selectedYear % 400 == 0))
                        numDays = 29;
                    else
                        numDays = 28;
                    break;
                default:
                    numDays = 30;
                    break;
            }
            for (int i = 1; i <= numDays; i++)
            {
                cbDate.Items.Add(i);
            }
            dateIndex = intThisDate - 1;
            try
            {
                cbDate.SelectedIndex = dateIndex;
            }
            catch
            {
                try
                {
                    cbDate.SelectedIndex = dateIndex-1;
                }
                catch
                {
                    try
                    {
                        cbDate.SelectedIndex = dateIndex - 2;
                    }
                    catch
                    {
                        try
                        {
                            cbDate.SelectedIndex = dateIndex - 3;
                        }
                        catch
                        {
                            return;
                        }
                    }
                }
            }
        }

        private void cbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbDate.Items.Clear();
            cbDate.ResetText();
            resetDateComboBox();//reset combobox theo giá trị mới của tháng
            monthCalendar1.SetDate(new DateTime(int.Parse(cbYear.Text), int.Parse(cbMonth.Text), int.Parse(cbDate.Text)));
        }

        private void cbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbDate.Items.Clear();
            cbDate.ResetText();
            resetDateComboBox();
            monthCalendar1.SetDate(new DateTime(int.Parse(cbYear.Text), int.Parse(cbMonth.Text), int.Parse(cbDate.Text)));
        }

        private void cbDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            monthCalendar1.SetDate(new DateTime(int.Parse(cbYear.Text),int.Parse(cbMonth.Text),int.Parse(cbDate.Text)));
        }

        // sự kiện nhấn nút đăng nhập: mở form đăng nhập
        private void buttonDangNhap_Click(object sender, EventArgs e)
        {
            DangNhap form = new DangNhap();
            form.Location = new Point(700, 500);
            form.Show();
        }

        // kiểm tra có item nào trong ListView lv được chọn không,
        // nếu có trả về true, nếu không xuất thông báo, trả về false
        public bool checkNullItemClick(ListView lv)
        {
            foreach (ListViewItem item in lv.Items)
            {
                if (item.Selected == true)
                {                    
                    return true;
                }
            }

            MessageBox.Show("Hãy chọn một tiệc cưới!",
                "Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            return false;
        }

        // sự kiện nhấn nút xuất hóa đơn: kiểm tra xem có tiệc đc chọn,
        // nếu có mở form hóa đơn
        private void buttonXuatHoaDon_Click(object sender, EventArgs e)
        {
            bool check = checkNullItemClick(listViewDanhSachTiecCuoi);
            if (check)
            {
                HoaDon form = new HoaDon(
                    QuanLySQL.getMaTiecCuoi(listViewDanhSachTiecCuoi));
                form.Show();
            }
        }

        // load form QuanLy
        private void QuanLy_Load(object sender, EventArgs e)
        {
            DatTiecSQL.loadDanhSachTiecCuoi(listViewDanhSachTiecCuoi);
            listViewDanhSachTiecCuoi.FullRowSelect = true;
        }

        // sự kiện nhấn nút xóa tiệc cưới đc chọn: kiểm tra tiệc đã đc chọn,
        // nếu có thì xóa tiệc, không có thì xuất thông báo
        private void buttonXoaTiec_Click(object sender, EventArgs e)
        {
            if (checkNullItemClick(listViewDanhSachTiecCuoi))
            {

                foreach (ListViewItem item in listViewDanhSachTiecCuoi.Items)
                {
                    if (item.Selected == true)
                    {
                        DatTiecSQL.deleteDanhSachTiecCuoiItem(
                            item.SubItems[2].Text, item.SubItems[1].Text);
                        break;
                    }
                }
                DatTiecSQL.loadDanhSachTiecCuoi(listViewDanhSachTiecCuoi);
            }
        }

        // sự kiện nhấn nút sửa tiệc cưới: kiểm tra tiệc đã đc chọn,
        // nếu có thì mở form DatTiec để sửa, không có thì xuất thông báo
        private void buttonSuaTiecCuoi_Click(object sender, EventArgs e)
        {
            if (checkNullItemClick(listViewDanhSachTiecCuoi))
            {
                String maTiecCuoi = QuanLySQL.getMaTiecCuoi(listViewDanhSachTiecCuoi);

                dtForm = new DatTiec(this, maTiecCuoi);

                dtForm.Show();
                dtForm.Location = new Point(50, 50);
                DatTiecSQL.loadDanhSachTiecCuoi(listViewDanhSachTiecCuoi);
            }
        }

    }
}
