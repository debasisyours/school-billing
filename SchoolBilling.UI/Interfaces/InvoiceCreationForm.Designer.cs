namespace SchoolBilling.UI.Interfaces
{
    partial class InvoiceCreationForm
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
            this.gbDetails = new System.Windows.Forms.GroupBox();
            this.txtInvoiceNumber = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.mtbNotes = new System.Windows.Forms.MaskedTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCovidDayCount = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTotalCost = new System.Windows.Forms.TextBox();
            this.txtDayCount = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPerdiem = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAidCost = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRouteCost = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpInvoiceDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cboClient = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboRoute = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.gbDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDetails
            // 
            this.gbDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDetails.Controls.Add(this.txtInvoiceNumber);
            this.gbDetails.Controls.Add(this.label13);
            this.gbDetails.Controls.Add(this.mtbNotes);
            this.gbDetails.Controls.Add(this.label12);
            this.gbDetails.Controls.Add(this.txtCovidDayCount);
            this.gbDetails.Controls.Add(this.label11);
            this.gbDetails.Controls.Add(this.txtTotalCost);
            this.gbDetails.Controls.Add(this.txtDayCount);
            this.gbDetails.Controls.Add(this.label10);
            this.gbDetails.Controls.Add(this.label9);
            this.gbDetails.Controls.Add(this.txtPerdiem);
            this.gbDetails.Controls.Add(this.label8);
            this.gbDetails.Controls.Add(this.txtAidCost);
            this.gbDetails.Controls.Add(this.label7);
            this.gbDetails.Controls.Add(this.txtRouteCost);
            this.gbDetails.Controls.Add(this.label6);
            this.gbDetails.Controls.Add(this.dtpEndDate);
            this.gbDetails.Controls.Add(this.label5);
            this.gbDetails.Controls.Add(this.dtpStartDate);
            this.gbDetails.Controls.Add(this.label4);
            this.gbDetails.Controls.Add(this.dtpInvoiceDate);
            this.gbDetails.Controls.Add(this.label3);
            this.gbDetails.Controls.Add(this.cboClient);
            this.gbDetails.Controls.Add(this.label2);
            this.gbDetails.Controls.Add(this.cboRoute);
            this.gbDetails.Controls.Add(this.label1);
            this.gbDetails.Location = new System.Drawing.Point(24, 57);
            this.gbDetails.Name = "gbDetails";
            this.gbDetails.Size = new System.Drawing.Size(671, 397);
            this.gbDetails.TabIndex = 0;
            this.gbDetails.TabStop = false;
            // 
            // txtInvoiceNumber
            // 
            this.txtInvoiceNumber.Location = new System.Drawing.Point(146, 20);
            this.txtInvoiceNumber.Name = "txtInvoiceNumber";
            this.txtInvoiceNumber.Size = new System.Drawing.Size(169, 27);
            this.txtInvoiceNumber.TabIndex = 25;
            this.txtInvoiceNumber.Tag = "Route cost";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 23);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(110, 19);
            this.label13.TabIndex = 24;
            this.label13.Text = "Invoice Number";
            // 
            // mtbNotes
            // 
            this.mtbNotes.Location = new System.Drawing.Point(146, 342);
            this.mtbNotes.Mask = "(00-00)-(00-00)";
            this.mtbNotes.Name = "mtbNotes";
            this.mtbNotes.Size = new System.Drawing.Size(169, 27);
            this.mtbNotes.TabIndex = 12;
            this.mtbNotes.ValidatingType = typeof(System.DateTime);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 345);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(116, 19);
            this.label12.TabIndex = 22;
            this.label12.Text = "Covid Day Notes";
            // 
            // txtCovidDayCount
            // 
            this.txtCovidDayCount.Location = new System.Drawing.Point(146, 305);
            this.txtCovidDayCount.Name = "txtCovidDayCount";
            this.txtCovidDayCount.Size = new System.Drawing.Size(169, 27);
            this.txtCovidDayCount.TabIndex = 11;
            this.txtCovidDayCount.Tag = "Covid day count";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 309);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(116, 19);
            this.label11.TabIndex = 20;
            this.label11.Text = "Covid Day Count";
            // 
            // txtTotalCost
            // 
            this.txtTotalCost.Location = new System.Drawing.Point(146, 269);
            this.txtTotalCost.Name = "txtTotalCost";
            this.txtTotalCost.Size = new System.Drawing.Size(169, 27);
            this.txtTotalCost.TabIndex = 10;
            this.txtTotalCost.Tag = "Total cost";
            // 
            // txtDayCount
            // 
            this.txtDayCount.Location = new System.Drawing.Point(477, 233);
            this.txtDayCount.Name = "txtDayCount";
            this.txtDayCount.Size = new System.Drawing.Size(169, 27);
            this.txtDayCount.TabIndex = 9;
            this.txtDayCount.Tag = "Day count";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(397, 237);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 19);
            this.label10.TabIndex = 17;
            this.label10.Text = "Day Count";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 273);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 19);
            this.label9.TabIndex = 16;
            this.label9.Text = "Total Cost";
            // 
            // txtPerdiem
            // 
            this.txtPerdiem.Location = new System.Drawing.Point(146, 233);
            this.txtPerdiem.Name = "txtPerdiem";
            this.txtPerdiem.Size = new System.Drawing.Size(169, 27);
            this.txtPerdiem.TabIndex = 8;
            this.txtPerdiem.Tag = "Per diem";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 237);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 19);
            this.label8.TabIndex = 14;
            this.label8.Text = "Per Diem";
            // 
            // txtAidCost
            // 
            this.txtAidCost.Location = new System.Drawing.Point(477, 197);
            this.txtAidCost.Name = "txtAidCost";
            this.txtAidCost.Size = new System.Drawing.Size(169, 27);
            this.txtAidCost.TabIndex = 7;
            this.txtAidCost.Tag = "Aid cost";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(397, 201);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 19);
            this.label7.TabIndex = 12;
            this.label7.Text = "Aide Cost";
            // 
            // txtRouteCost
            // 
            this.txtRouteCost.Location = new System.Drawing.Point(146, 197);
            this.txtRouteCost.Name = "txtRouteCost";
            this.txtRouteCost.Size = new System.Drawing.Size(169, 27);
            this.txtRouteCost.TabIndex = 6;
            this.txtRouteCost.Tag = "Route cost";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 201);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 19);
            this.label6.TabIndex = 10;
            this.label6.Text = "Route Cost";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(477, 161);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(169, 27);
            this.dtpEndDate.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(397, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "End Date";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(146, 161);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(169, 27);
            this.dtpStartDate.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "Start Date";
            // 
            // dtpInvoiceDate
            // 
            this.dtpInvoiceDate.Location = new System.Drawing.Point(146, 125);
            this.dtpInvoiceDate.Name = "dtpInvoiceDate";
            this.dtpInvoiceDate.Size = new System.Drawing.Size(500, 27);
            this.dtpInvoiceDate.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Invoice Date";
            // 
            // cboClient
            // 
            this.cboClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClient.FormattingEnabled = true;
            this.cboClient.Location = new System.Drawing.Point(146, 89);
            this.cboClient.Name = "cboClient";
            this.cboClient.Size = new System.Drawing.Size(500, 27);
            this.cboClient.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Select Client";
            // 
            // cboRoute
            // 
            this.cboRoute.FormattingEnabled = true;
            this.cboRoute.Location = new System.Drawing.Point(146, 53);
            this.cboRoute.Name = "cboRoute";
            this.cboRoute.Size = new System.Drawing.Size(500, 27);
            this.cboRoute.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Route";
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveButton.Location = new System.Drawing.Point(507, 462);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(91, 43);
            this.SaveButton.TabIndex = 13;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.Location = new System.Drawing.Point(604, 462);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(91, 43);
            this.CloseButton.TabIndex = 14;
            this.CloseButton.Text = "Cancel";
            this.CloseButton.UseVisualStyleBackColor = true;
            // 
            // InvoiceCreationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 523);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.gbDetails);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "InvoiceCreationForm";
            this.Padding = new System.Windows.Forms.Padding(27, 88, 27, 29);
            this.Text = "Invoice Details";
            this.gbDetails.ResumeLayout(false);
            this.gbDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDetails;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpInvoiceDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboClient;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboRoute;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCovidDayCount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTotalCost;
        private System.Windows.Forms.TextBox txtDayCount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPerdiem;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtAidCost;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRouteCost;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.MaskedTextBox mtbNotes;
        private System.Windows.Forms.TextBox txtInvoiceNumber;
        private System.Windows.Forms.Label label13;
    }
}