using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMNNPM.SQL
{
    class MonAnSQL
    {
        public static DataTable loadMonAn()
        {
            return DatabaseQuery.queryTable(
                "SELECT * FROM MONAN ORDER BY TENMONAN;");
        }

        public static bool loadListViewMonAn(ListView lv)
        {
            DataTable monan = loadMonAn();

            if (lv.Items.Count > 0)
            {
                lv.Items.Clear();
            }
            for (int i = 0; i < monan.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = (i + 1).ToString();
                item.SubItems.Add(monan.Rows[i]["TENMONAN"].ToString());
                item.SubItems.Add(monan.Rows[i]["GIA"].ToString());

                lv.Items.Add(item);
            }
            return true;
        }

        public static bool loadMonAnFromTenMonAn(String tenmonan,
            TextBox tenmonan1,
            TextBox gia)
        {
            DataTable table = DatabaseQuery.queryTable(
                "SELECT * FROM MONAN "
                + "WHERE MONAN.TENMONAN = '" + tenmonan + "';");
            if (table.Rows.Count > 0)
            {
                tenmonan1.Text = table.Rows[0]["TENMONAN"]
                    .ToString()
                    .TrimEnd();
                gia.Text = table.Rows[0]["GIA"]
                    .ToString()
                    .Trim();
                return true;
            }
            else return false;
        }

        public static bool insertMonAn(String tenmonan, String gia)
        {
            DataTable table = DatabaseQuery.queryTable(
                "SELECT * FROM MONAN WHERE TENMONAN = '" + tenmonan + "';");
            if (table.Rows.Count > 0)
            {
                return false;
            }

            table = DatabaseQuery.queryTable(
                "INSERT INTO MONAN VALUES('" + DatabaseQuery.generateID("MA")
                + "', '" + tenmonan
                + "', '" + gia
                + "');");
            return true;
        }

        public static bool updateMonAn(String tenmonan, String gia)
        {
            DataTable table = DatabaseQuery.queryTable(
                "SELECT * FROM MONAN WHERE TENMONAN = '"
                + tenmonan.TrimEnd() + "';");
            if (table.Rows.Count <= 0)
            {
                return false;
            }

            table = DatabaseQuery.queryTable(
                "UPDATE MONAN SET "
                + "GIA = '" + gia
                + "' WHERE TENMONAN = '" + tenmonan.TrimEnd() + "';");
            return true;
        }

        public static String getMaMonAnFromTenMonAn(String tenmonan)
        {
            DataTable table = DatabaseQuery.queryTable(
                "SELECT MAMONAN FROM MONAN "
                + "WHERE TENMONAN = '" + tenmonan.TrimEnd()
                + "';");

            if (table.Rows.Count > 0)
            {
                return table.Rows[0][0].ToString().Trim();
            }
            else
                return "";
        }

        public static bool deleteMonAn(String tenmonan)
        {
            String mamonan = getMaMonAnFromTenMonAn(tenmonan)
                .Trim();

            DataTable thucdon = DatabaseQuery.queryTable(
                "SELECT * FROM THUCDON "
                + "WHERE THUCDON.MAMONAN = '" + mamonan + "';");

            if (thucdon.Rows.Count <= 0)
            {
                DataTable dsmonan = DatabaseQuery.queryTable(
                    "DELETE FROM MONAN WHERE TENMONAN = '" + tenmonan + "';");
                return true;
            }
            else return false;
        }
    }
}
