using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.IO;

namespace SEM
{
    public partial class RegStudent : Form
    {
        public RegStudent()
        {
            InitializeComponent();
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control |Keys.N))
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
        private void Search()
        {
            if (txtGR.Text.Length > 0)
            {
               
                using (SqlDataAdapter a = new SqlDataAdapter(
                        "Select * from regstudent where stGR=" + txtGR.Text, AppStart.cnn))
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
                        txtCaste.Text = dr["stCaste"].ToString();
                        cbReligion.Text = dr["stReligion"].ToString();
                        txtBirthPlace.Text = dr["stBirthPlace"].ToString();
                        dtBirthDate.Text = dr["stBirthDate"].ToString();
                        txtOldGR.Text = dr["stOldGR"].ToString();
                        txtLastSchool.Text = dr["stLastSchool"].ToString();

                        cbAdmitClass.SelectedValue = Convert.ToInt32(dr["stAdmitClass"].ToString().Trim());
                        cbSection.Text = dr["stSection"].ToString();
                        dtAdmissionDate.Text = dr["stDateAdmission"].ToString();
                        txtMonthlyFees.Text = dr["stMonthlyFees"].ToString();
                        txtDiscount.Text = dr["stDiscount"].ToString();
                        txtGaurdian.Text = dr["stGaurdian"].ToString();
                        txtContactNo.Text = dr["stContactNo"].ToString();
                        cbClass.SelectedValue = Convert.ToInt32( dr["stClass"].ToString());
                        cbGender.Text = dr["stGender"].ToString();
                        txtAdress.Text = dr["stAddress"].ToString();
                        cbBlood.Text = dr["stBloodGroup"].ToString();
                        txtAnyChronical.Text = dr["stAnyChronicalIssue"].ToString();
                        txtDisability.Text = dr["stAnyDisability"].ToString();
                        dtLeavingDate.Text = dr["stLeavingDate"].ToString();
                        cbClassLeft.SelectedValue = dr["stClassLeft"].ToString();
                        txtLeavingReason.Text = dr["stReason"].ToString();
                        txtAcademicProgress.Text = dr["stAcademicProgress"].ToString();
                        txtConduct.Text = dr["stConduct"].ToString();
                        txtRemarks.Text = dr["stRemarks"].ToString();
                        //if (dr["stGR"].ToString().Length > 0)
                        //{
                        picImage.Image = null;
                        try
                        {
                            picImage.Load(@"img//s" + dr["stGR"].ToString() + ".jpg");
                            picImage.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                        catch (Exception ex)
                        {
                        }
                        //}
                    }

                }
            } // if
            else
            {
                MessageBox.Show("G.R. No. is empty");
            }

        }
        private void New()
        {
            txtGR.Text = "";
            txtName.Text = "";
            txtFName.Text = "";
            txtBirthPlace.Text = "";
            txtOldGR.Text = "";
            txtLastSchool.Text = "";
            txtMonthlyFees.Text = "";
            txtDiscount.Text = "";
            txtGaurdian.Text = "";
            txtContactNo.Text = "";
            txtAdress.Text = "";
            txtAnyChronical.Text = "";
            txtDisability.Text = "";
            txtLeavingReason.Text = "";
            txtAcademicProgress.Text = "";
            txtConduct.Text = "";
            txtRemarks.Text = "";
            txtCaste.Text = "";
            //cbAdmitClass.Text = "";
            cbBlood.Text = "";
           // cbClass.Text = "";
            //cbClassLeft.Text = "";
            cbGender.Text = "";
            cbReligion.Text = "";
            cbSection.Text = "";
            dtAdmissionDate.Value = DateTime.Now;
            dtBirthDate.Value = DateTime.Now;
            dtLeavingDate.Value = DateTime.Now;
            
        }

        private void Save()
        {
            SqlCommand c=new SqlCommand("Select stgr from regstudent where stGR=" + txtGR.Text.Trim(), AppStart.cnn);
           if (AppStart.cnn.State==ConnectionState.Closed) AppStart.cnn.Open();
            if ( c.ExecuteScalar()==null)
          
            {
                SqlCommand cmd = new SqlCommand("insert into regstudent(stGR,stName,stFName,stCaste,stReligion,stBirthPlace,stBirthDate,stOldGR,stLastSchool,stAdmitClass,stSection,stDateAdmission,stMonthlyFees,stDiscount,stGaurdian,stContactNo,stClass,stGender,stAddress,stBloodGroup,stAnyChronicalIssue,stAnyDisability,stLeavingDate,stClassLeft,stReason,stAcademicProgress,stConduct,stRemarks) values (@stGR,@stName,@stFName,@stCaste,@stReligion,@stBirthPlace,@stBirthDate,@stOldGR,@stLastSchool,@stAdmitClass,@stSection,@stDateAdmission,@stMonthlyFees,@stDiscount,@stGaurdian,@stContactNo,@stClass,@stGender,@stAddress,@stBloodGroup,@stAnyChronicalIssue,@stAnyDisability,@stLeavingDate,@stClassLeft,@stReason,@stAcademicProgress,@stConduct,@stRemarks) ", AppStart.cnn);
                //cmd.CommandType = CommandType.;
                cmd.Parameters.AddWithValue("@stGR", txtGR.Text);
                cmd.Parameters.AddWithValue("@stName", txtName.Text);
                cmd.Parameters.AddWithValue("@stFName", txtFName.Text);
                cmd.Parameters.AddWithValue("@stCaste", txtCaste.Text);
                cmd.Parameters.AddWithValue("@stReligion", cbReligion.Text);
                cmd.Parameters.AddWithValue("@stBirthPlace", txtBirthPlace.Text);
                cmd.Parameters.AddWithValue("@stBirthDate", dtBirthDate.Text);
                cmd.Parameters.AddWithValue("@stOldGR", txtOldGR.Text);
                cmd.Parameters.AddWithValue("@stLastSchool", txtLastSchool.Text);
                cmd.Parameters.AddWithValue("@stAdmitClass", cbAdmitClass.SelectedValue);
                cmd.Parameters.AddWithValue("@stSection", cbSection.Text);
                cmd.Parameters.AddWithValue("@stDateAdmission", dtAdmissionDate.Text);
                cmd.Parameters.AddWithValue("@stMonthlyFees", txtMonthlyFees.Text);
                cmd.Parameters.AddWithValue("@stDiscount", txtDiscount.Text);
                cmd.Parameters.AddWithValue("@stGaurdian", txtGaurdian.Text);
                cmd.Parameters.AddWithValue("@stContactNo", txtContactNo.Text);
                cmd.Parameters.AddWithValue("@stClass", cbClass.SelectedValue);
                cmd.Parameters.AddWithValue("@stGender", cbGender.Text);
                cmd.Parameters.AddWithValue("@stAddress", txtAdress.Text);
                cmd.Parameters.AddWithValue("@stBloodGroup", cbBlood.Text);
                cmd.Parameters.AddWithValue("@stAnyChronicalIssue", txtAnyChronical.Text);
                cmd.Parameters.AddWithValue("@stAnyDisability", txtDisability.Text);
                cmd.Parameters.AddWithValue("@stLeavingDate", dtLeavingDate.Text);
                cmd.Parameters.AddWithValue("@stClassLeft", cbClassLeft.SelectedValue);
                cmd.Parameters.AddWithValue("@stReason", txtLeavingReason.Text);
                cmd.Parameters.AddWithValue("@stAcademicProgress", txtAcademicProgress.Text);
                cmd.Parameters.AddWithValue("@stConduct", txtConduct.Text);
                cmd.Parameters.AddWithValue("@stRemarks", txtRemarks.Text);

                string Ext = "";
                if (File.Exists(txtFilePic.Text))
                {
                    Ext = Path.GetExtension(Path.GetFileName(txtFilePic.Text));
                    string dest = Path.Combine("img//", "s" + StudentID().ToString() + Ext);
                    // MessageBox.Show("Path: " + dest);
                    File.Copy(txtFilePic.Text, dest, true);
                }

                cmd.Parameters.AddWithValue("@stPic", "s" + StudentID().ToString() + Ext);
                if (AppStart.cnn.State == ConnectionState.Closed) AppStart.cnn.Open();
                int ii = cmd.ExecuteNonQuery();
                if (ii > 0)
                {
                    MessageBox.Show("Record Successfully Added.");
                }
                else
                {
                    MessageBox.Show("Error Found.");
                }


            }
            else
            {
                MessageBox.Show("Duplicate G.R No found");
            }
           
        }
        private void Updates()
        {
            SqlCommand c = new SqlCommand("Select stgr from regstudent where stGR=" + txtGR.Text.Trim(), AppStart.cnn);
            if (AppStart.cnn.State == ConnectionState.Closed) AppStart.cnn.Open();
            if (c.ExecuteScalar() != null)
            {
                SqlCommand cmd = new SqlCommand("update regstudent set stGR=@stGR,stName=@stName,stFName=@stFName,stCaste=@stCaste,stReligion=@stReligion,stBirthPlace=@stBirthPlace,stBirthDate=@stBirthDate,stOldGR=@stOldGR,stLastSchool=@stLastSchool,stAdmitClass=@stAdmitClass,stSection=@stSection,stDateAdmission=@stDateAdmission,stMonthlyFees=@stMonthlyFees,stDiscount=@stDiscount,stGaurdian=@stGaurdian,stContactNo=@stContactNo,stClass=@stClass,stGender=@stGender,stAddress=@stAddress,stBloodGroup=@stBloodGroup,stAnyChronicalIssue=@stAnyChronicalIssue,stAnyDisability=@stAnyDisability,stLeavingDate=@stLeavingDate,stClassLeft=@stClassLeft,stReason=@stReason,stAcademicProgress=@stAcademicProgress,stConduct=@stConduct,stRemarks=@stRemarks where stgr="+txtGR.Text, AppStart.cnn) ;
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  
                //cmd.CommandType = CommandType.;               
                cmd.Parameters.AddWithValue("@stGR", txtGR.Text);
                cmd.Parameters.AddWithValue("@stName", txtName.Text);
                cmd.Parameters.AddWithValue("@stFName", txtFName.Text);
                cmd.Parameters.AddWithValue("@stCaste", txtCaste.Text);
                cmd.Parameters.AddWithValue("@stReligion", cbReligion.Text);
                cmd.Parameters.AddWithValue("@stBirthPlace", txtBirthPlace.Text);
                cmd.Parameters.AddWithValue("@stBirthDate", dtBirthDate.Text);
                cmd.Parameters.AddWithValue("@stOldGR", txtOldGR.Text);
                cmd.Parameters.AddWithValue("@stLastSchool", txtLastSchool.Text);
                cmd.Parameters.AddWithValue("@stAdmitClass", cbAdmitClass.SelectedValue);
                cmd.Parameters.AddWithValue("@stSection", cbSection.Text);
                cmd.Parameters.AddWithValue("@stDateAdmission", dtAdmissionDate.Text);
                cmd.Parameters.AddWithValue("@stMonthlyFees", txtMonthlyFees.Text);
                cmd.Parameters.AddWithValue("@stDiscount", txtDiscount.Text);
                cmd.Parameters.AddWithValue("@stGaurdian", txtGaurdian.Text);
                cmd.Parameters.AddWithValue("@stContactNo", txtContactNo.Text);
                cmd.Parameters.AddWithValue("@stClass", cbClass.SelectedValue);
                cmd.Parameters.AddWithValue("@stGender", cbGender.Text);
                cmd.Parameters.AddWithValue("@stAddress", txtAdress.Text);
                cmd.Parameters.AddWithValue("@stBloodGroup", cbBlood.Text);
                cmd.Parameters.AddWithValue("@stAnyChronicalIssue", txtAnyChronical.Text);
                cmd.Parameters.AddWithValue("@stAnyDisability", txtDisability.Text);
                cmd.Parameters.AddWithValue("@stLeavingDate", dtLeavingDate.Text);
                cmd.Parameters.AddWithValue("@stClassLeft", cbClassLeft.SelectedValue);
                cmd.Parameters.AddWithValue("@stReason", txtLeavingReason.Text);
                cmd.Parameters.AddWithValue("@stAcademicProgress", txtAcademicProgress.Text);
                cmd.Parameters.AddWithValue("@stConduct", txtConduct.Text);
                cmd.Parameters.AddWithValue("@stRemarks", txtRemarks.Text);

                string Ext = "";
                if (File.Exists(txtFilePic.Text))
                {
                    Ext = Path.GetExtension(Path.GetFileName(txtFilePic.Text));
                    string dest = Path.Combine("img//", "s" + txtGR.Text + Ext);
                    // MessageBox.Show("Path: " + dest);
                    File.Copy(txtFilePic.Text, dest, true);
                }

                cmd.Parameters.AddWithValue("@stPic", "s" + txtGR.Text + Ext);
                if (AppStart.cnn.State == ConnectionState.Closed) AppStart.cnn.Open();
                int ii = cmd.ExecuteNonQuery();
                if (ii > 0)
                {
                    MessageBox.Show("Record Successfully Updated.");
                }
                else
                {
                    MessageBox.Show("Error Found.");
                }


            }
            else
            {
                MessageBox.Show("G.R No. not found");
            }

        }
        private int StudentID()
        {
            using (SqlDataAdapter a = new SqlDataAdapter(
                    "Select top 1 stID as ID from regstudent order by id DESC", AppStart.cnn))
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
        private void btnNew_Click(object sender, EventArgs e)
        {
            New();
        }

        private void RegStudent_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.RegClass' table. You can move, or remove it, as needed.
            this.regClassTableAdapter.Fill(this.dataSet1.RegClass);

        }

        private void checkLeaving_CheckedChanged(object sender, EventArgs e)
        {
            dtLeavingDate.Enabled = false;
            cbClassLeft.Enabled = false;
            txtLeavingReason.Enabled = false;
            txtRemarks.Enabled = false;
            txtConduct.Enabled = false;
            txtAcademicProgress.Enabled = false;

            if (checkLeaving.Checked)
            {
                dtLeavingDate.Enabled = true;
                cbClassLeft.Enabled = true;
                txtLeavingReason.Enabled = true;
                txtRemarks.Enabled = true;
                txtConduct.Enabled = true;
                txtAcademicProgress.Enabled = true;

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Updates();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

       
    }
}
