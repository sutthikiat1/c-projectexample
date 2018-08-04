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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        SqlConnection Conn = new SqlConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();

        private void Menu_Load(object sender, EventArgs e)
        {
            string strConn = "Server=localhost\\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=Project;";
            if (Conn.State == ConnectionState.Open)
            {
                Conn.Close();
            }
            Conn.ConnectionString = strConn;
            Conn.Open();
            try
            {
                string strSql = "Select * from Employee";
                da = new SqlDataAdapter(strSql, Conn);
                da.Fill(ds, "Employee");
                dataGridView1.DataSource = ds.Tables["Employee"];
                format_DataGrid();

                label1.Text = "จำนวนพนักงานทั้งหมด = " + ds.Tables["Employee"].Rows.Count.ToString() + " คน.";
            }
            catch
            {
               
            }
        }

        private void format_DataGrid()
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.GridColor = Color.LightCyan;
            dataGridView1.ForeColor = Color.SlateBlue;
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.LightBlue;

            dataGridView1.Columns[0].HeaderText = "รหัส";
            dataGridView1.Columns[1].HeaderText = "ชื่อพนักงาน";
            dataGridView1.Columns[2].HeaderText = "นามสกุล";
            dataGridView1.Columns[3].HeaderText = "เบอร์โทรศัพท์";
            dataGridView1.Columns[4].HeaderText = "วันที่ทำงาน";
            dataGridView1.Columns[5].HeaderText = "อายุ";
            dataGridView1.Columns[6].HeaderText = "ที่อยู่";

            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 250;
            dataGridView1.Columns[3].Width = 80;
            dataGridView1.Columns[4].Width = 80;

            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[0].DefaultCellStyle.Format = "#,###.00"; //จัด format ตัวเลข
        }

        private void เพมพนกงานToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
        }

        private void แกไขพนกงานToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Edit edit = new Edit();
            edit.Show();
        }

        private void ลบพนกงานToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete delete = new Delete();
            delete.Show();
        }

        private void เพมงานToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Work work = new Work();
            work.Show();
        }

        private void คำนวณรายไดToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckMoney Cmy = new CheckMoney();
            Cmy.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }
    }
}
