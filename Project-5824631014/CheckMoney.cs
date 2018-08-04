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
    public partial class CheckMoney : Form
    {
        public CheckMoney()
        {
            InitializeComponent();
        }

        SqlConnection Conn = new SqlConnection();
        DataSet ds = new DataSet();
        DataSet dx = new DataSet();
        DataSet dsemp = new DataSet();
        SqlDataAdapter da;
        SqlDataAdapter dl;
        StringBuilder sb = new StringBuilder();

        private void CheckMoney_Load(object sender, EventArgs e)
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
            da = new SqlDataAdapter(sqlemp, Conn);
            da.Fill(dsemp, "Employee");

            cboName.DisplayMember = "EmpName";
            cboName.ValueMember = "EmpName";
            cboName.DataSource = dsemp.Tables["Employee"];
            dataGridView1.ReadOnly = true;
            format_DataGrid();



        }


        private void cboName_SelectedValueChanged(object sender, EventArgs e)
        {
            string strSql = "Select * from Work where EmpName ='" + cboName.SelectedValue + "'";
            da = new SqlDataAdapter(strSql, Conn);
            ds.Clear();
            da.Fill(ds, "Work");
            dataGridView1.DataSource = ds.Tables["Work"];

            string strmoney = "Select WorkMoney from Work";
            dl = new SqlDataAdapter(strmoney, Conn);
            dl.Fill(dx, "Work");


            //label3.Text = "จำนวนรายได้ทั้งหมด = " + dx.Tables["Work"].Rows.Count.ToString() + " บาท.";

        }

        private void format_DataGrid()
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.GridColor = Color.RosyBrown;
            dataGridView1.ForeColor = Color.Black;
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.Pink;

            dataGridView1.Columns[0].HeaderText = "ชื่อ";
            dataGridView1.Columns[1].HeaderText = "งานที่ทำ";
            dataGridView1.Columns[2].HeaderText = "เงินที่ได้";
            dataGridView1.Columns[3].HeaderText = "วันที่ทำงาน";

            dataGridView1.Columns[0].Width = 120;
            dataGridView1.Columns[1].Width = 120;
            dataGridView1.Columns[2].Width = 80;
            dataGridView1.Columns[3].Width = 80;

            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[0].DefaultCellStyle.Format = "#,###.00"; //จัด format ตัวเลข
        }
    }
}
