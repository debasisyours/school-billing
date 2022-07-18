namespace SchoolBilling.UI.Interfaces
{
    partial class RegistrationForm
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
            this.picAbout = new System.Windows.Forms.PictureBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.OkButton = new System.Windows.Forms.Button();
            this.lblRequest = new System.Windows.Forms.Label();
            this.txtRequestEmail = new System.Windows.Forms.TextBox();
            this.RequestButton = new System.Windows.Forms.Button();
            this.lblActivate = new System.Windows.Forms.Label();
            this.txtActivationCode = new System.Windows.Forms.TextBox();
            this.RegisterButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picAbout)).BeginInit();
            this.SuspendLayout();
            // 
            // picAbout
            // 
            this.picAbout.Image = global::SchoolBilling.UI.Properties.Resources.about;
            this.picAbout.Location = new System.Drawing.Point(25, 72);
            this.picAbout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.picAbout.Name = "picAbout";
            this.picAbout.Size = new System.Drawing.Size(293, 172);
            this.picAbout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picAbout.TabIndex = 0;
            this.picAbout.TabStop = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(344, 75);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(44, 16);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "label1";
            // 
            // OkButton
            // 
            this.OkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OkButton.Location = new System.Drawing.Point(542, 267);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(95, 38);
            this.OkButton.TabIndex = 2;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            // 
            // lblRequest
            // 
            this.lblRequest.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequest.Location = new System.Drawing.Point(344, 112);
            this.lblRequest.Name = "lblRequest";
            this.lblRequest.Size = new System.Drawing.Size(293, 34);
            this.lblRequest.TabIndex = 4;
            this.lblRequest.Text = "To activate, please send license request email (on behalf of)";
            // 
            // txtRequestEmail
            // 
            this.txtRequestEmail.Location = new System.Drawing.Point(348, 149);
            this.txtRequestEmail.Name = "txtRequestEmail";
            this.txtRequestEmail.Size = new System.Drawing.Size(174, 26);
            this.txtRequestEmail.TabIndex = 5;
            // 
            // RequestButton
            // 
            this.RequestButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RequestButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RequestButton.Location = new System.Drawing.Point(528, 149);
            this.RequestButton.Name = "RequestButton";
            this.RequestButton.Size = new System.Drawing.Size(95, 26);
            this.RequestButton.TabIndex = 6;
            this.RequestButton.Text = "Request";
            this.RequestButton.UseVisualStyleBackColor = true;
            // 
            // lblActivate
            // 
            this.lblActivate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActivate.Location = new System.Drawing.Point(344, 178);
            this.lblActivate.Name = "lblActivate";
            this.lblActivate.Size = new System.Drawing.Size(293, 34);
            this.lblActivate.TabIndex = 7;
            this.lblActivate.Text = "If you already have a product key, please mention here";
            // 
            // txtActivationCode
            // 
            this.txtActivationCode.Location = new System.Drawing.Point(347, 215);
            this.txtActivationCode.Name = "txtActivationCode";
            this.txtActivationCode.Size = new System.Drawing.Size(174, 26);
            this.txtActivationCode.TabIndex = 8;
            // 
            // RegisterButton
            // 
            this.RegisterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RegisterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterButton.Location = new System.Drawing.Point(528, 215);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(95, 26);
            this.RegisterButton.TabIndex = 9;
            this.RegisterButton.Text = "Register";
            this.RegisterButton.UseVisualStyleBackColor = true;
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 322);
            this.Controls.Add(this.RegisterButton);
            this.Controls.Add(this.txtActivationCode);
            this.Controls.Add(this.lblActivate);
            this.Controls.Add(this.RequestButton);
            this.Controls.Add(this.txtRequestEmail);
            this.Controls.Add(this.lblRequest);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.picAbout);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "RegistrationForm";
            this.Padding = new System.Windows.Forms.Padding(30, 92, 30, 31);
            this.Text = "Product Registration";
            ((System.ComponentModel.ISupportInitialize)(this.picAbout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picAbout;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Label lblRequest;
        private System.Windows.Forms.TextBox txtRequestEmail;
        private System.Windows.Forms.Button RequestButton;
        private System.Windows.Forms.Label lblActivate;
        private System.Windows.Forms.TextBox txtActivationCode;
        private System.Windows.Forms.Button RegisterButton;
    }
}