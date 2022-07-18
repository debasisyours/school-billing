using MetroFramework.Forms;
using OfficeOpenXml;
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
using Microsoft.Office.Interop;
using Microsoft.Office.Interop.Outlook;
using Microsoft.Office.Interop.Excel;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace SchoolBilling.UI.Interfaces
{
    public partial class InvoiceSearchForm : MetroForm
    {
        #region Declaration

        private InvoiceDataSet _invoices;

        #endregion

        #region Constructor
        public InvoiceSearchForm()
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

        #region Custom functions

        private void AssignEventHandlers()
        {
            this.AddButton.Click += new EventHandler(OnAddInvoice);
            this.EditButton.Click+=new EventHandler(OnEditInvoice);
            this.InitializeValues();
            this.CloseButton.Click += new EventHandler(OnCancel);
            this.DateSelectButton.Click += new EventHandler(OnChangeDate);
            this.txtExportPath.Click += new EventHandler(OnSelectExportPath);
            this.SelectAllButton.Click += new EventHandler(OnSelectAll);
            this.PrintButton.Click+=new EventHandler(OnPrintInvoice);
            this.mailButton.Click+=new EventHandler(OnMailInvoice);
            this.dgvInvoices.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(OnGridHeaderClick);
            this.dgvInvoices.CellDoubleClick += new DataGridViewCellEventHandler(OnInvoiceSelect);
            this.txtSearch.TextChanged += new EventHandler(OnSearchChange);
        }

        private void OnMailInvoice(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Outlook.Application application = new Microsoft.Office.Interop.Outlook.Application();
            Microsoft.Office.Interop.Outlook.MailItem mailItem = (Microsoft.Office.Interop.Outlook.MailItem)application.CreateItem(OlItemType.olMailItem);
            mailItem.Subject = "Invoice Email";
            mailItem.Body = "Please find attached invoice.";
            mailItem.BodyFormat = OlBodyFormat.olFormatHTML;
            mailItem.Importance = OlImportance.olImportanceNormal;
            string fileName = this.GenerateExportFile(false);
            mailItem.Attachments.Add(Path.Combine(this.txtExportPath.Text, fileName), Microsoft.Office.Interop.Outlook.OlAttachmentType.olByValue, Type.Missing, Type.Missing);

            mailItem.Display();
        }

        private void OnSearchChange(object sender, EventArgs e)
        {
            string filterExpression = string.Empty;

            switch (this.lblSearch.Text.Substring(9).Trim())
            {
                case "Client":
                    {
                        filterExpression = $"{InvoiceDataSet.ClientNameColumn} LIKE '%{this.txtSearch.Text}%'";
                        break;
                    }
                case "Route":
                    {
                        filterExpression = $"{InvoiceDataSet.RouteNameColumn} LIKE '%{this.txtSearch.Text}%'";
                        break;
                    }
                case "Total Cost":
                    {
                        filterExpression = $"CONVERT({InvoiceDataSet.TotalCostColumn}, 'System.String') LIKE '%{this.txtSearch.Text}%'";
                        break;
                    }
                case "Invoice #":
                    {
                        filterExpression = $"CONVERT({InvoiceDataSet.InvoiceNumberColumn}, 'System.String') LIKE '%{this.txtSearch.Text}%'";
                        break;
                    }
            }

            if (!string.IsNullOrWhiteSpace(filterExpression))
            {
                DataRow[] selectedRows = this._invoices.Tables[InvoiceDataSet.TableInvoice].Select(filterExpression);
                if (selectedRows.Length > 0)
                {
                    InvoiceDataSet tempDataSet = new InvoiceDataSet();
                    foreach (DataRow row in selectedRows)
                    {
                        tempDataSet.Tables[InvoiceDataSet.TableInvoice].ImportRow(row);
                    }

                    this.dgvInvoices.DataSource = tempDataSet.Tables[InvoiceDataSet.TableInvoice];
                    this.dgvInvoices.Columns[InvoiceDataSet.IdColumn].Width = 0;
                    this.dgvInvoices.Columns[InvoiceDataSet.ClientIdColumn].Width = 0;
                    this.dgvInvoices.Columns[InvoiceDataSet.RouteIdColumn].Width = 0;
                    this.dgvInvoices.Columns[InvoiceDataSet.IdColumn].Visible = false;
                    this.dgvInvoices.Columns[InvoiceDataSet.ClientIdColumn].Visible = false;
                    this.dgvInvoices.Columns[InvoiceDataSet.RouteIdColumn].Visible = false;
                }
            }
        }

        private void OnInvoiceSelect(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvInvoices.RowCount > 0)
            {
                int selectedId = Convert.ToInt32(this.dgvInvoices.Rows[e.RowIndex].Cells[InvoiceDataSet.IdColumn].Value);
                using (var invoiceForm = new InvoiceCreationForm(selectedId))
                {
                    var result = invoiceForm.ShowDialog();
                    if(result== DialogResult.OK)
                    {
                        this.FormatGrid();
                    }
                }
            }
        }

        private void OnGridHeaderClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            switch (this.dgvInvoices.Columns[e.ColumnIndex].HeaderText)
            {
                case "Client":
                    {
                        this.lblSearch.Text = "Search by Client";
                        this.txtSearch.Focus();
                        break;
                    }
                case "Route":
                    {
                        this.lblSearch.Text = "Search by Route";
                        this.txtSearch.Focus();
                        break;
                    }
                case "Total Cost":
                    {
                        this.lblSearch.Text = "Search by Total Cost";
                        this.txtSearch.Focus();
                        break;
                    }
                case "Invoice #":
                    {
                        this.lblSearch.Text = "Search by Invoice #";
                        this.txtSearch.Focus();
                        break;
                    }
            }
        }

        private void InitializeValues()
        {
            this.dtpFrom.Format = DateTimePickerFormat.Custom;
            this.dtpFrom.CustomFormat = "MM/dd/yyyy";
            this.dtpTo.Format = DateTimePickerFormat.Custom;
            this.dtpTo.CustomFormat = "MM/dd/yyyy";

            this.dtpFrom.Value = DateTime.Now;
            this.dtpTo.Value = DateTime.Now;
            this.txtExportPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }

        private void OnAddInvoice(object sender, EventArgs e)
        {
            using (var invoiceForm = new InvoiceCreationForm())
            {
                var dialog = invoiceForm.ShowDialog();
                if(dialog == DialogResult.OK)
                {
                    this.FormatGrid();
                }
            }
        }

        private void OnEditInvoice(object sender, EventArgs e)
        {
            if(this.dgvInvoices.SelectedRows.Count==0)
            {
                MessageBox.Show(this, "Please select an invoice to edit.", System.Windows.Forms.Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dgvInvoices.Focus();
                return;
            }
            int selectedId = Convert.ToInt32(this.dgvInvoices.SelectedRows[0].Cells[InvoiceDataSet.IdColumn].Value);
            using (var invoiceForm = new InvoiceCreationForm(selectedId))
            {
                var dialog = invoiceForm.ShowDialog();
                if (dialog == DialogResult.OK)
                {
                    this.FormatGrid();
                }
            }
        }

        private void OnChangeDate(object sender, EventArgs e)
        {
            this._invoices = DataLayer.GetInvoicesDataSet(this.dtpFrom.Value, this.dtpTo.Value);
            this.dgvInvoices.DataSource = this._invoices.Tables[InvoiceDataSet.TableInvoice];
            this.dgvInvoices.Columns[InvoiceDataSet.IdColumn].Width = 0;
            this.dgvInvoices.Columns[InvoiceDataSet.ClientIdColumn].Width = 0;
            this.dgvInvoices.Columns[InvoiceDataSet.RouteIdColumn].Width = 0;
            this.dgvInvoices.Columns[InvoiceDataSet.IdColumn].Visible = false;
            this.dgvInvoices.Columns[InvoiceDataSet.ClientIdColumn].Visible = false;
            this.dgvInvoices.Columns[InvoiceDataSet.RouteIdColumn].Visible = false;
        }

        private void OnSelectAll(object sender, EventArgs e)
        {
            if (this.dgvInvoices.RowCount > 0)
            {
                if(this.SelectAllButton.Text=="Select All")
                {
                    foreach (DataRow row in this._invoices.Tables[InvoiceDataSet.TableInvoice].Rows)
                    {
                        row[InvoiceDataSet.SelectedColumn] = true;
                    }
                    this._invoices.Tables[InvoiceDataSet.TableInvoice].AcceptChanges();
                    this.SelectAllButton.Text = "Clear All";
                }
                else if(this.SelectAllButton.Text == "Clear All")
                {
                    foreach(DataRow row in this._invoices.Tables[InvoiceDataSet.TableInvoice].Rows)
                    {
                        row[InvoiceDataSet.SelectedColumn] = false;
                    }
                    this._invoices.Tables[InvoiceDataSet.TableInvoice].AcceptChanges();
                    this.SelectAllButton.Text = "Select All";
                }
            }
        }

        private void OnPrintInvoice(object sender, EventArgs e)
        {
            int selectionCount = 0;

            if (this.dgvInvoices.RowCount > 0)
            {
                for(int count = 0; count< this.dgvInvoices.RowCount; count++)
                {
                    if (Convert.ToBoolean(this.dgvInvoices.Rows[count].Cells[InvoiceDataSet.SelectedColumn].Value))
                    {
                        selectionCount++;
                    }
                }
            }

            if (selectionCount == 0)
            {
                MessageBox.Show(this, "No invoice selected.", System.Windows.Forms.Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (selectionCount > 1)
            {
                MessageBox.Show(this, "Please select one invoice to print.", System.Windows.Forms.Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.GenerateExportFile(true);
            MessageBox.Show(this, "Invoice(s) exported to Excel successfully.", System.Windows.Forms.Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string GenerateExportFile(bool showPreview)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage application = new ExcelPackage();
            int row = 7;
            decimal totalAmount = 0;
            string filePath = $"InvoiceExport-{DateTime.Now.Year}-{DateTime.Now.Month.ToString().PadLeft(2, '0')}-{DateTime.Now.Day.ToString().PadLeft(2, '0')}-{DateTime.Now.Hour.ToString().PadLeft(2, '0')}-{DateTime.Now.Minute.ToString().PadLeft(2, '0')}-{DateTime.Now.Second.ToString().PadLeft(2, '0')}.xlsx";
            var sheet = application.Workbook.Worksheets.Add("Invoice Export");

            var companyInfo = DataLayer.GetCompanyDetail();
            if (companyInfo != null)
            {
                this.SetHeaderInfo(sheet, companyInfo);
            }

            foreach (DataRow rowItem in this._invoices.Tables[InvoiceDataSet.TableInvoice].Rows)
            {
                if (Convert.ToBoolean(rowItem[InvoiceDataSet.SelectedColumn]))
                {
                    row += 1;
                    totalAmount += this.AddSingleRow(rowItem, sheet, row);
                }
            }

            row += 1;
            this.AddFooter(sheet, row, totalAmount);
            sheet.Cells[7, 1, row, 11].Style.WrapText = true;

            for (int startRow = 7; startRow <= row; startRow++)
            {
                for (int startCol = 1; startCol < 12; startCol++)
                {
                    sheet.Cells[startRow, startCol].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin, Color.Black);
                }
            }

            application.SaveAs(Path.Combine(this.txtExportPath.Text, filePath));

            if (showPreview)
            {
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                Workbook workbook = excelApp.Workbooks.Open(Path.Combine(this.txtExportPath.Text, filePath));
                excelApp.Visible = true;
                ((Worksheet)workbook.ActiveSheet).PageSetup.Orientation = XlPageOrientation.xlLandscape;
                ((Worksheet)workbook.ActiveSheet).PageSetup.FitToPagesWide = 1;
                workbook.PrintPreview();               
            }

            return filePath;
        }

        private void AddFooter(ExcelWorksheet sheet, int row, decimal totalValue)
        {
            sheet.Cells[row, 1].Value = "Total";
            this.SetCellFont(sheet, row, 1, 12, true);

            sheet.Cells[row, 9].Value = totalValue.ToString("N2");
            this.SetCellFont(sheet, row, 9, 12, true);
        }

        private int GetSelectedInvoiceNumber()
        {
            int selectedInvoiceNumber = 0;

            if (this.dgvInvoices.RowCount > 0)
            {
                for(int loop=0; loop < this.dgvInvoices.RowCount; loop++)
                {
                    if (Convert.ToBoolean(this.dgvInvoices.Rows[loop].Cells[InvoiceDataSet.SelectedColumn].Value))
                    {
                        selectedInvoiceNumber = Convert.ToInt32(this.dgvInvoices.Rows[loop].Cells[InvoiceDataSet.InvoiceNumberColumn].Value);
                    }
                }
            }

            return selectedInvoiceNumber;
        }

        private DateTime GetSelectedInvoiceDate()
        {
            DateTime? selectedInvoiceDate = null;

            if (this.dgvInvoices.RowCount > 0)
            {
                for (int loop = 0; loop < this.dgvInvoices.RowCount; loop++)
                {
                    if (Convert.ToBoolean(this.dgvInvoices.Rows[loop].Cells[InvoiceDataSet.SelectedColumn].Value))
                    {
                        selectedInvoiceDate = Convert.ToDateTime(this.dgvInvoices.Rows[loop].Cells[InvoiceDataSet.InvoiceDateColumn].Value);
                    }
                }
            }

            return selectedInvoiceDate.Value;
        }

        private decimal AddSingleRow(DataRow dataRow, ExcelWorksheet sheet, int row)
        {
            sheet.Cells[row, 1].Value = Convert.ToString(dataRow[InvoiceDataSet.RouteNameColumn]);
            sheet.Cells[row, 1, row, 2].Merge = true;
            sheet.Cells[row, 3].Value = Convert.ToString(dataRow[InvoiceDataSet.ClientNameColumn]);
            sheet.Cells[row, 4].Value = $"{Convert.ToDateTime(dataRow[InvoiceDataSet.StartDateColumn]).ToString("M/d/yyyy")} to {Convert.ToDateTime(dataRow[InvoiceDataSet.EndDateColumn]).ToString("M/d/yyyy")}";
            sheet.Cells[row, 5].Value = Convert.ToDecimal(dataRow[InvoiceDataSet.RouteCostColumn]).ToString("N2");
            sheet.Cells[row, 6].Value = Convert.ToDecimal(dataRow[InvoiceDataSet.AideCostColumn]).ToString("N2");
            sheet.Cells[row, 7].Value = Convert.ToDecimal(dataRow[InvoiceDataSet.PerdiemColumn]).ToString("N2");
            sheet.Cells[row, 8].Value = Convert.ToInt32(dataRow[InvoiceDataSet.DayCountColumn]);
            sheet.Cells[row, 9].Value = Convert.ToDecimal(dataRow[InvoiceDataSet.TotalCostColumn]).ToString("N2");
            sheet.Cells[row, 10].Value = Convert.ToInt32(dataRow[InvoiceDataSet.CovidDayCountColumn]);
            sheet.Cells[row, 11].Value = Convert.ToString(dataRow[InvoiceDataSet.CovidNotesColumn]);
            return Convert.ToDecimal(dataRow[InvoiceDataSet.TotalCostColumn]);
        }

        private void SetHeaderInfo(ExcelWorksheet sheet, Company companyInfo)
        {
            sheet.Cells[1, 1].Value = companyInfo.Name;
            this.SetCellFont(sheet, 1, 1, 14, true);
            sheet.Cells[1, 1, 1, 6].Merge = true;

            sheet.Cells[2, 1].Value = companyInfo.Address;
            this.SetCellFont(sheet, 2, 1, 14, true);
            sheet.Cells[2, 1, 2, 6].Merge = true;

            sheet.Cells[3, 1].Value = $"{companyInfo.City}, {companyInfo.State}, {companyInfo.PostalCode}";
            this.SetCellFont(sheet, 3, 1, 14, true);
            sheet.Cells[3, 1, 3, 6].Merge = true;

            sheet.Cells[5, 1].Value = $"Tel: {companyInfo.Phone}";
            this.SetCellFont(sheet, 5, 1, 12, true);
            sheet.Cells[5, 1, 5, 2].Merge = true;

            sheet.Cells[5, 3].Value = $"Fax: {companyInfo.Fax}";
            this.SetCellFont(sheet, 5, 3, 12, true);
            sheet.Cells[5, 3, 5, 4].Merge = true;

            sheet.Cells[1, 8].Value = "INVOICE";
            this.SetCellFont(sheet, 1, 8, 14, true);
            sheet.Cells[1, 8, 1, 9].Merge = true;

            sheet.Cells[3, 8].Value = "Date:";
            this.SetCellFont(sheet, 3, 8, 14, true);

            sheet.Cells[4, 8].Value = this.GetSelectedInvoiceDate().ToString("MMMM dd, yyyy");
            this.SetCellFont(sheet, 4, 8, 12, true);
            sheet.Cells[4, 8, 4, 9].Merge = true;

            sheet.Cells[5, 8].Value = "Email:";
            this.SetCellFont(sheet, 5, 8, 12, true);
            sheet.Cells[5, 9].Value = companyInfo.ContactEmail;
            this.SetCellFont(sheet, 5, 9, 12, true);

            sheet.Cells[1, 10].Value = this.GetSelectedInvoiceNumber();
            this.SetCellFont(sheet, 1, 10, 12, true);

            sheet.Cells[7, 1].Value = "Route ID";
            sheet.Cells[7, 1, 7, 2].Merge = true;
            sheet.Cells[7, 3].Value = "School Name";
            sheet.Columns[3].Width = 15;
            sheet.Cells[7, 4].Value = "Date (Start-End)";
            sheet.Columns[4].Width = 20;
            sheet.Cells[7, 5].Value = "Route Cost";
            sheet.Columns[5].Width = 10;
            sheet.Cells[7, 6].Value = "Aide Cost";
            sheet.Columns[6].Width = 10;
            sheet.Cells[7, 7].Value = "Per Diem";
            sheet.Cells[7, 8].Value = "# of Days Transported of the Month";
            sheet.Columns[8].Width = 12.75;
            sheet.Cells[7, 9].Value = "Total";
            sheet.Cells[7, 10].Value = "# of COVID Days";
            sheet.Cells[7, 11].Value = "COVID Date";
            sheet.Columns[11].Width = 12.75;

            for (int loop = 1; loop < 12; loop++)
            {
                this.SetCellFont(sheet, 7, loop, 12, true);
            }
        }

        private void SetCellFont(ExcelWorksheet sheet, int row, int column, int size, bool bold)
        {
            sheet.Cells[row, column].Style.Font.Name = "Times New Roman";
            sheet.Cells[row, column].Style.Font.Size = size;
            sheet.Cells[row, column].Style.Font.Bold = bold;
        }

        private void OnCancel(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void OnSelectExportPath(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            dialog.Title = "Select path to save the exported Excel file";
            dialog.FileName = "DummyTest.dummy";
            var result = dialog.ShowDialog();

            if(result == DialogResult.OK)
            {
                this.txtExportPath.Text = dialog.FileName.Substring(0, dialog.FileName.LastIndexOf(@"\"));
            }
        }

        private void FormatGrid()
        {
            DataGridViewTextBoxColumn textColumn = null;
            DataGridViewCheckBoxColumn checkBoxColumn = null;

            this.dgvInvoices.AllowUserToAddRows = false;
            this.dgvInvoices.AllowUserToDeleteRows = false;
            this.dgvInvoices.AllowUserToResizeRows = false;
            this.dgvInvoices.AutoGenerateColumns = false;
            this.dgvInvoices.AutoSizeColumnsMode= DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInvoices.BackgroundColor = Color.White;
            this.dgvInvoices.MultiSelect = false;
            this.dgvInvoices.ReadOnly = false;
            this.dgvInvoices.RowHeadersVisible = false;
            this.dgvInvoices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvInvoices.Columns.Clear();

            checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.DataPropertyName = InvoiceDataSet.SelectedColumn;
            checkBoxColumn.Name = InvoiceDataSet.SelectedColumn;
            checkBoxColumn.HeaderText = "Select";
            checkBoxColumn.FillWeight = 20;
            checkBoxColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            checkBoxColumn.FlatStyle = FlatStyle.Flat;
            checkBoxColumn.ReadOnly = false;
            checkBoxColumn.Width = 40;
            checkBoxColumn.Visible = true;
            this.dgvInvoices.Columns.Add(checkBoxColumn);

            textColumn = new DataGridViewTextBoxColumn();
            textColumn.DataPropertyName = InvoiceDataSet.IdColumn;
            textColumn.Name = InvoiceDataSet.IdColumn;
            textColumn.HeaderText = InvoiceDataSet.IdColumn;
            textColumn.FillWeight = 10;
            textColumn.Visible = false;
            textColumn.ReadOnly = true;
            textColumn.Width = 0;
            textColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvInvoices.Columns.Add(textColumn);

            textColumn = new DataGridViewTextBoxColumn();
            textColumn.DataPropertyName = InvoiceDataSet.InvoiceNumberColumn;
            textColumn.Name = InvoiceDataSet.InvoiceNumberColumn;
            textColumn.HeaderText = "Invoice #";
            textColumn.FillWeight = 20;
            textColumn.Visible = true;
            textColumn.ReadOnly = true;
            textColumn.Width = 40;
            textColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvInvoices.Columns.Add(textColumn);

            textColumn = new DataGridViewTextBoxColumn();
            textColumn.DataPropertyName = InvoiceDataSet.ClientIdColumn;
            textColumn.Name = InvoiceDataSet.ClientIdColumn;
            textColumn.HeaderText = InvoiceDataSet.ClientIdColumn;
            textColumn.FillWeight = 10;
            textColumn.Visible = false;
            textColumn.ReadOnly = true;
            textColumn.Width = 0;
            textColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvInvoices.Columns.Add(textColumn);

            textColumn = new DataGridViewTextBoxColumn();
            textColumn.DataPropertyName = InvoiceDataSet.RouteIdColumn;
            textColumn.Name = InvoiceDataSet.RouteIdColumn;
            textColumn.HeaderText = InvoiceDataSet.RouteIdColumn;
            textColumn.FillWeight = 10;
            textColumn.Visible = false;
            textColumn.ReadOnly = true;
            textColumn.Width = 0;
            textColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvInvoices.Columns.Add(textColumn);

            textColumn = new DataGridViewTextBoxColumn();
            textColumn.DataPropertyName = InvoiceDataSet.ClientNameColumn;
            textColumn.Name = InvoiceDataSet.ClientNameColumn;
            textColumn.HeaderText = "Client";
            textColumn.FillWeight = 40;
            textColumn.Visible = true;
            textColumn.ReadOnly = true;
            textColumn.Width = 80;
            textColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvInvoices.Columns.Add(textColumn);

            textColumn = new DataGridViewTextBoxColumn();
            textColumn.DataPropertyName = InvoiceDataSet.RouteNameColumn;
            textColumn.Name = InvoiceDataSet.RouteNameColumn;
            textColumn.HeaderText = "Route";
            textColumn.FillWeight = 30;
            textColumn.Visible = true;
            textColumn.ReadOnly = true;
            textColumn.Width = 80;
            textColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvInvoices.Columns.Add(textColumn);

            textColumn = new DataGridViewTextBoxColumn();
            textColumn.DataPropertyName = InvoiceDataSet.InvoiceDateColumn;
            textColumn.Name = InvoiceDataSet.InvoiceDateColumn;
            textColumn.HeaderText = "Invoice Date";
            textColumn.FillWeight = 30;
            textColumn.Visible = true;
            textColumn.ReadOnly = true;
            textColumn.Width = 50;
            textColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            textColumn.DefaultCellStyle.Format = "dd/MMM/yyyy";
            this.dgvInvoices.Columns.Add(textColumn);

            textColumn = new DataGridViewTextBoxColumn();
            textColumn.DataPropertyName = InvoiceDataSet.StartDateColumn;
            textColumn.Name = InvoiceDataSet.StartDateColumn;
            textColumn.HeaderText = "Start Date";
            textColumn.FillWeight = 30;
            textColumn.Visible = true;
            textColumn.ReadOnly = true;
            textColumn.Width = 50;
            textColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            textColumn.DefaultCellStyle.Format = "dd/MMM/yyyy";
            this.dgvInvoices.Columns.Add(textColumn);

            textColumn = new DataGridViewTextBoxColumn();
            textColumn.DataPropertyName = InvoiceDataSet.EndDateColumn;
            textColumn.Name = InvoiceDataSet.EndDateColumn;
            textColumn.HeaderText = "End Date";
            textColumn.FillWeight = 30;
            textColumn.Visible = true;
            textColumn.ReadOnly = true;
            textColumn.Width = 50;
            textColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            textColumn.DefaultCellStyle.Format = "dd/MMM/yyyy";
            this.dgvInvoices.Columns.Add(textColumn);

            textColumn = new DataGridViewTextBoxColumn();
            textColumn.DataPropertyName = InvoiceDataSet.TotalCostColumn;
            textColumn.Name = InvoiceDataSet.TotalCostColumn;
            textColumn.HeaderText = "Total Cost";
            textColumn.FillWeight = 30;
            textColumn.Visible = true;
            textColumn.ReadOnly = true;
            textColumn.Width = 50;
            textColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            textColumn.DefaultCellStyle.Format = "C2";
            this.dgvInvoices.Columns.Add(textColumn);

            this._invoices = DataLayer.GetInvoicesDataSet(this.dtpFrom.Value, this.dtpTo.Value);
            this.dgvInvoices.DataSource = this._invoices.Tables[InvoiceDataSet.TableInvoice];
            this.dgvInvoices.Columns[InvoiceDataSet.IdColumn].Width = 0;
            this.dgvInvoices.Columns[InvoiceDataSet.ClientIdColumn].Width = 0;
            this.dgvInvoices.Columns[InvoiceDataSet.RouteIdColumn].Width = 0;
            this.dgvInvoices.Columns[InvoiceDataSet.IdColumn].Visible = false;
            this.dgvInvoices.Columns[InvoiceDataSet.ClientIdColumn].Visible = false;
            this.dgvInvoices.Columns[InvoiceDataSet.RouteIdColumn].Visible = false;
        }

        #endregion
    }
}
