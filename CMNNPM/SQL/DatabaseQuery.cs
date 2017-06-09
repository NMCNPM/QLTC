using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMNNPM.SQL
{
    class DatabaseQuery
    {
        public static String CONNECTION_STRING =
            "Data Source=DESKTOP-DM3AGPH\\SQLEXPRESS;Initial Catalog=_QLTC;Integrated Security=True";
        public static String DichVuName = "DICHVU";
        public static String LoaiSanhName = "LOAISANH";
        public static String KhachHangName = "KHACHHANG";
        public static String CaName = "CA";
        public static String DanhSachDVName = "DANHSACHDV";
        public static String HoaDonName = "HOADON";
        public static String MonAnName = "MONAN";
        public static String SanhName = "SANH";
        public static String TaiKhoanName = "TAIKHOAN";
        public static String ThucDonName = "THUCDON";
        public static String TiecCuoiName = "TIECCUOI";
        public static String tableName = "qlnv2";

        // trình tạo mã tự động dựa vào thời gian thực
        public static string generateID(string Header)
        {
            string result = DateTime.Now.ToString("ddMMyyyyhhmmss");
            result = Header + result;
            return result;
        }

        // truy vấn cơ sở dữ liệu bằng câu lệnh SQL từ cmd
        public static DataTable queryTable(String cmd)
        {
            DataTable mTable = new DataTable();

            SqlConnection khConnection = new SqlConnection();
            khConnection.ConnectionString = DatabaseQuery.CONNECTION_STRING;
            khConnection.Open();

            SqlCommand khCommand = khConnection.CreateCommand();
            khCommand.CommandText = cmd;

            mTable.Load(khCommand.ExecuteReader());
            khConnection.Close();
            return mTable;
        }
        
    }
}
