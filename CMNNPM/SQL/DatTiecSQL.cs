using CMNNPM.SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMNNPM
{
    class DatTiecSQL
    {        
        private static DataTable DanhSachTiecCuoi;
        public static String MATIECCUOI = "";
        public static DataRow rowTiecCuoi;                      

        // truy vấn csdl, lấy danh sách dịch vụ từ mã tiệc cưới,
        // truyền dữ liệu vào ListView lv
        public static bool loadDatabaseDSDichVu(ListView lv, String maTiecCuoi)
        {            
            DataTable dvTable = DatabaseQuery.queryTable(
                "SELECT DANHSACHDV.MATIECCUOI, DICHVU.TENDICHVU, "
                + "DANHSACHDV.SOLUONG, DICHVU.GIA "
                + "FROM DANHSACHDV LEFT JOIN DICHVU "
                + "ON DANHSACHDV.MADICHVU = DICHVU.MADICHVU "
                + "WHERE DANHSACHDV.MATIECCUOI = '" 
                + maTiecCuoi.Trim() + "';");

            if (lv.Items.Count > 0)
            {
                lv.Items.Clear();
            }
            for (int i = 0; i < dvTable.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = (i + 1).ToString();
                item.SubItems.Add(dvTable.Rows[i]["TENDICHVU"].ToString());
                item.SubItems.Add(dvTable.Rows[i]["SOLUONG"].ToString());
                item.SubItems.Add(dvTable.Rows[i]["GIA"].ToString());

                lv.Items.Add(item);
            }
            return true;
        }

        // truy vấn csdl, lấy danh sách thực phẩm từ mã tiệc cưới,
        // truyền dữ liệu vào ListView lv 
        public static bool loadDatabaseDanhSachThucPham(ListView lv, String maTiecCuoi)
        {
            DataTable tpTable = DatabaseQuery.queryTable(
                "SELECT THUCDON.MATIECCUOI, MONAN.TENMONAN, "
                + "MONAN.GIA, THUCDON.GHICHU "
                + "FROM THUCDON LEFT JOIN MONAN "
                + "ON THUCDON.MAMONAN = MONAN.MAMONAN "
                + "WHERE THUCDON.MATIECCUOI = '"
                + maTiecCuoi.Trim() + "';");

            if (lv.Items.Count > 0)
            {
                lv.Items.Clear();
            }
            for (int i = 0; i < tpTable.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = (i + 1).ToString();
                item.SubItems.Add(tpTable.Rows[i]["TENMONAN"].ToString());
                item.SubItems.Add(tpTable.Rows[i]["GIA"].ToString());
                item.SubItems.Add(tpTable.Rows[i]["GHICHU"].ToString());

                lv.Items.Add(item);
            }
            return true;
        }

        public static void loadDatabaseLoaiSanh(ListView lv)
        {                      
            DataTable lsTable = DatabaseQuery.queryTable("SELECT * FROM LOAISANH");

            if (lv.Items.Count > 0)
            {
                lv.Clear();
            }
            for (int i = 0; i < lsTable.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = (i + 1).ToString();
                item.SubItems.Add(lsTable.Rows[i]["MALOAISANH"].ToString());
                item.SubItems.Add(lsTable.Rows[i]["TENLOAISANH"].ToString());
                item.SubItems.Add(lsTable.Rows[i]["DONGIABANTOITHIEU"].ToString());
                lv.Items.Add(item);
            }
        }

        // LOAD danh sách tiệc cưới biểu mẫu
        public static void loadDanhSachTiecCuoi(ListView lv)
        {
            DanhSachTiecCuoi = DatabaseQuery.queryTable(
                "SELECT TENCHURE, TENCODAU, TENSANH, NGAYDATTIEC, TENCA, SLBAN, SLBANDUTRU FROM (((TIECCUOI "
            + "JOIN KHACHHANG ON KHACHHANG.MAKHACHHANG = TIECCUOI.MAKHACHHANG) "
            + "JOIN SANH ON TIECCUOI.MASANH = SANH.MASANH) "
            + "JOIN CA ON TIECCUOI.MACA = CA.MACA);");

            if (lv.Items.Count > 0)
            {
                lv.Items.Clear();
            }
            int i = 1;
            foreach(DataRow row in DanhSachTiecCuoi.Rows)
            {
                ListViewItem item = new ListViewItem();
                item.Text = i.ToString();
                i++;
                item.SubItems.Add(row["TENCHURE"].ToString().TrimEnd());
                item.SubItems.Add(row["TENCODAU"].ToString().TrimEnd());
                item.SubItems.Add(row["TENSANH"].ToString().TrimEnd());
                item.SubItems.Add(row["NGAYDATTIEC"].ToString().TrimEnd());
                item.SubItems.Add(row["TENCA"].ToString().TrimEnd());
                item.SubItems.Add(row["SLBAN"].ToString().TrimEnd());
                item.SubItems.Add(row["SLBANDUTRU"].ToString().TrimEnd());

                lv.Items.Add(item);
            }
        }
        // Filter
        public static void locDanhSachTiecCuoi(ListView lv, string time)
        {
            DanhSachTiecCuoi = DatabaseQuery.queryTable(
                "SELECT TENCHURE, TENCODAU, TENSANH, NGAYDATTIEC, TENCA, SLBAN, SLBANDUTRU FROM (((TIECCUOI "
            + "JOIN KHACHHANG ON KHACHHANG.MAKHACHHANG = TIECCUOI.MAKHACHHANG) "
            + "JOIN SANH ON TIECCUOI.MASANH = SANH.MASANH) "
            + "JOIN CA ON TIECCUOI.MACA = CA.MACA)"+"WHERE(TIECCUOI.NGAYDATTIEC = '"+ time +"');");

            if (lv.Items.Count > 0)
            {
                lv.Items.Clear();
            }
            int i = 1;
            foreach (DataRow row in DanhSachTiecCuoi.Rows)
            {
                ListViewItem item = new ListViewItem();
                item.Text = i.ToString();
                i++;
                item.SubItems.Add(row["TENCHURE"].ToString().TrimEnd());
                item.SubItems.Add(row["TENCODAU"].ToString().TrimEnd());
                item.SubItems.Add(row["TENSANH"].ToString().TrimEnd());
                item.SubItems.Add(row["NGAYDATTIEC"].ToString().TrimEnd());
                item.SubItems.Add(row["TENCA"].ToString().TrimEnd());
                item.SubItems.Add(row["SLBAN"].ToString().TrimEnd());
                item.SubItems.Add(row["SLBANDUTRU"].ToString().TrimEnd());

                lv.Items.Add(item);
            }
        }

        public static bool insertKhachHang(String tenCoDau, String tenChuRe, String SDT)
        {
            DataTable tablet = DatabaseQuery.queryTable("INSERT INTO KHACHHANG VALUES('" + 
                DatabaseQuery.generateID("KH") + "','" +
                tenCoDau +"','" +
                tenChuRe + "', '"+
                SDT +"');");
           
            return true;
        }

        public static DataTable loadTenLoaiSanh()
        {            
            return DatabaseQuery.queryTable("SELECT LOAISANH.TENLOAISANH FROM LOAISANH");
        }

        public static DataTable loadCa()
        {
            return DatabaseQuery.queryTable("SELECT CA.TENCA FROM CA");
        }

        public static DataTable loadLoaiSanh()
        {
            return DatabaseQuery.queryTable("SELECT * FROM LOAISANH");
        }

        public static DataTable loadSanh()
        {
            return DatabaseQuery.queryTable("SELECT * FROM SANH");
        }
        public static DataTable loadTenSanh()
        {
            return DatabaseQuery.queryTable("SELECT SANH.TENSANH FROM SANH");
        }

        public static DataTable loadSLBanToiDa()
        {
            return DatabaseQuery.queryTable("SELECT SANH.SLBANTOIDA FROM SANH");
        }

        public static bool checkIfTiecCuoiExisted(String sanh, String ca, DateTime ngay)
        {
            DataTable tieccuoi = DatabaseQuery.queryTable(
                "select * from tieccuoi where masanh = '"
                + selectMaSanhFromTenSanh(sanh).Trim()
                + "' and maca = '" + selectMaCaFromTenCa(ca).Trim()
                + "' and ngaydattiec = '" + ngay + "';");

            if (tieccuoi.Rows.Count > 0)
                return false;
            return true;
        }

        public static String selectMaCaFromTenCa(String tenCa)
        {
            String maCa = "";
            DataTable caTable = DatabaseQuery.queryTable("SELECT CA.MACA FROM CA "
                + "WHERE CA.TENCA = '" + tenCa
                + "' ORDER BY CA.MACA DESC");

            maCa = caTable.Rows[0][0].ToString();
            return maCa;
        }

        public static String selectMaKhachHangFromCoDauChuRe(String tenCoDau, String tenChuRe)
        {
            String ma = "";
            DataTable mTable = DatabaseQuery.queryTable("SELECT KHACHHANG.MAKHACHHANG FROM KHACHHANG "
                + "WHERE KHACHHANG.TENCODAU = '" + tenCoDau
                + "' AND KHACHHANG.TENCHURE = '" + tenChuRe
                + "' ORDER BY KHACHHANG.MAKHACHHANG DESC");

            ma = mTable.Rows[0][0].ToString();
            return ma;
        }

        public static String selectMaSanhFromTenSanh(String tenSanh)
        {
            String ma = "";
            DataTable mTable = DatabaseQuery.queryTable("SELECT SANH.MASANH FROM SANH "
                + "WHERE SANH.TENSANH = '" + tenSanh
                + "' ORDER BY SANH.MASANH DESC");

            ma = mTable.Rows[0][0].ToString();
            return ma;
        }
        

        public static bool insertDatTiec(String tenChuRe, String tenCoDau, String SDT,
            DateTime ngayThang, String loaiSanh, String sanh, String ca,
            int slBan, int slBanDuTru)
        {
            
            insertKhachHang(tenCoDau, tenChuRe, SDT);
            DataTable khachhangTable = DatabaseQuery.queryTable("SELECT KHACHHANG.MAKHACHHANG FROM KHACHHANG WHERE "
                + "TENCODAU = '" + tenCoDau + "'AND "
                + "TENCHURE = '" + tenChuRe + "' ORDER BY KHACHHANG.MAKHACHHANG ASC;");

            DataTable tablet = DatabaseQuery.queryTable("INSERT INTO TIECCUOI VALUES('" +
                DatabaseQuery.generateID("TC") + "','" +
                selectMaKhachHangFromCoDauChuRe(tenCoDau, tenChuRe).Trim() + "','" +
                selectMaSanhFromTenSanh(sanh).Trim() + "', '" +
                selectMaCaFromTenCa(ca).Trim() + "', '" +
                ngayThang + "', '" +
                slBan + "', '" +
                slBanDuTru + "');");

            return true;
        }

        public static DataRow getSelectedTiecCuoiRow(int index)
        {
            DataRow mRow = DatabaseQuery.queryTable(
                "SELECT * FROM TIECCUOI ORDER BY MATIECCUOI ASC")
                .Rows[index];
            if (!mRow.IsNull("MATIECCUOI"))
            {
                rowTiecCuoi = mRow;
            }
                return mRow;            
        }

        public static bool updateDatTiec(String tenChuRe, String tenCoDau, String SDT,
            DateTime ngayThang, String loaiSanh, String sanh, String ca,
            int slBan, int slBanDuTru)
        {
            if (rowTiecCuoi != null)
            {
                DataTable khTable = DatabaseQuery.queryTable("UPDATE KHACHHANG SET "
                    + "TENCODAU = '" + tenCoDau + "', "
                    + "TENCHURE = '" + tenChuRe + "', "
                    + "SDT = '" + SDT
                    + "' WHERE MAKHACHHANG = '" 
                    + rowTiecCuoi["MAKHACHHANG"].ToString().Trim()+ "'");

                DataTable caTable = DatabaseQuery.queryTable("SELECT MACA FROM CA "
                    + "WHERE TENCA = '" + ca.Trim() + "';");
                String MACA = caTable.Rows[0][0].ToString().Trim();

                DataTable tcTable = DatabaseQuery.queryTable("UPDATE TIECCUOI SET "
                    + "NGAYDATTIEC = '" + ngayThang.ToString().TrimEnd() 
                    +"', SOLUONGBAN = '" + slBan 
                    + "', SLBANDUTRU = '" + slBanDuTru
                    + "', MACA = '" + MACA
                    + "' WHERE MATIECCUOI = '"
                    + rowTiecCuoi["MATIECCUOI"].ToString().TrimEnd() +"';");
            }
            return true;
        }
        
        public static DataTable loadDSThucPham()
        {
            DataTable table = DatabaseQuery.queryTable(
                "SELECT TENMONAN, GIA, GHICHU FROM "
                + "MONAN LEFT JOIN THUCDON ON MONAN.MAMONAN = THUCDON.MAMONAN "
                + "ORDER BY TENMONAN ASC");
            return table;
        }        

        public static DataTable loadTiecCuoiThucDon( String MATIECCUOI)
        {
            return DatabaseQuery.queryTable(
                "SELECT MATHUCDON, MATIECCUOI, MAMONAN, TENMONAN, GIA, GHICHU FROM "
                + "THUCDON LEFT JOIN MONAN ON MONAN.MAMONAN = THUCDON.MAMONAN " 
                + "WHERE MATIECCUOI = '" + MATIECCUOI + "';");
        }

        public static bool updateThucDon(DataTable thucDon)
        {
            DataTable table = DatabaseQuery.queryTable(
                "DELETE FROM THUCDON WHERE MATIECCUOI = '"
                + thucDon.Rows[0]["MATIECCUOI"].ToString().Trim()
                + "';");

            foreach (DataRow row in thucDon.Rows)
            {
                DataTable tdTable = DatabaseQuery.queryTable("INSERT INTO THUCDON VALUES ('"
                    + DatabaseQuery.generateID("TD")
                    + "', '" + row["MATIECCUOI"].ToString().Trim()
                    + "', '" + row["MAMONAN"].ToString().Trim()
                    + "', '" + row["GHICHU"].ToString().TrimEnd()
                    + "');");
            }
            return true;
        }

        public static bool deleteDanhSachTiecCuoiItem(String tencodau, String tenchure)
        {
            DataTable tieccuoi = DatabaseQuery.queryTable(
                "SELECT TIECCUOI.MATIECCUOI, TIECCUOI.MAKHACHHANG FROM TIECCUOI "
                + "JOIN KHACHHANG ON TIECCUOI.MAKHACHHANG = KHACHHANG.MAKHACHHANG "
                + "WHERE TENCODAU = '" + tencodau.TrimEnd()
                + "' AND TENCHURE = '" + tenchure.TrimEnd() + "';");

            String matieccuoi = tieccuoi.Rows[0]["MATIECCUOI"].ToString().Trim();

            DataTable table = DatabaseQuery.queryTable(
                "DELETE FROM HOADON WHERE MATIECCUOI = '"
                + matieccuoi
                + "';");

            table = DatabaseQuery.queryTable(
                "DELETE FROM THUCDON WHERE MATIECCUOI = '"
                + matieccuoi + "';");

            table = DatabaseQuery.queryTable(
                "DELETE FROM DANHSACHDV WHERE MATIECCUOI = '"
                + matieccuoi + "';");

            table = DatabaseQuery.queryTable(
                "DELETE FROM TIECCUOI WHERE MATIECCUOI = '"
                + matieccuoi
                + "';");

            String makhachhang = tieccuoi.Rows[0]["MAKHACHHANG"].ToString().Trim();

            table = DatabaseQuery.queryTable(
                "DELETE FROM KHACHHANG WHERE MAKHACHHANG = '"
                + makhachhang
                + "';");
           
            return true;
        }
        
        public static DataTable getTiecCuoiInfo(String maTiecCuoi)
        {
            return DatabaseQuery.queryTable(
                "SELECT TENCHURE, TENCODAU, TENSANH, NGAYDATTIEC, "
                + "TENCA, SLBAN, SLBANDUTRU, SDT FROM (((TIECCUOI "
                + "JOIN KHACHHANG ON KHACHHANG.MAKHACHHANG = TIECCUOI.MAKHACHHANG) "
                + "JOIN SANH ON TIECCUOI.MASANH = SANH.MASANH) "
                + "JOIN CA ON TIECCUOI.MACA = CA.MACA);");
        }
       
    }
}
