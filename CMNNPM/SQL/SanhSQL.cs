using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMNNPM.SQL
{
    class SanhSQL
    {
        public static DataTable loadSanh()
        {
            return DatabaseQuery.queryTable(
                "SELECT SANH.TENSANH, LOAISANH.TENLOAISANH, SANH.SLBANTOIDA, SANH.GHICHU "
                + "FROM SANH JOIN LOAISANH ON SANH.MALOAISANH = LOAISANH.MALOAISANH;");
        }

        public static bool insertSanh(String tenloaisanh, String tensanh,
            int slbantoida, String ghichu)
        {
            String maloaisanh = LoaiSanhSQL
                .getMaLoaiSanhFromTenLoaiSanh(tenloaisanh)
                .Trim();

            DataTable table = DatabaseQuery.queryTable(
                "INSERT INTO SANH VALUES('" + DatabaseQuery.generateID("S")
                + "', '"+ maloaisanh 
                + "', '" + tensanh.TrimEnd()
                + "', '" + slbantoida
                + "', '" + ghichu + "');");
            return true;
        }
    }
}
