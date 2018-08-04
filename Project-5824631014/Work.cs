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
    public partial class Work : Form
    {
        public Work()
        {
            InitializeComponent();
        }

        SqlConnection Conn = new SqlConnection();
        DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();
        SqlDataAdapter daEmp;

        private void Work_Load(object sender, EventArgs e)
        {
            string strConn = "Server=localhost\\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=Project;";
            Conn = new SqlConnection();
            if (Conn.State == ConnectionState.Open)
            {
                Conn.Close();
            }
            Conn.ConnectionString = strConn;
            Conn.Open();

            string sqlemp = "Select * from Employee";
            daEmp = new SqlDataAdapter(sqlemp, Conn);
            daEmp.Fill(ds, "Employee");

            cboName.DisplayMember = "EmpName";
            cboName.ValueMember = "EmpName";
            cboName.DataSource = ds.Tables["Employee"];

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            string krisDate = txtDateWork.Value.Year.ToString() + "-" +
            txtDateWork.Value.Month.ToString() + "-" + txtDateWork.Value.Day.ToString();
            MessageBox.Show(txtDateWork.Value.ToShortDateString());

            if (txtWorkName.Text == "")
            {
                MessageBox.Show("กรุณราป้อนงานที่จะทำ", "เตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            } else if (txtWorkmoney.Text == "")
            {
                MessageBox.Show("กรุณราป้อนรายได้", "เตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            } else
            {
                sb.Remove(0, sb.Length);
                sb.Append("INSERT into Work values('" + cboName.Text + "',");
                sb.Append("'" + txtWorkName.Text + "'," + "'" + txtWorkmoney.Text + "',");
                sb.Append("'" + krisDate + "')");
                string sqlAdd = sb.ToString();
                SqlCommand comAdd = new SqlCommand();
                comAdd.CommandType = CommandType.Text;
                comAdd.CommandText = sqlAdd;
                comAdd.Connection = Conn;
                comAdd.ExecuteNonQuery(); //run คำสั่ง insert
                MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
