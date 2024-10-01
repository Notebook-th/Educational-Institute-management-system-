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
    public partial class GradeEntryForm : Form
    {
        public GradeEntryForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=MY-POTATO\SQLEXPRESS;Initial Catalog=edudb;Integrated Security=True;");
            con.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO gradetab (StudentId, SubjectId, Grade, DateAdded) VALUES (@StudentId, @SubjectId, @Grade, @DateAdded)", con);
            cmd.Parameters.AddWithValue("@StudentId", txtStudentId.Text);
            cmd.Parameters.AddWithValue("@SubjectId", txtSubjectId.Text);
            cmd.Parameters.AddWithValue("@Grade", txtGrade.Text);
            cmd.Parameters.AddWithValue("@DateAdded", DateTime.Now);

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Grade added successfully!");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=MY-POTATO\SQLEXPRESS;Initial Catalog=edudb;Integrated Security=True;");
            con.Open();

            SqlCommand cnn = new SqlCommand("select * from gradetab", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=MY-POTATO\SQLEXPRESS;Initial Catalog=edudb;Integrated Security=True;");
            con.Open();

            // SQL command to update the grade for a specific student and subject
            SqlCommand cnn = new SqlCommand("UPDATE Gradetab SET Grade=@Grade WHERE StudentId=@StudentId AND SubjectId=@SubjectId", con);

            // Pass the StudentId, SubjectId, and the new Grade
            cnn.Parameters.AddWithValue("@StudentId", int.Parse(txtStudentId.Text)); // Assuming textBox1 contains Student ID
            cnn.Parameters.AddWithValue("@SubjectId", int.Parse(txtSubjectId.Text)); // Assuming textBox2 contains Subject ID
            cnn.Parameters.AddWithValue("@Grade", txtGrade.Text); // Assuming textBox3 contains the new Grade

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Grade updated successfully!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=MY-POTATO\SQLEXPRESS;Initial Catalog=edudb;Integrated Security=True;");
            con.Open();

            // SQL command to delete the grade for a specific student and subject
            SqlCommand cnn = new SqlCommand("DELETE FROM Gradetab WHERE StudentId=@StudentId AND SubjectId=@SubjectId", con);

            // Pass the StudentId and SubjectId to delete the specific grade
            cnn.Parameters.AddWithValue("@StudentId", int.Parse(txtStudentId.Text)); // Assuming textBox1 contains Student ID
            cnn.Parameters.AddWithValue("@SubjectId", int.Parse(txtSubjectId.Text)); // Assuming textBox2 contains Subject ID

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Grade deleted successfully!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtStudentId.Text = "";
            txtSubjectId.Text = "";
            txtGrade.Text = "";
            
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=MY-POTATO\SQLEXPRESS;Initial Catalog=edudb;Integrated Security=True;");
            con.Open();

            SqlCommand cnn = new SqlCommand("select * from gradetab", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=MY-POTATO\SQLEXPRESS;Initial Catalog=edudb;Integrated Security=True;");
            con.Open();

            SqlCommand cnn = new SqlCommand("select * from studentab", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView2.DataSource = table;
        }
    }
}
