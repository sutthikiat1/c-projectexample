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
    public partial class Edit : Form
    {
        public Edit()
        {
            InitializeComponent();
        }

        SqlConnection Conn = new SqlConnection();
        DataSet ds = new DataSet();

        private void Edit_Load(object sender, EventArgs e)
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

            }
            else
            {
                MessageBox.Show("ไม่มีพนักงานที่คุณป้อน...!!!", "ข้แผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text.Trim() == "")
            {
                MessageBox.Show("กรุณาป้อนรหัสพนักงาน....!!!!", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } else
            {
                StringBuilder sb = new StringBuilder();
                string krisDate = txtBirthday.Value.Year.ToString() + "-" +
                txtBirthday.Value.Month.ToString() + "-" + txtBirthday.Value.Day.ToString();
                MessageBox.Show(txtBirthday.Value.ToShortDateString());

                sb.Remove(0, sb.Length);
                sb.Append("UPDATE Employee set EmpNo='" + txtCode.Text + "',");
                sb.Append("EmpName='" + txtName.Text + "',EmpLastName='" + txtLastName.Text + "',");
                sb.Append("EmpTel='" + txtTel.Text + "',EmpBirthday='" + krisDate + "',");
                sb.Append("EmpAge='" + txtAge.Text + "', EmpAddress='" + txtAddress.Text + "'");
                sb.Append(" where(EmpNo='" + txtCode.Text + "')");

                string sqlEdit = sb.ToString();
                SqlCommand comEdit = new SqlCommand();
                comEdit.CommandType = CommandType.Text;
                comEdit.CommandText = sqlEdit;
                comEdit.Connection = Conn;
                comEdit.ExecuteNonQuery();
                MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
