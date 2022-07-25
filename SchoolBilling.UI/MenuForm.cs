using MetroFramework;
using MetroFramework.Forms;
using SchoolBilling.Common;
using SchoolBilling.Data;
using SchoolBilling.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolBilling.UI
{
    public partial class MenuForm : MetroForm
    {
        #region Declaration

        private Timer _timer;

        #endregion

        #region Constructor
        public MenuForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Form events

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.InitializeControls();
            this.AssignEventHandlers();
            this.WindowState = FormWindowState.Maximized;
            this.CheckForCompanyData();
            this.CheckForLicenseStatus();
        }

        #endregion

        #region Custom functions

        private void CheckForLicenseStatus()
        {
            var status = Licensor.CheckLicenseStatus();

            if(status == LicenseStatus.None || status == LicenseStatus.Tampered)
            {
                MessageBox.Show(this, "License file has been tampered with, please contact administrator.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DisableMenuAccess();
                return;
            }
            else if(status == LicenseStatus.Expired)
            {
                MessageBox.Show(this, "Your trial has expired, please contact administrator.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DisableMenuAccess();
                return;
            }
            else if(status == LicenseStatus.Trial)
            {
                MessageBox.Show(this, "Your trial is going to expire soon, please go to Help -> About and submit a registration request.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void DisableMenuAccess()
        {
            this.clientInformationToolStripMenuItem.Enabled = false;
            this.routeInformationToolStripMenuItem.Enabled = false;
            this.invoiceEntryToolStripMenuItem.Enabled = false;
        }

        private void EnableMenuAccess()
        {
            this.clientInformationToolStripMenuItem.Enabled = true;
            this.routeInformationToolStripMenuItem.Enabled = true;
            this.invoiceEntryToolStripMenuItem.Enabled = true;
        }

        private void CheckForCompanyData()
        {
            var companyDetails = DataLayer.GetCompanyDetail();
            if (companyDetails == null)
            {
                this.DisableMenuAccess();
                string licenseKey = Guid.NewGuid().ToString();
                Licensor.CreateSecretFile(licenseKey);
                if(MessageBox.Show(this, "It appears that Company information is not configured yet, would you like to configure it now?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes)
                {
                    var companyForm = new CompanyInformationForm();
                    companyForm.MdiParent = this;
                    companyForm.Show();
                }
            }
        }

        private void AssignEventHandlers()
        {
            this.companyInformationToolStripMenuItem.Click += new EventHandler(OnCompanyInformation);
            this.clientInformationToolStripMenuItem.Click+=new EventHandler(OnClientInformation);
            this.routeInformationToolStripMenuItem.Click+=new EventHandler(OnRouteInformation);
            this.invoiceEntryToolStripMenuItem.Click += new EventHandler(OnInvoiceEntry);
            this.lightModeToolStripMenuItem.Click += new EventHandler(OnThemeSelect);
            this.aboutToolStripMenuItem.Click += new EventHandler(OnAbout);
            this.darkModeToolStripMenuItem.Click += new EventHandler(OnThemeSelect);
            this.routeSummaryToolStripMenuItem.Click += new EventHandler(OnRouteSummary);
            this.exitToolStripMenuItem.Click += new EventHandler(OnExit);
        }

        private void InitializeControls()
        {
            this.toolStripStatusAppName.Text = $"{Application.ProductName} Ver {Application.ProductVersion}";
            this._timer = new Timer();
            this._timer.Interval = 1000;
            this._timer.Enabled = true;
            this._timer.Tick += new EventHandler(OnElapsed);
            this._timer.Start();
        }

        private void OnElapsed(object sender, EventArgs e)
        {
            this.toolStripStatusDate.Text = DateTime.Today.ToString("dddd, MMM dd, yyyy");
            this.toolStripStatusTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void OnCompanyInformation(object sender, EventArgs e)
        {
            bool valid = false;
            using (var passwordForm = new PasswordForm())
            {
                var result = passwordForm.ShowDialog();
                valid = result == DialogResult.OK && passwordForm.IsPasswordValid;
            }

            if (valid)
            {
                var companyForm = new CompanyInformationForm();
                companyForm.MdiParent = this;
                companyForm.Show();
            }
        }

        private void OnClientInformation(object sender, EventArgs e)
        {
            var clientForm = new ClientInformationForm();
            clientForm.MdiParent = this;
            clientForm.Show();
        }

        private void OnRouteInformation(object sender, EventArgs e)
        {
            var routeForm = new RouteInformationForm();
            routeForm.MdiParent = this;
            routeForm.Show();
        }

        private void OnRouteSummary(object sender, EventArgs e)
        {
            var routeForm = new RouteSummaryForm();
            routeForm.MdiParent = this;
            routeForm.Show();
        }

        private void OnInvoiceEntry(object sender, EventArgs e)
        {
            var invoiceSearch = new InvoiceSearchForm();
            invoiceSearch.MdiParent = this;
            invoiceSearch.Show();
        }

        private void OnAbout(object sender, EventArgs e)
        {
            var aboutForm = new RegistrationForm();
            aboutForm.MdiParent = this;
            aboutForm.Show();
        }

        private void OnThemeSelect(object sender, EventArgs e)
        {
            switch((sender as ToolStripMenuItem).Text)
            {
                case "Light Mode":
                    {
                        this.Theme = MetroThemeStyle.Light;
                        Program.SelectedTheme = MetroThemeStyle.Light;
                        this.Refresh();
                        break;
                    }
                case "Dark Mode":
                    {
                        this.Theme = MetroThemeStyle.Dark;
                        Program.SelectedTheme = MetroThemeStyle.Dark;
                        this.Refresh();
                        break;
                    }
            }
        }

        private void OnExit(object sender, EventArgs e)
        {
            if(MessageBox.Show(this, "Are you sure you want to exit the application?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        #endregion
    }
}
