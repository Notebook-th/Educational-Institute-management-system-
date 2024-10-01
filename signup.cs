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
    public partial class signup : Form
    {
        public signup()
        {
            InitializeComponent();
        }

        private void signup_Load(object sender, EventArgs e)
        {
            txtSignUpUsername.Text = string.Empty;
            txtSignUpPassword.Text = string.Empty;

            // Optionally set focus to the username field
            txtSignUpUsername.Focus();
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=MY-POTATO\SQLEXPRESS;Initial Catalog=edudb;Integrated Security=True;");
            try
            {
                con.Open();
                string username = txtSignUpUsername.Text;
                string password = txtSignUpPassword.Text;
                string role = cmbRole.SelectedItem?.ToString(); // Role selection from ComboBox

                // Check if any field is empty
                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(role))
                {
                    MessageBox.Show("Please fill in all fields and select a role.");
                    return;
                }

                // Insert query with the role
                string query = "INSERT INTO logintab2 (Username, Password, Role) VALUES (@Username, @Password, @Role)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@Role", role);

                // Execute the query and check the result
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Account created successfully as " + role + "!");
                    this.Close(); // Close the signup form after successful signup
                }
                else
                {
                    MessageBox.Show("Account creation failed!");
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
    }
}
