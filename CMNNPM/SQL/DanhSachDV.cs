using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMNNPM.SQL
{
    class DanhSachDV
    {

        public static DataTable loadDichVu()
        {
            return DatabaseQuery.queryTable(
                "SELECT MADICHVU, TENDICHVU, GIA FROM DICHVU ORDER BY TENDICHVU ASC");
        }

        public static DataTable loadDSDichVu()
        {
            DataTable table = DatabaseQuery.queryTable(
                "SELECT TENDICHVU, SOLUONG, GIA FROM "
                + "DICHVU LEFT JOIN DANHSACHDV ON DICHVU.MADICHVU = DANHSACHDV.MADICHVU "
                + "ORDER BY TENDICHVU ASC;");
            return table;
        }
    }
}
