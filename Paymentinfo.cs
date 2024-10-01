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
    public partial class Paymentinfo : Form
    {
        public Paymentinfo()
        {
            InitializeComponent();
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=MY-POTATO\SQLEXPRESS;Initial Catalog=edudb;Integrated Security=True;");
            con.Open();

            SqlCommand cnn = new SqlCommand("select * from paymenttab", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }
    }
}
