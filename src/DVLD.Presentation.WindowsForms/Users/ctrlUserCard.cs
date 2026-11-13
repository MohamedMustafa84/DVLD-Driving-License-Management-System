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
    public partial class ctrlUserCard : UserControl
    {
        int _UserID = -1;
        ClsUser _User;

        public int UserID
        {
            get { return _UserID; }
        }
        public ctrlUserCard()
        {
            InitializeComponent();
        }

        private void _ResetUserInfo()
        {
            ctrlPersonCard1.LoadPersonInfo(-1);
            lbUserID.Text = "-1";
            lbUserName.Text = "UnKnown";
            lbIsActive.Text = "UnKnown";
        }

        private void _FillUserInfo()
        {
            ctrlPersonCard1.LoadPersonInfo(_User.PersonID);
            lbUserID.Text = _UserID.ToString();
            lbUserName.Text = _User.UserName;
            if (_User.IsActive)
            {
                lbIsActive.Text = "Yes";
            }
            else
            {
                lbIsActive.Text = "No";
            }
        }
        public bool LoadUserData(int UserID)
        {
            _UserID = UserID;

            _User = ClsUser.FindUserByUserID(_UserID);

            if(_User == null)
            {
                MessageBox.Show("User With ID "+_UserID+"Is Not Exist","User Not Exist",MessageBoxButtons.OK,MessageBoxIcon.Error);
                _ResetUserInfo();
                return false;
            }

            _FillUserInfo();


            return true;
        }

        
    }
}
