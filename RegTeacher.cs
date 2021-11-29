using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Data.SqlClient;
using System.Globalization;

namespace SEM
{
    public partial class RegTeacher : Form
    {
        public RegTeacher()
        {
            InitializeComponent();
        }
       private string Ukey;
        private int TeacherID()
        {
            using (SqlDataAdapter a = new SqlDataAdapter(
                    "Select top 1 tID as ID from regteacher order by id DESC", AppStart.cnn))
            {
                // 3
                // Use DataAdapter to fill DataTable
                DataTable t = new DataTable();
                a.Fill(t);
                // 4
                int i = 0;
                foreach (DataRow dr in t.Rows)
                {
                    i = Convert.ToInt32(dr["ID"].ToString());
                }
                return i;
            }

        }
        private void New()
        {
            lblID.Text = "";
            txtName.Text = "";
            txtFName.Text = "";
            txtCaste.Text = "";
            txtCNICno.Text = "";
            cbReligion.Text = "";
            txtTrainingAttended.Text = "";
            txtStartSalary.Text = "";
            txtCurrentSalary.Text = "";
            txtAnyChronical.Text = "";
            txtLeavingReason.Text = "";
        }
        private void Save()
        {
            SqlCommand cmd = new SqlCommand("insert into regTeacher(tName,tFName,tCaste,tCNICno,tReligion,tGender,tBirthDate,tMaritalStatus,tJoiningDate,tQuatification,tPQualification,tExperience,tTrainingAttended,tStartingSalary,tCurrentSalary,tBloodGroup,tAnyChronical,tLeavingSchool,tLeavingReason,tPic) values (@tName,@tFName,@tCaste,@tCNICno,@tReligion,@tGender,@tBirthDate,@tMaritalStatus,@tJoiningDate,@tQuatification,@tPQualification,@tExperience,@tTrainingAttended,@tStartingSalary,@tCurrentSalary,@tBloodGroup,@tAnyChronical,@tLeavingSchool,@tLeavingReason,@tPic) ", AppStart.cnn);
            //cmd.CommandType = CommandType.;
            cmd.Parameters.AddWithValue("@tName", txtName.Text);
            cmd.Parameters.AddWithValue("@tFName", txtFName.Text);
            cmd.Parameters.AddWithValue("@tCaste", txtCaste.Text);
            cmd.Parameters.AddWithValue("@tCNICno", txtCNICno.Text);
            cmd.Parameters.AddWithValue("@tReligion", cbReligion.Text);
            cmd.Parameters.AddWithValue("@tGender", cbGender.Text);
            cmd.Parameters.AddWithValue("@tBirthDate", dtBirthDate.Text);
            cmd.Parameters.AddWithValue("@tMaritalStatus", cbMaritalStatus.Text );
            cmd.Parameters.AddWithValue("@tJoiningDate", dtJoiningDate.Text);
            cmd.Parameters.AddWithValue("@tQuatification", cbQualification.Text);
            cmd.Parameters.AddWithValue("@tPQualification", cbProfQualification.Text);
            cmd.Parameters.AddWithValue("@tExperience", cbExperience.Text);
            cmd.Parameters.AddWithValue("@tTrainingAttended", txtTrainingAttended.Text);
            cmd.Parameters.AddWithValue("@tStartingSalary", txtStartSalary.Text);
            cmd.Parameters.AddWithValue("@tCurrentSalary", txtCurrentSalary.Text);
            cmd.Parameters.AddWithValue("@tBloodGroup", cbBlood.Text);
            cmd.Parameters.AddWithValue("@tAnyChronical", txtAnyChronical.Text);
            cmd.Parameters.AddWithValue("@tLeavingSchool", dtLeavingDate.Text);
            cmd.Parameters.AddWithValue("@tLeavingReason", txtLeavingReason.Text);
            
            string Ext = "";
            if (File.Exists(txtFilePic.Text))
            {
                Ext = Path.GetExtension(Path.GetFileName(txtFilePic.Text));
                string dest = Path.Combine("img//", "t" + TeacherID().ToString() + Ext);
                // MessageBox.Show("Path: " + dest);
                File.Copy(txtFilePic.Text, dest, true);
            }

            cmd.Parameters.AddWithValue("@tPic", "t" + TeacherID().ToString() + Ext);
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
            SqlCommand cmd = new SqlCommand("update regTeacher set tName=@tName,tFName=@tFName,tCaste=@tCaste,tCNICno=@tCNICno,tReligion=@tReligion,tGender=@tGender,tBirthDate=@tBirthDate,tMaritalStatus=@tMaritalStatus,tJoiningDate=@tJoiningDate,tQuatification=@tQuatification,tPQualification=@tPQualification,tExperience=@tExperience,tTrainingAttended=@tTrainingAttended,tStartingSalary=@tStartingSalary,tCurrentSalary=@tCurrentSalary,tBloodGroup=@tBloodGroup,tAnyChronical=@tAnyChronical,tLeavingSchool=@tLeavingSchool,tLeavingReason=@tLeavingReason,tPic=@tPic where tCNICno=" + Ukey, AppStart.cnn);
            //cmd.CommandType = CommandType.;
            cmd.Parameters.AddWithValue("@tName", txtName.Text);
            cmd.Parameters.AddWithValue("@tFName", txtFName.Text);
            cmd.Parameters.AddWithValue("@tCaste", txtCaste.Text);
            cmd.Parameters.AddWithValue("@tCNICno", txtCNICno.Text);
            cmd.Parameters.AddWithValue("@tReligion", cbReligion.Text);
            cmd.Parameters.AddWithValue("@tGender", cbGender.Text);
            cmd.Parameters.AddWithValue("@tBirthDate", dtBirthDate.Text);
            cmd.Parameters.AddWithValue("@tMaritalStatus", cbMaritalStatus.Text );
            cmd.Parameters.AddWithValue("@tJoiningDate", dtJoiningDate.Text);
            cmd.Parameters.AddWithValue("@tQuatification", cbQualification.Text);
            cmd.Parameters.AddWithValue("@tPQualification", cbProfQualification.Text);
            cmd.Parameters.AddWithValue("@tExperience", cbExperience.Text);
            cmd.Parameters.AddWithValue("@tTrainingAttended", txtTrainingAttended.Text);
            cmd.Parameters.AddWithValue("@tStartingSalary", txtStartSalary.Text);
            cmd.Parameters.AddWithValue("@tCurrentSalary", txtCurrentSalary.Text);
            cmd.Parameters.AddWithValue("@tBloodGroup", cbBlood.Text);
            cmd.Parameters.AddWithValue("@tAnyChronical", txtAnyChronical.Text);
            cmd.Parameters.AddWithValue("@tLeavingSchool", dtLeavingDate.Text);
            cmd.Parameters.AddWithValue("@tLeavingReason", txtLeavingReason.Text);
            
            string Ext = "";
            if (File.Exists(txtFilePic.Text))
            {
                Ext = Path.GetExtension(Path.GetFileName(txtFilePic.Text));
                string dest = Path.Combine("img//", "t" + lblID.Text + Ext);
                // MessageBox.Show("Path: " + dest);
                File.Copy(txtFilePic.Text, dest, true);
            }

            cmd.Parameters.AddWithValue("@tPic", "t" + lblID.Text + Ext);
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
            using (SqlDataAdapter a = new SqlDataAdapter(
                   "Select * from regteacher where tcnicno=" + txtCNICno.Text, AppStart.cnn))
            {
                // 3
                // Use DataAdapter to fill DataTable
                DataTable t = new DataTable();
                a.Fill(t);
                // 4
                int i = 0;
                foreach (DataRow dr in t.Rows)
                {
                   // i = Convert.ToInt32(dr["ID"].ToString());
                    lblID.Text = dr["tid"].ToString();
                    txtName.Text = dr["tName"].ToString();
                    txtFName.Text=dr["tFName"].ToString();
                    txtCaste.Text = dr["tCaste"].ToString();
                    txtCNICno.Text=dr["tCNICno"].ToString();
                    cbReligion.Text=dr["tReligion"].ToString();
                    cbGender.Text=dr["tGender"].ToString();
                    dtBirthDate.Text=dr["tBirthDate"].ToString();
                    cbMaritalStatus.Text= dr["tMaritalStatus"].ToString();
                    Ukey= txtCNICno.Text;
                    //if (dr["tJoiningDate"].ToString().Length > 1)
                    //{
                    //    DateTime dt = DateTime.Parse(dr["tJoiningDate"].ToString()); // Convert.ToDateTime(dr["tJoiningDate"].ToString(), CultureInfo.CurrentUICulture);
                        dtJoiningDate.Text =dr["tJoiningDate"].ToString(); // .Parse( dr["tJoiningDate"].ToString());
                   // }
                        cbQualification.Text=dr["tQuatification"].ToString();
                    cbProfQualification.Text=dr["tPQualification"].ToString();
                    cbExperience.Text=dr["tExperience"].ToString();
                    txtTrainingAttended.Text=dr["tTrainingAttended"].ToString();
                    txtStartSalary.Text=dr["tStartingSalary"].ToString();
                    txtCurrentSalary.Text=dr["tCurrentSalary"].ToString();
                    cbBlood.Text=dr["tBloodGroup"].ToString();
                    txtAnyChronical.Text = dr["tAnyChronical"].ToString();
                    dtLeavingDate.Text=dr["tLeavingSchool"].ToString();
                    txtLeavingReason.Text=dr["tLeavingReason"].ToString();

                    picImage.Load("img//" + dr["tpic"].ToString());
                    picImage.SizeMode = PictureBoxSizeMode.StretchImage;
                }
               
            }
        }
        private void btnPicBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                var ofd = new OpenFileDialog();
                ofd.InitialDirectory = GetDownloadsPath();
                ofd.Filter = "JPG Files|*.jpg|PNG Files|*.png";
                ofd.ShowDialog();
                txtFilePic.Text = ofd.FileName;
                picImage.Load(@ofd.FileName);
                picImage.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch
            { }
        }
        public static string GetDownloadsPath()
        {
            string path = null;
            if (Environment.OSVersion.Version.Major >= 6)
            {
                IntPtr pathPtr;
                int hr = SHGetKnownFolderPath(ref FolderDownloads, 0, IntPtr.Zero, out pathPtr);
                if (hr == 0)
                {
                    path = Marshal.PtrToStringUni(pathPtr);
                    Marshal.FreeCoTaskMem(pathPtr);
                    return path;
                }
            }
            path = Path.GetDirectoryName(Environment.GetFolderPath(Environment.SpecialFolder.Personal));
            path = Path.Combine(path, "Downloads");
            return path;
        }

        private static Guid FolderDownloads = new Guid("374DE290-123F-4565-9164-39C4925E467B");
        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        private static extern int SHGetKnownFolderPath(ref Guid id, int flags, IntPtr token, out IntPtr path);
       
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
            if (keyData == (Keys.Control | Keys.R))
            {
                Search();


                return true;
            }
            if (keyData == (Keys.Control | Keys.U))
            {
                Updates();


                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            New();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Updates();
        }
    }
}
