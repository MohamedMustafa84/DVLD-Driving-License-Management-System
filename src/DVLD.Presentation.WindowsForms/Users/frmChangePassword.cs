using DVLD.BusinessLogic;
using System;
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
    public partial class frmChangePassword : Form
    {

        private int _UserID = -1;
        private ClsUser _User;
        private int _MaxPasswordAttempts = 5;
        public frmChangePassword(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            _User = ClsUser.FindUserByUserID(_UserID);
            ctrlUserCard1.LoadUserData(_UserID);
        }



        private void tbConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbConfirmPassword.Text.Trim()))
            {
                errorProvider1.SetError(tbConfirmPassword, "This Filed Is Required");

            }

            if (tbConfirmPassword.Text.Trim() != tbNewPassword.Text)
            {
                e.Cancel = true;
                errorProvider1.SetError(tbConfirmPassword, "your Input dose Not Match The New Password");

            }
            else
            {
                errorProvider1.SetError(tbCurrentPassword, null);

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
                return;

            if (ClsUser.ChangePassword(_UserID, tbNewPassword.Text.Trim()))
            {
                MessageBox.Show("Password Updated Successfully ", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error While Changing Pasword", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbCurrentPassword_Validating_1(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbCurrentPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbCurrentPassword, "This Field Is Required");
                return;
            }

            if (tbCurrentPassword.Text.Trim() != _User.Password)
            {
                e.Cancel = true;

                _MaxPasswordAttempts--;

                if (_MaxPasswordAttempts > 0)
                {
                    if (_MaxPasswordAttempts == 1)
                    {
                        MessageBox.Show("Inccorect Password .this is Your Last Attempt","Wrong Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    MessageBox.Show("Inccorect Password you have " + _MaxPasswordAttempts + " Attempts Remaining", "Wrong Password", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    MessageBox.Show("Too Many Wrong Attempts Please Contact Your Admin", "Wrong Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }

            }
        }

    }

}
