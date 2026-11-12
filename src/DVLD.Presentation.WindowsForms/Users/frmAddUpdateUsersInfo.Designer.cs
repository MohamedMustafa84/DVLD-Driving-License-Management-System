namespace DVLD.Presentation.WindowsForms.Users
{
    partial class frmAddUpdateUsersInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbAddUpdateUserTitle = new System.Windows.Forms.Label();
            this.tabControll1 = new System.Windows.Forms.TabControl();
            this.tcUserPersonalInfo = new System.Windows.Forms.TabPage();
            this.btnNext = new System.Windows.Forms.Button();
            this.ctrlPersonCardWithFilter1 = new DVLD.Presentation.WindowsForms.People.Controls.ctrlPersonCardWithFilter();
            this.tcUserLoginInfo = new System.Windows.Forms.TabPage();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.lbConfirmPassword = new System.Windows.Forms.Label();
            this.tbPasswordConfirm = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.lbPassword = new System.Windows.Forms.Label();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbUserID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tabControll1.SuspendLayout();
            this.tcUserPersonalInfo.SuspendLayout();
            this.tcUserLoginInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbAddUpdateUserTitle
            // 
            this.lbAddUpdateUserTitle.AutoSize = true;
            this.lbAddUpdateUserTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAddUpdateUserTitle.ForeColor = System.Drawing.Color.Red;
            this.lbAddUpdateUserTitle.Location = new System.Drawing.Point(479, 9);
            this.lbAddUpdateUserTitle.Name = "lbAddUpdateUserTitle";
            this.lbAddUpdateUserTitle.Size = new System.Drawing.Size(347, 55);
            this.lbAddUpdateUserTitle.TabIndex = 0;
            this.lbAddUpdateUserTitle.Text = "Add New User";
            // 
            // tabControll1
            // 
            this.tabControll1.Controls.Add(this.tcUserPersonalInfo);
            this.tabControll1.Controls.Add(this.tcUserLoginInfo);
            this.tabControll1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControll1.Location = new System.Drawing.Point(12, 56);
            this.tabControll1.Name = "tabControll1";
            this.tabControll1.SelectedIndex = 0;
            this.tabControll1.Size = new System.Drawing.Size(1517, 714);
            this.tabControll1.TabIndex = 1;
            // 
            // tcUserPersonalInfo
            // 
            this.tcUserPersonalInfo.Controls.Add(this.btnNext);
            this.tcUserPersonalInfo.Controls.Add(this.ctrlPersonCardWithFilter1);
            this.tcUserPersonalInfo.Location = new System.Drawing.Point(4, 31);
            this.tcUserPersonalInfo.Name = "tcUserPersonalInfo";
            this.tcUserPersonalInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tcUserPersonalInfo.Size = new System.Drawing.Size(1509, 679);
            this.tcUserPersonalInfo.TabIndex = 0;
            this.tcUserPersonalInfo.Text = "Personal Info";
            this.tcUserPersonalInfo.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Image = global::DVLD.Presentation.WindowsForms.Properties.Resources.Next_32;
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNext.Location = new System.Drawing.Point(1196, 600);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(125, 49);
            this.btnNext.TabIndex = 4;
            this.btnNext.Text = "Next    ";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // ctrlPersonCardWithFilter1
            // 
            this.ctrlPersonCardWithFilter1.EnabelFilter = true;
            this.ctrlPersonCardWithFilter1.Location = new System.Drawing.Point(7, -41);
            this.ctrlPersonCardWithFilter1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlPersonCardWithFilter1.Name = "ctrlPersonCardWithFilter1";
            this.ctrlPersonCardWithFilter1.ShowAddPerson = true;
            this.ctrlPersonCardWithFilter1.Size = new System.Drawing.Size(1452, 634);
            this.ctrlPersonCardWithFilter1.TabIndex = 0;
            // 
            // tcUserLoginInfo
            // 
            this.tcUserLoginInfo.Controls.Add(this.chkIsActive);
            this.tcUserLoginInfo.Controls.Add(this.lbConfirmPassword);
            this.tcUserLoginInfo.Controls.Add(this.tbPasswordConfirm);
            this.tcUserLoginInfo.Controls.Add(this.tbPassword);
            this.tcUserLoginInfo.Controls.Add(this.lbPassword);
            this.tcUserLoginInfo.Controls.Add(this.tbUserName);
            this.tcUserLoginInfo.Controls.Add(this.label2);
            this.tcUserLoginInfo.Controls.Add(this.lbUserID);
            this.tcUserLoginInfo.Controls.Add(this.label1);
            this.tcUserLoginInfo.Location = new System.Drawing.Point(4, 31);
            this.tcUserLoginInfo.Name = "tcUserLoginInfo";
            this.tcUserLoginInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tcUserLoginInfo.Size = new System.Drawing.Size(1509, 679);
            this.tcUserLoginInfo.TabIndex = 1;
            this.tcUserLoginInfo.Text = "Login Info";
            this.tcUserLoginInfo.UseVisualStyleBackColor = true;
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsActive.Location = new System.Drawing.Point(473, 415);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(123, 29);
            this.chkIsActive.TabIndex = 9;
            this.chkIsActive.Text = " Is Active";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // lbConfirmPassword
            // 
            this.lbConfirmPassword.AutoSize = true;
            this.lbConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbConfirmPassword.Location = new System.Drawing.Point(117, 356);
            this.lbConfirmPassword.Name = "lbConfirmPassword";
            this.lbConfirmPassword.Size = new System.Drawing.Size(261, 29);
            this.lbConfirmPassword.TabIndex = 7;
            this.lbConfirmPassword.Text = "Confirm Password  :  ";
            // 
            // tbPasswordConfirm
            // 
            this.tbPasswordConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPasswordConfirm.Location = new System.Drawing.Point(417, 345);
            this.tbPasswordConfirm.Name = "tbPasswordConfirm";
            this.tbPasswordConfirm.Size = new System.Drawing.Size(430, 39);
            this.tbPasswordConfirm.TabIndex = 6;
            this.tbPasswordConfirm.Validating += new System.ComponentModel.CancelEventHandler(this.tbPasswordConfirm_Validating);
            // 
            // tbPassword
            // 
            this.tbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPassword.Location = new System.Drawing.Point(417, 258);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(430, 39);
            this.tbPassword.TabIndex = 5;
            this.tbPassword.Validating += new System.ComponentModel.CancelEventHandler(this.tbPasswordConfirm_Validating);
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPassword.Location = new System.Drawing.Point(226, 269);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(142, 29);
            this.lbPassword.TabIndex = 4;
            this.lbPassword.Text = "Password :";
            // 
            // tbUserName
            // 
            this.tbUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUserName.Location = new System.Drawing.Point(417, 174);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(430, 39);
            this.tbUserName.TabIndex = 3;
            this.tbUserName.Validating += new System.ComponentModel.CancelEventHandler(this.tbPasswordConfirm_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(209, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "User Name :   ";
            // 
            // lbUserID
            // 
            this.lbUserID.AutoSize = true;
            this.lbUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUserID.Location = new System.Drawing.Point(485, 117);
            this.lbUserID.Name = "lbUserID";
            this.lbUserID.Size = new System.Drawing.Size(52, 29);
            this.lbUserID.TabIndex = 1;
            this.lbUserID.Text = "???";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(242, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "User ID   :        ";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::DVLD.Presentation.WindowsForms.Properties.Resources.Save_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(1298, 779);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(136, 49);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "     Save  ";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1120, 782);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(123, 42);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close       ";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmAddUpdateUsersInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1542, 839);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabControll1);
            this.Controls.Add(this.lbAddUpdateUserTitle);
            this.Name = "frmAddUpdateUsersInfo";
            this.Text = "Add New User";
            this.Load += new System.EventHandler(this.frmAddUpdateUsersInfo_Load);
            this.tabControll1.ResumeLayout(false);
            this.tcUserPersonalInfo.ResumeLayout(false);
            this.tcUserLoginInfo.ResumeLayout(false);
            this.tcUserLoginInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbAddUpdateUserTitle;
        private System.Windows.Forms.TabControl tabControll1;
        private System.Windows.Forms.TabPage tcUserPersonalInfo;
        private System.Windows.Forms.TabPage tcUserLoginInfo;
        private People.Controls.ctrlPersonCardWithFilter ctrlPersonCardWithFilter1;
        private System.Windows.Forms.Label lbUserID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbConfirmPassword;
        private System.Windows.Forms.TextBox tbPasswordConfirm;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnNext;
    }
}