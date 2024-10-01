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

namespace Educational_Inistitute_Management
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=MY-POTATO\SQLEXPRESS;Initial Catalog=edudb;Integrated Security=True;");
            try
            {
                con.Open();
                string username = txtUsername.Text;
                string password = txtPassword.Text;
                string role = cmbRole.SelectedItem?.ToString(); // Role selection from ComboBox

                // Check if any field is empty
                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(role))
                {
                    MessageBox.Show("Please fill in all fields and select a role.");
                    return;
                }

                // Query to check username, password, and role
                SqlCommand cmd = new SqlCommand("SELECT Username, Password, Role FROM logintab2 WHERE Username=@Username AND Password=@Password AND Role=@Role", con);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@Role", role);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    // Hide login form and open the main form, passing the user role
                    this.Hide();
                    Main mainForm = new Main(role); // Pass the role to the Main form
                    mainForm.Show();
                }
                else
                {
                    MessageBox.Show("Invalid Username, Password, or Role! Please try again.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            signup sp = new signup();
            sp.ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
