using MetroFramework.Forms;
using SchoolBilling.Data;
using SchoolBilling.Data.Entities;
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
    public partial class ClientUpdateForm : MetroForm
    {
        #region Declaration

        private int _clientId = 0;

        #endregion

        #region Constructor
        public ClientUpdateForm()
        {
            InitializeComponent();
        }

        public ClientUpdateForm(int clientId)
        {
            InitializeComponent();
            _clientId = clientId;
        }

        #endregion

        #region Form events

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.Theme = Program.SelectedTheme;
            this.Refresh();
            this.AssignEventHandlers();
            this.LoadClientDetails();
        }

        #endregion

        #region Custom functions

        private void LoadClientDetails()
        {
            if (this._clientId > 0)
            {
                var client = DataLayer.GetClientDetail(this._clientId);
                if (client != null)
                {
                    this.txtClientName.Text = client.Name;
                    this.chkActive.Checked = client.IsActive;
                }
            }
            else
            {
                this.chkActive.Checked = true;
            }
        }

        private void AssignEventHandlers()
        {
            this.SaveButton.Click += new EventHandler(OnSave);
            this.CancelButton.Click+=new EventHandler(OnCancel);
        }

        private void OnSave(object sender, EventArgs e)
        {
            if (!this.ValidateDataForSave()) return;
            if(MessageBox.Show(this, "Are you sure you want to update the school details?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool success = DataLayer.SaveClient(CreateObjectForSave());

                if (success)
                {
                    MessageBox.Show(this, "School details saved successfully.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(this, "School details could not be saved, please check log file.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private Client CreateObjectForSave()
        {
            var client = new Client
            {
                Name = this.txtClientName.Text.Trim(),
                IsActive = this.chkActive.Checked,
                Id = this._clientId
            };

            return client;
        }

        private bool ValidateDataForSave()
        {
            bool success = true;

            if (string.IsNullOrWhiteSpace(this.txtClientName.Text))
            {
                MessageBox.Show(this, "School name cannot be empty.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtClientName.Focus();
                success = false;
                return success;
            }

            return success;
        }

        private void OnCancel(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #endregion
    }
}
