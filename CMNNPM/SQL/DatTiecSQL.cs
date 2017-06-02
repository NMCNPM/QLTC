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
        //private DataTable mTable;

        private OleDbConnection mConn;
        private OleDbCommand mComm;
        private OleDbConnection mConnLoaiSanh;

        private OleDbDataAdapter DichVuAdapter;
        private OleDbDataAdapter LoaiSanhAdapter;        

        private static DataTable DichVu;
        private static DataTable LoaiSanh;
        private static DataTable DanhSachTiecCuoi;

        public static String MATIECCUOI = "";
        public static DataRow rowTiecCuoi;              

        private void createConnection()
        {
            mConn = new OleDbConnection(DatabaseQuery.CONNECTION_STRING);
            mConn.Open();
            mComm = new OleDbCommand("select * from DICHVU", mConn);
            DichVu = new DataTable();
            DichVu.Load(mComm.ExecuteReader());

            mComm = new OleDbCommand("select * from LOAISANH", mConn);
            LoaiSanh = new DataTable();
            LoaiSanh.Load(mComm.ExecuteReader());

        }

        public static bool loadDatabaseDichVu(ListView lv)
        {
            SqlConnection mConnection = new SqlConnection();
            mConnection.ConnectionString = DatabaseQuery.CONNECTION_STRING;
            mConnection.Open();

            SqlCommand mCommand = mConnection.CreateCommand();
            mCommand.CommandText = "select * from DICHVU;";

            SqlDataAdapter mAdapter = new SqlDataAdapter();
            mAdapter.SelectCommand = mCommand;

            DichVu = new DataTable();
            mAdapter.Fill(DichVu);
            mConnection.Close();
            if (lv.Items.Count > 0)
            {
                lv.Clear();
            }
            for (int i = 0; i < DichVu.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = (i + 1).ToString();
                item.SubItems.Add(DichVu.Rows[i]["MADICHVU"].ToString());
                item.SubItems.Add(DichVu.Rows[i]["TENDICHVU"].ToString());
                item.SubItems.Add(DichVu.Rows[i]["GIADICHVU"].ToString());

                lv.Items.Add(item);
            }
            return true;
        }

        public static void loadDatabaseLoaiSanh(ListView lv)
        {
            SqlConnection mConnection = new SqlConnection();
            mConnection.ConnectionString = DatabaseQuery.CONNECTION_STRING;
            mConnection.Open();

            SqlCommand mCommand = mConnection.CreateCommand();
            mCommand.CommandText = "select * from LOAISANH;";

            SqlDataAdapter mAdapter = new SqlDataAdapter();
            mAdapter.SelectCommand = mCommand;

            DichVu = new DataTable();
            mAdapter.Fill(DichVu);
            mConnection.Close();
            if (lv.Items.Count > 0)
            {
                lv.Clear();
            }
            for (int i = 0; i < DichVu.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = (i + 1).ToString();
                item.SubItems.Add(DichVu.Rows[i]["MALOAISANH"].ToString());
                item.SubItems.Add(DichVu.Rows[i]["TENLOAISANH"].ToString());
                item.SubItems.Add(DichVu.Rows[i]["DONGIABANTOITHIEU"].ToString());

                lv.Items.Add(item);
            }
        }

        public static void loadDatabaseDanhSachTiecCuoi(ListView lv)
        {
            SqlConnection mConnection = new SqlConnection();
            mConnection.ConnectionString = DatabaseQuery.CONNECTION_STRING;
            mConnection.Open();

            SqlCommand mCommand = mConnection.CreateCommand();
            mCommand.CommandText =
            " SELECT * FROM TIECCUOI "
            + "JOIN KHACHHANG ON KHACHHANG.MAKHACHHANG = TIECCUOI.MAKHACHHANG"
            + "JOIN SANH ON TIECCUOI.MASANH = SANH.MASANH"
            + "JOIN CA ON TIECCUOI.MACA = CA.MACA";

            SqlDataAdapter mAdapter = new SqlDataAdapter();
            mAdapter.SelectCommand = mCommand;

            DichVu = new DataTable();
            mAdapter.Fill(DichVu);
            mConnection.Close();
            if (lv.Items.Count > 0)
            {
                lv.Clear();
            }
            for (int i = 0; i < DichVu.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = (i + 1).ToString();
                item.SubItems.Add(DichVu.Rows[i]["MALOAISANH"].ToString());
                item.SubItems.Add(DichVu.Rows[i]["TENLOAISANH"].ToString());
                item.SubItems.Add(DichVu.Rows[i]["DONGIABANTOITHIEU"].ToString());

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
            if (MATIECCUOI != null)
            {
                DataTable mTable = DatabaseQuery.queryTable("UPDATE KHACHHANG SET "
                    + "TENCODAU = '" + tenCoDau + "', "
                    + "TENCHURE = '" + tenChuRe + "', "
                    + "SDT = '" + SDT
                    + "' WHERE MAKHACHHANG = '" + rowTiecCuoi["MAKHACHHANG"]+ "'");

            }
            return true;
        }

        public static DataTable loadDichVu()
        {
            return DatabaseQuery.queryTable("SELECT TENMONAN, GIA FROM MONAN ");
        }

        public static DataTable loadThucDon()
        {
            DataTable table = DatabaseQuery.queryTable(
                "SELECT TENMONAN, GIA, GHICHU FROM "
                + "MONAN JOIN THUCDON ON MONAN.MAMONAN = THUCDON.MAMONAN "
                + "ORDER BY TENMONAN ASC");
            return table;
        }

        public void close()
        {
            mConn.Close();
            mConnLoaiSanh.Close();
        }
    }
}
