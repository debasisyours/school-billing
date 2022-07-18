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
    public partial class PasswordForm : MetroForm
    {
        #region Declaration

        private bool _validation = false;

        #endregion

        #region Constructor
        public PasswordForm()
        {
            InitializeComponent();
        }
        #endregion

        #region Form events

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.AssignEventHandlers();
        }

        #endregion

        #region Custom functions

        public bool IsPasswordValid
        {
            get { return _validation; }
        }

        private void AssignEventHandlers()
        {
            this.OkButton.Click += new EventHandler(OnOk);
            this.CancelButton.Click += new EventHandler(OnCancel);
        }

        private void OnOk(object sender, EventArgs e)
        {
            string actualPassword = DataLayer.GetPassword();
            this._validation = actualPassword == this.txtPassword.Text;
            if (!this._validation)
            {
                MessageBox.Show(this, "Password is not correct, Company information cannot be accessed", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtPassword.Focus();
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void OnCancel(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #endregion
    }
}
