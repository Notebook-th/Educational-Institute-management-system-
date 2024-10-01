using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Educational_Inistitute_Management
{
    public partial class Mysection : Form
    {
        public Mysection()
        {
            InitializeComponent();
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=MY-POTATO\SQLEXPRESS;Initial Catalog=edudb;Integrated Security=True;");
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT StudentName, Section FROM entab WHERE Studentname = @Studentname", con);

            cmd.Parameters.AddWithValue("@Studentname", txtStudentId.Text);

            SqlDataAdapter dm = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            dm.Fill(ds);

            dataGridView1.DataSource = ds;
            con.Close();
        }
    }
}
