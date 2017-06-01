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
    class DatabaseData
    {
        //private DataTable mTable;

        private OleDbConnection mConn;
        private OleDbCommand mComm;
        private OleDbConnection mConnLoaiSanh;

        private OleDbDataAdapter DichVuAdapter;
        private OleDbDataAdapter LoaiSanhAdapter;

        private static String CONNECTION_STRING = 
            "Data Source=DESKTOP-DM3AGPH\\SQLEXPRESS;Initial Catalog=_QLTC;Integrated Security=True";

        private String DichVuName = "DICHVU";
        private String LoaiSanhName = "LOAISANH";
        private String KhachHangName = "KHACHHANG";
        private String CaName = "CA";
        private String DanhSachDVName = "DANHSACHDV";
        private String HoaDonName = "HOADON";
        private String MonAnName = "MONAN";
        private String SanhName = "SANH";
        private String TaiKhoanName = "TAIKHOAN";
        private String ThucDonName = "THUCDON";
        private String TiecCuoiName = "TIECCUOI";
        private String tableName = "qlnv2";

        private static DataTable DichVu;
        private static DataTable LoaiSanh;
        private static DataTable DanhSachTiecCuoi;
        private DataSet mSetDichVu;

        public string generateID(string Header)
        {
            string result = DateTime.Now.ToString("ddMMyyyyhhmmss");
            result = Header + result;
            return result;
        }

        public DataTable queryTable(String cmd)
        {
            DataTable mTable = new DataTable();

            SqlConnection khConnection = new SqlConnection();
            khConnection.ConnectionString = CONNECTION_STRING;
            khConnection.Open();

            SqlCommand khCommand = khConnection.CreateCommand();
            khCommand.CommandText = cmd;

            mTable.Load(khCommand.ExecuteReader());
            khConnection.Close();
            return mTable;
        }

        private void createConnection()
        {
            mConn = new OleDbConnection(CONNECTION_STRING);
            mConn.Open();
            mComm = new OleDbCommand("select * from DICHVU", mConn);
            DichVu = new DataTable();
            DichVu.Load(mComm.ExecuteReader());

            mComm = new OleDbCommand("select * from LOAISANH", mConn);
            LoaiSanh = new DataTable();
            LoaiSanh.Load(mComm.ExecuteReader());

        }

        public bool loadDatabaseDichVu(ListView lv)
        {
            SqlConnection mConnection = new SqlConnection();
            mConnection.ConnectionString = CONNECTION_STRING;
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

        public void loadDatabaseLoaiSanh(ListView lv)
        {
            SqlConnection mConnection = new SqlConnection();
            mConnection.ConnectionString = CONNECTION_STRING;
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

        public void loadDatabaseDanhSachTiecCuoi(ListView lv)
        {
            SqlConnection mConnection = new SqlConnection();
            mConnection.ConnectionString = CONNECTION_STRING;
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

        public bool insertKhachHang(String tenCoDau, String tenChuRe, String SDT)
        {
            DataTable tablet = queryTable("INSERT INTO KHACHHANG VALUES('" + 
                generateID("KH") + "','" +
                tenCoDau +"','" +
                tenChuRe + "', '"+
                SDT +"');");
           
            return true;
        }

        public DataTable loadTenLoaiSanh()
        {            
            return queryTable("SELECT LOAISANH.TENLOAISANH FROM LOAISANH");
        }

        public DataTable loadCa()
        {
            return queryTable("SELECT CA.TENCA FROM CA");
        }

        public DataTable loadLoaiSanh()
        {
            return queryTable("SELECT * FROM LOAISANH");
        }

        public DataTable loadSanh()
        {
            return queryTable("SELECT * FROM SANH");
        }
        public DataTable loadTenSanh()
        {
            return queryTable("SELECT SANH.TENSANH FROM SANH");
        }

        public DataTable loadSLBanToiDa()
        {
            return queryTable("SELECT SANH.SLBANTOIDA FROM SANH");
        }

        public String selectMaCaFromTenCa(String tenCa)
        {
            String maCa = "";
            DataTable caTable = queryTable("SELECT CA.MACA FROM CA "
                + "WHERE CA.TENCA = '" + tenCa
                + "' ORDER BY CA.MACA DESC");

            maCa = caTable.Rows[0][0].ToString();
            return maCa;
        }

        public String selectMaKhachHangFromCoDauChuRe(String tenCoDau, String tenChuRe)
        {
            String ma = "";
            DataTable mTable = queryTable("SELECT KHACHHANG.MAKHACHHANG FROM KHACHHANG "
                + "WHERE KHACHHANG.TENCODAU = '" + tenCoDau
                + "' AND KHACHHANG.TENCHURE = '" + tenChuRe
                + "' ORDER BY KHACHHANG.MAKHACHHANG DESC");

            ma = mTable.Rows[0][0].ToString();
            return ma;
        }

        public String selectMaSanhFromTenSanh(String tenSanh)
        {
            String ma = "";
            DataTable mTable = queryTable("SELECT SANH.MASANH FROM SANH "
                + "WHERE SANH.TENSANH = '" + tenSanh
                + "' ORDER BY SANH.MASANH DESC");

            ma = mTable.Rows[0][0].ToString();
            return ma;
        }

        public bool insertDatTiec(String tenChuRe, String tenCoDau, String SDT,
            DateTime ngayThang, String loaiSanh, String sanh, String ca,
            String slBan, String slBanDuTru)
        {
            insertKhachHang(tenCoDau, tenChuRe, SDT);
            DataTable khachhangTable = queryTable("SELECT KHACHHANG.MAKHACHHANG FROM KHACHHANG WHERE "
                + "TENCODAU = '" + tenCoDau + "'AND "
                + "TENCHURE = '" + tenChuRe + "' ORDER BY KHACHHANG.MAKHACHHANG ASC;");

            DataTable tablet = queryTable("INSERT INTO TIECCUOI VALUES('" +
                generateID("TC") + "','" +
                selectMaKhachHangFromCoDauChuRe(tenCoDau, tenChuRe).Trim() + "','" +
                selectMaSanhFromTenSanh(sanh).Trim() + "', '" +
                selectMaCaFromTenCa(ca).Trim() + "', '" +
                ngayThang + "', '" +
                slBan + "', '" +
                slBanDuTru + "');");

            return true;
        }

        public bool alterDatTiec(String tenChuRe, String tenCoDau, String SDT,
            DateTime ngayThang, String loaiSanh, String sanh, String ca,
            String slBan, String slBanDuTru)
        {

            return true;
        }

        public void close()
        {
            mConn.Close();
            mConnLoaiSanh.Close();
        }
    }
}
