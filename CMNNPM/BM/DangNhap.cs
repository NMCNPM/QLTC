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
    public partial class DangNhap : Form
    {
        string strConnection = @"Data Source = DESKTOP-KGDRVJL\SQLEXPRESS; Initial Catalog = QLTC; Integrated Security = True";
        SqlConnection connection;
        SqlCommand command;
        public DangNhap()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(strConnection);
            connection.Open();
            string sqlCommand = "Select COUNT(*) from TAIKHOAN where TAIKHOAN.TENTAIKHOAN = @ID AND TAIKHOAN.MATKHAU = @PASS";
            command = new SqlCommand(sqlCommand,connection);
            command.Parameters.Add(new SqlParameter("@ID", tbTaiKhoan.Text));
            command.Parameters.Add(new SqlParameter("@PASS", tbMatKhau.Text));
            int check = (int)command.ExecuteScalar();
            if(check == 1)
            {
                QuanTri form = new QuanTri();
                form.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng","Đăng nhập thất bại",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
    }
}
