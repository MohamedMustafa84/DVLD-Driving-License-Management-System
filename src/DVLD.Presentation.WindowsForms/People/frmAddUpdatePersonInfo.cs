using DVLD.BusinessLogic;
using DVLD.Presentation.WindowsForms.GlobalClasses;
using DVLD.Presentation.WindowsForms.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Presentation.WindowsForms.People
{
    public partial class frmAddUpdatePersonInfo : Form
    {

        public delegate void DataBackEventHandeler(object sender, int PersonID);

        public event DataBackEventHandeler DataBack;

        enum enMode { AddNew = 1, Update = 2 }
        enum enGender { Male = 1, Female = 2 }
        enMode _Mode;
        int _PersonID = -1;
        ClsPerson _Person;

        public frmAddUpdatePersonInfo()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmAddUpdatePersonInfo(int PersonID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _PersonID = PersonID;
        }


        
        void _LoadPersonInfo()
        {

            _Person = ClsPerson.Find(_PersonID);

            if (_Person == null)
            {
                MessageBox.Show("No Person with ID = " + _PersonID, "Person Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }


            lbPersonID.Text = _Person.PersonID.ToString();

            tbFirstName.Text = _Person.FirstName;
            tbSecondName.Text = _Person.SecondName;
            tbThirdName.Text = _Person.ThirdName;
            tbLastName.Text = _Person.LastName;

            tbNationalNo.Text = _Person.NationalNo;
            dtDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();
            tbPhone.Text = _Person.Phone;

            if (_Person.Email != null)
            {
                tbEmail.Text = _Person.Email;
            }
            else
            {
                tbEmail.Text = string.Empty;
            }

            
            if (_Person.Gender == 1)
            {
                rbMale.Checked = true;
            }
            else
            {
                rbFemale.Checked = true;
            }


            if (_Person.ImagePath !=null)
            {
                pbPersonImage.ImageLocation = _Person.ImagePath;
            }

            llRemoveImage.Visible = (_Person.ImagePath != null);

            tbAddress.Text = _Person.PersonAddress;
            cbCountries.SelectedText = _Person.CountryInfo.CountryName;


        }

        void _FillComboBoxWithCountries()
        {
            DataTable dtCountries = ClsCountry.GetCountries();

            foreach (DataRow Row in dtCountries.Rows)
            {
                cbCountries.Items.Add(Row["CountryName"]);
            }
        }

        void _AddUpdateNewPerson()
        {
            _Person.FirstName = tbFirstName.Text.Trim();
            _Person.SecondName = tbSecondName.Text.Trim();
            _Person.ThirdName = tbThirdName.Text.Trim();
            _Person.LastName = tbLastName.Text.Trim();

            _Person.NationalityID = ClsCountry.Find(cbCountries.Text).ID;
            _Person.Phone = tbPhone.Text.Trim();
            _Person.PersonAddress = tbAddress.Text.Trim();
            _Person.NationalNo = tbNationalNo.Text.Trim();
            _Person.DateOfBirth = dtDateOfBirth.Value.Date;


            if (rbMale.Checked)
            {
                _Person.Gender = (byte)enGender.Male;
            }
            else
            {
                _Person.Gender = (byte)enGender.Female;
            }


            if (tbEmail.Text != null || tbEmail.Text != "")
            {
                _Person.Email = tbEmail.Text.Trim();
            }
            else
            {
                _Person.Email = null;
            }

            if (pbPersonImage.Image != null)
            {
                _Person.ImagePath = pbPersonImage.ImageLocation;
            }
            else
            {
                _Person.ImagePath = null;
            }
        }
        void _ResetetDefaultValues()
        {

            _FillComboBoxWithCountries();

            if (_Mode == enMode.AddNew)
            {
                lbTitle.Text = "Add New Person";
                _Person = new ClsPerson();
            }
            else
            {
                lbTitle.Text = "Update Person Info";
                return;
            }

            lbPersonID.Text = "-1";

            tbFirstName.Text = "";
            tbSecondName.Text = "";
            tbThirdName.Text = "";
            tbLastName.Text = "";
            tbEmail.Text = "";
            rbMale.Checked = true;
            pbPersonImage.Image = Resources.Male_512;
            tbPhone.Text = "";
            cbCountries.SelectedIndex = cbCountries.FindString("Sudan");
            tbAddress.Text = "";
            tbNationalNo.Text = "";
            dtDateOfBirth.Text = "";


            dtDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtDateOfBirth.Value = DateTime.Now.AddYears(-18);
            dtDateOfBirth.MinDate = DateTime.Now.AddYears(-100);

            llRemoveImage.Visible = (pbPersonImage.ImageLocation != null);
        }

        private void frmAddUpdatePersonInfo_Load(object sender, EventArgs e)
        {
            _ResetetDefaultValues();

            if (_Mode == enMode.Update)
                _LoadPersonInfo();


        }


       

        public bool _HandelImage() 
        {

            

            if(_Person.ImagePath != pbPersonImage.ImageLocation)
            {
                if (_Person.ImagePath != "")
                {
                    try
                    {
                        File.Delete(_Person.ImagePath);
                    }
                    catch (Exception)
                    {
                        //Excepttion  Deletting The Image Path 
                        //we will log thid later
                       
                    }

                }

                

                
            }

            if (pbPersonImage.ImageLocation != null)
            {
                string   SourceImageFile = pbPersonImage.ImageLocation.ToString();
                if (ClsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
                {
                    pbPersonImage.ImageLocation = SourceImageFile;
                    return true;
                }
                else
                {
                    MessageBox.Show("Error Coping Image File ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _AddUpdateNewPerson();

            _HandelImage();

            if (_Person.Save())
            {
                lbPersonID.Text = _Person.PersonID.ToString();
                _Mode = enMode.Update;
                lbTitle.Text = "Update Person";

                MessageBox.Show("Data Saved Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DataBack?.Invoke(this, _Person.PersonID);



            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            _Person.Gender = (byte)enGender.Female;
            pbPersonImage.Image = Resources.Female_512;
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            _Person.Gender = (byte)enGender.Male;
            pbPersonImage.Image = Resources.Male_512;
        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonImage.ImageLocation = null;

            if (rbMale.Checked)
            {
                pbPersonImage.Image = Resources.Male_512;
            }
            else
            {
                pbPersonImage.Image = Resources.Female_512;
            }

            llRemoveImage.Visible = false;
        }


        
        private void _ValidateEmptyTextBox(object sender,CancelEventArgs e)
        {
            // set Auto validate Property of your form to enable allow focus change in desiger 

            TextBox Temp =(TextBox)sender;

            if (string.IsNullOrEmpty(Temp.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, "This Field Is Required");
            }
            else
            {
                errorProvider1.SetError(Temp, null);
            }
        }

        

    private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
            {
                openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                openFileDialog1.FilterIndex = 1;
                openFileDialog1.RestoreDirectory = true;

                if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string SelectedFile = openFileDialog1.FileName;

                pbPersonImage.Load(SelectedFile);
                
                llRemoveImage.Visible=true;
            }
                

            }


        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {

            // First: set AutoValidate property of your Form to EnableAllowFocusChange in designer 
            TextBox Temp = ((TextBox)sender);
            if (string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(Temp, null);
            }

        }



        private void tbNationalNo_Validating_1(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(tbNationalNo.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbNationalNo, "This Filed Is Required");
                return;
            }
            else
            {
                errorProvider1.SetError(tbNationalNo, null);
            }

            if (tbNationalNo.Text.Trim()!= _Person.NationalNo && ClsPerson.IsPersonExist(tbNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbNationalNo, "unValid NationalNo ");
                return;
            }

            e.Cancel = false;
            errorProvider1.SetError(tbNationalNo, null);
        }

        private void tbEmail_Validating_1(object sender, CancelEventArgs e)
        {

            if (tbEmail.Text.Trim() == "")
            {
                errorProvider1.SetError(tbEmail, null);
                return;

            }

            if (!ClsValidation.ValidateEmail(tbEmail.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbEmail, "invalid Email Format");

               
            }
            else
            {
                errorProvider1.SetError(tbEmail, null);
            }

        }

        private void tbPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled =! char.IsDigit(e.KeyChar) && ! char.IsControl(e.KeyChar);
        }
    }
}
