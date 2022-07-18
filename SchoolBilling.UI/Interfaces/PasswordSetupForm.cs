using MetroFramework.Forms;
using SchoolBilling.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolBilling.UI.Interfaces
{
    public partial class PasswordSetupForm : MetroForm
    {
        #region Constructor
        public PasswordSetupForm()
        {
            InitializeComponent();
        }
        #endregion

        #region Form events

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.AssignEventHandlers();
            this.InitializeFormControls();
        }

        #endregion

        #region Custom functions

        private void InitializeFormControls()
        {
            if (DataLayer.IsPasswordSet())
            {
                this.label1.Visible = true;
                this.txtOldPassword.Visible = true;
            }
            else
            {
                this.label1.Visible = false;
                this.txtOldPassword.Visible = false;
            }
        }

        private void AssignEventHandlers()
        {
            this.saveButton.Click += new EventHandler(OnSetPassword);
            this.cancelButton.Click+=new EventHandler(OnClose);
        }

        private void OnSetPassword(object sender, EventArgs e)
        {
            if (!this.IsDataValid()) return;

            bool success = DataLayer.SetPassword(this.txtNewPassword.Text);
            if (success)
            {
                MessageBox.Show(this, "Password has been successfully updated. Application will restart now.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
                Application.Restart();
            }
            else
            {
                MessageBox.Show(this, "Password could not be updated.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool IsDataValid()
        {
            bool success = true;

            if (string.IsNullOrWhiteSpace(this.txtOldPassword.Text) && this.txtOldPassword.Visible)
            {
                MessageBox.Show(this, "Old password must be specified.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                success = false;
                this.txtOldPassword.Focus();
                return success;
            }

            if (this.txtOldPassword.Visible && DataLayer.GetPassword() != this.txtOldPassword.Text)
            {
                MessageBox.Show(this, "Old password is not correct.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                success = false;
                this.txtOldPassword.Focus();
                return success;
            }

            if (string.IsNullOrWhiteSpace(this.txtNewPassword.Text))
            {
                MessageBox.Show(this, "New password must be specified.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                success = false;
                this.txtNewPassword.Focus();
                return success;
            }

            if (string.IsNullOrWhiteSpace(this.txtConfirmPassword.Text))
            {
                MessageBox.Show(this, "Confirm password must be specified.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                success = false;
                this.txtConfirmPassword.Focus();
                return success;
            }

            if(this.txtNewPassword.Text != this.txtConfirmPassword.Text)
            {
                MessageBox.Show(this, "New password does not match confirm password.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                success = false;
                this.txtConfirmPassword.Focus();
                return success;
            }

            return success;
        }

        private void OnClose(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #endregion
    }
}
