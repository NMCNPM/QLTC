using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
