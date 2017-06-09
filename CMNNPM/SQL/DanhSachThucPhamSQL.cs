using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMNNPM.SQL
{
    class DanhSachThucPhamSQL
    {
        // trả ra DataTable từ bảng MONAN và THUCDON
        public static DataTable loadDSThucPham()
        {
            DataTable table = DatabaseQuery.queryTable(
                "SELECT MONAN.MAMONAN, MONAN.TENMONAN, MONAN.GIA, THUCDON.GHICHU FROM "
                + "MONAN LEFT JOIN THUCDON ON MONAN.MAMONAN = THUCDON.MAMONAN "
                + "ORDER BY TENMONAN ASC;");
            return table;
        }

        // lấy danh sách thực phẩm vào ListView lv
        public static bool loadListViewDanhSachThucPham(ListView lv)
        {            
            DataTable table = loadDSThucPham();

            if (lv.Items.Count > 0)
            {
                lv.Clear();
            }
            for (int i = 0; i < table.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = (i + 1).ToString();
                item.SubItems.Add(table.Rows[i]["TENMONAN"].ToString());
                item.SubItems.Add(table.Rows[i]["GIA"].ToString());
                item.SubItems.Add(table.Rows[i]["GHICHU"].ToString());

                lv.Items.Add(item);
            }
            return true;        
    }

    }
}
