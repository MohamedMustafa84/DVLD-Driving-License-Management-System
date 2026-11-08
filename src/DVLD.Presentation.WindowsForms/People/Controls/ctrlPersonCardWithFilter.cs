using DVLD.BusinessLogic;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Presentation.WindowsForms.People.Controls
{
    public partial class ctrlPersonCardWithFilter : UserControl
    {
        public event Action<int> OnPersonSelected;

        protected virtual void PersonSelected(int PersonID)
        {
            Action <int> Handler = OnPersonSelected;

            if(Handler != null)
            {
                Handler (PersonID);
            }
        }
        private int _PersonID = -1;

        public int PersonID
        {
            get {
                _PersonID= ctrlCard.PersonID;
                return _PersonID;
            }
        }


        private ClsPerson _SelectedPerson
        {
            get { return ctrlCard.SelectedPerson; }
        }

        private bool _ShowAddPerson= true;

        public bool ShowAddPerson
        {
            get { return _ShowAddPerson; }
            set
            {
                _ShowAddPerson = value;
                btnAddNewPerson.Enabled = _ShowAddPerson;
            }
        }


        private bool _EnabelFilter = true;

        public bool EnabelFilter
        {
            get { 
                return _EnabelFilter;
            }

            set
            {
                _EnabelFilter= value;
                gbFilter.Enabled = _EnabelFilter;
            }
        }
        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePersonInfo frmAddNewPerson = new frmAddUpdatePersonInfo();
            frmAddNewPerson.DataBack += _DataBackEvent; //subscribe to the event 
            frmAddNewPerson.ShowDialog();
        }
        private void _DataBackEvent(object sender,int PersonID)
        {
            cbFilterBy.SelectedIndex = 0;
            cbFilterBy.SelectedValue = "Person ID";

            tbFilterValue.Text =PersonID.ToString();
            ctrlCard.LoadPersonInfo(PersonID);
        }
 
        private void btnSearch_Click(object sender, EventArgs e)
        {
            FindNow();
        }
        public void LoadPersonData(int PersonID)
        {
            cbFilterBy.SelectedValue = 0;
            tbFilterValue.Text=PersonID.ToString();
            tbFilterValue.Focus();


            FindNow();


        }

        public void FindNow()
        {

            if (cbFilterBy.Text =="Person ID")
            {
                int PersonID = int.Parse(tbFilterValue.Text);

                ctrlCard.LoadPersonInfo(PersonID);
            }
            else
            {
                ctrlCard.LoadPersonInfo(tbFilterValue.Text);
            }

            if(OnPersonSelected != null && EnabelFilter == true)
            {
                OnPersonSelected(ctrlCard.PersonID);
            }

        }

       

        private void ctrlPersonCardWithFilter_Load(object sender, EventArgs e)
        {
            tbFilterValue.Focus();
            cbFilterBy.SelectedIndex = 0;
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbFilterValue.Text = "";
            tbFilterValue.Focus();
        }

       

        private void tbFilterValue_Validating_1(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbFilterValue.Text))
            {
                e.Cancel= true;
                errorProvider1.SetError(tbFilterValue, "This Filed Is Required");
            }
            else
            {
                errorProvider1.SetError(tbFilterValue, null);
            }
        }

        private void tbFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            // check if the pressed key is the enter key (char 13)
            if(e.KeyChar == (char)13)
            {
              btnFind.PerformClick();
            }

            // Allow digit only if personid filter selected

            if(cbFilterBy.Text =="Person ID")
            {
                e.Handled =!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }
    }
}
