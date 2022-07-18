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
    public partial class RouteUpdateForm : MetroForm
    {
        #region Declaration

        private int _selectedId = 0;

        #endregion

        #region Constructor
        public RouteUpdateForm()
        {
            InitializeComponent();
        }

        public RouteUpdateForm(int selectedId)
        {
            InitializeComponent();
            _selectedId = selectedId;
        }
        #endregion

        #region Form events

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.Theme = Program.SelectedTheme;
            this.Refresh();
            this.AssignEventHandlers();
            this.LoadRouteDetails();
        }

        #endregion

        #region Custom functions

        private void AssignEventHandlers()
        {
            this.SaveButton.Click += new EventHandler(OnSave);
            this.CancelButton.Click+=new EventHandler(OnCancel);
            this.txtRouteName.KeyDown+=new KeyEventHandler(OnKeyDown);
            this.txtRouteCost.KeyDown+=new KeyEventHandler(OnKeyDown);
            this.txtAidCost.KeyDown+=new KeyEventHandler(OnKeyDown);
        }

        private void LoadRouteDetails()
        {
            if (this._selectedId > 0)
            {
                var routeDetails = DataLayer.GetRouteDetail(this._selectedId);
                if (routeDetails != null)
                {
                    this.txtRouteName.Text = routeDetails.Name;
                    this.txtRouteCost.Text = routeDetails.RouteCost.ToString("C2");
                    this.txtAidCost.Text = routeDetails.AidCost.ToString("C2");
                }
            }
        }

        private bool ValidateDataForSave()
        {
            bool success = true;

            if (string.IsNullOrWhiteSpace(this.txtRouteName.Text))
            {
                MessageBox.Show(this, "Route name cannot be left blank.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtRouteName.Focus();
                success = false;
                return success;
            }

            if(!string.IsNullOrWhiteSpace(this.txtRouteCost.Text) && !decimal.TryParse(this.txtRouteCost.Text, NumberStyles.Number | NumberStyles.AllowCurrencySymbol, CultureInfo.CurrentCulture, out decimal routeCost))
            {
                MessageBox.Show(this, "Route cost must be specified in numeric figures.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtRouteCost.Focus();
                success = false;
                return success;
            }

            if (!string.IsNullOrWhiteSpace(this.txtAidCost.Text) && !decimal.TryParse(this.txtAidCost.Text, NumberStyles.Number | NumberStyles.AllowCurrencySymbol, CultureInfo.CurrentCulture, out decimal aidCost))
            {
                MessageBox.Show(this, "Aid cost must be specified in numeric figures.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtAidCost.Focus();
                success = false;
                return success;
            }

            return success;
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private Route CreateObjectForSave()
        {
            return new Route
            {
                Name = this.txtRouteName.Text.Trim(),
                IsActive = true,
                RouteCost = decimal.TryParse(this.txtRouteCost.Text, NumberStyles.Number | NumberStyles.AllowCurrencySymbol, CultureInfo.CurrentCulture, out decimal routeCost) ? routeCost : 0,
                AidCost = decimal.TryParse(this.txtAidCost.Text, NumberStyles.Number | NumberStyles.AllowCurrencySymbol, CultureInfo.CurrentCulture, out decimal aidCost) ? aidCost : 0,
                Id = this._selectedId
            };
        }

        private void OnSave(object sender, EventArgs e)
        {
            if (!this.ValidateDataForSave()) return;
            if(MessageBox.Show(this, "Are you sure you want to save the route details?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool success = DataLayer.SaveRoute(this.CreateObjectForSave());
                if (success)
                {
                    MessageBox.Show(this, "Route details saved successfully.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(this, "Route details could not be saved.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
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
