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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Educational_Inistitute_Management
{
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=MY-POTATO\SQLEXPRESS;Initial Catalog=edudb;Integrated Security=True;");
            con.Open();

            SqlCommand cnn = new SqlCommand("insert into paymenttab values(@paymentid,@studentid,@sectionid,@amountpaid)", con);
            cnn.Parameters.AddWithValue("@PaymentId", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@StudentId", textBox2.Text);
            cnn.Parameters.AddWithValue("@SectionId", textBox3.Text);
            cnn.Parameters.AddWithValue("@AmountPaid", textBox4.Text);
            
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Paid successfully !", "Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

      

        private void btnNew_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=MY-POTATO\SQLEXPRESS;Initial Catalog=edudb;Integrated Security=True;");
            con.Open();

            SqlCommand cnn = new SqlCommand("select * from sectionab", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=MY-POTATO\SQLEXPRESS;Initial Catalog=edudb;Integrated Security=True;"))
            {
                con.Open();

                // Use a parameterized query to select only the specified StudentId
                SqlCommand cnn = new SqlCommand("SELECT StudentId, AmountPaid FROM Paymenttab WHERE StudentId = @StudentId", con);

                // Assuming txtStudentId is the TextBox where the user enters the Student ID
                cnn.Parameters.AddWithValue("@StudentId", int.Parse(textBox2.Text));

                SqlDataAdapter da = new SqlDataAdapter(cnn);
                DataTable table = new DataTable();
                da.Fill(table);

                // Bind the result to the DataGridView to display
                dataGridView1.DataSource = table;
            }
        }
    }
}
