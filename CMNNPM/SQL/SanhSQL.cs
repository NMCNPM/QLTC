using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMNNPM.SQL
{
    class SanhSQL
    {
        public static DataTable loadSanh()
        {
            return DatabaseQuery.queryTable(
                "SELECT SANH.TENSANH, LOAISANH.TENLOAISANH, "
                + "SANH.SLBANTOIDA, LOAISANH.DONGIABANTOITHIEU, SANH.GHICHU "
                + "FROM SANH JOIN LOAISANH ON SANH.MALOAISANH = LOAISANH.MALOAISANH;");
        }

        public static bool loadListViewDSSanh(ListView lv)
        {

            DataTable sanh = loadSanh();

            if (lv.Items.Count > 0)
            {
                lv.Items.Clear();
            }
            for (int i = 0; i < sanh.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = (i + 1).ToString();
                item.SubItems.Add(sanh.Rows[i]["TENSANH"].ToString());
                item.SubItems.Add(sanh.Rows[i]["TENLOAISANH"].ToString());
                item.SubItems.Add(sanh.Rows[i]["SLBANTOIDA"].ToString());
                item.SubItems.Add(sanh.Rows[i]["DONGIABANTOITHIEU"].ToString());
                item.SubItems.Add(sanh.Rows[i]["GHICHU"].ToString());

                lv.Items.Add(item);

            }
            return true;
        }

        public static bool insertSanh(String tenloaisanh, String tensanh,
            int slbantoida, String ghichu)
        {
            DataTable table = DatabaseQuery.queryTable(
                "SELECT * FROM SANH WHERE TENSANH = '" + tensanh + "';");
            if(table.Rows.Count > 0)
            {
                return false;
            }

            String maloaisanh = LoaiSanhSQL
                .getMaLoaiSanhFromTenLoaiSanh(tenloaisanh)
                .Trim();

            table = DatabaseQuery.queryTable(
                "INSERT INTO SANH VALUES('" + DatabaseQuery.generateID("S")
                + "', '"+ maloaisanh 
                + "', '" + tensanh.TrimEnd()
                + "', '" + slbantoida
                + "', '" + ghichu + "');");
            return true;
        }

        public static bool updateSanh(String tenloaisanh, String tensanh,
            int slbantoida, String ghichu)
        {
            DataTable table = DatabaseQuery.queryTable(
                "SELECT * FROM SANH WHERE TENSANH = '" + tensanh + "';");
            if (table.Rows.Count <= 0)
            {
                return false;
            }

            String maloaisanh = LoaiSanhSQL
                .getMaLoaiSanhFromTenLoaiSanh(tenloaisanh)
                .Trim();

            table = DatabaseQuery.queryTable(
                "UPDATE SANH SET "
                + "MALOAISANH = '" + maloaisanh
                + "', SLBANTOIDA = '" + slbantoida
                + "', GHICHU = '" + ghichu + "' "
                + "WHERE TENSANH = '" + tensanh.TrimEnd() + "';");
            return true;
        }

        public static bool deleteDSSanh(String tensanh)
        {
            DataTable tieccuoi = DatabaseQuery.queryTable(
                "SELECT TIECCUOI.MATIECCUOI FROM "
                + "TIECCUOI JOIN SANH ON SANH.MASANH = TIECCUOI.MASANH "
                + " WHERE SANH.TENSANH = '" + tensanh + "';");

            if (tieccuoi.Rows.Count <= 0)
            {
                DataTable sanh = DatabaseQuery.queryTable(
                    "DELETE FROM SANH WHERE TENSANH = '" + tensanh + "';");
                return true;
            }
            else return false;
        }

        public static bool loadSanhFromTenSanh(String tensanh,
            TextBox tensanh1,
            ComboBox loaisanh,
            TextBox slbantoida, 
            TextBox ghichu)
        {
            DataTable table = DatabaseQuery.queryTable(
                "SELECT * FROM SANH JOIN LOAISANH ON SANH.MALOAISANH = LOAISANH.MALOAISANH "
                + "WHERE SANH.TENSANH = '" + tensanh + "';");
            if (table.Rows.Count > 0)
            {
                tensanh1.Text = table.Rows[0]["TENSANH"].ToString().Trim();
                loaisanh.Text = table.Rows[0]["TENLOAISANH"].ToString().Trim();
                slbantoida.Text = table.Rows[0]["SLBANTOIDA"].ToString().Trim();
                ghichu.Text = table.Rows[0]["GHICHU"].ToString().Trim();
                return true;
            }
            else return false;
        }
    }
}
