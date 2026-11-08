using DVLD.BusinessLogic;
using DVLD.Presentation.WindowsForms.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Presentation.WindowsForms.People.Controls
{
    public partial class ctrlPersonCard : UserControl
    {

        ClsPerson _Person;

        int _PersonID;

        public int PersonID
        {
            get {return _PersonID; }
        }

        public ClsPerson SelectedPerson
        {
            get { return _Person; }
        }
        public ctrlPersonCard()
        {
            InitializeComponent();
        }
        private void _ResetPersonInfo()
        {
            lbPersonID.Text = "-1";
            lbPersonName.Text = "[????]";
            lbNationalNo.Text = "[????]";
            lbPhone.Text = "[????]";
            lbEmail.Text = "[????]";
            lbGender.Text = "[????]";
            lbCountryName.Text = "[????]";
            lbDateOfBirth.Text = "[????]";
            lbAddress.Text = "[????]";
            pbPersonImage.Image = Resources.Male_512;

            llEditPersonInfo.Enabled = false;


        }

        public bool LoadPersonInfo(int PersonID)
        {
            _PersonID = PersonID;
            _Person = ClsPerson.Find(PersonID);

            if (_Person == null)
            {
                MessageBox.Show("No Person with ID = " + PersonID, "Person Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                _ResetPersonInfo();
                return false;
            }

            _FillPersonInfo();
            return true;
        }


        public bool LoadPersonInfo(string NationalNo)
        {
            _Person = ClsPerson.Find(NationalNo);

            if (_Person == null)
            {
                MessageBox.Show("No Person with ID = " + PersonID, "Person Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                _ResetPersonInfo();
                return false;
            }

            _FillPersonInfo();
            return true;
        }


        private void _LoadPersonImage()
        {
            string ImagePath = _Person.ImagePath;

            if (!string.IsNullOrEmpty(ImagePath))
            {

                if (File.Exists(ImagePath))
                {
                    pbPersonImage.ImageLocation = ImagePath;

                }
                else
                {
                    MessageBox.Show("Could not found this image : " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return;
            }


            pbPersonImage.Image = _Person.Gender == 1 ? Resources.Male_512 : Resources.Female_512;


        }
        private void _FillPersonInfo()
        {

            lbPersonID.Text = _Person.PersonID.ToString();
            lbPersonName.Text = _Person.FullName;
            lbNationalNo.Text = _Person.NationalNo.ToString();

            lbEmail.Text = _Person.Email != null ? _Person.Email : "";


            lbPhone.Text = _Person.Phone;
            lbAddress.Text = _Person.PersonAddress;
            lbCountryName.Text = _Person.CountryInfo.CountryName;
            lbDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();


            lbGender.Text = _Person.Gender == 1 ? "Male" : "female";

            llEditPersonInfo.Enabled = true;

            _LoadPersonImage();

        }

        private void llEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdatePersonInfo EditPerson = new frmAddUpdatePersonInfo(_PersonID);

            EditPerson.DataBack += _DataBackHandeler;

            EditPerson.ShowDialog();

        }

        private void _DataBackHandeler(object sender ,int PersonID)
        {
            _PersonID = PersonID;
            LoadPersonInfo(_Person.PersonID);

        }
    }
}
