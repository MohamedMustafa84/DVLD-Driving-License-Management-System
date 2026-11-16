using DVLD.BusinessLogic;
using DVLD.Presentation.WindowsForms.GlobalClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Presentation.WindowsForms.Login
{
    public partial class frmLogIn : Form
    {
        public frmLogIn()
        {
            InitializeComponent();
        }

        private string _UserName;
        private string _Password;
        private int _MaxPasswordAttempts = 5;

        ClsUser _User;

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void _GetLogInInfo()
        {
            _UserName = tbUserName.Text.Trim();
            _Password = tbPassword.Text.Trim();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            _GetLogInInfo();
            _User = ClsUser.FindUserByUserNameAndPassword(_UserName, _Password);

            if (_User != null)
            {
                if (_User.IsActive == false)
                {
                    MessageBox.Show("Your Account Is Not Active Please Contact Your Admin", "Un Active User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbUserName.Focus();
                    return;
                }

                if(chkRemnberMe.Checked == true)
                {
                    ClsGlobal.SaveUserNameAndPassword(_UserName, _Password);
                }
                else
                {
                    ClsGlobal.SaveUserNameAndPassword("", "");
                }

                    ClsGlobal.CurrentUser = _User;

            }
            else
            {
                 _MaxPasswordAttempts--;

                if (_MaxPasswordAttempts > 0)
                {
                    if (_MaxPasswordAttempts == 1)
                    {
                        MessageBox.Show("InValid UserName/Password , this is Your Last Attempt", "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    MessageBox.Show("InValid UserName/Password you have " + _MaxPasswordAttempts + " Attempts Remaining", "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show("Too Many Wrong Attempts Please Contact Your Admin", "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }

                
            }

            this.Hide();
            frmMain main = new frmMain(this);
            main.Show();
        }

        private void frmLogIn_Load(object sender, EventArgs e)
        {
            if(ClsGlobal.GetStoredGredential(ref _UserName, ref _Password)){
                tbUserName.Text = _UserName;
                tbPassword.Text = _Password;
                chkRemnberMe.Checked= true;
                return;
            }

            tbUserName.Focus();
            chkRemnberMe.Checked= false;
        }
    }
}
