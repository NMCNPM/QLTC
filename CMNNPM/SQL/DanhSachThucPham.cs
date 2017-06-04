using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMNNPM.SQL
{
    class DanhSachThucPham
    {
        //public static DataTable DSThucPham;

        public static DataTable loadMonAn()
        {
            return DatabaseQuery.queryTable(
                "SELECT MAMONAN, TENMONAN, GIA FROM MONAN ORDER BY TENMONAN ASC");
        }

        public static DataTable loadDSThucPham()
        {
            DataTable table = DatabaseQuery.queryTable(
                "SELECT MAMONAN, TENMONAN, GIA, GHICHU FROM "
                + "MONAN LEFT JOIN THUCDON ON MONAN.MAMONAN = THUCDON.MAMONAN "
                + "ORDER BY TENMONAN ASC;");
            return table;
        }

    }
}
