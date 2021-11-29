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
    public partial class RegFees : Form
    {
        public RegFees()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void RegFees_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.RegFeesType' table. You can move, or remove it, as needed.
            this.regFeesTypeTableAdapter.Fill(this.dataSet1.RegFeesType);
            // TODO: This line of code loads data into the 'dataSet1.RegClass' table. You can move, or remove it, as needed.
            this.regClassTableAdapter.Fill(this.dataSet1.RegClass);

        }
        private void Search()
        {

            using (SqlDataAdapter a = new SqlDataAdapter(
                   "Select * from regstudent where stgr=" + txtGRno.Text, AppStart.cnn))
            {

                // Use DataAdapter to fill DataTable
                DataTable t = new DataTable();
                a.Fill(t);

                int i = 0;
                New();
                foreach (DataRow dr in t.Rows)
                {
                    // i = Convert.ToInt32(dr["ID"].ToString());
                    // .Text = dr["stID"].ToString();

                    txtName.Text = dr["stName"].ToString();
                    lblstID.Text = dr["stid"].ToString();
                    txtFees.Text = (Convert.ToInt32(dr["stMonthlyFees"].ToString()) - Convert.ToInt32(dr["stDiscount"].ToString())).ToString();
                    cbClass.SelectedValue = dr["stClass"].ToString();
                    //if (dr["bStudyAs"].ToString()=="Regular")
                    //{
                    //cbRegular.Text= dr["bGroup"].ToString();
                    //}
                    //else
                    //{
                    //    cbPrivate.Text=dr["bGroup"].ToString();
                    //}


                    txtGRno.Text = dr["stgr"].ToString();
                    txtFName.Text = dr["stFName"].ToString();
                    // txtBoardName.Text=dr["bBoard"].ToString();
                    // txtSeatNo.Text=dr["bSeatNo"].ToString();
                    // txtIdentification.Text=dr["bIdentification"].ToString();
                    //txtYear.Text=dr["bYear"].ToString();
                    // txtCenter.Text=dr["bCenter"].ToString();

                }

            }
            using (SqlDataAdapter a = new SqlDataAdapter(
                  "Select * from RegFees where stgrno=" + txtGRno.Text, AppStart.cnn))
            {
                // 3
                // Use DataAdapter to fill DataTable
                DataTable t = new DataTable();
                a.Fill(t);
                // 4
                int i = 0;
                dataGridView1.DataSource = t;
            }
            SqlCommand cm = new SqlCommand("Select top 1 fArriers from RegFees where stgrno=" + txtGRno.Text + " order by fid  Desc", AppStart.cnn);
            if (AppStart.cnn.State == ConnectionState.Closed) AppStart.cnn.Open();
            int data = Convert.ToInt32( cm.ExecuteScalar());
            txtPrevBalance.Text = data.ToString();
            

            txtDues.Text = (Convert.ToInt32(txtPrevBalance.Text) + Convert.ToInt32(txtFees.Text)).ToString();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
            txtDues.ReadOnly = true;
            txtArriers.ReadOnly = true;
            txtDues.ReadOnly = true;
            txtPrevBalance.ReadOnly = true;
        }
        private void New()
        {
            txtGRno.Text = "";
            txtName.Text = "";
            txtFName.Text = "";
            txtFees.Text = "";
            txtArriers.Text = "";
            txtPaid.Text = "";
            txtPrevBalance.Text = "";
            

        }
        private void Save()
        {
            SqlCommand cmd = new SqlCommand("insert into regFees(stgrNo,fName,ffName,fClassId,fMonth,fType,fPrevBal,ffees,fpaid,farriers) values (@stgrNo,@fName,@ffName,@fClassId,@fMonth,@fType,@fPrevBal,@ffees,@fpaid,@farriers) ", AppStart.cnn);
            //cmd.CommandType = CommandType.;
            cmd.Parameters.AddWithValue("@stgrNo", txtGRno.Text);
            cmd.Parameters.AddWithValue("@fClassId", cbClass.SelectedValue);

            cmd.Parameters.AddWithValue("@fMonth", dtMonth.Text);
            cmd.Parameters.AddWithValue("@fType", cbFeesType.SelectedValue);
            cmd.Parameters.AddWithValue("@fName", txtName.Text);
            cmd.Parameters.AddWithValue("@ffName", txtFName.Text);
            cmd.Parameters.AddWithValue("@fPrevBal", txtPrevBalance.Text);
            cmd.Parameters.AddWithValue("@ffees", txtFees.Text);
            cmd.Parameters.AddWithValue("@fpaid", txtPaid.Text);
            cmd.Parameters.AddWithValue("@farriers", txtArriers.Text);
          


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
            Search();
        }
        private void Updates()
        {
            SqlCommand cmd = new SqlCommand("update regFees set stgrNo=@stgrNo,fName=@fName,ffName=@ffName,fClassId=@fClassId,fMonth=@fMonth,fType=@fType,fPrevBal=@fPrevBal,ffees=@ffees,fpaid=@fpaid,farriers=@farriers where fid=" + lblID.Text , AppStart.cnn);
            //cmd.CommandType = CommandType.;
            cmd.Parameters.AddWithValue("@stgrNo", txtGRno.Text);
            cmd.Parameters.AddWithValue("@fClassId", cbClass.SelectedValue);

            cmd.Parameters.AddWithValue("@fMonth", dtMonth.Text);
            cmd.Parameters.AddWithValue("@fType", cbFeesType.SelectedValue);
            cmd.Parameters.AddWithValue("@fName", txtName.Text);
            cmd.Parameters.AddWithValue("@ffName", txtFName.Text);
            cmd.Parameters.AddWithValue("@fPrevBal", txtPrevBalance.Text);
            cmd.Parameters.AddWithValue("@ffees", txtFees.Text);
            cmd.Parameters.AddWithValue("@fpaid", txtPaid.Text);
            cmd.Parameters.AddWithValue("@farriers", txtArriers.Text);



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
            Search();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.N))
            {
                New();


                return true;
            }
            if (keyData == (Keys.Control | Keys.S))
            {
                Save();


                return true;
            }
            if (keyData == (Keys.Control | Keys.U))
            {
                Updates();


                return true;
            }
            if (keyData == (Keys.Control | Keys.R))
            {
                Search();


                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void txtPaid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtArriers.Text = ((Convert.ToInt32(txtPrevBalance.Text) + Convert.ToInt32(txtFees.Text)) - Convert.ToInt32(txtPaid.Text)).ToString();
            }
            catch
            {
            }
            }

        private void btnNew_Click(object sender, EventArgs e)
        {
            New();
            txtDues.ReadOnly = true;
            txtArriers.ReadOnly = true;
            txtDues.ReadOnly = true;
            txtPrevBalance.ReadOnly = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            txtDues.ReadOnly = true;
            txtArriers.ReadOnly = true;
            txtDues.ReadOnly = true;
            txtPrevBalance.ReadOnly = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Updates();
           txtDues.ReadOnly = true;
                txtArriers.ReadOnly = true;
                txtDues.ReadOnly = true;
                txtPrevBalance.ReadOnly = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells["stgrno"].Value.ToString().Length < 1)
            {
                New();
            }
            else
            {
                New();
                //picImage.Image = null;
                //picImage.SizeMode = PictureBoxSizeMode.StretchImage;
                // DataGridViewRow row = this.dataGridView1.SelectedRows[0];
                // txtComputerID.Text = dataGridView1.CurrentRow.Cells["stID"].Value.ToString();
                lblID.Text = dataGridView1.CurrentRow.Cells["fid"].Value.ToString();
               // lblstID.Text = dataGridView1.CurrentRow.Cells["stID"].Value.ToString();

                txtName.Text = dataGridView1.CurrentRow.Cells["fName"].Value.ToString(); ;
                //lblstID.Text=dr["stid"].ToString();
                cbClass.SelectedValue = dataGridView1.CurrentRow.Cells["fClassid"].Value.ToString();
               

                txtGRno.Text = dataGridView1.CurrentRow.Cells["stGRNo"].Value.ToString();
                txtFName.Text = dataGridView1.CurrentRow.Cells["fFName"].Value.ToString();
                txtPrevBalance.Text = dataGridView1.CurrentRow.Cells["fprevbal"].Value.ToString();
                txtFees.Text = dataGridView1.CurrentRow.Cells["ffees"].Value.ToString();
                txtPaid.Text = dataGridView1.CurrentRow.Cells["fpaid"].Value.ToString();
                txtArriers.Text = dataGridView1.CurrentRow.Cells["farriers"].Value.ToString();
                cbFeesType.SelectedValue = dataGridView1.CurrentRow.Cells["fType"].Value.ToString();
                dtMonth.Text = dataGridView1.CurrentRow.Cells["fMonth"].Value.ToString();
                txtDues.Text = (Convert.ToInt32(txtPrevBalance.Text) + Convert.ToInt32(txtFees.Text)).ToString();
                txtDues.ReadOnly = false;
                txtArriers.ReadOnly = false;
                txtDues.ReadOnly = false;
                txtPrevBalance.ReadOnly = false;

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
