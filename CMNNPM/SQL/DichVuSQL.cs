using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMNNPM.SQL
{
    class DichVuSQL
    {
        public static DataTable loadDichVu()
        {
            return DatabaseQuery.queryTable(
                "SELECT * FROM DICHVU ORDER BY TENDICHVU;");
        }

        public static bool loadListViewDichVu(ListView lv)
        {
            DataTable dichvu = loadDichVu();

            if (lv.Items.Count > 0)
            {
                lv.Items.Clear();
            }
            for (int i = 0; i < dichvu.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = (i + 1).ToString();
                item.SubItems.Add(dichvu.Rows[i]["TENDICHVU"].ToString());
                item.SubItems.Add(dichvu.Rows[i]["GIA"].ToString());

                lv.Items.Add(item);
            }
            return true;
        }

        public static bool loadDichVuFromTenDichVu(String tendichvu,
            TextBox tendichvu1,
            TextBox gia)
        {
            DataTable table = DatabaseQuery.queryTable(
                "SELECT * FROM DICHVU "
                + "WHERE DICHVU.TENDICHVU = '" + tendichvu + "';");

            if (table.Rows.Count > 0)
            {
                tendichvu1.Text = table.Rows[0]["TENDICHVU"]
                    .ToString()
                    .TrimEnd();
                gia.Text = table.Rows[0]["GIA"]
                    .ToString()
                    .Trim();
                return true;
            }
            else return false;
        }

        public static bool insertDichVu(String tendichvu, String gia)
        {
            DataTable table = DatabaseQuery.queryTable(
                "SELECT * FROM DICHVU WHERE TENDICHVU = '" + tendichvu + "';");
            if (table.Rows.Count > 0)
            {
                return false;
            }

            table = DatabaseQuery.queryTable(
                "INSERT INTO DICHVU VALUES('" + DatabaseQuery.generateID("DV")
                + "', '" + tendichvu
                + "', '" + gia
                + "');");
            return true;
        }

        public static bool updateDichVu(String tendichvu, String gia)
        {
            DataTable table = DatabaseQuery.queryTable(
                "SELECT * FROM DICHVU WHERE TENDICHVU = '"
                + tendichvu.TrimEnd() + "';");
            if (table.Rows.Count <= 0)
            {
                return false;
            }

            table = DatabaseQuery.queryTable(
                "UPDATE DICHVU SET "
                + "GIA = '" + gia
                + "' WHERE TENDICHVU = '" + tendichvu.TrimEnd() + "';");
            return true;
        }

        public static String getMaDichVuFromTenDichVu(String tendichvu)
        {
            DataTable table = DatabaseQuery.queryTable(
                "SELECT MADICHVU FROM DICHVU "
                + "WHERE TENDICHVU = '" + tendichvu.TrimEnd()
                + "';");

            if (table.Rows.Count > 0)
            {
                return table.Rows[0][0].ToString().Trim();
            }
            else
                return "";
        }

        public static bool deleteDichVu(String tendichvu)
        {
            String madichvu = getMaDichVuFromTenDichVu(tendichvu)
                .Trim();

            DataTable dsdichvu = DatabaseQuery.queryTable(
                "SELECT * FROM "
                + "DANHSACHDV "
                + "WHERE DANHSACHDV.MADICHVU = '" + madichvu + "';");

            if (dsdichvu.Rows.Count <= 0)
            {
                DataTable dsmonan = DatabaseQuery.queryTable(
                    "DELETE FROM DICHVU WHERE TENDICHVU = '" + tendichvu + "';");
                return true;
            }
            else return false;
        }
    }
}
