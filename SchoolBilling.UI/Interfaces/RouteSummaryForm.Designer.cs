namespace SchoolBilling.UI.Interfaces
{
    partial class RouteSummaryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.filterGroup = new System.Windows.Forms.GroupBox();
            this.detailsGroup = new System.Windows.Forms.GroupBox();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.cboRoute = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.ShowButton = new System.Windows.Forms.Button();
            this.ExportButton = new System.Windows.Forms.Button();
            this.txtExportPath = new System.Windows.Forms.TextBox();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.filterGroup.SuspendLayout();
            this.detailsGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // filterGroup
            // 
            this.filterGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filterGroup.Controls.Add(this.ShowButton);
            this.filterGroup.Controls.Add(this.dtpToDate);
            this.filterGroup.Controls.Add(this.label3);
            this.filterGroup.Controls.Add(this.dtpFromDate);
            this.filterGroup.Controls.Add(this.label2);
            this.filterGroup.Controls.Add(this.label1);
            this.filterGroup.Controls.Add(this.cboRoute);
            this.filterGroup.Location = new System.Drawing.Point(31, 64);
            this.filterGroup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.filterGroup.Name = "filterGroup";
            this.filterGroup.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.filterGroup.Size = new System.Drawing.Size(1148, 100);
            this.filterGroup.TabIndex = 0;
            this.filterGroup.TabStop = false;
            this.filterGroup.Text = "Report Filter(s)";
            // 
            // detailsGroup
            // 
            this.detailsGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.detailsGroup.Controls.Add(this.dgvDetail);
            this.detailsGroup.Location = new System.Drawing.Point(31, 172);
            this.detailsGroup.Margin = new System.Windows.Forms.Padding(4);
            this.detailsGroup.Name = "detailsGroup";
            this.detailsGroup.Padding = new System.Windows.Forms.Padding(4);
            this.detailsGroup.Size = new System.Drawing.Size(1148, 438);
            this.detailsGroup.TabIndex = 1;
            this.detailsGroup.TabStop = false;
            this.detailsGroup.Text = "Route Summary";
            // 
            // dgvDetail
            // 
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetail.Location = new System.Drawing.Point(4, 24);
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.Size = new System.Drawing.Size(1140, 410);
            this.dgvDetail.TabIndex = 0;
            // 
            // OkButton
            // 
            this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OkButton.Location = new System.Drawing.Point(949, 617);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(110, 41);
            this.OkButton.TabIndex = 5;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.Location = new System.Drawing.Point(1065, 617);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(110, 41);
            this.CancelButton.TabIndex = 6;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // cboRoute
            // 
            this.cboRoute.FormattingEnabled = true;
            this.cboRoute.Location = new System.Drawing.Point(128, 40);
            this.cboRoute.Name = "cboRoute";
            this.cboRoute.Size = new System.Drawing.Size(295, 27);
            this.cboRoute.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select route";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(485, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "From date";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(565, 39);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(140, 27);
            this.dtpFromDate.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(738, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "To date";
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(801, 39);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(140, 27);
            this.dtpToDate.TabIndex = 3;
            // 
            // ShowButton
            // 
            this.ShowButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ShowButton.Location = new System.Drawing.Point(991, 30);
            this.ShowButton.Name = "ShowButton";
            this.ShowButton.Size = new System.Drawing.Size(149, 41);
            this.ShowButton.TabIndex = 4;
            this.ShowButton.Text = "Show";
            this.ShowButton.UseVisualStyleBackColor = true;
            // 
            // ExportButton
            // 
            this.ExportButton.Location = new System.Drawing.Point(35, 617);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(120, 41);
            this.ExportButton.TabIndex = 7;
            this.ExportButton.Text = "Export (Excel)";
            this.ExportButton.UseVisualStyleBackColor = true;
            // 
            // txtExportPath
            // 
            this.txtExportPath.Location = new System.Drawing.Point(161, 625);
            this.txtExportPath.Name = "txtExportPath";
            this.txtExportPath.Size = new System.Drawing.Size(357, 27);
            this.txtExportPath.TabIndex = 8;
            // 
            // BrowseButton
            // 
            this.BrowseButton.Location = new System.Drawing.Point(524, 617);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(110, 41);
            this.BrowseButton.TabIndex = 9;
            this.BrowseButton.Text = "Browse";
            this.BrowseButton.UseVisualStyleBackColor = true;
            // 
            // RouteSummaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1225, 683);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.txtExportPath);
            this.Controls.Add(this.ExportButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.detailsGroup);
            this.Controls.Add(this.filterGroup);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "RouteSummaryForm";
            this.Padding = new System.Windows.Forms.Padding(27, 88, 27, 29);
            this.Text = "Route Summary Report";
            this.filterGroup.ResumeLayout(false);
            this.filterGroup.PerformLayout();
            this.detailsGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox filterGroup;
        private System.Windows.Forms.GroupBox detailsGroup;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button ShowButton;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboRoute;
        private System.Windows.Forms.Button ExportButton;
        private System.Windows.Forms.TextBox txtExportPath;
        private System.Windows.Forms.Button BrowseButton;
    }
}