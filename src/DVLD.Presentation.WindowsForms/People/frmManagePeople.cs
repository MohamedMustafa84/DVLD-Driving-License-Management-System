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

namespace DVLD.Presentation.WindowsForms.People
{
    public partial class frmManagePeople : Form
    {
        public frmManagePeople()
        {
            InitializeComponent();
        }

        

        


        private static DataTable _dtAllPeopleInfo = ClsPerson.GetPeopleInfo();

        private DataTable _dtPeople = _dtAllPeopleInfo.DefaultView.ToTable(false,"PersonID","FirstName", "SecondName", "ThirdName", "LastName","NationalNo","DateOfBirth", "CountryName", "Email", "GenderCaption", "PersonAddress");



        private  void _RefrshPeopleData()
        {
            _dtAllPeopleInfo = ClsPerson.GetPeopleInfo();
            _dtPeople = _dtAllPeopleInfo.DefaultView.ToTable(false, "PersonID", "FirstName", "SecondName", "ThirdName", "LastName", "NationalNo", "DateOfBirth", "CountryName", "Email", "GenderCaption", "PersonAddress");


            dgvPeopleInfoList.DataSource = _dtPeople;
            tbFilterValue.Text = "";
            lbPeopleCount.Text =dgvPeopleInfoList.RowCount.ToString();
            
        }

        private void _SetTableColumnNameAndWidth()
        {
            if (dgvPeopleInfoList.Rows.Count > 0)
            {
                dgvPeopleInfoList.Columns[0].HeaderText = "Person ID";
                dgvPeopleInfoList.Columns[0].Width = 110;

                dgvPeopleInfoList.Columns[1].HeaderText = "First Name";
                dgvPeopleInfoList.Columns[1].Width = 110;

                dgvPeopleInfoList.Columns[2].HeaderText = "Second Name";
                dgvPeopleInfoList.Columns[2].Width = 110;


                dgvPeopleInfoList.Columns[3].HeaderText = "Third Name";
                dgvPeopleInfoList.Columns[3].Width = 110;


                dgvPeopleInfoList.Columns[4].HeaderText = "Last Name";
                dgvPeopleInfoList.Columns[4].Width = 110;


                dgvPeopleInfoList.Columns[5].HeaderText = "National No";
                dgvPeopleInfoList.Columns[5].Width = 120;


                dgvPeopleInfoList.Columns[6].HeaderText = "Date Of Birth";
                dgvPeopleInfoList.Columns[6].Width = 120;


                dgvPeopleInfoList.Columns[7].HeaderText = "Country Name";
                dgvPeopleInfoList.Columns[7].Width = 110;

                dgvPeopleInfoList.Columns[8].HeaderText = "Email";
                dgvPeopleInfoList.Columns[8].Width = 120;

                dgvPeopleInfoList.Columns[9].HeaderText = "Gender Caption";
                dgvPeopleInfoList.Columns[9].Width = 120;


                dgvPeopleInfoList.Columns[10].HeaderText = "Person Address";
                dgvPeopleInfoList.Columns[10].Width = 110;

                
            }
        }

        private void frmLManagePeople_Load(object sender, EventArgs e)
        {
            dgvPeopleInfoList.DataSource = _dtPeople;
            _SetTableColumnNameAndWidth();
            cbFilterBy.Focus();
            cbFilterBy.SelectedText = "None";
            tbFilterValue.Visible = false;
            lbPeopleCount.Text =dgvPeopleInfoList.RowCount.ToString();
        }


        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbFilterBy.SelectedText != "None")
            {
                tbFilterValue.Visible =true;
                tbFilterValue.Text = "";
                tbFilterValue.Focus();

            }

           
        }

        private void tbFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbFilterBy.SelectedIndex == 0) 
            e.Handled =! char.IsDigit(e.KeyChar) && ! char.IsControl(e.KeyChar);
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePersonInfo frmAdd = new frmAddUpdatePersonInfo();
            frmAdd.ShowDialog();
            _RefrshPeopleData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonDetails frmShowPersonDetails = new frmShowPersonDetails((int) dgvPeopleInfoList.CurrentRow.Cells[0].Value);
            frmShowPersonDetails.ShowDialog();
            _RefrshPeopleData();

        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatePersonInfo frmAddNewPerson= new frmAddUpdatePersonInfo();
            frmAddNewPerson.ShowDialog();
            _RefrshPeopleData();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvPeopleInfoList.CurrentRow.Cells[0].Value;
            frmAddUpdatePersonInfo frmAddUpdatePersonInfo = new frmAddUpdatePersonInfo(PersonID);
            frmAddUpdatePersonInfo.ShowDialog();
        }

       
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
                int PersonID = (int)dgvPeopleInfoList.CurrentRow.Cells[0].Value;
            if(MessageBox.Show("Are You Sure You Want To Delete Person with ID : "+PersonID ,"warning",MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
               if ( ClsPerson.Delete(PersonID)){
                    MessageBox.Show("Person With ID : " + PersonID +" Deleted Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefrshPeopleData();

                }
                else
                {
                    MessageBox.Show("Perosn Was Not Deleted becouse It has Data Linked To It", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }

        private void tbFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            switch (cbFilterBy.Text)
            {
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;
                case "First Name":
                    FilterColumn = "FirstName";
                    break;
                case "Second Name":
                    FilterColumn = "SecondName";
                    break;
                case "Third Name":
                    FilterColumn = "ThirdName";
                    break;
                case "Last Name":
                    FilterColumn = "LastName";
                    break;
                case "National No":
                    FilterColumn = "NationalNo";
                    break;

                case "Email":
                    FilterColumn = "Email";
                    break;
                case "Gender Caption":
                    FilterColumn = "GenderCaption";
                    break;


                default:
                    FilterColumn = "None";
                    break;

            }

            if (tbFilterValue.Text.Trim()=="" || tbFilterValue.Text.Trim() == "None")
            {
                _dtPeople.DefaultView.RowFilter = "";
                lbPeopleCount.Text = dgvPeopleInfoList.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "PersonID")
            {
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}]= {1}", FilterColumn, tbFilterValue.Text.Trim());
            }
            else
            {
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, tbFilterValue.Text.Trim());
            }

            lbPeopleCount.Text = dgvPeopleInfoList.Rows.Count.ToString();


        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Are Not Implemented yet !", "Not Implemented", MessageBoxButtons.OK);
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Are Not Implemented yet !", "Not Implemented", MessageBoxButtons.OK);
        }

        private void dgvPeopleInfoList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmShowPersonDetails frmPersonDetails = new frmShowPersonDetails((int)dgvPeopleInfoList.CurrentRow.Cells[0].Value);
            frmPersonDetails.ShowDialog();
        }
    }
}
