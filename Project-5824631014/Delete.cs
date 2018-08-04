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

namespace Project_5824631014
{
    public partial class Delete : Form
    {
        public Delete()
        {
            InitializeComponent();
        }

        SqlConnection Conn = new SqlConnection();
        DataSet ds = new DataSet();

        private void Delete_Load(object sender, EventArgs e)
        {
            string strConn = "Server=localhost\\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=Project;";
            Conn = new SqlConnection();
            if (Conn.State == ConnectionState.Open)
            {
                Conn.Close();
            }
            Conn.ConnectionString = strConn;
            Conn.Open();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text.Trim() == "")
            {
                MessageBox.Show("กรุณาป้อนรหัสพนักงาน....!!!!", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string sqlEmp = "Select * from Employee where EmpNo ='" + txtSearch.Text.Trim() + "'";
            SqlCommand com = new SqlCommand();
            SqlDataReader dr;
            DataTable dt;
            com.CommandType = CommandType.Text;
            com.CommandText = sqlEmp;
            com.Connection = Conn;
            dr = com.ExecuteReader();

            if (dr.HasRows)
            {
                dt = new DataTable();
                dt.Load(dr);
                txtCode.Text = dt.Rows[0]["EmpNo"].ToString();
                txtName.Text = dt.Rows[0]["EmpName"].ToString();
                txtLastName.Text = dt.Rows[0]["EmpLastName"].ToString();
                txtTel.Text = dt.Rows[0]["EmpTel"].ToString();
                txtBirthday.Text = dt.Rows[0]["EmpBirthday"].ToString();
                txtAge.Text = dt.Rows[0]["EmpAge"].ToString();
                txtAddress.Text = dt.Rows[0]["EmpAddress"].ToString();

                txtCode.Enabled = false;
                txtName.Enabled = false;
                txtLastName.Enabled = false;
                txtTel.Enabled = false;
                txtBirthday.Enabled = false;
                txtAge.Enabled = false;
                txtAddress.Enabled = false;
            }
            else
            {
                MessageBox.Show("ไม่มีพนักงานที่คุณป้อน...!!!", "ข้แผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("คุณต้องการลบข้อมูลหรือไม่ ?", "คำยินยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                try
                {
                    string sqlDelete = "DELETE from Employee where EmpNo=" + txtCode.Text.Trim() + "";
                    SqlCommand Comdelete = new SqlCommand();
                    Comdelete.CommandType = CommandType.Text;
                    Comdelete.CommandText = sqlDelete;
                    Comdelete.Connection = Conn;
                    Comdelete.ExecuteNonQuery();
                    MessageBox.Show("ลบข้อมูลเรียบร้อยแล้ว !!", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear_Form();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ความผิดพลาด" + ex.Message, "catch");
                }
            }
        }

        private void Clear_Form()
        {
            txtCode.Text = "";
            txtName.Text = "";
            txtLastName.Text = "";
            txtTel.Text = "";
            txtBirthday.Text = "";
            txtAge.Text = "";
            txtAddress.Text = "";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
