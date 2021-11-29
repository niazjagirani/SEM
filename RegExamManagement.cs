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
    public partial class RegExamManagement : Form
    {
        public RegExamManagement()
        {
            InitializeComponent();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void RegExamManagement_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.RegSubjectName' table. You can move, or remove it, as needed.
            this.regSubjectNameTableAdapter.Fill(this.dataSet1.RegSubjectName);
            // TODO: This line of code loads data into the 'dataSet1.RegClass' table. You can move, or remove it, as needed.
            this.regClassTableAdapter.Fill(this.dataSet1.RegClass);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
                var index = dgSubject.Rows.Add();
            dgSubject.Rows[index].Cells["Subject"].Value = cbSubject.Text;
           
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dgSubject.SelectedRows)
            {
                dgSubject.Rows.RemoveAt(item.Index);
                MessageBox.Show(item.Index + "Removed");
            }

            
        }
        private void Save()
        {
            SqlCommand cmd = new SqlCommand("insert into CurrentExam(Term,eClass,eDate) values (@Term,@eClass,@eDate) ", AppStart.cnn);
            //cmd.CommandType = CommandType.;
            cmd.Parameters.AddWithValue("@Term", cbExamType.Text);
            cmd.Parameters.AddWithValue("@eclass", cbClass.Text);
            cmd.Parameters.AddWithValue("@eDate", DateTime.Now.ToShortDateString());
         
            if (AppStart.cnn.State == ConnectionState.Closed) AppStart.cnn.Open();
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
               // MessageBox.Show("Record Successfully Added.");
            }
            else
            {
                MessageBox.Show("Exam Error Found.");
                return;
            }
            //GET Last ID of Exam
            SqlCommand cmd1 = new SqlCommand("Select top 1 excid from CurrentExam order by excid DESC ", AppStart.cnn);
            int Exid = Convert.ToInt32( cmd1.ExecuteScalar().ToString());

            foreach (DataGridViewRow row in dgSubject.Rows)
            {
               //  row.Cells["qty"].Value;
                
           
            SqlCommand cmd2 = new SqlCommand("insert into CurrentExamSubject(Excid,eSubject) values (@Excid,@eSubject) ", AppStart.cnn);
            //cmd.CommandType = CommandType.;
            cmd2.Parameters.AddWithValue("@Excid", Exid);
            cmd2.Parameters.AddWithValue("@eSubject", row.Cells["Subject"].Value);
           
            int ii = cmd2.ExecuteNonQuery();
            }

            foreach (DataGridViewRow row in dgSeatNo.Rows)
            {
                //  row.Cells["qty"].Value;


                SqlCommand cmd3 = new SqlCommand("insert into CurrentExamSeatNo(Excid,stid,GSeatNo) values (@Excid,@stid,@GSeatNo) ", AppStart.cnn);
                //cmd.CommandType = CommandType.;
                cmd3.Parameters.AddWithValue("@Excid", Exid);
                cmd3.Parameters.AddWithValue("@stid", row.Cells["id"].Value);
                cmd3.Parameters.AddWithValue("@GSeatNo", row.Cells["SeatNo"].Value);

                int ii = cmd3.ExecuteNonQuery();
            }
           
        }
        private void cbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SQL = "Select stName,STfName,stid from RegStudent where stClass=" + cbClass.SelectedValue;
            try
            {
                using (SqlDataAdapter a = new SqlDataAdapter(
                      SQL, AppStart.cnn))
                {
                    dgSeatNo.Rows.Clear();
                    // 3
                    // Use DataAdapter to fill DataTable
                    DataTable t = new DataTable();
                    a.Fill(t);
                    // 4
                    int i = Convert.ToInt32(txtSeatNoStart.Text);
                    if (i == 0)
                        i = 1;
                    foreach (DataRow dr in t.Rows)
                    // dgSeatNo.DataSource = t;
                    // dgSeatNo.Refresh();
                    {
                        var index = dgSeatNo.Rows.Add();
                        dgSeatNo.Rows[index].Cells["SeatNo"].Value = i;

                        dgSeatNo.Rows[index].Cells["Student"].Value = dr["stName"].ToString() + " " + dr["stFName"].ToString();
                        dgSeatNo.Rows[index].Cells["id"].Value = dr["stid"].ToString();
                        i += 1;
                    }

                   

                }
            }
            catch
            {
               // MessageBox.Show("Please enter Numbers only in Seat.No");
            }
        }

        private void cbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SQL = "Select eDate, Term,Excid from CurrentExam where Year(edate)='" + cbYear.Text + "' order by Cast(edate as Date) Desc";
            try
            {
                using (SqlDataAdapter a = new SqlDataAdapter(
                      SQL, AppStart.cnn))
                {
                    dgExam.Rows.Clear();
                    // 3
                    // Use DataAdapter to fill DataTable
                    DataTable t = new DataTable();
                    a.Fill(t);
                    // 4
                  
                    foreach (DataRow dr in t.Rows)
                    // dgSeatNo.DataSource = t;
                    // dgSeatNo.Refresh();
                    {
                        var index = dgExam.Rows.Add();
                        dgExam.Rows[index].Cells["eDate"].Value = dr["eDate"].ToString();
                        dgExam.Rows[index].Cells["Term"].Value = dr["Term"].ToString();
                        dgExam.Rows[index].Cells["Excid"].Value = dr["Excid"].ToString();
                        
                     
                    }



                }
            }
            catch
            {
               
            }
        }

        private void dgExam_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgExam_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string SQL = "Select gSeatNo,Name from ViewSeatNo where excid=" + dgExam.Rows[e.RowIndex].Cells["Excid"].Value;
            try
            {
                using (SqlDataAdapter a = new SqlDataAdapter(
                      SQL, AppStart.cnn))
                {
                    dgSeatNo.Rows.Clear();
                    // 3
                    // Use DataAdapter to fill DataTable
                    DataTable t = new DataTable();
                    a.Fill(t);
                    // 4

                    foreach (DataRow dr in t.Rows)
                    // dgSeatNo.DataSource = t;
                    // dgSeatNo.Refresh();
                    {
                        var index = dgSeatNo.Rows.Add();
                        dgSeatNo.Rows[index].Cells["SeatNo"].Value = dr["gSeatNo"].ToString();

                        dgSeatNo.Rows[index].Cells["Student"].Value = dr["Name"].ToString();

                    }

                }
                SQL = "Select eSubject from currentexamsubject where excid=" + dgExam.Rows[e.RowIndex].Cells["Excid"].Value;
                using (SqlDataAdapter b = new SqlDataAdapter(
                     SQL, AppStart.cnn))
                {
                    dgSubject.Rows.Clear();
                    // 3
                    // Use DataAdapter to fill DataTable
                    DataTable tt = new DataTable();
                    b.Fill(tt);
                    // 4

                    foreach (DataRow dr in tt.Rows)
                    // dgSeatNo.DataSource = t;
                    // dgSeatNo.Refresh();
                    {
                        var index = dgSubject.Rows.Add();
                        dgSubject.Rows[index].Cells["Subject"].Value = dr["eSubject"].ToString();



                    }

                }


            }
            catch
            {
                // MessageBox.Show("Please enter Numbers only in Seat.No");
            }
        }
    }
}
