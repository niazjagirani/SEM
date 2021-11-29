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
    public partial class RegExam : Form
    {
        public RegExam()
        {
            InitializeComponent();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RegExam_Load(object sender, EventArgs e)
        {
// TODO: This line of code loads data into the 'dataSet1.RegClass' table. You can move, or remove it, as needed.
this.regClassTableAdapter.Fill(this.dataSet1.RegClass);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            Save();


        }
        private void New()
        {
            txtName.Text  = "";
            txtFName.Text = "";
           // cbClass.Text. = "";
            txtSeatNo.Text = "";
            cbExamType.Text = "";
            cbSubject1.Text = "";
            cbSubject2.Text = "";
            cbSubject3.Text = "";
            cbSubject4.Text = "";
            cbSubject5.Text = "";
            cbSubject6.Text = "";
            cbSubject7.Text = "";
            cbSubject8.Text = "";
            txtTotMarks1.Text = "";
            txtTotMarks2.Text = "";
            txtTotMarks3.Text = "";
            txtTotMarks4.Text = "";
            txtTotMarks5.Text = "";
            txtTotMarks6.Text = "";
            txtTotMarks7.Text = "";
            txtTotMarks8.Text = "";
            cbPassMarks1.Text = "";
            cbPassMarks2.Text = "";
            cbPassMarks3.Text = "";
            cbPassMarks4.Text = "";
            cbPassMarks5.Text = "";
            cbPassMarks6.Text = "";
            cbPassMarks7.Text = "";
            cbPassMarks8.Text = "";
            txtObtainMarks1.Text = "";
            txtObtainMarks2.Text = "";
            txtObtainMarks3.Text = "";
            txtObtainMarks4.Text = "";
            txtObtainMarks5.Text = "";
            txtObtainMarks6.Text = "";
            txtObtainMarks7.Text = "";
            txtObtainMarks8.Text = "";

        }
        private void Search()
        {
            if (txtGR.Text.Length > 0)
            {

                using (SqlDataAdapter a = new SqlDataAdapter("Select * from regstudent where stGR=" + txtGR.Text, AppStart.cnn))
                {
                    New();
                    // 3
                    // Use DataAdapter to fill DataTable
                    DataTable t = new DataTable();
                    a.Fill(t);
                    // 4
                    int i = 0;
                    if (t.Rows.Count < 1)
                    {
                        MessageBox.Show("G.R. No. is not found");
                        return;
                    }
                    foreach (DataRow dr in t.Rows)
                    {

                        txtGR.Text = dr["stGR"].ToString();
                        txtName.Text = dr["stName"].ToString();
                        txtFName.Text = dr["stFName"].ToString();
                        cbClass.SelectedValue = dr["stClass"].ToString();
                       
                    }
                }
                using (SqlDataAdapter b = new SqlDataAdapter("Select distinct stGR as GR,eYear as Year, eExamType as ExamType, eSeatNo as SeatNo  from regExam where stGR=" + txtGR.Text, AppStart.cnn))
                {
                   // New();
                    // 3
                    // Use DataAdapter to fill DataTable
                    DataTable tt = new DataTable();
                    b.Fill(tt);
                    // 4
                    dataGridView1.DataSource = tt;
                    dataGridView1.Refresh();
                }
            }
        }
        private int InsertRecords(int GR, string Year, string SeatNo, string ExamType, string Subject, int Obtain, int Pass, int Total)
        {
            SqlCommand cmd = new SqlCommand("insert into regExam(stGR,eYear,eSeatNo,eExamType,eSubject,eOMarks,ePMarks,eTMarks,eDate) values (@stGR,@eYear,@eSeatNo,@eExamType,@eSubject,@eOMarks,@ePMarks,@eTMarks,@eDate) ", AppStart.cnn);
            //cmd.CommandType = CommandType.;
            cmd.Parameters.AddWithValue("@stGR", GR);
            cmd.Parameters.AddWithValue("@eYear", Year);
            cmd.Parameters.AddWithValue("@eSeatNo", SeatNo);
            cmd.Parameters.AddWithValue("@eExamType", ExamType);
            cmd.Parameters.AddWithValue("@eSubject", Subject);
            cmd.Parameters.AddWithValue("@eOMarks", Obtain);
            cmd.Parameters.AddWithValue("@ePMarks", Pass);
            cmd.Parameters.AddWithValue("@eTMarks", Total);
            cmd.Parameters.AddWithValue("@eDate", DateTime.Now.ToShortDateString());
           int ii= cmd.ExecuteNonQuery();
           return ii;
        }
        private int UpdateRecords(int GR, string Year, string SeatNo, string ExamType, string Subject, int Obtain, int Pass, int Total,int ID)
        {
            SqlCommand cmd = new SqlCommand("update regExam set stGR=@stGR,eYear=@eYear,eSeatNo=@eSeatNo,eExamType=@eExamType,eSubject=@eSubject,eOMarks=@eOMarks,ePMarks=@ePMarks,eTMarks=@eTMarks where exid=" +ID, AppStart.cnn);
            //cmd.CommandType = CommandType.;
            cmd.Parameters.AddWithValue("@stGR", GR);
            cmd.Parameters.AddWithValue("@eYear", Year);
            cmd.Parameters.AddWithValue("@eSeatNo", SeatNo);
            cmd.Parameters.AddWithValue("@eExamType", ExamType);
            cmd.Parameters.AddWithValue("@eSubject", Subject);
            cmd.Parameters.AddWithValue("@eOMarks", Obtain);
            cmd.Parameters.AddWithValue("@ePMarks", Pass);
            cmd.Parameters.AddWithValue("@eTMarks", Total);
            
            int ii = cmd.ExecuteNonQuery();
            return ii;
        }
        private void Update()
        {
            int ii = 0;
            if (AppStart.cnn.State == ConnectionState.Closed) AppStart.cnn.Open();
            if (cbSubject1.Text.Length > 0 && txtObtainMarks1.Text.Length > 0 && cbPassMarks1.Text.Length > 0 && txtTotMarks1.Text.Length > 0)
            {
                ii = UpdateRecords(Convert.ToInt32(txtGR.Text), dtYear.Text, txtSeatNo.Text, cbExamType.Text, cbSubject1.Text, Convert.ToInt32(txtObtainMarks1.Text), Convert.ToInt32(cbPassMarks1.Text), Convert.ToInt32(txtTotMarks1.Text),Convert.ToInt32(lblID1.Text));
            }
            if (cbSubject2.Text.Length > 0 && txtObtainMarks2.Text.Length > 0 && cbPassMarks2.Text.Length > 0 && txtTotMarks2.Text.Length > 0)
            {
                ii = UpdateRecords(Convert.ToInt32(txtGR.Text), dtYear.Text, txtSeatNo.Text, cbExamType.Text, cbSubject2.Text, Convert.ToInt32(txtObtainMarks2.Text), Convert.ToInt32(cbPassMarks2.Text), Convert.ToInt32(txtTotMarks2.Text), Convert.ToInt32(lblID2.Text));
            }
            if (cbSubject3.Text.Length > 0 && txtObtainMarks3.Text.Length > 0 && cbPassMarks3.Text.Length > 0 && txtTotMarks3.Text.Length > 0)
            {
                ii = UpdateRecords(Convert.ToInt32(txtGR.Text), dtYear.Text, txtSeatNo.Text, cbExamType.Text, cbSubject3.Text, Convert.ToInt32(txtObtainMarks3.Text), Convert.ToInt32(cbPassMarks3.Text), Convert.ToInt32(txtTotMarks3.Text), Convert.ToInt32(lblID3.Text));
            }
            if (cbSubject4.Text.Length > 0 && txtObtainMarks4.Text.Length > 0 && cbPassMarks4.Text.Length > 0 && txtTotMarks4.Text.Length > 0)
            {
                ii = UpdateRecords(Convert.ToInt32(txtGR.Text), dtYear.Text, txtSeatNo.Text, cbExamType.Text, cbSubject4.Text, Convert.ToInt32(txtObtainMarks4.Text), Convert.ToInt32(cbPassMarks4.Text), Convert.ToInt32(txtTotMarks4.Text), Convert.ToInt32(lblID4.Text));
            }
            if (cbSubject5.Text.Length > 0 && txtObtainMarks5.Text.Length > 0 && cbPassMarks5.Text.Length > 0 && txtTotMarks5.Text.Length > 0)
            {
                ii = UpdateRecords(Convert.ToInt32(txtGR.Text), dtYear.Text, txtSeatNo.Text, cbExamType.Text, cbSubject5.Text, Convert.ToInt32(txtObtainMarks5.Text), Convert.ToInt32(cbPassMarks5.Text), Convert.ToInt32(txtTotMarks5.Text), Convert.ToInt32(lblID5.Text));
            }
            if (cbSubject6.Text.Length > 0 && txtObtainMarks6.Text.Length > 0 && cbPassMarks6.Text.Length > 0 && txtTotMarks6.Text.Length > 0)
            {
                ii = UpdateRecords(Convert.ToInt32(txtGR.Text), dtYear.Text, txtSeatNo.Text, cbExamType.Text, cbSubject6.Text, Convert.ToInt32(txtObtainMarks6.Text), Convert.ToInt32(cbPassMarks6.Text), Convert.ToInt32(txtTotMarks6.Text), Convert.ToInt32(lblID6.Text));
            }
            if (cbSubject7.Text.Length > 0 && txtObtainMarks7.Text.Length > 0 && cbPassMarks7.Text.Length > 0 && txtTotMarks7.Text.Length > 0)
            {
                ii = UpdateRecords(Convert.ToInt32(txtGR.Text), dtYear.Text, txtSeatNo.Text, cbExamType.Text, cbSubject7.Text, Convert.ToInt32(txtObtainMarks7.Text), Convert.ToInt32(cbPassMarks7.Text), Convert.ToInt32(txtTotMarks7.Text), Convert.ToInt32(lblID7.Text));
            }
            if (cbSubject8.Text.Length > 0 && txtObtainMarks8.Text.Length > 0 && cbPassMarks8.Text.Length > 0 && txtTotMarks8.Text.Length > 0)
            {
                ii = UpdateRecords(Convert.ToInt32(txtGR.Text), dtYear.Text, txtSeatNo.Text, cbExamType.Text, cbSubject8.Text, Convert.ToInt32(txtObtainMarks8.Text), Convert.ToInt32(cbPassMarks8.Text), Convert.ToInt32(txtTotMarks8.Text), Convert.ToInt32(lblID8.Text));
            }
            if (ii > 0)
            {
                MessageBox.Show("Record Successfully Updated.");
            }
            else
            {
                MessageBox.Show("Error Found.");
            }
        }
        private void Save()
        {
            int ii = 0;
            if (AppStart.cnn.State == ConnectionState.Closed) AppStart.cnn.Open();
            if (cbSubject1.Text.Length > 0 && txtObtainMarks1.Text.Length > 0 && cbPassMarks1.Text.Length > 0 && txtTotMarks1.Text.Length > 0)
            {
               ii= InsertRecords(Convert.ToInt32(txtGR.Text), dtYear.Text, txtSeatNo.Text, cbExamType.Text, cbSubject1.Text, Convert.ToInt32(txtObtainMarks1.Text), Convert.ToInt32(cbPassMarks1.Text), Convert.ToInt32(txtTotMarks1.Text));
            }
            if (cbSubject2.Text.Length > 0 && txtObtainMarks2.Text.Length > 0 && cbPassMarks2.Text.Length > 0 && txtTotMarks2.Text.Length > 0)
            {
               ii= InsertRecords(Convert.ToInt32(txtGR.Text), dtYear.Text, txtSeatNo.Text, cbExamType.Text, cbSubject2.Text, Convert.ToInt32(txtObtainMarks2.Text), Convert.ToInt32(cbPassMarks2.Text), Convert.ToInt32(txtTotMarks2.Text));
            }
            if (cbSubject3.Text.Length > 0 && txtObtainMarks3.Text.Length > 0 && cbPassMarks3.Text.Length > 0 && txtTotMarks3.Text.Length > 0)
            {
                ii=InsertRecords(Convert.ToInt32(txtGR.Text), dtYear.Text, txtSeatNo.Text, cbExamType.Text, cbSubject3.Text, Convert.ToInt32(txtObtainMarks3.Text), Convert.ToInt32(cbPassMarks3.Text), Convert.ToInt32(txtTotMarks3.Text));
            }
            if (cbSubject4.Text.Length > 0 && txtObtainMarks4.Text.Length > 0 && cbPassMarks4.Text.Length > 0 && txtTotMarks4.Text.Length > 0)
            {
               ii= InsertRecords(Convert.ToInt32(txtGR.Text), dtYear.Text, txtSeatNo.Text, cbExamType.Text, cbSubject4.Text, Convert.ToInt32(txtObtainMarks4.Text), Convert.ToInt32(cbPassMarks4.Text), Convert.ToInt32(txtTotMarks4.Text));
            }
            if (cbSubject5.Text.Length > 0 && txtObtainMarks5.Text.Length > 0 && cbPassMarks5.Text.Length > 0 && txtTotMarks5.Text.Length > 0)
            {
               ii= InsertRecords(Convert.ToInt32(txtGR.Text), dtYear.Text, txtSeatNo.Text, cbExamType.Text, cbSubject5.Text, Convert.ToInt32(txtObtainMarks5.Text), Convert.ToInt32(cbPassMarks5.Text), Convert.ToInt32(txtTotMarks5.Text));
            }
            if (cbSubject6.Text.Length > 0 && txtObtainMarks6.Text.Length > 0 && cbPassMarks6.Text.Length > 0 && txtTotMarks6.Text.Length > 0)
            {
               ii= InsertRecords(Convert.ToInt32(txtGR.Text), dtYear.Text, txtSeatNo.Text, cbExamType.Text, cbSubject6.Text, Convert.ToInt32(txtObtainMarks6.Text), Convert.ToInt32(cbPassMarks6.Text), Convert.ToInt32(txtTotMarks6.Text));
            }
            if (cbSubject7.Text.Length > 0 && txtObtainMarks7.Text.Length > 0 && cbPassMarks7.Text.Length > 0 && txtTotMarks7.Text.Length > 0)
            {
               ii= InsertRecords(Convert.ToInt32(txtGR.Text), dtYear.Text, txtSeatNo.Text, cbExamType.Text, cbSubject7.Text, Convert.ToInt32(txtObtainMarks7.Text), Convert.ToInt32(cbPassMarks7.Text), Convert.ToInt32(txtTotMarks7.Text));
            }
            if (cbSubject8.Text.Length > 0 && txtObtainMarks8.Text.Length>0 && cbPassMarks8.Text.Length>0 && txtTotMarks8.Text.Length>0)
            {
               ii= InsertRecords(Convert.ToInt32(txtGR.Text), dtYear.Text, txtSeatNo.Text, cbExamType.Text, cbSubject8.Text, Convert.ToInt32(txtObtainMarks8.Text), Convert.ToInt32(cbPassMarks8.Text), Convert.ToInt32(txtTotMarks8.Text));
            }
            if (ii > 0)
            {
                MessageBox.Show("Record Successfully Added.");
            }
            else
            {
                MessageBox.Show("Error Found.");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            New();
        }
        private void Search2()
        {
            if (txtGR.Text.Length > 0)
            {

                using (SqlDataAdapter a = new SqlDataAdapter("Select * from regExam where stGR=" + txtGR.Text + " and eYear='" + dtYear.Text + "' and eExamType='" + cbExamType.Text + "'", AppStart.cnn))
                {
                   // New();
                    // 3
                    // Use DataAdapter to fill DataTable
                    DataTable t = new DataTable();
                    a.Fill(t);
                    // 4
                    int i = 0;
                    if (t.Rows.Count < 1)
                    {
                       // MessageBox.Show("G.R. No. is not found");
                        return;
                    }
                    int c = 0;
                    foreach (DataRow dr in t.Rows)
                    {
                        c += 1;
                        if (c == 1)
                        {
                            lblID1.Text = dr["exid"].ToString();
                            cbSubject1.Text = dr["eSubject"].ToString();
                            txtTotMarks1.Text = dr["eTMarks"].ToString();
                            txtObtainMarks1.Text = dr["eOMarks"].ToString();
                            cbPassMarks1.Text = dr["ePMarks"].ToString();
                        }
                        if (c == 2)
                        {
                            lblID2.Text = dr["exid"].ToString();
                            cbSubject2.Text = dr["eSubject"].ToString();
                            txtTotMarks2.Text = dr["eTMarks"].ToString();
                            txtObtainMarks2.Text = dr["eOMarks"].ToString();
                            cbPassMarks2.Text = dr["ePMarks"].ToString();
                        }
                        if (c == 3)
                        {
                            lblID3.Text = dr["exid"].ToString();
                            cbSubject3.Text = dr["eSubject"].ToString();
                            txtTotMarks3.Text = dr["eTMarks"].ToString();
                            txtObtainMarks3.Text = dr["eOMarks"].ToString();
                            cbPassMarks3.Text = dr["ePMarks"].ToString();
                        }
                        if (c == 4)
                        {
                            lblID4.Text = dr["exid"].ToString();
                            cbSubject4.Text = dr["eSubject"].ToString();
                            txtTotMarks4.Text = dr["eTMarks"].ToString();
                            txtObtainMarks4.Text = dr["eOMarks"].ToString();
                            cbPassMarks4.Text = dr["ePMarks"].ToString();
                        }
                        if (c == 5)
                        {
                            lblID5.Text = dr["exid"].ToString();
                            cbSubject5.Text = dr["eSubject"].ToString();
                            txtTotMarks5.Text = dr["eTMarks"].ToString();
                            txtObtainMarks5.Text = dr["eOMarks"].ToString();
                            cbPassMarks5.Text = dr["ePMarks"].ToString();
                        }
                        if (c == 6)
                        {
                            lblID6.Text = dr["exid"].ToString();
                            cbSubject6.Text = dr["eSubject"].ToString();
                            txtTotMarks6.Text = dr["eTMarks"].ToString();
                            txtObtainMarks6.Text = dr["eOMarks"].ToString();
                            cbPassMarks6.Text = dr["ePMarks"].ToString();
                        }
                        if (c == 7)
                        {
                            lblID7.Text = dr["exid"].ToString();
                            cbSubject7.Text = dr["eSubject"].ToString();
                            txtTotMarks7.Text = dr["eTMarks"].ToString();
                            txtObtainMarks7.Text = dr["eOMarks"].ToString();
                            cbPassMarks7.Text = dr["ePMarks"].ToString();
                        }
                        if (c == 8)
                        {
                            lblID8.Text = dr["exid"].ToString();
                            cbSubject8.Text = dr["eSubject"].ToString();
                            txtTotMarks8.Text = dr["eTMarks"].ToString();
                            txtObtainMarks8.Text = dr["eOMarks"].ToString();
                            cbPassMarks8.Text = dr["ePMarks"].ToString();
                        }


                    }
                }
            }
        }
        private void cbExamType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search2();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Update();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtSeatNo.Text = dataGridView1.Rows[e.RowIndex].Cells["SeatNo"].Value.ToString();
            cbExamType.Text = dataGridView1.Rows[e.RowIndex].Cells["ExamType"].Value.ToString();
            dtYear.Text = dataGridView1.Rows[e.RowIndex].Cells["Year"].Value.ToString();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtSeatNo.Text = dataGridView1.Rows[e.RowIndex].Cells["SeatNo"].Value.ToString();
            cbExamType.Text = dataGridView1.Rows[e.RowIndex].Cells["ExamType"].Value.ToString();
            dtYear.Text = dataGridView1.Rows[e.RowIndex].Cells["Year"].Value.ToString();
        }
  }
    
}
