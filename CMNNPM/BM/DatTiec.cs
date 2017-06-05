﻿using CMNNPM.SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMNNPM
{
    public partial class DatTiec : Form
    {
        public DatTiec()
        {
            InitializeComponent();
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DanhSachThucPham mForm = new DanhSachThucPham();
            mForm.Show();
            mForm.Location = new Point(this.Location.X + this.Width, this.Location.Y);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DanhSachDichVu mForm = new DanhSachDichVu();
            mForm.Show();
            mForm.Location = new Point(this.Location.X + this.Width, this.Location.Y);
        }

        private void buttonChapNhan_Click(object sender, EventArgs e)
        {

        }

        public void addItemToLoaiSanh()
        {
            DataTable lsTable = DatTiecSQL.loadLoaiSanh();
            if (comboBoxLoaiSanh.Items.Count > 0)
                comboBoxLoaiSanh.Items.Clear();

            for(int i = 0; i < lsTable.Rows.Count; i++)
            {
                comboBoxLoaiSanh.Items.Add(
                    lsTable.Rows[i]["TENLOAISANH"].ToString().TrimEnd());
            }
        }

        private void DatTiec_Load(object sender, EventArgs e)
        {
            
        }
    }
}
