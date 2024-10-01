using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Educational_Inistitute_Management
{
    public partial class Main : Form
    {
        private string userRole; // Variable to store the user role

        // Constructor that accepts the user's role
        public Main(string role)
        {
            InitializeComponent();
            userRole = role;
            SetupMain(); // Call the method to hide/show buttons
        }

        // Function to configure the Main form based on the role
        private void SetupMain()
        {
            // Role-based access control
            if (userRole == "Student")
            {
                // Hide or disable buttons not accessible to students
                button3.Visible = false; // Hide Teacher button
                button2.Visible = false; // Hide Subject button
                button6.Visible = false; // Hide Attendance button
                button7.Visible = false;  // Show Dashboard for students
                button5.Visible = true;  // Show Enrollment button
                button8.Visible = true;
                button10.Visible = false;
                button11.Visible = false;
                button1.Visible = true;  // Show Student button
                button4.Visible = false;  // Show Section button
                btnMakePayment.Visible = true;
            }
            else if (userRole == "Teacher")
            {
                // Hide or disable buttons not accessible to teachers
                button1.Visible = false; // Hide Student button
                button5.Visible = false; // Hide Enrollment button
                button3.Visible = true; // Hide Teacher button (can't manage other teachers)
                button2.Visible = true; // Hide Subject button
                button4.Visible = true;  // Show Section button
                button6.Visible = true;  // Show Attendance button
                button7.Visible = false;  // Show Dashboard for teachers
                button8.Visible = false;
                button9.Visible = false;
                button10.Visible = false;
                button12.Visible = false;
                btnMakePayment.Visible = false;
            }
            else if (userRole == "Admin")
            {
                // Admins can access everything, so nothing is hidden
                button1.Visible = true;  // Show Student button
                button2.Visible = true;  // Show Subject button
                button3.Visible = true;  // Show Teacher button
                button4.Visible = true;  // Show Section button
                button5.Visible = true; // Hide Enrollment (optional, based on your needs)
                button6.Visible = true;  // Show Attendance button
                button7.Visible = true;  // Show Dashboard for admins
                button8.Visible = true;
                button9.Visible = true;
                button10.Visible = true;
                btnMakePayment.Visible = false;
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student st = new Student();
            st.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Subject sj = new Subject();
            sj.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Teacher tr = new Teacher();
            tr.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Section sn = new Section();
            sn.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Enrollment et = new Enrollment();
            et.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Attendance aet = new Attendance();
            aet.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Dashboard dd = new Dashboard();
            dd.Show();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                this.Hide();  // Hide the current form (Main form)
                Form1 loginForm = new Form1(); // Create an instance of the login form
                loginForm.Show();  // Show the login form again
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Mysection ms = new Mysection();
            ms.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Showteachers tv = new Showteachers();
            tv.Show();
        }

        private void btnMakePayment_Click(object sender, EventArgs e)
        {
            Payment tk = new Payment();
            tk.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Paymentinfo pi = new Paymentinfo();
            pi.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            GradeEntryForm gef = new GradeEntryForm();
            gef.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ViewResultForm vr = new ViewResultForm();
            vr.Show();
        }
    }
}
