﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMNNPM.SQL
{
    class DanhSachDichVuSQL
    {
        // trả ra DataTable từ bảng DICHVU và DANHSACHDICHVU        
        public static DataTable loadDSDichVu()
        {
            DataTable table = DatabaseQuery.queryTable(
                "SELECT TENDICHVU, SOLUONG, GIA FROM "
                + "DICHVU LEFT JOIN DANHSACHDV ON DICHVU.MADICHVU = DANHSACHDV.MADICHVU "
                + "ORDER BY TENDICHVU ASC;");
            return table;
        }

        // danh sách các dịch vụ vào ListView lv
        public static void loadDatabaseDichVu(ListView lv)
        {            

            DataTable DichVu = loadDSDichVu();

            if (lv.Items.Count > 0)
            {
                lv.Clear();
            }
            for (int i = 0; i < DichVu.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = (i + 1).ToString();
                item.SubItems.Add(DichVu.Rows[i]["TENDICHVU"].ToString());
                item.SubItems.Add(DichVu.Rows[i]["SOLUONG"].ToString());
                item.SubItems.Add(DichVu.Rows[i]["GIA"].ToString());

                lv.Items.Add(item);
            }
        }
    }
}
