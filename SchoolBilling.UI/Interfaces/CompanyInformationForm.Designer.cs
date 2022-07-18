using MetroFramework.Controls;

namespace SchoolBilling.UI.Interfaces
{
    partial class CompanyInformationForm
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
            this.gbDetail = new System.Windows.Forms.GroupBox();
            this.txtInvoiceNumber = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtContactEmail = new MetroFramework.Controls.MetroTextBox();
            this.label12 = new MetroFramework.Controls.MetroLabel();
            this.gbContact = new System.Windows.Forms.GroupBox();
            this.txtContactInformation = new MetroFramework.Controls.MetroTextBox();
            this.label11 = new MetroFramework.Controls.MetroLabel();
            this.txtContactPerson = new MetroFramework.Controls.MetroTextBox();
            this.label10 = new MetroFramework.Controls.MetroLabel();
            this.txtCounty = new MetroFramework.Controls.MetroTextBox();
            this.label9 = new MetroFramework.Controls.MetroLabel();
            this.txtFax = new MetroFramework.Controls.MetroTextBox();
            this.label8 = new MetroFramework.Controls.MetroLabel();
            this.txtPhone = new MetroFramework.Controls.MetroTextBox();
            this.label7 = new MetroFramework.Controls.MetroLabel();
            this.txtCountry = new MetroFramework.Controls.MetroTextBox();
            this.label6 = new MetroFramework.Controls.MetroLabel();
            this.txtZip = new MetroFramework.Controls.MetroTextBox();
            this.label5 = new MetroFramework.Controls.MetroLabel();
            this.txtState = new MetroFramework.Controls.MetroTextBox();
            this.label4 = new MetroFramework.Controls.MetroLabel();
            this.txtCity = new MetroFramework.Controls.MetroTextBox();
            this.label3 = new MetroFramework.Controls.MetroLabel();
            this.txtAddress = new MetroFramework.Controls.MetroTextBox();
            this.label2 = new MetroFramework.Controls.MetroLabel();
            this.txtName = new MetroFramework.Controls.MetroTextBox();
            this.label1 = new MetroFramework.Controls.MetroLabel();
            this.SaveButton = new MetroFramework.Controls.MetroButton();
            this.CancelButton = new MetroFramework.Controls.MetroButton();
            this.gbDetail.SuspendLayout();
            this.gbContact.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDetail
            // 
            this.gbDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDetail.Controls.Add(this.txtInvoiceNumber);
            this.gbDetail.Controls.Add(this.metroLabel1);
            this.gbDetail.Controls.Add(this.txtContactEmail);
            this.gbDetail.Controls.Add(this.label12);
            this.gbDetail.Controls.Add(this.gbContact);
            this.gbDetail.Controls.Add(this.txtCounty);
            this.gbDetail.Controls.Add(this.label9);
            this.gbDetail.Controls.Add(this.txtFax);
            this.gbDetail.Controls.Add(this.label8);
            this.gbDetail.Controls.Add(this.txtPhone);
            this.gbDetail.Controls.Add(this.label7);
            this.gbDetail.Controls.Add(this.txtCountry);
            this.gbDetail.Controls.Add(this.label6);
            this.gbDetail.Controls.Add(this.txtZip);
            this.gbDetail.Controls.Add(this.label5);
            this.gbDetail.Controls.Add(this.txtState);
            this.gbDetail.Controls.Add(this.label4);
            this.gbDetail.Controls.Add(this.txtCity);
            this.gbDetail.Controls.Add(this.label3);
            this.gbDetail.Controls.Add(this.txtAddress);
            this.gbDetail.Controls.Add(this.label2);
            this.gbDetail.Controls.Add(this.txtName);
            this.gbDetail.Controls.Add(this.label1);
            this.gbDetail.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDetail.Location = new System.Drawing.Point(23, 63);
            this.gbDetail.Name = "gbDetail";
            this.gbDetail.Size = new System.Drawing.Size(952, 280);
            this.gbDetail.TabIndex = 0;
            this.gbDetail.TabStop = false;
            // 
            // txtInvoiceNumber
            // 
            this.txtInvoiceNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtInvoiceNumber.CustomButton.Image = null;
            this.txtInvoiceNumber.CustomButton.Location = new System.Drawing.Point(75, 1);
            this.txtInvoiceNumber.CustomButton.Name = "";
            this.txtInvoiceNumber.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtInvoiceNumber.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtInvoiceNumber.CustomButton.TabIndex = 1;
            this.txtInvoiceNumber.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtInvoiceNumber.CustomButton.UseSelectable = true;
            this.txtInvoiceNumber.CustomButton.Visible = false;
            this.txtInvoiceNumber.Lines = new string[0];
            this.txtInvoiceNumber.Location = new System.Drawing.Point(91, 232);
            this.txtInvoiceNumber.MaxLength = 10;
            this.txtInvoiceNumber.Name = "txtInvoiceNumber";
            this.txtInvoiceNumber.PasswordChar = '\0';
            this.txtInvoiceNumber.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtInvoiceNumber.SelectedText = "";
            this.txtInvoiceNumber.SelectionLength = 0;
            this.txtInvoiceNumber.SelectionStart = 0;
            this.txtInvoiceNumber.ShortcutsEnabled = true;
            this.txtInvoiceNumber.Size = new System.Drawing.Size(101, 27);
            this.txtInvoiceNumber.TabIndex = 24;
            this.txtInvoiceNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtInvoiceNumber.UseSelectable = true;
            this.txtInvoiceNumber.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtInvoiceNumber.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel1
            // 
            this.metroLabel1.Location = new System.Drawing.Point(5, 220);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(85, 39);
            this.metroLabel1.TabIndex = 23;
            this.metroLabel1.Text = "Invoice number start";
            this.metroLabel1.WrapToLine = true;
            // 
            // txtContactEmail
            // 
            // 
            // 
            // 
            this.txtContactEmail.CustomButton.Image = null;
            this.txtContactEmail.CustomButton.Location = new System.Drawing.Point(822, 1);
            this.txtContactEmail.CustomButton.Name = "";
            this.txtContactEmail.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtContactEmail.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtContactEmail.CustomButton.TabIndex = 1;
            this.txtContactEmail.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtContactEmail.CustomButton.UseSelectable = true;
            this.txtContactEmail.CustomButton.Visible = false;
            this.txtContactEmail.Lines = new string[0];
            this.txtContactEmail.Location = new System.Drawing.Point(107, 197);
            this.txtContactEmail.MaxLength = 200;
            this.txtContactEmail.Name = "txtContactEmail";
            this.txtContactEmail.PasswordChar = '\0';
            this.txtContactEmail.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtContactEmail.SelectedText = "";
            this.txtContactEmail.SelectionLength = 0;
            this.txtContactEmail.SelectionStart = 0;
            this.txtContactEmail.ShortcutsEnabled = true;
            this.txtContactEmail.Size = new System.Drawing.Size(845, 27);
            this.txtContactEmail.TabIndex = 7;
            this.txtContactEmail.UseSelectable = true;
            this.txtContactEmail.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtContactEmail.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 199);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 19);
            this.label12.TabIndex = 22;
            this.label12.Text = "Email";
            // 
            // gbContact
            // 
            this.gbContact.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbContact.Controls.Add(this.txtContactInformation);
            this.gbContact.Controls.Add(this.label11);
            this.gbContact.Controls.Add(this.txtContactPerson);
            this.gbContact.Controls.Add(this.label10);
            this.gbContact.Location = new System.Drawing.Point(6, 293);
            this.gbContact.Name = "gbContact";
            this.gbContact.Size = new System.Drawing.Size(940, 49);
            this.gbContact.TabIndex = 18;
            this.gbContact.TabStop = false;
            this.gbContact.Text = "Contact Person";
            this.gbContact.Visible = false;
            // 
            // txtContactInformation
            // 
            this.txtContactInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtContactInformation.CustomButton.Image = null;
            this.txtContactInformation.CustomButton.Location = new System.Drawing.Point(322, 1);
            this.txtContactInformation.CustomButton.Name = "";
            this.txtContactInformation.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtContactInformation.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtContactInformation.CustomButton.TabIndex = 1;
            this.txtContactInformation.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtContactInformation.CustomButton.UseSelectable = true;
            this.txtContactInformation.CustomButton.Visible = false;
            this.txtContactInformation.Lines = new string[0];
            this.txtContactInformation.Location = new System.Drawing.Point(586, 28);
            this.txtContactInformation.MaxLength = 200;
            this.txtContactInformation.Name = "txtContactInformation";
            this.txtContactInformation.PasswordChar = '\0';
            this.txtContactInformation.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtContactInformation.SelectedText = "";
            this.txtContactInformation.SelectionLength = 0;
            this.txtContactInformation.SelectionStart = 0;
            this.txtContactInformation.ShortcutsEnabled = true;
            this.txtContactInformation.Size = new System.Drawing.Size(348, 27);
            this.txtContactInformation.TabIndex = 10;
            this.txtContactInformation.UseSelectable = true;
            this.txtContactInformation.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtContactInformation.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(519, 29);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 19);
            this.label11.TabIndex = 19;
            this.label11.Text = "Contact";
            // 
            // txtContactPerson
            // 
            // 
            // 
            // 
            this.txtContactPerson.CustomButton.Image = null;
            this.txtContactPerson.CustomButton.Location = new System.Drawing.Point(387, 1);
            this.txtContactPerson.CustomButton.Name = "";
            this.txtContactPerson.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtContactPerson.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtContactPerson.CustomButton.TabIndex = 1;
            this.txtContactPerson.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtContactPerson.CustomButton.UseSelectable = true;
            this.txtContactPerson.CustomButton.Visible = false;
            this.txtContactPerson.Lines = new string[0];
            this.txtContactPerson.Location = new System.Drawing.Point(85, 26);
            this.txtContactPerson.MaxLength = 200;
            this.txtContactPerson.Name = "txtContactPerson";
            this.txtContactPerson.PasswordChar = '\0';
            this.txtContactPerson.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtContactPerson.SelectedText = "";
            this.txtContactPerson.SelectionLength = 0;
            this.txtContactPerson.SelectionStart = 0;
            this.txtContactPerson.ShortcutsEnabled = true;
            this.txtContactPerson.Size = new System.Drawing.Size(413, 27);
            this.txtContactPerson.TabIndex = 9;
            this.txtContactPerson.UseSelectable = true;
            this.txtContactPerson.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtContactPerson.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 19);
            this.label10.TabIndex = 17;
            this.label10.Text = "Name";
            // 
            // txtCounty
            // 
            // 
            // 
            // 
            this.txtCounty.CustomButton.Image = null;
            this.txtCounty.CustomButton.Location = new System.Drawing.Point(328, 1);
            this.txtCounty.CustomButton.Name = "";
            this.txtCounty.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtCounty.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCounty.CustomButton.TabIndex = 1;
            this.txtCounty.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCounty.CustomButton.UseSelectable = true;
            this.txtCounty.CustomButton.Visible = false;
            this.txtCounty.Lines = new string[0];
            this.txtCounty.Location = new System.Drawing.Point(592, 291);
            this.txtCounty.MaxLength = 200;
            this.txtCounty.Name = "txtCounty";
            this.txtCounty.PasswordChar = '\0';
            this.txtCounty.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCounty.SelectedText = "";
            this.txtCounty.SelectionLength = 0;
            this.txtCounty.SelectionStart = 0;
            this.txtCounty.ShortcutsEnabled = true;
            this.txtCounty.Size = new System.Drawing.Size(354, 27);
            this.txtCounty.TabIndex = 8;
            this.txtCounty.UseSelectable = true;
            this.txtCounty.Visible = false;
            this.txtCounty.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCounty.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(530, 294);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 19);
            this.label9.TabIndex = 16;
            this.label9.Text = "County";
            this.label9.Visible = false;
            // 
            // txtFax
            // 
            // 
            // 
            // 
            this.txtFax.CustomButton.Image = null;
            this.txtFax.CustomButton.Location = new System.Drawing.Point(334, 1);
            this.txtFax.CustomButton.Name = "";
            this.txtFax.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtFax.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtFax.CustomButton.TabIndex = 1;
            this.txtFax.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtFax.CustomButton.UseSelectable = true;
            this.txtFax.CustomButton.Visible = false;
            this.txtFax.Lines = new string[0];
            this.txtFax.Location = new System.Drawing.Point(592, 164);
            this.txtFax.MaxLength = 100;
            this.txtFax.Name = "txtFax";
            this.txtFax.PasswordChar = '\0';
            this.txtFax.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtFax.SelectedText = "";
            this.txtFax.SelectionLength = 0;
            this.txtFax.SelectionStart = 0;
            this.txtFax.ShortcutsEnabled = true;
            this.txtFax.Size = new System.Drawing.Size(360, 27);
            this.txtFax.TabIndex = 6;
            this.txtFax.UseSelectable = true;
            this.txtFax.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtFax.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(530, 167);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 19);
            this.label8.TabIndex = 14;
            this.label8.Text = "Fax";
            // 
            // txtPhone
            // 
            // 
            // 
            // 
            this.txtPhone.CustomButton.Image = null;
            this.txtPhone.CustomButton.Location = new System.Drawing.Point(387, 1);
            this.txtPhone.CustomButton.Name = "";
            this.txtPhone.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtPhone.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPhone.CustomButton.TabIndex = 1;
            this.txtPhone.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPhone.CustomButton.UseSelectable = true;
            this.txtPhone.CustomButton.Visible = false;
            this.txtPhone.Lines = new string[0];
            this.txtPhone.Location = new System.Drawing.Point(107, 164);
            this.txtPhone.MaxLength = 200;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.PasswordChar = '\0';
            this.txtPhone.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPhone.SelectedText = "";
            this.txtPhone.SelectionLength = 0;
            this.txtPhone.SelectionStart = 0;
            this.txtPhone.ShortcutsEnabled = true;
            this.txtPhone.Size = new System.Drawing.Size(397, 27);
            this.txtPhone.TabIndex = 5;
            this.txtPhone.UseSelectable = true;
            this.txtPhone.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPhone.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 167);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 19);
            this.label7.TabIndex = 12;
            this.label7.Text = "Phone";
            // 
            // txtCountry
            // 
            this.txtCountry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtCountry.CustomButton.Image = null;
            this.txtCountry.CustomButton.Location = new System.Drawing.Point(328, 1);
            this.txtCountry.CustomButton.Name = "";
            this.txtCountry.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtCountry.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCountry.CustomButton.TabIndex = 1;
            this.txtCountry.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCountry.CustomButton.UseSelectable = true;
            this.txtCountry.CustomButton.Visible = false;
            this.txtCountry.Lines = new string[0];
            this.txtCountry.Location = new System.Drawing.Point(592, 290);
            this.txtCountry.MaxLength = 100;
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.PasswordChar = '\0';
            this.txtCountry.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCountry.SelectedText = "";
            this.txtCountry.SelectionLength = 0;
            this.txtCountry.SelectionStart = 0;
            this.txtCountry.ShortcutsEnabled = true;
            this.txtCountry.Size = new System.Drawing.Size(354, 27);
            this.txtCountry.TabIndex = 5;
            this.txtCountry.UseSelectable = true;
            this.txtCountry.Visible = false;
            this.txtCountry.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCountry.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(530, 288);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 19);
            this.label6.TabIndex = 10;
            this.label6.Text = "Country";
            this.label6.Visible = false;
            // 
            // txtZip
            // 
            this.txtZip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtZip.CustomButton.Image = null;
            this.txtZip.CustomButton.Location = new System.Drawing.Point(75, 1);
            this.txtZip.CustomButton.Name = "";
            this.txtZip.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtZip.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtZip.CustomButton.TabIndex = 1;
            this.txtZip.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtZip.CustomButton.UseSelectable = true;
            this.txtZip.CustomButton.Visible = false;
            this.txtZip.Lines = new string[0];
            this.txtZip.Location = new System.Drawing.Point(576, 125);
            this.txtZip.MaxLength = 10;
            this.txtZip.Name = "txtZip";
            this.txtZip.PasswordChar = '\0';
            this.txtZip.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtZip.SelectedText = "";
            this.txtZip.SelectionLength = 0;
            this.txtZip.SelectionStart = 0;
            this.txtZip.ShortcutsEnabled = true;
            this.txtZip.Size = new System.Drawing.Size(124, 27);
            this.txtZip.TabIndex = 4;
            this.txtZip.UseSelectable = true;
            this.txtZip.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtZip.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(515, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "Zip";
            // 
            // txtState
            // 
            this.txtState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtState.CustomButton.Image = null;
            this.txtState.CustomButton.Location = new System.Drawing.Point(328, 1);
            this.txtState.CustomButton.Name = "";
            this.txtState.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtState.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtState.CustomButton.TabIndex = 1;
            this.txtState.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtState.CustomButton.UseSelectable = true;
            this.txtState.CustomButton.Visible = false;
            this.txtState.Lines = new string[0];
            this.txtState.Location = new System.Drawing.Point(576, 90);
            this.txtState.MaxLength = 100;
            this.txtState.Name = "txtState";
            this.txtState.PasswordChar = '\0';
            this.txtState.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtState.SelectedText = "";
            this.txtState.SelectionLength = 0;
            this.txtState.SelectionStart = 0;
            this.txtState.ShortcutsEnabled = true;
            this.txtState.Size = new System.Drawing.Size(360, 27);
            this.txtState.TabIndex = 3;
            this.txtState.UseSelectable = true;
            this.txtState.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtState.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(515, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "State";
            // 
            // txtCity
            // 
            this.txtCity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtCity.CustomButton.Image = null;
            this.txtCity.CustomButton.Location = new System.Drawing.Point(328, 1);
            this.txtCity.CustomButton.Name = "";
            this.txtCity.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtCity.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCity.CustomButton.TabIndex = 1;
            this.txtCity.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCity.CustomButton.UseSelectable = true;
            this.txtCity.CustomButton.Visible = false;
            this.txtCity.Lines = new string[0];
            this.txtCity.Location = new System.Drawing.Point(576, 57);
            this.txtCity.MaxLength = 100;
            this.txtCity.Name = "txtCity";
            this.txtCity.PasswordChar = '\0';
            this.txtCity.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCity.SelectedText = "";
            this.txtCity.SelectionLength = 0;
            this.txtCity.SelectionStart = 0;
            this.txtCity.ShortcutsEnabled = true;
            this.txtCity.Size = new System.Drawing.Size(360, 27);
            this.txtCity.TabIndex = 2;
            this.txtCity.UseSelectable = true;
            this.txtCity.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCity.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(515, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "City";
            // 
            // txtAddress
            // 
            // 
            // 
            // 
            this.txtAddress.CustomButton.Image = null;
            this.txtAddress.CustomButton.Location = new System.Drawing.Point(313, 1);
            this.txtAddress.CustomButton.Name = "";
            this.txtAddress.CustomButton.Size = new System.Drawing.Size(99, 99);
            this.txtAddress.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtAddress.CustomButton.TabIndex = 1;
            this.txtAddress.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtAddress.CustomButton.UseSelectable = true;
            this.txtAddress.CustomButton.Visible = false;
            this.txtAddress.Lines = new string[0];
            this.txtAddress.Location = new System.Drawing.Point(107, 57);
            this.txtAddress.MaxLength = 500;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.PasswordChar = '\0';
            this.txtAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAddress.SelectedText = "";
            this.txtAddress.SelectionLength = 0;
            this.txtAddress.SelectionStart = 0;
            this.txtAddress.ShortcutsEnabled = true;
            this.txtAddress.Size = new System.Drawing.Size(397, 101);
            this.txtAddress.TabIndex = 1;
            this.txtAddress.UseSelectable = true;
            this.txtAddress.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtAddress.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Address";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtName.CustomButton.Image = null;
            this.txtName.CustomButton.Location = new System.Drawing.Point(829, 1);
            this.txtName.CustomButton.Name = "";
            this.txtName.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtName.CustomButton.TabIndex = 1;
            this.txtName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtName.CustomButton.UseSelectable = true;
            this.txtName.CustomButton.Visible = false;
            this.txtName.Lines = new string[0];
            this.txtName.Location = new System.Drawing.Point(107, 24);
            this.txtName.MaxLength = 200;
            this.txtName.Name = "txtName";
            this.txtName.PasswordChar = '\0';
            this.txtName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtName.SelectedText = "";
            this.txtName.SelectionLength = 0;
            this.txtName.SelectionStart = 0;
            this.txtName.ShortcutsEnabled = true;
            this.txtName.Size = new System.Drawing.Size(829, 27);
            this.txtName.TabIndex = 0;
            this.txtName.UseSelectable = true;
            this.txtName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.SaveButton.Location = new System.Drawing.Point(796, 349);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(86, 42);
            this.SaveButton.TabIndex = 8;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseSelectable = true;
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.CancelButton.Location = new System.Drawing.Point(889, 349);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(86, 42);
            this.CancelButton.TabIndex = 9;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseSelectable = true;
            // 
            // CompanyInformationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 436);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.gbDetail);
            this.MaximizeBox = false;
            this.Name = "CompanyInformationForm";
            this.Text = "Company Information";
            this.gbDetail.ResumeLayout(false);
            this.gbDetail.PerformLayout();
            this.gbContact.ResumeLayout(false);
            this.gbContact.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDetail;
        private System.Windows.Forms.GroupBox gbContact;
        private MetroTextBox txtContactInformation;
        private MetroLabel label11;
        private MetroTextBox txtContactPerson;
        private MetroLabel label10;
        private MetroTextBox txtCounty;
        private MetroLabel label9;
        private MetroTextBox txtFax;
        private MetroLabel label8;
        private MetroTextBox txtPhone;
        private MetroLabel label7;
        private MetroTextBox txtCountry;
        private MetroLabel label6;
        private MetroTextBox txtZip;
        private MetroLabel label5;
        private MetroTextBox txtState;
        private MetroLabel label4;
        private MetroTextBox txtCity;
        private MetroLabel label3;
        private MetroTextBox txtAddress;
        private MetroLabel label2;
        private MetroTextBox txtName;
        private MetroLabel label1;
        private MetroButton SaveButton;
        private MetroButton CancelButton;
        private MetroTextBox txtContactEmail;
        private MetroLabel label12;
        private MetroTextBox txtInvoiceNumber;
        private MetroLabel metroLabel1;
    }
}