using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace SEM
{
    public partial class AppStart : Form
    {
        public static SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString);
        public AppStart()
        {
            InitializeComponent();
        }

        private void AppStart_Load(object sender, EventArgs e)
        {
            CountTeacher();
            CountStudent();
        }
        private void CountTeacher()
        {
            SqlCommand cmd = new SqlCommand("select * from CountTeachers", AppStart.cnn);

            if (AppStart.cnn.State == ConnectionState.Closed) AppStart.cnn.Open();
            int i =Convert.ToInt32(cmd.ExecuteScalar().ToString());
            if (i > 0)
            {
                
            }
            else
            {
                i = 0;
            }
            lblRegTeachers.Text = i.ToString();
        }
        private void CountStudent()
        {
            SqlCommand cmd = new SqlCommand("select * from CountRegStudents", AppStart.cnn);

            if (AppStart.cnn.State == ConnectionState.Closed) AppStart.cnn.Open();
            int i = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            if (i > 0)
            {

            }
            else
            {
                i = 0;
            }
            lblRegRegStudents.Text = i.ToString();
        }
       

        private void marksManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void registerationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegTeacher f = new RegTeacher();
            f.Show();
        }

        private void BoardReg_Click(object sender, EventArgs e)
        {
            RegBoard f = new RegBoard();
            f.Show();
        }

        private void registrationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RegStudent f = new RegStudent();
            f.Show();
        }

        private void registrationToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            RegStudentPrivate f = new RegStudentPrivate();
            f.Show();
        }

        private void assignSubjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegSubject f = new RegSubject();
            f.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void lblRegRegStudents_Click(object sender, EventArgs e)
        {

        }

        private void lblRegPrivStudents_Click(object sender, EventArgs e)
        {

        }

        private void lblRegTeachers_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void billingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegFees f = new RegFees();
            f.Show();
        }

        private void marksManagmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegExam f = new RegExam();
            f.Show();
        }

        private void entryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RegSalary f = new RegSalary();
            f.Show();
        }

        private void assignSeatNoAndSubjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegExamManagement f = new RegExamManagement();
            f.Show();
        }
    }
}
