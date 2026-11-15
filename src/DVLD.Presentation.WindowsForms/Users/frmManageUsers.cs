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
    public partial class frmManageUsers : Form
    {

        private static DataTable _dtAllUsers;
        

        public frmManageUsers()
        {
            InitializeComponent();
        }


        private void _RefreshUsersList()
        {
            _dtAllUsers = ClsUser.GetAllUsers();
            dgvUsersInfoList.DataSource = _dtAllUsers;
            lbUsersCount.Text = dgvUsersInfoList.RowCount.ToString();
        }

 

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            frmAddUpdateUsersInfo frmAddNewUser = new frmAddUpdateUsersInfo();
            frmAddNewUser.ShowDialog();
           
            _RefreshUsersList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _SetColumnsNameAndWidth()
        {
            if(dgvUsersInfoList.Rows.Count > 0)
            {
                dgvUsersInfoList.Columns[0].HeaderText = "User ID";
                dgvUsersInfoList.Columns[0].Width = 130;

                dgvUsersInfoList.Columns[1].HeaderText = "Person ID";
                dgvUsersInfoList.Columns[1].Width = 130;

                dgvUsersInfoList.Columns[2].HeaderText = "Full Name";
                dgvUsersInfoList.Columns[2].Width = 250;

                dgvUsersInfoList.Columns[3].HeaderText = "User Name";
                dgvUsersInfoList.Columns[3].Width = 180;


                dgvUsersInfoList.Columns[4].HeaderText = "Is Active";
                dgvUsersInfoList.Columns[4].Width = 130;
            }
        }
        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            _dtAllUsers = ClsUser.GetAllUsers(); 
            
            cbFilterBy.Focus();
            cbFilterBy.SelectedIndex = 0;
            tbFilterValue.Visible = false;
            cbIsActive.Visible = false;


            if(_dtAllUsers.Rows.Count == 0)
            {
                MessageBox.Show("They Is No Users Yet","No Users Found",MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            dgvUsersInfoList.DataSource = _dtAllUsers;
            lbUsersCount.Text = dgvUsersInfoList.RowCount.ToString();
            _SetColumnsNameAndWidth();

            

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            if(cbFilterBy.Text != "None")
            {

                if (cbFilterBy.Text == "Is Active")
                {
                    cbIsActive.Visible = true;
                    tbFilterValue.Visible = false;

                    cbIsActive.Focus();
                    cbIsActive.SelectedIndex = 0;
                    return;
                }

                tbFilterValue.Visible=true;
                cbIsActive.Visible = false;

                tbFilterValue.Focus();
                tbFilterValue.Text = "";

                return;
            }

            tbFilterValue.Visible = false;
            cbIsActive.Visible = false;
        }

        private void tbFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbFilterBy.SelectedIndex ==0 || cbFilterBy.SelectedIndex == 1)
                e.Handled = ! char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private string _GetFilterColumn()
        {

            string FilterColumn;
            switch (cbFilterBy.Text)
            {

                case "User ID":
                    FilterColumn = "UserID";
                    break;
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;
                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                case "User Name":
                    FilterColumn = "UserName";
                    break;
                default:
                    FilterColumn = "None";
                    break;


            }
            return FilterColumn;
        }
        private void tbFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = _GetFilterColumn();

            if(tbFilterValue.Text.Trim()=="" || tbFilterValue.Text.Trim() == "None")
            {
                _dtAllUsers.DefaultView.RowFilter = "";
                lbUsersCount.Text = dgvUsersInfoList.RowCount.ToString();
                return;
            }


            if(cbFilterBy.Text.Trim() == "Person ID" || cbFilterBy.Text.Trim()=="User ID")
            {
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}]= {1}", FilterColumn, tbFilterValue.Text.Trim());

            }
            else
            {
                _dtAllUsers.DefaultView.RowFilter= string.Format("[{0}] like '{1}%'",FilterColumn, tbFilterValue.Text.Trim());
            
            }
                lbUsersCount.Text = dgvUsersInfoList.RowCount.ToString();


        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo UserInfo = new frmUserInfo((int)dgvUsersInfoList.CurrentRow.Cells[0].Value);
            UserInfo.ShowDialog();

        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateUsersInfo AddNewUser = new frmAddUpdateUsersInfo();
            AddNewUser.ShowDialog();
            _RefreshUsersList();

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateUsersInfo EditUser = new frmAddUpdateUsersInfo((int)dgvUsersInfoList.CurrentRow.Cells[0].Value);
            EditUser.ShowDialog();
            _RefreshUsersList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if((MessageBox.Show("Are You Sure You Want To Delete This User ?","Delete Users",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                if (ClsUser.DeleteUser((int)dgvUsersInfoList.CurrentRow.Cells[0].Value))
                { 
                    MessageBox.Show("User Deleted Successfully", "Delete Users", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshUsersList();
                }
                else
                {
                    MessageBox.Show("User Is Not Deleted Due Data Connected To It ", "Delete Users", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }

            
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (cbIsActive.Text)
            {
                case "All":
                    _dtAllUsers.DefaultView.RowFilter = "";
                    return;
                case "Yes":
                    _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}]= {1}", "IsActive",true);
                    lbUsersCount.Text = dgvUsersInfoList.RowCount.ToString();
                    return;
                case "No":
                    _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}]= {1}", "IsActive", false);
                    lbUsersCount.Text = dgvUsersInfoList.RowCount.ToString();
                    return;



            }
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frmChangePassword = new frmChangePassword((int)dgvUsersInfoList.CurrentRow.Cells[0].Value);
            frmChangePassword.ShowDialog();
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet", "Not Implemented", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet", "Not Implemented", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
