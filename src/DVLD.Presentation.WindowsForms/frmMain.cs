using DVLD.BusinessLogic;
using DVLD.Presentation.WindowsForms.GlobalClasses;
using DVLD.Presentation.WindowsForms.Login;
using DVLD.Presentation.WindowsForms.People;
using DVLD.Presentation.WindowsForms.People.Controls;
using DVLD.Presentation.WindowsForms.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Presentation.WindowsForms
{
    public partial class frmMain: Form
    {
        frmLogIn _frmLogIn;
        public frmMain(frmLogIn logInForm)
        {
            InitializeComponent();
            _frmLogIn = logInForm;
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmManagePeople frmMagagePeople = new frmManagePeople();
            frmMagagePeople.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Manage Drivers feature is not implemented yet");
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageUsers manageUsers = new frmManageUsers();
            manageUsers.ShowDialog();

        }

        private void currnetUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo UserInfo = new frmUserInfo(ClsGlobal.CurrentUser.UserID);
            UserInfo.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword ChangePassword = new frmChangePassword(ClsGlobal.CurrentUser.UserID);
            ChangePassword.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsGlobal.CurrentUser = null;
            _frmLogIn.Show();
            this.Close();
        }
    }
}
