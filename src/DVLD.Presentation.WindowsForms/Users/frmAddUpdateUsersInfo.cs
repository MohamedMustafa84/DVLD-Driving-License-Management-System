using DVLD.BusinessLogic;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Presentation.WindowsForms.Users
{
    public partial class frmAddUpdateUsersInfo : Form
    {
      

        private ClsUser _User;
        enum enMode { AddNew = 1, Update = 2 }
        enMode Mode = enMode.AddNew;
        int _UserID = -1;


        public  frmAddUpdateUsersInfo(int UserID)
        {
            Mode = enMode.Update;
            InitializeComponent();
            _UserID = UserID;
            
        }
        public frmAddUpdateUsersInfo()
        {
            _User = new ClsUser();
            Mode = enMode.AddNew;
            InitializeComponent();
        }

        
        private void _LoadUserData()
        {
            _User =ClsUser.FindUserByUserID(_UserID);

            if(_User == null)
            {
                MessageBox.Show("No User With ID = "+_UserID,"No User Found",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            } 

            ctrlPersonCardWithFilter1.EnabelFilter = false;
            ctrlPersonCardWithFilter1.LoadPersonData(_User.PersonID);
            lbUserID.Text = _User.UserID.ToString();
            tbUserName.Text = _User.UserName;
            tbPassword.Text = _User.Password;
            tbPasswordConfirm.Text = _User.Password;
            chkIsActive.Checked = _User.IsActive;

        }

        private void _SetDefaultValues()
        {
            if(Mode ==enMode.AddNew)
            {
                this.Text = "Add New User";
                lbAddUpdateUserTitle.Text = "Add New User";
                lbUserID.Text = "-1";
                tbUserName.Text = "";
                tbPassword.Text = "";
                tbPasswordConfirm.Text = "";
                chkIsActive.Checked = false;
                

            } else if(Mode ==enMode.Update) {
                this.Text = "Update User";
                lbAddUpdateUserTitle.Text = "Update User Info";
            }

        }
        private void frmAddUpdateUsersInfo_Load(object sender, EventArgs e)
        {

            _SetDefaultValues();
            if (Mode == enMode.Update)
                _LoadUserData();

        }

        
        

        private void tbPasswordConfirm_Validating(object sender, CancelEventArgs e)
        {
            TextBox temp =(TextBox)sender;
            if (string.IsNullOrEmpty(temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(temp, "This Filed Is Required");
            }
            else
            {
                errorProvider1.SetError(temp, null);
            }
            return;
        }

        private bool _ConfirmPasswordMatch()
        {
            if(tbPassword.Text.Trim() != tbPasswordConfirm.Text.Trim())
            {
                errorProvider1.SetError(tbPasswordConfirm, "Password is Not Match");
                return false;
            }
            return true;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void  _GetUserDataFromControls()
        {
            _User.UserName = tbUserName.Text.Trim();
            _User.PersonID = ctrlPersonCardWithFilter1.PersonID;
            _User.Password = tbPassword.Text.Trim();


            if (chkIsActive.Checked)
            {
                _User.IsActive = true;
            }
            else
            {
                _User.IsActive= false;
            }
        }


        private bool _IsUserNameExist()
        {
            return ClsUser.IsUserExist(tbUserName.Text.Trim());
        }
        private bool _ValidateInputData()
        {

            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some Fiald Are Not Valid Click Red Icon For More Information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (Mode==enMode.AddNew && _IsUserNameExist())
            {
                errorProvider1.SetError(tbUserName, "This User Name Is Already Exist ,Please Choose Another One");
                return false;

            }
            
            return _ConfirmPasswordMatch();


        }


        private void btnNext_Click(object sender, EventArgs e)
        {

            if (ctrlPersonCardWithFilter1.PersonID != -1 && Mode == enMode.AddNew)
            {

                if (ClsUser.IsUserExistForPersonID(ctrlPersonCardWithFilter1.PersonID))
                {
                    MessageBox.Show("Selected Person Already has a User ,Please Choose Another One", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return;
                }
            }
            else if (ctrlPersonCardWithFilter1.PersonID == -1)
            {
                MessageBox.Show("Please Select A Person", "Select A Person", MessageBoxButtons.OK);
                return;
            }


            tabControll1.SelectedTab = tcUserLoginInfo;
            btnNext.Enabled = false;

            btnSave.Enabled = true;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_ValidateInputData())
            {
                return;
            }

            _GetUserDataFromControls();

            if (_User.Save())
            {
                _UserID = _User.UserID;
                lbUserID.Text = _UserID.ToString();
                this.Text = "Update User Info";
                lbAddUpdateUserTitle.Text = "Update User Info";
                MessageBox.Show("Operation Is Done Successfully ","info",MessageBoxButtons.OK,MessageBoxIcon.Information);


            }
            else
            {
                MessageBox.Show("Operation Is Faild Please Try Again Later ","info",MessageBoxButtons.OK,MessageBoxIcon.Information);

            }



        }

        private void IsUserNameAvilable(object sender, CancelEventArgs e)
        {
            if (ClsUser.IsUserExist(tbUserName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbUserName, "This User Name Is Already Taken ,Please Choose Another One");
            }
        }
    }
}
