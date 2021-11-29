using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.InteropServices;

namespace SEM
{
    public partial class RegStudentPrivate : Form
    {
        public RegStudentPrivate()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void New()
        {
            txtGR.Text = "";
            txtName.Text = "";
            txtFName.Text = "";
            txtLastSchool.Text = "";
            txtContactNo.Text = "";
            txtAdress.Text = "";
            txtCaste.Text = "";
            cbGender.Text = "";
            dtAdmissionDate.Value = DateTime.Now;
            dtBirthDate.Value = DateTime.Now;
           

        }
        private void Search()
        {
            if (txtGR.Text.Length > 0)
            {

                using (SqlDataAdapter a = new SqlDataAdapter(
                        "Select * from regstudentprivate where stGR=" + txtGR.Text, AppStart.cnn))
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
                        dtBirthDate.Text = dr["stBirthDate"].ToString();
                        txtLastSchool.Text = dr["stLastSchool"].ToString();

                        cbAdmitClass.SelectedValue = Convert.ToInt32(dr["stAdmitClass"].ToString().Trim());
                        dtAdmissionDate.Text = dr["stDateAdmission"].ToString();
                        txtContactNo.Text = dr["stContactNo"].ToString();
                        cbClass.SelectedValue = Convert.ToInt32(dr["stClass"].ToString());
                        cbGender.Text = dr["stGender"].ToString();
                        txtAdress.Text = dr["stAddress"].ToString();
                        //if (dr["stGR"].ToString().Length > 0)
                        //{
                        picImage.Image = null;
                        try
                        {
                            picImage.Load(@"img//sp" + dr["stGR"].ToString() + ".jpg");
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
                MessageBox.Show("Roll No. is empty");
            }

        }
        private void Save()
        {
            SqlCommand c = new SqlCommand("Select stgr from regstudentprivate where stGR=" + txtGR.Text.Trim(), AppStart.cnn);
            if (AppStart.cnn.State == ConnectionState.Closed) AppStart.cnn.Open();
            if (c.ExecuteScalar() == null)
            {
                SqlCommand cmd = new SqlCommand("insert into regstudentprivate(stGR,stName,stFName,stCaste,stBirthDate,stLastSchool,stAdmitClass,stDateAdmission,stContactNo,stClass,stGender,stAddress) values (@stGR,@stName,@stFName,@stCaste,@stBirthDate,@stLastSchool,@stAdmitClass,@stDateAdmission,@stContactNo,@stClass,@stGender,@stAddress) ", AppStart.cnn);
                //cmd.CommandType = CommandType.;
                cmd.Parameters.AddWithValue("@stGR", txtGR.Text);
                cmd.Parameters.AddWithValue("@stName", txtName.Text);
                cmd.Parameters.AddWithValue("@stFName", txtFName.Text);
                cmd.Parameters.AddWithValue("@stCaste", txtCaste.Text);
                cmd.Parameters.AddWithValue("@stBirthDate", dtBirthDate.Text);
                cmd.Parameters.AddWithValue("@stLastSchool", txtLastSchool.Text);
                cmd.Parameters.AddWithValue("@stAdmitClass", cbAdmitClass.SelectedValue);
                cmd.Parameters.AddWithValue("@stDateAdmission", dtAdmissionDate.Text);
                cmd.Parameters.AddWithValue("@stContactNo", txtContactNo.Text);
                cmd.Parameters.AddWithValue("@stClass", cbClass.SelectedValue);
                cmd.Parameters.AddWithValue("@stGender", cbGender.Text);
                cmd.Parameters.AddWithValue("@stAddress", txtAdress.Text);

                string Ext = "";
                if (File.Exists(txtFilePic.Text))
                {
                    Ext = Path.GetExtension(Path.GetFileName(txtFilePic.Text));
                    string dest = Path.Combine("img//", "sp" + StudentID().ToString() + Ext);
                    // MessageBox.Show("Path: " + dest);
                    File.Copy(txtFilePic.Text, dest, true);
                }

                cmd.Parameters.AddWithValue("@stPic", "sp" + StudentID().ToString() + Ext);
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
            SqlCommand c = new SqlCommand("Select stgr from regstudentprivate where stGR=" + txtGR.Text.Trim(), AppStart.cnn);
            if (AppStart.cnn.State == ConnectionState.Closed) AppStart.cnn.Open();
            if (c.ExecuteScalar() != null)
            {
                SqlCommand cmd = new SqlCommand("update regstudentprivate set stGR=@stGR,stName=@stName,stFName=@stFName,stCaste=@stCaste,stBirthDate=@stBirthDate,stLastSchool=@stLastSchool,stAdmitClass=@stAdmitClass,stDateAdmission=@stDateAdmission,stContactNo=@stContactNo,stClass=@stClass,stGender=@stGender,stAddress=@stAddress where stgr=" + txtGR.Text, AppStart.cnn);

                //cmd.CommandType = CommandType.;               
                cmd.Parameters.AddWithValue("@stGR", txtGR.Text);
                cmd.Parameters.AddWithValue("@stName", txtName.Text);
                cmd.Parameters.AddWithValue("@stFName", txtFName.Text);
                cmd.Parameters.AddWithValue("@stCaste", txtCaste.Text);
                cmd.Parameters.AddWithValue("@stBirthDate", dtBirthDate.Text);
                cmd.Parameters.AddWithValue("@stLastSchool", txtLastSchool.Text);
                cmd.Parameters.AddWithValue("@stAdmitClass", cbAdmitClass.SelectedValue);
                cmd.Parameters.AddWithValue("@stDateAdmission", dtAdmissionDate.Text);
                cmd.Parameters.AddWithValue("@stContactNo", txtContactNo.Text);
                cmd.Parameters.AddWithValue("@stClass", cbClass.SelectedValue);
                cmd.Parameters.AddWithValue("@stGender", cbGender.Text);
                cmd.Parameters.AddWithValue("@stAddress", txtAdress.Text);

                string Ext = "";
                if (File.Exists(txtFilePic.Text))
                {
                    Ext = Path.GetExtension(Path.GetFileName(txtFilePic.Text));
                    string dest = Path.Combine("img//", "sp" + txtGR.Text + Ext);
                    // MessageBox.Show("Path: " + dest);
                    File.Copy(txtFilePic.Text, dest, true);
                }

                cmd.Parameters.AddWithValue("@stPic", "sp" + txtGR.Text + Ext);
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
                MessageBox.Show("Roll No. not found");
            }

        }
        private int StudentID()
        {
            using (SqlDataAdapter a = new SqlDataAdapter(
                    "Select top 1 stID as ID from regstudentprivate order by id DESC", AppStart.cnn))
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Updates();
        }

        private void RegStudentPrivate_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.RegClass' table. You can move, or remove it, as needed.
            this.regClassTableAdapter.Fill(this.dataSet1.RegClass);

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
        private static Guid FolderDownloads = new Guid("374DE290-123F-4565-9164-39C4925E467B");
        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        private static extern int SHGetKnownFolderPath(ref Guid id, int flags, IntPtr token, out IntPtr path);
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            New();
        }

    }
}
