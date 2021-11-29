using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SEM
{
    public partial class RegSalary : Form
    {
        public RegSalary()
        {
            InitializeComponent();
        }

        private void RegSalary_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.RegTeacher' table. You can move, or remove it, as needed.
            this.regTeacherTableAdapter.Fill(this.dataSet1.RegTeacher);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void Save()
        {
            SqlCommand cmd = new SqlCommand("insert into regSalary(tid,BasicSalary,TravelAllow,OthersAllow,SalaryMonth,sDate) values (@tid,@BasicSalary,@TravelAllow,@OthersAllow,@SalaryMonth,@sDate) ", AppStart.cnn);
            //cmd.CommandType = CommandType.;
            cmd.Parameters.AddWithValue("@tid", cbTeacher.SelectedValue);
            cmd.Parameters.AddWithValue("@BasicSalary", txtSalary.Text);
            cmd.Parameters.AddWithValue("@TravelAllow", txtTravelAllow.Text);
            cmd.Parameters.AddWithValue("@OthersAllow", txtOtherAllow.Text );
            cmd.Parameters.AddWithValue("@SalaryMonth", dtSalaryMonth.Text);
            cmd.Parameters.AddWithValue("@sDate", dtDate.Text);
            if (AppStart.cnn.State == ConnectionState.Closed) AppStart.cnn.Open();
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                MessageBox.Show("Record Successfully Added.");
            }
            else
            {
                MessageBox.Show("Error Found.");
            }
        }
        private void New()
        {
            //txtGRno.Text = "";
            //txtName.Text = "";
            //txtFName.Text = "";
            //txtFees.Text = "";
            //txtArriers.Text = "";
            //txtPaid.Text = "";
            //txtPrevBalance.Text = "";


        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void cbTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
