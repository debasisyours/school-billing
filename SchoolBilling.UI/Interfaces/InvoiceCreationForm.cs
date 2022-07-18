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
    public partial class InvoiceCreationForm : MetroForm
    {
        #region Declaration

        private int _invoiceId = 0;

        #endregion

        #region Constructor
        public InvoiceCreationForm()
        {
            InitializeComponent();
        }

        public InvoiceCreationForm(int invoiceId)
        {
            InitializeComponent();
            this._invoiceId = invoiceId;
        }
        #endregion

        #region Form events

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.Theme = Program.SelectedTheme;
            this.Refresh();
            this.PopulateList();
            this.AssignEventHandlers();
            this.LoadInvoiceDetail();
        }

        #endregion

        #region Custom functions

        private void PopulateList()
        {
            var clientList = DataLayer.GetOrderedClients();
            if(clientList!=null && clientList.Count > 0)
            {
                this.cboClient.Items.Clear();
                this.cboClient.DataSource = clientList;
                this.cboClient.DisplayMember = "Name";
                this.cboClient.ValueMember = "Id";
            }

            var routeList = DataLayer.GetOrderedRoutes();
            if (routeList != null && routeList.Count > 0)
            {
                this.cboRoute.Items.Clear();
                this.cboRoute.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cboRoute.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.cboRoute.DataSource = routeList;
                this.cboRoute.DisplayMember = "Name";
                this.cboRoute.ValueMember = "Id";

                this.OnRouteSelected(this.cboRoute, new EventArgs());
            }
        }

        private void OnClientSelected(object sender, EventArgs e)
        {
            // No action needed as of now
        }

        private void OnRouteSelected(object sender, EventArgs e)
        {
            int routeId = Convert.ToInt32(this.cboRoute.SelectedValue);
            if (routeId > 0)
            {
                var routeDetails = DataLayer.GetRouteDetail(routeId);
                if (routeDetails != null)
                {
                    this.txtRouteCost.Text = routeDetails.RouteCost.ToString("C2");
                    this.txtAidCost.Text = routeDetails.AidCost.ToString("C2");
                    this.txtPerdiem.Text = (routeDetails.RouteCost + routeDetails.AidCost).ToString("C2");
                    this.txtDayCount.Focus();
                }
            }
        }

        private void OnCalculateCost()
        {
            decimal routeCost = string.IsNullOrEmpty(this.txtRouteCost.Text)? 0 : decimal.Parse(this.txtRouteCost.Text, NumberStyles.Number | NumberStyles.AllowCurrencySymbol, CultureInfo.CurrentCulture);
            decimal aidCost = string.IsNullOrEmpty(this.txtAidCost.Text)? 0 : decimal.Parse(this.txtAidCost.Text, NumberStyles.Number | NumberStyles.AllowCurrencySymbol, CultureInfo.CurrentCulture);
            int dayCount = string.IsNullOrEmpty(this.txtDayCount.Text)? 0 : int.Parse(this.txtDayCount.Text, NumberStyles.Integer, CultureInfo.CurrentCulture);

            decimal perdiem = routeCost + aidCost;
            decimal totalCost = perdiem * dayCount;
            this.txtPerdiem.Text = perdiem.ToString("C2");
            this.txtTotalCost.Text = totalCost.ToString("C2");
        }

        private void AssignEventHandlers()
        {
            this.SaveButton.Click += new EventHandler(OnSave);
            this.CloseButton.Click+= new EventHandler(OnClose);
            this.cboClient.SelectedIndexChanged += new EventHandler(OnClientSelected);
            this.cboRoute.SelectedIndexChanged += new EventHandler(OnRouteSelected);
            this.txtRouteCost.Leave += new EventHandler(OnCostChange);
            this.txtAidCost.Leave += new EventHandler(OnCostChange);
            this.txtPerdiem.Leave += new EventHandler(OnCostChange);
            this.txtDayCount.Leave += new EventHandler(OnCostChange);
            this.txtTotalCost.Leave += new EventHandler(OnCostChange);
            this.txtCovidDayCount.Leave += new EventHandler(OnCostChange);
            this.cboClient.KeyDown+=new KeyEventHandler(OnKeyDown);
            this.cboRoute.KeyDown+=new KeyEventHandler(OnKeyDown);
            this.dtpInvoiceDate.KeyDown += new KeyEventHandler(OnKeyDown);
            this.dtpStartDate.KeyDown += new KeyEventHandler(OnKeyDown);
            this.dtpEndDate.KeyDown += new KeyEventHandler(OnKeyDown);
            this.txtRouteCost.KeyDown += new KeyEventHandler(OnKeyDown);
            this.txtAidCost.KeyDown += new KeyEventHandler(OnKeyDown);
            this.txtPerdiem.KeyDown += new KeyEventHandler(OnKeyDown);
            this.txtDayCount.KeyDown += new KeyEventHandler(OnKeyDown);
            this.txtTotalCost.KeyDown += new KeyEventHandler(OnKeyDown);
            this.txtCovidDayCount.KeyDown += new KeyEventHandler(OnKeyDown);
            this.mtbNotes.KeyDown += new KeyEventHandler(OnKeyDown);
        }

        private void OnCostChange(object sender, EventArgs e)
        {
            string textName = (sender as TextBox).Name;

            switch (textName)
            {
                case "txtRouteCost":
                case "txtAidCost": 
                case "txtPerdiem": 
                case "txtTotalCost":
                    {
                        if(!decimal.TryParse((sender as TextBox).Text, NumberStyles.Number | NumberStyles.AllowCurrencySymbol, CultureInfo.CurrentCulture, out decimal costValue))
                        {
                            MessageBox.Show(this, $"Value entered in {(sender as TextBox).Tag} is not proper, should be decimal only.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            (sender as TextBox).Focus();
                            return;
                        }
                        else
                        {
                            if((sender as TextBox).Name=="txtRouteCost" || (sender as TextBox).Name == "txtAidCost")
                            {
                                this.OnCalculateCost();
                            }
                        }
                        break;
                    }
                case "txtDayCount":
                case "txtCovidDayCount":
                    {
                        if (!string.IsNullOrWhiteSpace(this.txtCovidDayCount.Text) && !int.TryParse((sender as TextBox).Text, NumberStyles.Integer, CultureInfo.CurrentCulture, out int countValue))
                        {
                            MessageBox.Show(this, $"Value entered in {(sender as TextBox).Tag} is not proper, should be integer only.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            (sender as TextBox).Focus();
                            return;
                        }
                        else
                        {
                            if((sender as TextBox).Name == "txtDayCount")
                            {
                                this.OnCalculateCost();
                            }
                        }
                        break;
                    }
            }
        }

        private void LoadInvoiceDetail()
        {
            this.dtpStartDate.Value = DateTime.Now;
            this.dtpEndDate.Value = DateTime.Now;
            this.dtpInvoiceDate.Value = DateTime.Now;

            this.dtpStartDate.CustomFormat = "MM/dd/yyyy";
            this.dtpEndDate.CustomFormat = "MM/dd/yyyy";
            this.dtpInvoiceDate.CustomFormat = "MM/dd/yyyy";

            this.dtpStartDate.Format = DateTimePickerFormat.Custom;
            this.dtpEndDate.Format = DateTimePickerFormat.Custom;
            this.dtpInvoiceDate.Format = DateTimePickerFormat.Custom;

            if (this._invoiceId > 0)
            {
                var invoice = DataLayer.GetInvoiceById(this._invoiceId);
                if (invoice != null)
                {
                    this.cboClient.SelectedValue = invoice.ClientId;
                    this.cboRoute.SelectedValue = invoice.RouteId;
                    this.dtpInvoiceDate.Value = invoice.InvoiceDate;
                    this.dtpStartDate.Value = invoice.StartDate;
                    this.dtpEndDate.Value = invoice.EndDate;
                    this.txtRouteCost.Text = invoice.RouteCost.ToString("C2");
                    this.txtAidCost.Text = invoice.AidCost.ToString("C2");
                    this.txtPerdiem.Text = invoice.Perdiem.ToString("C2");
                    this.txtDayCount.Text = invoice.DayCount.ToString();
                    this.txtTotalCost.Text = invoice.TotalCost.ToString("C2");
                    this.txtCovidDayCount.Text = invoice.CovidDayCount.ToString();
                    this.mtbNotes.Text = invoice.Notes;
                    this.txtInvoiceNumber.Text = invoice.InvoiceNumber.ToString();
                }
            }
            else
            {
                this.txtInvoiceNumber.Text = DataLayer.GenerateInvoiceNumber().ToString();
            }
        }

        private void OnSave(object sender, EventArgs e)
        {
            if (!this.ValidateDataForSave()) return;

            if(MessageBox.Show(this, "Are you sure you want to save the current invoice?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes)
            {
                bool success = DataLayer.SaveInvoice(this.CreateObjectForSave());
                if (success)
                {
                    MessageBox.Show(this, "Invoice saved successfully.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(this, "Invoice could not be saved, please check the log file.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private Invoice CreateObjectForSave()
        {
            return new Invoice
            {
                Id = _invoiceId,
                AidCost = decimal.Parse(this.txtAidCost.Text, NumberStyles.Number | NumberStyles.AllowCurrencySymbol, CultureInfo.CurrentCulture),
                ClientId = Convert.ToInt32(this.cboClient.SelectedValue),
                CovidDayCount = string.IsNullOrWhiteSpace(this.txtCovidDayCount.Text)?0:int.Parse(this.txtCovidDayCount.Text, NumberStyles.Integer, CultureInfo.CurrentCulture),
                DayCount = string.IsNullOrWhiteSpace(this.txtDayCount.Text) ? 0 : int.Parse(this.txtDayCount.Text, NumberStyles.Integer, CultureInfo.CurrentCulture),
                EndDate = this.dtpEndDate.Value,
                InvoiceDate = this.dtpInvoiceDate.Value,
                Notes = this.mtbNotes.Text.Trim(),
                Perdiem = decimal.Parse(this.txtPerdiem.Text, NumberStyles.Number | NumberStyles.AllowCurrencySymbol, CultureInfo.CurrentCulture),
                RouteCost = decimal.Parse(this.txtRouteCost.Text, NumberStyles.Number | NumberStyles.AllowCurrencySymbol, CultureInfo.CurrentCulture),
                RouteId = Convert.ToInt32(this.cboRoute.SelectedValue),
                StartDate = this.dtpStartDate.Value,
                TotalCost = decimal.Parse(this.txtTotalCost.Text, NumberStyles.Number | NumberStyles.AllowCurrencySymbol, CultureInfo.CurrentCulture),
                InvoiceNumber = int.Parse(this.txtInvoiceNumber.Text)
            };
        }

        private bool ValidateDataForSave()
        {
            bool success = true;

            if (string.IsNullOrWhiteSpace(this.txtInvoiceNumber.Text) || !int.TryParse(this.txtInvoiceNumber.Text, NumberStyles.Integer, CultureInfo.CurrentCulture, out int result))
            {
                MessageBox.Show(this, "Invoice number cannot be empty and must be a numeric value.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtInvoiceNumber.Focus();
                success = false;
                return success;
            }

            if(!DataLayer.IsInvoiceNumberValid(this._invoiceId, int.Parse(this.txtInvoiceNumber.Text)))
            {
                MessageBox.Show(this, "Invoice number is not correct, please check.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtInvoiceNumber.Focus();
                this.txtInvoiceNumber.SelectAll();
                success = false;
                return success;
            }

            if (Convert.ToInt32(this.cboRoute.SelectedValue) <= 0)
            {
                MessageBox.Show(this, "Please select or create a Route to proceed.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cboRoute.Focus();
                success = false;
                return success;
            }

            if (Convert.ToInt32(this.cboClient.SelectedValue) <= 0)
            {
                MessageBox.Show(this, "Please select client to proceed.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cboClient.Focus();
                success = false;
                return success;
            }

            if (this.dtpStartDate.Value > this.dtpEndDate.Value)
            {
                MessageBox.Show(this, "Start date must be earlier than end date.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dtpStartDate.Focus();
                success = false;
                return success;
            }

            if (string.IsNullOrWhiteSpace(this.txtRouteCost.Text) || !decimal.TryParse(this.txtRouteCost.Text, NumberStyles.Number | NumberStyles.AllowCurrencySymbol, CultureInfo.CurrentCulture, out decimal routeCost))
            {
                MessageBox.Show(this, "Route cost must be a valid number.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtRouteCost.Focus();
                success = false;
                return success;
            }

            if (string.IsNullOrWhiteSpace(this.txtAidCost.Text) || !decimal.TryParse(this.txtAidCost.Text, NumberStyles.Number | NumberStyles.AllowCurrencySymbol, CultureInfo.CurrentCulture, out decimal aidCost))
            {
                MessageBox.Show(this, "Aide cost must be a valid number.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtAidCost.Focus();
                success = false;
                return success;
            }

            if (string.IsNullOrWhiteSpace(this.txtPerdiem.Text) || !decimal.TryParse(this.txtPerdiem.Text, NumberStyles.Number | NumberStyles.AllowCurrencySymbol, CultureInfo.CurrentCulture, out decimal perdiem))
            {
                MessageBox.Show(this, "Per diem must be a valid number.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtPerdiem.Focus();
                success = false;
                return success;
            }

            if (string.IsNullOrWhiteSpace(this.txtDayCount.Text) || !int.TryParse(this.txtDayCount.Text, NumberStyles.Integer, CultureInfo.CurrentCulture, out int dayCount))
            {
                MessageBox.Show(this, "Total days must be a valid number.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtDayCount.Focus();
                success = false;
                return success;
            }

            if (string.IsNullOrWhiteSpace(this.txtTotalCost.Text) || !decimal.TryParse(this.txtTotalCost.Text, NumberStyles.Number | NumberStyles.AllowCurrencySymbol, CultureInfo.CurrentCulture, out decimal totalCost))
            {
                MessageBox.Show(this, "Total cost be a valid number.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtTotalCost.Focus();
                success = false;
                return success;
            }

            if(!string.IsNullOrWhiteSpace(this.txtCovidDayCount.Text) && !int.TryParse(this.txtCovidDayCount.Text, NumberStyles.Integer, CultureInfo.CurrentCulture, out int covidCount))
            {
                MessageBox.Show(this, "Covid day count be a valid number.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtCovidDayCount.Focus();
                success = false;
                return success;
            }

            if (!DataLayer.IsRouteValid(this.cboRoute.Text))
            {
                MessageBox.Show(this, "Selected route does not exist, please select from available options.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cboRoute.Focus();
                success = false;
                return success;
            }

            return success;
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void OnClose(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #endregion
    }
}
