using MetroFramework.Forms;
using SchoolBilling.Data;
using SchoolBilling.Data.DataSets;
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
    public partial class ClientInformationForm : MetroForm
    {
        #region Declaration

        private ClientDataSet _clients = new ClientDataSet();

        #endregion

        #region Constructor
        public ClientInformationForm()
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
            this.FormatGrid();
        }

        #endregion

        #region Custom Functions

        private void AssignEventHandlers()
        {
            this.AddButton.Click += new EventHandler(OnAddClient);
            this.EditButton.Click += new EventHandler(OnEditClient);
            this.CloseButton.Click += new EventHandler(OnClose);
            this.dgvClients.CellDoubleClick += new DataGridViewCellEventHandler(OnGridDoubleClick);
            this.dgvClients.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(OnGridHeaderClick);
            this.txtSearch.TextChanged += new EventHandler(OnSearchRequest);
        }

        private void OnSearchRequest(object sender, EventArgs e)
        {
            string filterExpression = string.Empty;
            ClientDataSet clientDataSet = new ClientDataSet();

            switch (this.lblSearch.Text.Substring(9).Trim())
            {
                case ClientDataSet.NameColumn:
                {
                    filterExpression = $"{ClientDataSet.NameColumn} LIKE '%{this.txtSearch.Text}%'";
                    break;
                }
            }

            if (!string.IsNullOrWhiteSpace(filterExpression))
            {
                DataRow[] selectedRows = this._clients.Tables[ClientDataSet.TableClient].Select(filterExpression);
                if (selectedRows.Length > 0)
                {
                    foreach(DataRow row in selectedRows)
                    {
                        clientDataSet.Tables[ClientDataSet.TableClient].ImportRow(row);
                    }
                }

                this.dgvClients.DataSource = clientDataSet.Tables[ClientDataSet.TableClient];
                this.dgvClients.Columns[ClientDataSet.IdColumn].Width = 0;
                this.dgvClients.Columns[ClientDataSet.IdColumn].Visible=false;
            }
        }

        private void OnGridHeaderClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (this.dgvClients.RowCount > 0)
            {
                switch (this.dgvClients.Columns[e.ColumnIndex].HeaderText)
                {
                    case ClientDataSet.NameColumn:
                    {
                        this.lblSearch.Text = $"Search by {ClientDataSet.NameColumn}";
                        break;
                    }
                    case "Active":
                    {
                        this.lblSearch.Text = $"Search by Active";
                        break;
                    }
                }
                this.txtSearch.Focus();
            }
        }

        private void OnGridDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvClients.RowCount > 0)
            {
                int selectedId = Convert.ToInt32(this.dgvClients.Rows[e.RowIndex].Cells[ClientDataSet.IdColumn].Value);
                using (var clientForm = new ClientUpdateForm(selectedId))
                {
                    var result = clientForm.ShowDialog();
                    if(result== DialogResult.OK)
                    {
                        this.FormatGrid();
                    }
                }
            }
        }

        private void OnAddClient(object sender, EventArgs e)
        {
            using (var clientForm = new ClientUpdateForm())
            {
                var result = clientForm.ShowDialog();
                if(result == DialogResult.OK)
                {
                    this.FormatGrid();
                }
            }
        }

        private void OnEditClient(object sender, EventArgs e)
        {
            int selectedId = 0;

            if (this.dgvClients.SelectedRows.Count == 0)
            {
                MessageBox.Show(this, "Please select a record to edit.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dgvClients.Focus();
                return;
            }
            else
            {
                selectedId = Convert.ToInt32(this.dgvClients.SelectedRows[0].Cells[ClientDataSet.IdColumn].Value);
            }

            using (var clientForm = new ClientUpdateForm(selectedId))
            {
                var result = clientForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    this.FormatGrid();
                }
            }
        }

        private void FormatGrid()
        {
            DataGridViewTextBoxColumn textColumn = null;
            DataGridViewCheckBoxColumn checkBoxColumn = null;

            this.dgvClients.AllowUserToAddRows = false;
            this.dgvClients.AllowUserToDeleteRows = false;
            this.dgvClients.AllowUserToResizeRows=false;
            this.dgvClients.AutoGenerateColumns = false;
            this.dgvClients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClients.BackgroundColor = Color.White;
            this.dgvClients.MultiSelect = false;
            this.dgvClients.ReadOnly = true;
            this.dgvClients.RowHeadersVisible = false;
            this.dgvClients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvClients.RowsDefaultCellStyle.BackColor = Color.White;
            this.dgvClients.AlternatingRowsDefaultCellStyle.BackColor = Color.BlanchedAlmond;
            this.dgvClients.Columns.Clear();

            textColumn = new DataGridViewTextBoxColumn();
            textColumn.Name = ClientDataSet.IdColumn;
            textColumn.HeaderText = ClientDataSet.IdColumn;
            textColumn.DataPropertyName = ClientDataSet.IdColumn;
            textColumn.FillWeight = 10;
            textColumn.Width = 0;
            textColumn.Visible = false;
            textColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvClients.Columns.Add(textColumn);

            textColumn = new DataGridViewTextBoxColumn();
            textColumn.Name = ClientDataSet.NameColumn;
            textColumn.HeaderText = ClientDataSet.NameColumn;
            textColumn.DataPropertyName = ClientDataSet.NameColumn;
            textColumn.FillWeight = 70;
            textColumn.Width = 200;
            textColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvClients.Columns.Add(textColumn);

            checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.Name = ClientDataSet.IsActiveColumn;
            checkBoxColumn.HeaderText = "Active";
            checkBoxColumn.DataPropertyName = ClientDataSet.IsActiveColumn;
            checkBoxColumn.FillWeight = 30;
            checkBoxColumn.Width = 120;
            checkBoxColumn.DefaultCellStyle.Alignment= DataGridViewContentAlignment.MiddleCenter;
            this.dgvClients.Columns.Add(checkBoxColumn);

            this._clients = DataLayer.GetAllClientDataSet();
            this.dgvClients.DataSource = this._clients.Tables[ClientDataSet.TableClient];

            this.dgvClients.Columns[ClientDataSet.IdColumn].Width = 0;
            this.dgvClients.Columns[ClientDataSet.IdColumn].Visible = false;
        }

        private void OnClose(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #endregion
    }
}
