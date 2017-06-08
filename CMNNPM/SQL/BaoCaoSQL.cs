﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMNNPM.SQL
{
    class BaoCaoSQL
    {
        public static DataTable loadBaoCao()
        {
            return DatabaseQuery.queryTable(
                "SELECT * FROM BAOCAO ORDER BY NGAYBAOCAO;");
        }
        public static bool loadListViewBaoCao(ListView lv)
        {
            DataTable baocao = loadBaoCao();

            if (lv.Items.Count > 0)
            {
                lv.Items.Clear();
            }
            for (int i = 0; i < baocao.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = (i + 1).ToString();
                item.SubItems.Add(baocao.Rows[i]["NGAYBAOCAO"].ToString());
                item.SubItems.Add(baocao.Rows[i]["SOLUONGTIECCUOI"].ToString());
                item.SubItems.Add(baocao.Rows[i]["DOANHTHU"].ToString());
                item.SubItems.Add(baocao.Rows[i]["TILE"].ToString());

                lv.Items.Add(item);
            }
            return true;
        }
        public static bool loadBaoCaoFromNgayBaoCao(String ngayBaoCao,
            DateTimePicker ngayBaoCao1,
            TextBox soLuong,
            TextBox doanhThu)
        {
            DataTable table = DatabaseQuery.queryTable(
                "SELECT * FROM BAOCAO "
                + "WHERE BAOCAO.NGAYBAOCAO = '" + ngayBaoCao + "';");

            if (table.Rows.Count > 0)
            {
                ngayBaoCao1.Value = DateTime.Parse(table.Rows[0]["NGAYBAOCAO"]
                    .ToString()
                    .TrimEnd());
                soLuong.Text = table.Rows[0]["SOLUONGTIECCUOI"]
                    .ToString()
                    .Trim();
                doanhThu.Text = table.Rows[0]["DOANHTHU"]
                    .ToString()
                    .Trim();
                return true;
            }
            else return false;
        }

        public static double getTiLe(double doanhThu1, double doanhThu2)
        {
            if(doanhThu1 < doanhThu2)
            {
                return - Math.Round(
                ((doanhThu2 - doanhThu1) / doanhThu2) * 100
                , 2);
            }
            else
            {
                return Math.Round(
                ((doanhThu1 - doanhThu2) / doanhThu1) * 100
                , 2);
            }
        }

        public static DateTime getPreviousDayInBaoCao(DateTime ngayBaoCao)
        {
            DataTable table = DatabaseQuery.queryTable(
                "SELECT NGAYBAOCAO FROM BAOCAO WHERE NGAYBAOCAO < '"
                + ngayBaoCao + "' ORDER BY NGAYBAOCAO DESC;");
            if (table.Rows.Count <= 0)
                return DateTime.MinValue;
            else
            {
                return DateTime.Parse(table
                .Rows[0]["NGAYBAOCAO"]
                .ToString());
            }
        }
        public static float getLastDoanhThu(DateTime ngayBaoCao)
        {
            DataTable table = DatabaseQuery.queryTable(
                "SELECT NGAYBAOCAO, DOANHTHU FROM BAOCAO WHERE NGAYBAOCAO < '"
                + ngayBaoCao + "' ORDER BY NGAYBAOCAO DESC;");

            if (table.Rows.Count <= 0)
                return 0;
            float doanhThuCuoi = float.Parse(table
                .Rows[0]["DOANHTHU"]
                .ToString());
            return  doanhThuCuoi;
        }

        public static bool setNextTiLe(DateTime ngayBaoCao, double doanhThu)
        {
            DataTable table = DatabaseQuery.queryTable(
                "SELECT NGAYBAOCAO, DOANHTHU FROM BAOCAO WHERE NGAYBAOCAO > '"
                + ngayBaoCao + "' ORDER BY NGAYBAOCAO ASC;");
            if (table.Rows.Count <= 0)
                return false;

            float doanhThuTiepTheo = float.Parse(table
                .Rows[0]["DOANHTHU"]
                .ToString());

            String ngayTiepTheo = table
                .Rows[0]["NGAYBAOCAO"]
                .ToString();

            double tiLeTiepTheo = getTiLe(doanhThuTiepTheo, doanhThu);

            table = DatabaseQuery.queryTable(
                "UPDATE BAOCAO SET TILE = '" + tiLeTiepTheo
                + "' WHERE NGAYBAOCAO = '" + ngayTiepTheo.TrimEnd() + "';");
            return true;
        }

        public static bool insertBaoCao(String ngayBaoCao, int soLuong,
            String doanhThu)
        {
            DataTable table = DatabaseQuery.queryTable(
                "SELECT * FROM BAOCAO WHERE NGAYBAOCAO = '" 
                + ngayBaoCao + "';");
            if (table.Rows.Count > 0)
            {
                return false;
            }
           
            double tiLe = getTiLe(double.Parse(doanhThu), getLastDoanhThu(
                DateTime.Parse(ngayBaoCao)));

            table = DatabaseQuery.queryTable(
                "INSERT INTO BAOCAO VALUES('" + DatabaseQuery.generateID("BC")
                + "', '" + ngayBaoCao + "', '" + soLuong
                + "', '" + doanhThu + "', '" + tiLe + "');");

            setNextTiLe(DateTime.Parse(ngayBaoCao), long.Parse(doanhThu));
            return true;
        }

        public static bool updateBaoCao(String ngayBaoCao, int soLuong,
            String doanhThu)
        {
            double tiLe = getTiLe(double.Parse(doanhThu)
                , getLastDoanhThu(
                        DateTime.Parse(ngayBaoCao)));

            DataTable table = DatabaseQuery.queryTable(
                "UPDATE BAOCAO SET "
                + "SOLUONGTIECCUOI = '" + soLuong
                + "', DOANHTHU = '" + doanhThu
                + "', TILE = '" + tiLe
                + "' WHERE NGAYBAOCAO = '" + ngayBaoCao.TrimEnd() + "';");

            setNextTiLe(DateTime.Parse(ngayBaoCao), double.Parse(doanhThu));

            return true;
        }

        public static String getMaBaoCaoFromNgayBaoCao(String ngayBaoCao)
        {
            DataTable table = DatabaseQuery.queryTable(
                "SELECT MABAOCAO FROM BAOCAO "
                + "WHERE NGAYBAOCAO = '" + ngayBaoCao.TrimEnd()
                + "';");

            if (table.Rows.Count > 0)
            {
                return table.Rows[0][0].ToString().Trim();
            }
            else
                return "";
        }

        public static bool deleteBaoCao(String ngayBaoCao)
        {
            String maBaoCao = getMaBaoCaoFromNgayBaoCao(ngayBaoCao)
                .Trim();

            if (!maBaoCao.Equals(""))
            {
                DataTable dsBaoCao = DatabaseQuery.queryTable(
                    "DELETE FROM BAOCAO WHERE NGAYBAOCAO = '" + ngayBaoCao + "';");

                setNextTiLe(getPreviousDayInBaoCao(
                    DateTime.Parse(ngayBaoCao.TrimEnd()))
                    , getLastDoanhThu(DateTime.Parse(ngayBaoCao.TrimEnd())));

                return true;
            }
            else return false;
        }
    }
}
