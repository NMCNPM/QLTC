using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CMNNPM
{
    public partial class QuanTri : Form
    {
        public QuanTri()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThemSanh form = new ThemSanh();
            form.Show();
        }

        private void QuanTri_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLTCDataSet3.MONAN' table. You can move, or remove it, as needed.
            this.mONANTableAdapter.Fill(this.qLTCDataSet3.MONAN);
            // TODO: This line of code loads data into the 'qLTCDataSet2.LOAISANH' table. You can move, or remove it, as needed.
            this.lOAISANHTableAdapter.Fill(this.qLTCDataSet2.LOAISANH);
            // TODO: This line of code loads data into the 'qLTCDataSet1.SANH' table. You can move, or remove it, as needed.
            this.sANHTableAdapter.Fill(this.qLTCDataSet1.SANH);
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Data Source = DESKTOP-KGDRVJL\SQLEXPRESS; Initial Catalog = QLTC; Integrated Security = True";
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM MONAN";

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;

            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();
            if (this.lvMA.Items.Count > 0)
                this.lvMA.Items.Clear();
            for(int i =0; i<dt.Rows.Count;i++)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = (i + 1).ToString();
                lvi.SubItems.Add(dt.Rows[i]["TENMONAN"].ToString());
                lvi.SubItems.Add(dt.Rows[i]["GIA"].ToString());
                lvi.SubItems.Add(dt.Rows[i]["GHICHU"].ToString());
                this.lvMA.Items.Add(lvi);
            }
            LoadData();
        }
        private void LoadData()
        {
            DataDataContext db = new DataDataContext();
            var dsDichVu = db.DICHVUs.ToList();
            gridControlDV.DataSource = dsDichVu;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ThemMonAn form = new ThemMonAn();
            form.Show();
        }
    }
}
