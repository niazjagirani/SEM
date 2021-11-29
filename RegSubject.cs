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
    public partial class RegSubject : Form
    {
        public RegSubject()
        {
            InitializeComponent();
        }

        private void RegSubject_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.RegClass' table. You can move, or remove it, as needed.
            this.regClassTableAdapter.Fill(this.dataSet1.RegClass);
            // TODO: This line of code loads data into the 'dataSet1.RegTeacher' table. You can move, or remove it, as needed.
            this.regTeacherTableAdapter.Fill(this.dataSet1.RegTeacher);
            // TODO: This line of code loads data into the 'dataSet1.RegSubjectName' table. You can move, or remove it, as needed.
            this.regSubjectNameTableAdapter.Fill(this.dataSet1.RegSubjectName);

            FillGrid();

        }
        private void FillGrid()
        {
            using (SqlDataAdapter a = new SqlDataAdapter(
                "Select * from Vsubjectassignedtoteacher where teacher='" + cbTeacher.Text + "'" , AppStart.cnn))
            {
                // 3
                // Use DataAdapter to fill DataTable
                DataTable t = new DataTable();
                a.Fill(t);
                // 4
                int i = 0;
                dataGridView1.DataSource = t;
            }
        }
        private void Save()
        {
            SqlCommand cmd = new SqlCommand("insert into regSubject( tid,classid,stid) values (@tid,@classid,@stid) ", AppStart.cnn);
            //cmd.CommandType = CommandType.;
            cmd.Parameters.AddWithValue("@tid", cbTeacher.SelectedValue);
            cmd.Parameters.AddWithValue("@classid", cbClass.SelectedValue);
            cmd.Parameters.AddWithValue("@stid", cbSubject.SelectedValue);
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

        private void Updates()
        {
            SqlCommand cmd = new SqlCommand("Update regSubject set tid=@tid,classid=@classid,stid=@stid where sid=" +lblID.Text, AppStart.cnn);
            //cmd.CommandType = CommandType.;
            cmd.Parameters.AddWithValue("@tid", cbTeacher.SelectedValue);
            cmd.Parameters.AddWithValue("@classid", cbClass.SelectedValue);
            cmd.Parameters.AddWithValue("@stid", cbSubject.SelectedValue);
            if (AppStart.cnn.State == ConnectionState.Closed) AppStart.cnn.Open();
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                MessageBox.Show("Record Successfully Updated.");
            }
            else
            {
                MessageBox.Show("Error Found.");
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            FillGrid();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Updates();
            FillGrid();
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
             if (dataGridView1.CurrentRow.Cells["subject"].Value.ToString().Length < 1)
            {
               // New();
            }
            else
            {
              //  New();
                //picImage.Image = null;
                //picImage.SizeMode = PictureBoxSizeMode.StretchImage;
                // DataGridViewRow row = this.dataGridView1.SelectedRows[0];
                // txtComputerID.Text = dataGridView1.CurrentRow.Cells["stID"].Value.ToString();
                lblID.Text=dataGridView1.CurrentRow.Cells["sid"].Value.ToString();
                cbTeacher.Text = dataGridView1.CurrentRow.Cells["teacher"].Value.ToString();
                 //lblstID.Text = dataGridView1.CurrentRow.Cells["stID"].Value.ToString();

               cbSubject.Text = dataGridView1.CurrentRow.Cells["subject"].Value.ToString();
                //lblstID.Text=dr["stid"].ToString();
                cbClass.Text = dataGridView1.CurrentRow.Cells["stClass"].Value.ToString();
               
             }
        }
        private void Delete()
        {
            SqlCommand cmd = new SqlCommand("Delete from regSubject where sid=" + lblID.Text, AppStart.cnn);
            
            if (AppStart.cnn.State == ConnectionState.Closed) AppStart.cnn.Open();
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                MessageBox.Show("Record Successfully Deleted.");
            }
            else
            {
                MessageBox.Show("Error Found.");
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
            FillGrid();
        }
    }
}
