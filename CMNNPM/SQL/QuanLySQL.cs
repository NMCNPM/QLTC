using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMNNPM.SQL
{
    class QuanLySQL
    {
        public static String getMaKhacHang(ListView lv)
        {
            foreach (ListViewItem item in lv.Items)
            {
                if (item.Selected == true)
                {
                    return DatTiecSQL.selectMaKhachHangFromCoDauChuRe(
                        item.SubItems[2].Text
                        , item.SubItems[1].Text);
                }
            }
            return "";
        }

        public static String getMaTiecCuoi(ListView lv)
        {
            String maKhachHang = getMaKhacHang(lv);
            DataTable table = DatabaseQuery.queryTable(
                "SELECT MATIECCUOI FROM TIECCUOI "
                + "WHERE MAKHACHHANG = '" + maKhachHang + "';");
            if (table.Rows.Count <= 0)
                return "";
            return table.Rows[0][0].ToString().Trim();
        }
    }
}
