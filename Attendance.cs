﻿using System;
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
    public partial class Attendance : Form
    {
        public Attendance()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=MY-POTATO\SQLEXPRESS;Initial Catalog=edudb;Integrated Security=True;");
            con.Open();

            SqlCommand cnn = new SqlCommand("insert into attentab values(@aid,@studentname,@status)", con);
            cnn.Parameters.AddWithValue("@AId", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@StudentName", textBox2.Text);

            cnn.Parameters.AddWithValue("@Status", textBox3.Text);
           

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Saved successfully !", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=MY-POTATO\SQLEXPRESS;Initial Catalog=edudb;Integrated Security=True;");
            con.Open();

            SqlCommand cnn = new SqlCommand("select * from attentab", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=MY-POTATO\SQLEXPRESS;Initial Catalog=edudb;Integrated Security=True;");
            con.Open();

            SqlCommand cnn = new SqlCommand("update attentab set studentname=@studentname,status=@status where aid=@aid", con);
            cnn.Parameters.AddWithValue("@AId", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@StudentName", textBox2.Text);

            cnn.Parameters.AddWithValue("@Status", textBox3.Text);


            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Updated successfully !", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=MY-POTATO\SQLEXPRESS;Initial Catalog=edudb;Integrated Security=True;");
            con.Open();

            SqlCommand cnn = new SqlCommand("delete attentab where aid=@aid", con);
            cnn.Parameters.AddWithValue("@AId", int.Parse(textBox1.Text));
           
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Deleted !", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=MY-POTATO\SQLEXPRESS;Initial Catalog=edudb;Integrated Security=True;");
            con.Open();

            SqlCommand cnn = new SqlCommand("select * from attentab", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void Attendance_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=MY-POTATO\SQLEXPRESS;Initial Catalog=edudb;Integrated Security=True;");
            con.Open();

            SqlCommand cnn = new SqlCommand("select * from attentab", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void btnstlist_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=MY-POTATO\SQLEXPRESS;Initial Catalog=edudb;Integrated Security=True;");
            con.Open();

            SqlCommand cnn = new SqlCommand("select studentid, studentname from studentab", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView2.DataSource = table;
        }
    }
}
