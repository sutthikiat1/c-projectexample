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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection Conn = new SqlConnection();
        DataSet ds = new DataSet();

        private void Form1_Load(object sender, EventArgs e)
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
        private void button1_Click_1(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            string krisDate = txtBirthday.Value.Year.ToString() + "-" +
            txtBirthday.Value.Month.ToString() + "-" + txtBirthday.Value.Day.ToString();
            MessageBox.Show(txtBirthday.Value.ToShortDateString());

            try
            {
                if (txtCode.Text == "")
                {
                    MessageBox.Show("กรุณราป้อนรหัสพนักงาน", "เตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    sb.Remove(0, sb.Length);
                    sb.Append("INSERT into Employee values('" + txtCode.Text + "',");
                    sb.Append("'" + txtName.Text + "'," + "'" + txtLastName.Text + "',");
                    sb.Append("'" + txtTel.Text + "'," + "'" + krisDate + "',");
                    sb.Append("'" + txtAge.Text + "'," + "'" + txtAddress.Text + "')");
                    string sqlAdd = sb.ToString();
                    SqlCommand comAdd = new SqlCommand();
                    comAdd.CommandType = CommandType.Text;
                    comAdd.CommandText = sqlAdd;
                    comAdd.Connection = Conn;
                    comAdd.ExecuteNonQuery(); //run คำสั่ง insert
                    MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                } //else
            }
            catch (Exception ex)
            {
                MessageBox.Show("ความผิดพลาดคือ" + ex.Message, "catch");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
