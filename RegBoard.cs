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
    public partial class RegBoard : Form
    {
        public RegBoard()
        {
            InitializeComponent();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

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
        private void New()
        {
           // chkRegular.Checked = false;
           // chkPrivate.Checked = false;
           // txtGRno.Text = "";
            txtName.Text = "";
            txtFName.Text = "";
            txtBoardName.Text = "";
            txtSeatNo.Text = "";
            txtIdentification.Text = "";
            txtYear.Text = "";
            txtCenter.Text = "";


           txtObtainMarks.Text="";
            txtGrade.Text="";
            cbPassFail.Text="";
        }
        private void New2()
        {
            chkRegular.Checked = false;
            chkPrivate.Checked = false;
            //txtGRno.Text = "";
           // txtName.Text = "";
           // txtFName.Text = "";
            txtBoardName.Text = "";
            txtSeatNo.Text = "";
            txtIdentification.Text = "";
            txtYear.Text = "";
            txtCenter.Text = "";
            txtObtainMarks.Text = "";
            txtGrade.Text = "";
            cbPassFail.Text = "";

        }
         private void Save()
        {
            SqlCommand cmd = new SqlCommand("insert into regBoard(stid,bclassid,bStudyAs,bRollGRNo,bName,bFName,bBoard,bSeatNo,bIdentification,bYear,bCenter,bGroup,bObtainMarks,bGrade,bPassFail) values (@stid,@bclassid,@bStudyAs,@bRollGRNo,@bName,@bFName,@bBoard,@bSeatNo,@bIdentification,@bYear,@bCenter,@bGroup,@bObtainMarks,@bGrade,@bPassFail) ", AppStart.cnn);
            //cmd.CommandType = CommandType.;
            cmd.Parameters.AddWithValue("@stid", lblstID.Text );
              cmd.Parameters.AddWithValue("@bclassid", cbClass.SelectedValue );
             string Study,Group;
             if (chkRegular.Checked==true)
             {
                 Study="Regular";
                 Group=cbRegular.Text;
             }
             else
             {
                 Group = cbPrivate.Text;
                 Study="Private";
             }
              cmd.Parameters.AddWithValue("@bStudyAs", Study);
              cmd.Parameters.AddWithValue("@bRollGRNo", txtGRno.Text);
              cmd.Parameters.AddWithValue("@bName", txtName.Text);
              cmd.Parameters.AddWithValue("@bFName", txtFName.Text);
              cmd.Parameters.AddWithValue("@bBoard", txtBoardName.Text);
              cmd.Parameters.AddWithValue("@bSeatNo", txtSeatNo.Text);
              cmd.Parameters.AddWithValue("@bIdentification", txtIdentification.Text);
              cmd.Parameters.AddWithValue("@bYear", txtYear.Text);
              cmd.Parameters.AddWithValue("@bCenter", txtCenter.Text);
              cmd.Parameters.AddWithValue("@bGroup", Group);

              cmd.Parameters.AddWithValue("@bObtainMarks", txtObtainMarks.Text);
              cmd.Parameters.AddWithValue("@bGrade", txtGrade.Text);
              cmd.Parameters.AddWithValue("@bPassFail", cbPassFail.Text);
             

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
             SqlCommand cmd = new SqlCommand("Update regBoard set stid=@stid,bclassid=@bclassid,bStudyAs=@bStudyAs,bRollGRNo=@bRollGRNo,bName=@bName,bFName=@bFName,bBoard=@bBoard,bSeatNo=@bSeatNo,bIdentification=@bIdentification,bYear=@bYear,bCenter=@bCenter,bGroup=@bGroup, bObtainMarks=@bObtainMarks,bGrade=@bGrade,bPassFail=@bPassFial where bid= " +lblID.Text , AppStart.cnn);
             //cmd.CommandType = CommandType.;
             cmd.Parameters.AddWithValue("@stid", lblstID.Text);
             cmd.Parameters.AddWithValue("@bclassid", cbClass.SelectedValue);
             string Study, Group;
             if (chkRegular.Checked == true)
             {
                 Study = "Regular";
                 Group = cbRegular.Text;
             }
             else
             {
                 Group = cbPrivate.Text;
                 Study = "Private";
             }
             cmd.Parameters.AddWithValue("@bStudyAs", Study);
             cmd.Parameters.AddWithValue("@bRollGRNo", txtGRno.Text);
             cmd.Parameters.AddWithValue("@bName", txtName.Text);
             cmd.Parameters.AddWithValue("@bFName", txtFName.Text);
             cmd.Parameters.AddWithValue("@bBoard", txtBoardName.Text);
             cmd.Parameters.AddWithValue("@bSeatNo", txtSeatNo.Text);
             cmd.Parameters.AddWithValue("@bIdentification", txtIdentification.Text);
             cmd.Parameters.AddWithValue("@bYear", txtYear.Text);
             cmd.Parameters.AddWithValue("@bCenter", txtCenter.Text);
             cmd.Parameters.AddWithValue("@bGroup", Group);

             cmd.Parameters.AddWithValue("@bObtainMarks", txtObtainMarks.Text);
             cmd.Parameters.AddWithValue("@bGrade", txtGrade.Text);
             cmd.Parameters.AddWithValue("@bPassFail", cbPassFail.Text);
             

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
         private void Search()
        {
            string SQL;
            if (chkPrivate.Checked)
                SQL = "Select * from regstudentprivate where stgr=" + txtGRno.Text;
            else
               SQL= "Select * from regstudent where stgr=" + txtGRno.Text;

            using (SqlDataAdapter a = new SqlDataAdapter(
                   SQL, AppStart.cnn))
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
                     lblstID.Text=dr["stid"].ToString();
                     cbClass.SelectedValue = dr["stClass"].ToString();
                    //if (dr["bStudyAs"].ToString()=="Regular")
                    //{
                    //cbRegular.Text= dr["bGroup"].ToString();
                    //}
                    //else
                    //{
                    //    cbPrivate.Text=dr["bGroup"].ToString();
                    //}

                    
                    txtGRno.Text=dr["stgr"].ToString();
                     txtFName.Text = dr["stFName"].ToString();
                   // txtBoardName.Text=dr["bBoard"].ToString();
                   // txtSeatNo.Text=dr["bSeatNo"].ToString();
                   // txtIdentification.Text=dr["bIdentification"].ToString();
                    //txtYear.Text=dr["bYear"].ToString();
                    // txtCenter.Text=dr["bCenter"].ToString();
                    
                }

            }
            if (chkPrivate.Checked)
                SQL = "Select * from ViewBoardPrivate where IDNO=" + txtGRno.Text;
            else
                SQL = "Select * from ViewBoard where IDNO=" + txtGRno.Text;
            using (SqlDataAdapter a = new SqlDataAdapter(
                  SQL, AppStart.cnn))
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
        private void btnNew_Click(object sender, EventArgs e)
        {
            New();
        }

        private void RegBoard_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.RegClass' table. You can move, or remove it, as needed.
            this.regClassTableAdapter.Fill(this.dataSet1.RegClass);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
      

        private void chkRegular_CheckedChanged(object sender, EventArgs e)
        {
           
          
            if (chkRegular.Checked)
            {
                cbRegular.Enabled = true;
                cbPrivate.Enabled = false;
            }
            else
            {
                cbRegular.Enabled = true;
                cbPrivate.Enabled = false;
            }
            chkPrivate.Checked = false;
        }

        private void chkPrivate_CheckedChanged(object sender, EventArgs e)
        {
           
           

            if (chkPrivate.Checked)
            {
                cbRegular.Enabled = false;
                cbPrivate.Enabled = true;
            }
            else
            {
                cbRegular.Enabled = false;
                cbPrivate.Enabled = true;
            }
            chkRegular.Checked = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells["IDNO"].Value.ToString().Length < 1)
            {
                New();
            }
            else
            {
                New2();
                //picImage.Image = null;
                //picImage.SizeMode = PictureBoxSizeMode.StretchImage;
                // DataGridViewRow row = this.dataGridView1.SelectedRows[0];
                // txtComputerID.Text = dataGridView1.CurrentRow.Cells["stID"].Value.ToString();
                lblID.Text=dataGridView1.CurrentRow.Cells["bid"].Value.ToString();
                lblstID.Text = dataGridView1.CurrentRow.Cells["stID"].Value.ToString();

              //  txtName.Text = dataGridView1.CurrentRow.Cells["bName"].Value.ToString(); ;
                //lblstID.Text=dr["stid"].ToString();
               // cbClass.SelectedValue = dataGridView1.CurrentRow.Cells["bClassid"].Value.ToString();
                if (dataGridView1.CurrentRow.Cells["bStudyAs"].Value.ToString() == "Regular")
                {
                    chkRegular.Checked = true;
                    chkPrivate.Checked = false;
                    cbRegular.Text = dataGridView1.CurrentRow.Cells["Group"].Value.ToString();
                }
                else
                {
                    cbPrivate.Text = dataGridView1.CurrentRow.Cells["Group"].Value.ToString();
                    chkRegular.Checked = false;
                    chkPrivate.Checked = true;
                }


               // txtGRno.Text = dataGridView1.CurrentRow.Cells["bRollGRNo"].Value.ToString();
              //  txtFName.Text = dataGridView1.CurrentRow.Cells["bFName"].Value.ToString();
                txtBoardName.Text = dataGridView1.CurrentRow.Cells["Board"].Value.ToString();
                txtSeatNo.Text = dataGridView1.CurrentRow.Cells["SeatNo"].Value.ToString();
                txtIdentification.Text = dataGridView1.CurrentRow.Cells["Identification"].Value.ToString();
                txtYear.Text = dataGridView1.CurrentRow.Cells["Year"].Value.ToString();
                txtCenter.Text = dataGridView1.CurrentRow.Cells["Center"].Value.ToString();
                txtObtainMarks.Text = dataGridView1.CurrentRow.Cells["bObtainMarks"].Value.ToString();
                txtGrade.Text = dataGridView1.CurrentRow.Cells["bGrade"].Value.ToString();
                cbPassFail.Text = dataGridView1.CurrentRow.Cells["bPassFail"].Value.ToString();
            }
             }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Updates();
        }

        private void chkExam_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExam.Checked)
            {
                txtObtainMarks.Enabled = true;
                txtGrade.Enabled = true;
                cbPassFail.Enabled = true;
            }
            else
            {
                txtObtainMarks.Enabled = false;
                txtGrade.Enabled = false;
                cbPassFail.Enabled = false;
            }
        }
    }
}
