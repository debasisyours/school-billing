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
    public partial class RouteInformationForm : MetroForm
    {
        #region Declaration

        private RouteDataSet _routeDataSet;

        #endregion

        #region Constructor
        public RouteInformationForm()
        {
            InitializeComponent();
        }
        #endregion

        #region Form events

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.Theme = Program.SelectedTheme;
            this.Refresh();
            this.AssignEventHandlers();
            this.FormatGrid();
        }

        #endregion

        #region Custom methods

        private void AssignEventHandlers()
        {
            this.AddButton.Click += new EventHandler(OnAddRoute);
            this.EditButton.Click+=new EventHandler(OnEditRoute);
            this.CloseButton.Click += new EventHandler(OnClose);
            this.DeleteButton.Click += new EventHandler(OnDeleteRoute);
            this.dgvRoutes.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(OnGridHeaderClick);
            this.dgvRoutes.CellDoubleClick += new DataGridViewCellEventHandler(OnGridDoubleClick);
            this.txtSearch.TextChanged += new EventHandler(OnSearchRequest);
        }

        private void OnDeleteRoute(object sender, EventArgs e)
        {
            if (this.dgvRoutes.SelectedRows.Count == 0)
            {
                MessageBox.Show(this, "No Route Id selected.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dgvRoutes.Focus();
                return;
            }

            int selectedId = Convert.ToInt32(this.dgvRoutes.SelectedRows[0].Cells[RouteDataSet.IdColumn].Value);

            if(MessageBox.Show(this, "Are you sure you want to delete selected Route Id?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes)
            {
                bool success = DataLayer.DeleteRoute(selectedId);
                if (success)
                {
                    MessageBox.Show(this, "Route Id deleted successfully.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.FormatGrid();
                }
                else
                {
                    MessageBox.Show(this, "Route Id could not be deleted, please check log file.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void OnSearchRequest(object sender, EventArgs e)
        {
            string filterExpression = string.Empty;
            RouteDataSet routeDataSet = new RouteDataSet();
            switch (this.lblSearch.Text.Substring(9).Trim())
            {
                case RouteDataSet.NameColumn:
                {
                    filterExpression = $"{RouteDataSet.NameColumn} LIKE '%{this.txtSearch.Text}%'";
                    break;
                }
                case "Route Cost":
                {
                    filterExpression = $"CONVERT({RouteDataSet.RouteCostColumn}, 'System.String') LIKE '%{this.txtSearch.Text}%'";
                    break;
                }
                case "Aid Cost":
                {
                    filterExpression = $"CONVERT({RouteDataSet.AidCostColumn}, 'System.String') LIKE '%{this.txtSearch.Text}%'";
                    break;
                }
            }

            if (!string.IsNullOrWhiteSpace(filterExpression))
            {
                DataRow[] filteredRows = this._routeDataSet.Tables[RouteDataSet.TableRoute].Select(filterExpression);
                if (filteredRows.Length > 0)
                {
                    foreach (DataRow row in filteredRows)
                    {
                        routeDataSet.Tables[RouteDataSet.TableRoute].ImportRow(row);
                    }
                }
                this.dgvRoutes.DataSource = routeDataSet.Tables[RouteDataSet.TableRoute];
                this.dgvRoutes.Columns[RouteDataSet.IdColumn].Width = 0;
                this.dgvRoutes.Columns[RouteDataSet.IdColumn].Visible = false;
            }
        }

        private void OnGridDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvRoutes.RowCount > 0)
            {
                int selectedId = Convert.ToInt32(this.dgvRoutes.Rows[e.RowIndex].Cells[RouteDataSet.IdColumn].Value);
                using (var routeForm = new RouteUpdateForm(selectedId))
                {
                    var result = routeForm.ShowDialog();
                    if(result== DialogResult.OK)
                    {
                        this.FormatGrid();
                    }
                }
            }
        }

        private void OnGridHeaderClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            switch (this.dgvRoutes.Columns[e.ColumnIndex].HeaderText)
            {
                case RouteDataSet.NameColumn:
                {
                    this.lblSearch.Text = $"Search on {RouteDataSet.NameColumn}";
                    break;
                }
                case "Route Cost":
                {
                    this.lblSearch.Text = $"Search on Route Cost";
                    break;
                }
                case "Aid Cost":
                {
                    this.lblSearch.Text = $"Search on Aid Cost";
                    break;
                }
            }
            this.txtSearch.Focus();
        }

        private void OnAddRoute(object sender, EventArgs e)
        {
            using (var routeForm = new RouteUpdateForm())
            {
                var result = routeForm.ShowDialog();
                if(result == DialogResult.OK)
                {
                    this.FormatGrid();
                }
            }
        }

        private void OnEditRoute(object sender, EventArgs e)
        {
            if (this.dgvRoutes.SelectedRows.Count == 0)
            {
                MessageBox.Show(this, "Please select a route to edit.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dgvRoutes.Focus();
                return;
            }

            int selectedId = Convert.ToInt32(this.dgvRoutes.SelectedRows[0].Cells[RouteDataSet.IdColumn].Value);

            using (var routeForm = new RouteUpdateForm(selectedId))
            {
                var result = routeForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    this.FormatGrid();
                }
            }
        }

        private void OnClose(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FormatGrid()
        {
            DataGridViewTextBoxColumn textColumn = null;

            this.dgvRoutes.AllowUserToAddRows = false;
            this.dgvRoutes.AllowUserToDeleteRows = false;
            this.dgvRoutes.AllowUserToResizeRows = false;
            this.dgvRoutes.AutoGenerateColumns = false;
            this.dgvRoutes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRoutes.BackgroundColor = Color.White;
            this.dgvRoutes.MultiSelect = false;
            this.dgvRoutes.ReadOnly = true;
            this.dgvRoutes.RowHeadersVisible = false;
            this.dgvRoutes.RowsDefaultCellStyle.BackColor = Color.White;
            this.dgvRoutes.AlternatingRowsDefaultCellStyle.BackColor = Color.BlanchedAlmond;
            this.dgvRoutes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvRoutes.Columns.Clear();

            textColumn = new DataGridViewTextBoxColumn();
            textColumn.DataPropertyName = RouteDataSet.IdColumn;
            textColumn.Name = RouteDataSet.IdColumn;
            textColumn.HeaderText = RouteDataSet.IdColumn;
            textColumn.FillWeight = 10;
            textColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            textColumn.Width = 0;
            textColumn.Visible = false;
            this.dgvRoutes.Columns.Add(textColumn);

            textColumn = new DataGridViewTextBoxColumn();
            textColumn.DataPropertyName = RouteDataSet.NameColumn;
            textColumn.Name = RouteDataSet.NameColumn;
            textColumn.HeaderText = RouteDataSet.NameColumn;
            textColumn.FillWeight = 80;
            textColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            textColumn.Width = 200;
            textColumn.Visible = true;
            this.dgvRoutes.Columns.Add(textColumn);

            textColumn = new DataGridViewTextBoxColumn();
            textColumn.DataPropertyName = RouteDataSet.RouteCostColumn;
            textColumn.Name = RouteDataSet.RouteCostColumn;
            textColumn.HeaderText = "Route Cost";
            textColumn.FillWeight = 50;
            textColumn.DefaultCellStyle.Format = "C2";
            textColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            textColumn.Width = 100;
            textColumn.Visible = true;
            this.dgvRoutes.Columns.Add(textColumn);

            textColumn = new DataGridViewTextBoxColumn();
            textColumn.DataPropertyName = RouteDataSet.AidCostColumn;
            textColumn.Name = RouteDataSet.AidCostColumn;
            textColumn.HeaderText = "Aid Cost";
            textColumn.FillWeight = 50;
            textColumn.DefaultCellStyle.Format = "C2";
            textColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            textColumn.Width = 100;
            textColumn.Visible = true;
            this.dgvRoutes.Columns.Add(textColumn);

            _routeDataSet = DataLayer.GetAllRoutesDataSet();
            this.dgvRoutes.DataSource = _routeDataSet.Tables[RouteDataSet.TableRoute];
            this.dgvRoutes.Columns[RouteDataSet.IdColumn].Width = 0;
            this.dgvRoutes.Columns[RouteDataSet.IdColumn].Visible = false;
        }

        #endregion
    }
}
