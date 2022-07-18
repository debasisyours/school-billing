using MetroFramework.Forms;
using SchoolBilling.Data;
using SchoolBilling.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolBilling.UI.Interfaces
{
    public partial class CompanyInformationForm : MetroForm
    {
        #region Constructor
        public CompanyInformationForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Form Events

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.Theme = Program.SelectedTheme;
            this.Refresh();
            this.AssignEventHandlers();
            this.LoadCompanyDetail();
        }

        #endregion

        #region Custom Events

        private void AssignEventHandlers()
        {
            this.SaveButton.Click += new EventHandler(OnSave);
            this.CancelButton.Click += new EventHandler(OnCancel);
            this.txtName.KeyDown += new KeyEventHandler(OnKeyDown);
            this.txtAddress.KeyDown += new KeyEventHandler(OnKeyDown);
            this.txtCity.KeyDown += new KeyEventHandler(OnKeyDown);
            this.txtState.KeyDown += new KeyEventHandler(OnKeyDown);
            this.txtZip.KeyDown += new KeyEventHandler(OnKeyDown);
            this.txtPhone.KeyDown += new KeyEventHandler(OnKeyDown);
            this.txtFax.KeyDown += new KeyEventHandler(OnKeyDown);
            this.txtContactEmail.KeyDown += new KeyEventHandler(OnKeyDown);
        }

        private void LoadCompanyDetail()
        {
            var companyDetail = DataLayer.GetCompanyDetail();

            if (companyDetail != null)
            {
                this.txtName.Text = companyDetail.Name;
                this.txtAddress.Text = companyDetail.Address;
                this.txtCity.Text = companyDetail.City;
                this.txtState.Text = companyDetail.State;
                this.txtZip.Text = companyDetail.PostalCode;
                //this.txtCountry.Text = companyDetail.Country;
                this.txtPhone.Text = companyDetail.Phone;
                this.txtFax.Text = companyDetail.Fax;
                //this.txtCounty.Text = companyDetail.CountyName;
                //this.txtContactPerson.Text = companyDetail.ContactPerson;
                //this.txtContactInformation.Text = companyDetail.ContactInformation;
                this.txtContactEmail.Text = companyDetail.ContactEmail;
                this.txtInvoiceNumber.Text = companyDetail.StartingInvoiceNumber.ToString();
                this.txtInvoiceNumber.ReadOnly = true;
            }
        }

        private void OnSave(object sender, EventArgs e)
        {
            if (!this.ValidateForSave()) return;

            if(MessageBox.Show(this, "Are you sure you want to save the Company information entered?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var companyDetail = this.CreateObjectForSave();
                bool success = DataLayer.SaveCompanyDetail(companyDetail);

                if (success)
                {
                    MessageBox.Show(this, "Company details saved successfully.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    bool isPasswordSet = DataLayer.IsPasswordSet();
                    if (!isPasswordSet)
                    {
                        var passwordSetup = new PasswordSetupForm();
                        passwordSetup.Show();
                    }
                }
                else
                {
                    MessageBox.Show(this, "Company details could not be saved, please check log for details.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private bool ValidateForSave()
        {
            bool success = true;

            if (string.IsNullOrWhiteSpace(this.txtName.Text))
            {
                MessageBox.Show(this, "Company name cannot be empty.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                success = false;
                this.txtName.Focus();
                return success;
            }

            if (string.IsNullOrWhiteSpace(this.txtAddress.Text))
            {
                MessageBox.Show(this, "Company address cannot be empty.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                success = false;
                this.txtAddress.Focus();
                return success;
            }

            if (string.IsNullOrWhiteSpace(this.txtInvoiceNumber.Text) || !int.TryParse(this.txtInvoiceNumber.Text, NumberStyles.Integer, CultureInfo.CurrentCulture, out int result))
            {
                MessageBox.Show(this, "Starting invoice number should be specified in numeric format (e.g. 1).", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                success = false;
                this.txtInvoiceNumber.Focus();
                return success;
            }

            //if (string.IsNullOrWhiteSpace(this.txtCountry.Text))
            //{
            //    MessageBox.Show(this, "Country name cannot be empty.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    success = false;
            //    this.txtCountry.Focus();
            //    return success;
            //}

            return success;
        }

        private Company CreateObjectForSave()
        {
            var companyDetail = new Company
            {
                Address = this.txtAddress.Text.Trim(),
                City = this.txtCity.Text.Trim(),
                ContactEmail = this.txtContactEmail.Text.Trim(),
                //ContactInformation = this.txtContactInformation.Text.Trim(),
                //ContactPerson = this.txtContactPerson.Text.Trim(),
                //Country = this.txtCountry.Text.Trim(),
                //CountyName = this.txtCounty.Text.Trim(),
                Fax = this.txtFax.Text.Trim(),
                Name = this.txtName.Text.Trim(),
                Phone = this.txtPhone.Text.Trim(),
                PostalCode = this.txtZip.Text.Trim(),
                State = this.txtState.Text.Trim(),
                StartingInvoiceNumber = int.Parse(this.txtInvoiceNumber.Text)
            };

            return companyDetail;
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void OnCancel(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #endregion
    }
}
