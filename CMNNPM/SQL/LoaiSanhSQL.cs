using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMNNPM.SQL
{
    class LoaiSanhSQL
    {

        public static DataTable loadLoaiSanh()
        {
            return DatabaseQuery.queryTable(
                "SELECT * FROM LOAISANH ORDER BY TENLOAISANH;");
        }

        public static String getMaLoaiSanhFromTenLoaiSanh(String tenloaisanh)
        {
            DataTable table = DatabaseQuery.queryTable(
                "SELECT MALOAISANH FROM LOAISANH "
                + "WHERE TENLOAISANH = '" + tenloaisanh.TrimEnd()
                + "';");

            if (table.Rows.Count > 0)
            {
                return table.Rows[0][0].ToString().Trim();
            }
            else
                return "";
        }

        public static bool loadListViewDSLoaiSanh(ListView lv)
        {

            DataTable loaisanh = loadLoaiSanh();

            if (lv.Items.Count > 0)
            {
                lv.Items.Clear();
            }
            for (int i = 0; i < loaisanh.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = (i + 1).ToString();
                item.SubItems.Add(loaisanh.Rows[i]["TENLOAISANH"].ToString());
                item.SubItems.Add(loaisanh.Rows[i]["DONGIABANTOITHIEU"].ToString());

                lv.Items.Add(item);

            }
            return true;
        }

        public static bool loadLoaiSanhFromTenLoaiSanh(String tenloaisanh,
            TextBox tenloaisanh1,
            TextBox dongiabantoithieu)
        {
            DataTable table = DatabaseQuery.queryTable(
                "SELECT * FROM LOAISANH "
                + "WHERE LOAISANH.TENLOAISANH = '" + tenloaisanh + "';");
            if (table.Rows.Count > 0)
            {
                tenloaisanh1.Text = table.Rows[0]["TENLOAISANH"]
                    .ToString()
                    .TrimEnd();
                dongiabantoithieu.Text = table.Rows[0]["DONGIABANTOITHIEU"]
                    .ToString()
                    .Trim();
                
                return true;
            }
            else return false;
        }

        public static bool insertLoaiSanh(String tenloaisanh, String dongiabantoithieu)
        {
            DataTable table = DatabaseQuery.queryTable(
                "SELECT * FROM LOAISANH WHERE TENLOAISANH = '" + tenloaisanh + "';");
            if (table.Rows.Count > 0)
            {
                return false;
            }
           
            table = DatabaseQuery.queryTable(
                "INSERT INTO LOAISANH VALUES('" + DatabaseQuery.generateID("LS")
                + "', '" + tenloaisanh
                + "', '" + dongiabantoithieu
                + "');");
            return true;
        }

        public static bool updateLoaiSanh(String tenloaisanh, String dongiabantoithieu)
        {
            DataTable table = DatabaseQuery.queryTable(
                "SELECT * FROM LOAISANH WHERE TENLOAISANH = '" 
                + tenloaisanh.TrimEnd() + "';");
            if (table.Rows.Count <= 0)
            {
                return false;
            }
           
            table = DatabaseQuery.queryTable(
                "UPDATE LOAISANH SET "
                + "DONGIABANTOITHIEU = '" + dongiabantoithieu
                + "' WHERE TENLOAISANH = '" + tenloaisanh.TrimEnd() + "';");
            return true;
        }

        public static bool deleteDSLoaiSanh(String tenloaisanh)
        {
            String maloaisanh = getMaLoaiSanhFromTenLoaiSanh(tenloaisanh)
                .Trim();

            DataTable sanh = DatabaseQuery.queryTable(
                "SELECT * FROM "
                + "SANH "
                + "WHERE SANH.MALOAISANH = '" + maloaisanh + "';");

            if (sanh.Rows.Count <= 0)
            {
                DataTable loaisanh = DatabaseQuery.queryTable(
                    "DELETE FROM LOAISANH WHERE TENLOAISANH = '" + tenloaisanh + "';");
                return true;
            }
            else return false;
        }
    }
}
