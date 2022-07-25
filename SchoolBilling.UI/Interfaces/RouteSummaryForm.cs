using MetroFramework.Forms;
using OfficeOpenXml;
using SchoolBilling.Common;
using SchoolBilling.Data;
using SchoolBilling.Data.DataSets;
using SchoolBilling.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace SchoolBilling.UI.Interfaces
{
    public partial class RouteSummaryForm : MetroForm
    {
        #region Constructor
        public RouteSummaryForm()
        {
            InitializeComponent();
        }
        #endregion

        #region Form events

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.AssignEventHandlers();
            this.PopulateControls();
            this.FormatGrid();
        }

        #endregion

        #region Custom functions

        private void AssignEventHandlers()
        {
            this.OkButton.Click += new EventHandler(OnOk);
            this.CancelButton.Click += new EventHandler(OnCancel);
            this.ShowButton.Click += new EventHandler(OnGenerate);
            this.ExportButton.Click += new EventHandler(ExportToExcel);
            this.BrowseButton.Click += new EventHandler(OnBrowse);
        }

        private void PopulateControls()
        {
            var routeList = DataLayer.GetAllRoutes(true);
            this.cboRoute.DataSource = routeList;
            this.cboRoute.DisplayMember = "Name";
            this.cboRoute.ValueMember = "Id";

            this.dtpFromDate.Value = DateTime.Now.AddMonths(-1);
            this.dtpToDate.Value = DateTime.Now;

            this.txtExportPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            this.txtExportPath.ReadOnly = true;
        }

        private void OnCancel(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void OnBrowse(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Title = "Select path to export";
            dialog.Filter = "Excel Files(*.xlsx)|*.xlsx|All Files(*.*)|*.*";
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.txtExportPath.Text = dialog.FileName;
            }
        }

        private void OnOk(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void OnGenerate(object sender, EventArgs e)
        {
            if (this.cboRoute.SelectedItem == null)
            {
                MessageBox.Show(this, "Please select route to generate report.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cboRoute.Focus();
                return;
            }

            if (this.dtpFromDate.Value > this.dtpToDate.Value)
            {
                MessageBox.Show(this, "From date must be lesser than to date.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dtpFromDate.Focus();
                return;
            }

            var routeList = new List<int>();
            if (Convert.ToInt32(this.cboRoute.SelectedValue) == 0)
            {
                foreach(var item in this.cboRoute.Items)
                {
                    if (((Route)item).Id > 0) routeList.Add(((Route)item).Id);
                }
            }
            else
            {
                routeList.Add(Convert.ToInt32(this.cboRoute.SelectedValue));
            }

            TransactionSummaryDataSet summaryReport = DataLayer.PopulateTransactionSummary(routeList, this.dtpFromDate.Value, this.dtpToDate.Value);
            this.dgvDetail.DataSource = summaryReport.Tables[TransactionSummaryDataSet.TableSummaryReport];
            this.dgvDetail.Columns[TransactionSummaryDataSet.RouteIdColumn].Width = 0;
            this.dgvDetail.Columns[TransactionSummaryDataSet.RouteIdColumn].Visible = false;
            this.dgvDetail.Columns[TransactionSummaryDataSet.ClientIdColumn].Width = 0;
            this.dgvDetail.Columns[TransactionSummaryDataSet.ClientIdColumn].Visible = false;

            this.FormatTotalRow();
        }

        private void FormatTotalRow()
        {
            var totalRows = new List<int>();

            foreach(DataGridViewRow rowItem in this.dgvDetail.Rows)
            {
                if (rowItem.Cells[TransactionSummaryDataSet.RouteNameColumn].Value.ToString().StartsWith("Total for"))
                {
                    totalRows.Add(rowItem.Index);
                }
            }

            if (totalRows.Any())
            {
                totalRows.ForEach(s =>
                {
                    this.dgvDetail.Rows[s].Cells[TransactionSummaryDataSet.RouteNameColumn].Style.Font = new Font(new FontFamily("Calibri"),12, FontStyle.Bold);
                    this.dgvDetail.Rows[s].Cells[TransactionSummaryDataSet.AideCostColumn].Style.ForeColor = Color.White;
                    this.dgvDetail.Rows[s].Cells[TransactionSummaryDataSet.RouteCostColumn].Style.ForeColor = Color.White;
                    this.dgvDetail.Rows[s].Cells[TransactionSummaryDataSet.PerDiemColumn].Style.ForeColor = Color.White;
                });
            }
        }

        private void ExportToExcel(object sender, EventArgs e)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage package = new ExcelPackage();
            var sheet = package.Workbook.Worksheets.Add("Transaction Summary");
            int row = 2;
            int col = 1;

            try
            {
                sheet.Cells[row, 1].Value = "Transaction Summary";
                sheet.Cells[row, 1].Style.Font.Size = 12;
                sheet.Cells[row, 1].Style.Font.Bold = true;
                sheet.Cells[row, 1, row, 8].Merge = true;
                sheet.Cells[row, 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                row++;

                sheet.Cells[row, 1].Value = "From:";
                sheet.Cells[row, 2].Value = dtpFromDate.Value.ToShortDateString();
                sheet.Cells[row, 1].Style.Font.Size = 9;
                sheet.Cells[row, 1].Style.Font.Bold = true;
                sheet.Cells[row, 2].Style.Font.Size = 9;
                sheet.Cells[row, 2].Style.Font.Bold = true;

                row++;
                sheet.Cells[row, 1].Value = "To:";
                sheet.Cells[row, 2].Value = dtpToDate.Value.ToShortDateString();
                sheet.Cells[row, 1].Style.Font.Size = 9;
                sheet.Cells[row, 1].Style.Font.Bold = true;
                sheet.Cells[row, 2].Style.Font.Size = 9;
                sheet.Cells[row, 2].Style.Font.Bold = true;

                row++;
                for (int column = 0; column < this.dgvDetail.Columns.Count; column++)
                {
                    if (this.dgvDetail.Columns[column].Visible)
                    {
                        sheet.Cells[row, col].Value = this.dgvDetail.Columns[column].HeaderText;
                        sheet.Cells[row, col].Style.Font.Bold = true;
                        col++;
                    }
                }

                sheet.Columns[1].Width = 20;
                sheet.Columns[2].Width = 20;
                sheet.Columns[3].Width = 12;
                sheet.Columns[4].Width = 12;
                sheet.Columns[5].Width = 12;
                sheet.Columns[6].Width = 12;
                sheet.Columns[7].Width = 12;
                sheet.Columns[8].Width = 15;

                sheet.Columns[4].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                sheet.Columns[5].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                sheet.Columns[6].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                sheet.Columns[7].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                sheet.Columns[8].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;

                row++;
                for (int gridRow = 0; gridRow < this.dgvDetail.RowCount; gridRow++)
                {
                    col = 1;
                    for (int column = 0; column < this.dgvDetail.Columns.Count; column++)
                    {
                        if (this.dgvDetail.Columns[column].Visible)
                        {
                            if (this.dgvDetail.Rows[gridRow].Cells[TransactionSummaryDataSet.RouteNameColumn].Value.ToString().StartsWith("Total for"))
                            {
                                switch (this.dgvDetail.Columns[column].HeaderText)
                                {
                                    case "Days #":
                                        {
                                            sheet.Cells[row, col].Value = this.dgvDetail.Rows[gridRow].Cells[column].Value.ToString();
                                            break;
                                        }
                                    case "Total Cost":
                                        {
                                            sheet.Cells[row, col].Value = this.dgvDetail.Rows[gridRow].Cells[column].Value.ToString();
                                            break;
                                        }
                                    case "Route Name":
                                        {
                                            sheet.Cells[row, col].Value = this.dgvDetail.Rows[gridRow].Cells[column].Value.ToString();
                                            sheet.Cells[row, col].Style.WrapText = true;
                                            break;
                                        }
                                }
                            }
                            else
                            {
                                if (this.dgvDetail.Columns[column].HeaderText == "Invoice Date")
                                {
                                    sheet.Cells[row, col].Value = Convert.ToDateTime(this.dgvDetail.Rows[gridRow].Cells[column].Value).ToShortDateString();
                                }
                                else
                                {
                                    sheet.Cells[row, col].Value = this.dgvDetail.Rows[gridRow].Cells[column].Value.ToString();
                                }
                            }
                            col++;
                        }
                    }
                    row++;
                }

                string fileName = $"TransactionSummary-{DateTime.Now.Year.ToString()}{DateTime.Now.Month.ToString().PadLeft(2, '0')}{DateTime.Now.Day.ToString().PadLeft(2, '0')}-{DateTime.Now.Hour.ToString().PadLeft(2, '0')}{DateTime.Now.Minute.ToString().PadLeft(2, '0')}{DateTime.Now.Second.ToString().PadLeft(2, '0')}.xlsx";
                package.SaveAs(Path.Combine(this.txtExportPath.Text, fileName));
                MessageBox.Show(this, "Transaction Summary exported successfully.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                Logger.LogException(ex);
            }
        }

        private void FormatGrid()
        {
            DataGridViewTextBoxColumn column;

            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            this.dgvDetail.AllowUserToResizeColumns = false;
            this.dgvDetail.AllowUserToResizeRows = false;
            this.dgvDetail.AutoGenerateColumns = false;
            this.dgvDetail.BackgroundColor = Color.White;
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.dgvDetail.Columns.Clear();
            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = TransactionSummaryDataSet.RouteIdColumn;
            column.Name = TransactionSummaryDataSet.RouteIdColumn;
            column.HeaderText = TransactionSummaryDataSet.RouteIdColumn;
            column.ReadOnly = true;
            column.FillWeight = 10;
            column.Width = 0;
            column.Visible = false;
            this.dgvDetail.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = TransactionSummaryDataSet.RouteNameColumn;
            column.Name = TransactionSummaryDataSet.RouteNameColumn;
            column.HeaderText = "Route Name";
            column.ReadOnly = true;
            column.FillWeight = 40;
            column.Width = 40;
            column.Visible = true;
            this.dgvDetail.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = TransactionSummaryDataSet.ClientIdColumn;
            column.Name = TransactionSummaryDataSet.ClientIdColumn;
            column.HeaderText = TransactionSummaryDataSet.ClientIdColumn;
            column.ReadOnly = true;
            column.FillWeight = 10;
            column.Width = 0;
            column.Visible = false;
            this.dgvDetail.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = TransactionSummaryDataSet.ClientNameColumn;
            column.Name = TransactionSummaryDataSet.ClientNameColumn;
            column.HeaderText = "School Name";
            column.ReadOnly = true;
            column.FillWeight = 50;
            column.Width = 60;
            column.Visible = true;
            this.dgvDetail.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = TransactionSummaryDataSet.InvoiceDateColumn;
            column.Name = TransactionSummaryDataSet.InvoiceDateColumn;
            column.HeaderText = "Invoice Date";
            column.DefaultCellStyle.Format = "MM/dd/yyyy";
            column.ReadOnly = true;
            column.FillWeight = 40;
            column.Width = 40;
            column.Visible = true;
            this.dgvDetail.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = TransactionSummaryDataSet.RouteCostColumn;
            column.Name = TransactionSummaryDataSet.RouteCostColumn;
            column.HeaderText = "Route Cost";
            column.ReadOnly = true;
            column.FillWeight = 40;
            column.Width = 40;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            column.Visible = true;
            this.dgvDetail.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = TransactionSummaryDataSet.AideCostColumn;
            column.Name = TransactionSummaryDataSet.AideCostColumn;
            column.HeaderText = "Aide Cost";
            column.ReadOnly = true;
            column.FillWeight = 40;
            column.Width = 40;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            column.Visible = true;
            this.dgvDetail.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = TransactionSummaryDataSet.PerDiemColumn;
            column.Name = TransactionSummaryDataSet.PerDiemColumn;
            column.HeaderText = "Per diem";
            column.ReadOnly = true;
            column.FillWeight = 40;
            column.Width = 40;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            column.Visible = true;
            this.dgvDetail.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = TransactionSummaryDataSet.DayCountColumn;
            column.Name = TransactionSummaryDataSet.DayCountColumn;
            column.HeaderText = "Days #";
            column.ReadOnly = true;
            column.FillWeight = 30;
            column.Width = 30;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            column.Visible = true;
            this.dgvDetail.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = TransactionSummaryDataSet.TotalCostColumn;
            column.Name = TransactionSummaryDataSet.TotalCostColumn;
            column.HeaderText = "Total Cost";
            column.ReadOnly = true;
            column.FillWeight = 40;
            column.Width = 40;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            column.Visible = true;
            this.dgvDetail.Columns.Add(column);
        }

        #endregion
    }
}
