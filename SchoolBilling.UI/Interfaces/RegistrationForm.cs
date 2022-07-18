using MetroFramework.Forms;
using SchoolBilling.Common;
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
    public partial class RegistrationForm : MetroForm
    {
        #region Constructor
        public RegistrationForm()
        {
            InitializeComponent();
        }
        #endregion

        #region Form events

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.AssignEventHandlers();
            this.CheckLicense();
            var company = DataLayer.GetCompanyDetail();
            if (company != null)
            {
                this.txtRequestEmail.Text = company.ContactEmail;
            }
        }

        #endregion

        #region Custom functions

        private void CheckLicense()
        {
            var status = Licensor.CheckLicenseStatus();
            if(status == LicenseStatus.Trial)
            {
                this.lblStatus.Text = "Your copy is in trial period";
                this.MakeRequestControlsVisible(true);
            }
            else if(status== LicenseStatus.None|| status== LicenseStatus.Tampered)
            {
                this.lblStatus.Text = "Your copy has been tampered, please contact administrator";
                this.MakeRequestControlsVisible(false);
            }
            else if (status == LicenseStatus.Expired)
            {
                this.lblStatus.Text = "Your copy has expired.";
                this.MakeRequestControlsVisible(true);
            }
            else if (status == LicenseStatus.Registered)
            {
                this.lblStatus.Text = "Your copy is already registered.";
                this.MakeRequestControlsVisible(false);
            }
        }

        private void MakeRequestControlsVisible(bool visible)
        {
            this.lblRequest.Visible = visible;
            this.lblActivate.Visible = visible;
            this.RequestButton.Visible = visible;
            this.RegisterButton.Visible = visible;
            this.txtActivationCode.Visible = visible;
            this.txtRequestEmail.Visible = visible;
        }

        private void AssignEventHandlers()
        {
            this.RequestButton.Click += new EventHandler(OnRequest);
            this.RegisterButton.Click += new EventHandler(OnRegister);
            this.OkButton.Click += new EventHandler(OnClose);
        }

        private void OnClose(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void OnRequest(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtRequestEmail.Text))
            {
                MessageBox.Show(this, "Please mention request email here.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtRequestEmail.Focus();
                return;
            }

            bool success = Licensor.SendActivationRequestMail(this.txtRequestEmail.Text);
            if (success)
            {
                MessageBox.Show(this, "Activation request has been sent successfully.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                MessageBox.Show(this, "Activation request could not be sent.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void OnRegister(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtActivationCode.Text))
            {
                MessageBox.Show(this, "Please mention Activation code.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtActivationCode.Focus();
                return;
            }

            bool success = Licensor.ActivateLicense(this.txtActivationCode.Text);
            if (success)
            {
                MessageBox.Show(this, "Congratulations! Your copy is now licensed. Application will now restart.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Restart();
            }
            else
            {
                MessageBox.Show(this, "License could not be applied, please check with administrator.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion
    }
}
