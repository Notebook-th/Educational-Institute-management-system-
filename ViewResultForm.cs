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
    public partial class ViewResultForm : Form
    {
        public ViewResultForm()
        {
            InitializeComponent();
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=MY-POTATO\SQLEXPRESS;Initial Catalog=edudb;Integrated Security=True;");
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT s.SubjectName, g.Grade, g.DateAdded FROM Gradetab g INNER JOIN subtab s ON g.SubjectId = s.SubjectId WHERE g.StudentId = @StudentId", con);
            cmd.Parameters.AddWithValue("@StudentId", txtStudentId.Text);

            SqlDataAdapter dm = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            dm.Fill(ds);

            dataGridView1.DataSource = ds;
            con.Close();
        }
    }
}
