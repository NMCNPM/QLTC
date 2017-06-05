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
    public partial class ThemSanh : Form
    {
        private QuanTri qtForm;

        public ThemSanh()
        {
            InitializeComponent();
        }

        public ThemSanh(QuanTri qt)
        {
            qtForm = qt;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ThemSanh_Load(object sender, EventArgs e)
        {
            addItemToComboLoaiSanh();
        }

        public void addItemToComboLoaiSanh()
        {
            DataTable lsTable = DatTiecSQL.loadSanh();
            if (comboBoxLoaiSanh.Items.Count > 0)
                comboBoxLoaiSanh.Items.Clear();

            for (int i = 0; i < lsTable.Rows.Count; i++)
            {
                comboBoxLoaiSanh.Items.Add(
                    lsTable.Rows[i]["TENLOAISANH"].ToString().TrimEnd());

            }

            comboBoxLoaiSanh.Text = comboBoxLoaiSanh.Items[0].ToString();
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            DataTable sanhTable = 
        }
    }
}
