namespace ProjectVIS.PresentationLayer.DesktopApp
{
    partial class PaymentForm
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
            this.boxPaymentAmmount = new System.Windows.Forms.TextBox();
            this.labelPaymentAmmount = new System.Windows.Forms.Label();
            this.buttonPaymentConfirm = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.boxPaymentCSV = new System.Windows.Forms.TextBox();
            this.labelCSV = new System.Windows.Forms.Label();
            this.boxPaymentCardNumber = new System.Windows.Forms.TextBox();
            this.comboPaymentType = new System.Windows.Forms.ComboBox();
            this.labelCardNumber = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.labelDetails = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // boxPaymentAmmount
            // 
            this.boxPaymentAmmount.Location = new System.Drawing.Point(348, 179);
            this.boxPaymentAmmount.Name = "boxPaymentAmmount";
            this.boxPaymentAmmount.ReadOnly = true;
            this.boxPaymentAmmount.Size = new System.Drawing.Size(263, 20);
            this.boxPaymentAmmount.TabIndex = 100;
            // 
            // labelPaymentAmmount
            // 
            this.labelPaymentAmmount.AutoSize = true;
            this.labelPaymentAmmount.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.labelPaymentAmmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelPaymentAmmount.Location = new System.Drawing.Point(195, 179);
            this.labelPaymentAmmount.Name = "labelPaymentAmmount";
            this.labelPaymentAmmount.Size = new System.Drawing.Size(120, 18);
            this.labelPaymentAmmount.TabIndex = 99;
            this.labelPaymentAmmount.Text = "Ammount to pay:";
            // 
            // buttonPaymentConfirm
            // 
            this.buttonPaymentConfirm.Location = new System.Drawing.Point(452, 328);
            this.buttonPaymentConfirm.Name = "buttonPaymentConfirm";
            this.buttonPaymentConfirm.Size = new System.Drawing.Size(159, 30);
            this.buttonPaymentConfirm.TabIndex = 98;
            this.buttonPaymentConfirm.Text = "Confirm";
            this.buttonPaymentConfirm.UseVisualStyleBackColor = true;
            this.buttonPaymentConfirm.Click += new System.EventHandler(this.buttonPaymentConfirm_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label16.Location = new System.Drawing.Point(176, 32);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(90, 24);
            this.label16.TabIndex = 97;
            this.label16.Text = "Payment";
            // 
            // boxPaymentCSV
            // 
            this.boxPaymentCSV.Location = new System.Drawing.Point(348, 143);
            this.boxPaymentCSV.Name = "boxPaymentCSV";
            this.boxPaymentCSV.Size = new System.Drawing.Size(263, 20);
            this.boxPaymentCSV.TabIndex = 95;
            // 
            // labelCSV
            // 
            this.labelCSV.AutoSize = true;
            this.labelCSV.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.labelCSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelCSV.Location = new System.Drawing.Point(195, 143);
            this.labelCSV.Name = "labelCSV";
            this.labelCSV.Size = new System.Drawing.Size(42, 18);
            this.labelCSV.TabIndex = 94;
            this.labelCSV.Text = "CSV:";
            // 
            // boxPaymentCardNumber
            // 
            this.boxPaymentCardNumber.Location = new System.Drawing.Point(348, 108);
            this.boxPaymentCardNumber.Name = "boxPaymentCardNumber";
            this.boxPaymentCardNumber.Size = new System.Drawing.Size(263, 20);
            this.boxPaymentCardNumber.TabIndex = 93;
            // 
            // comboPaymentType
            // 
            this.comboPaymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPaymentType.FormattingEnabled = true;
            this.comboPaymentType.Items.AddRange(new object[] {
            "Account Transfer",
            "Online Payment by Card",
            "In Person"});
            this.comboPaymentType.Location = new System.Drawing.Point(348, 74);
            this.comboPaymentType.Name = "comboPaymentType";
            this.comboPaymentType.Size = new System.Drawing.Size(263, 21);
            this.comboPaymentType.TabIndex = 92;
            this.comboPaymentType.SelectedIndexChanged += new System.EventHandler(this.comboRecordCategory_SelectedIndexChanged);
            // 
            // labelCardNumber
            // 
            this.labelCardNumber.AutoSize = true;
            this.labelCardNumber.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.labelCardNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelCardNumber.Location = new System.Drawing.Point(195, 108);
            this.labelCardNumber.Name = "labelCardNumber";
            this.labelCardNumber.Size = new System.Drawing.Size(98, 18);
            this.labelCardNumber.TabIndex = 90;
            this.labelCardNumber.Text = "Card number:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label14.Location = new System.Drawing.Point(195, 73);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(101, 18);
            this.label14.TabIndex = 91;
            this.label14.Text = "Payment type:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button1.Location = new System.Drawing.Point(180, 59);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(440, 263);
            this.button1.TabIndex = 96;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // labelDetails
            // 
            this.labelDetails.AutoSize = true;
            this.labelDetails.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.labelDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelDetails.Location = new System.Drawing.Point(289, 227);
            this.labelDetails.Name = "labelDetails";
            this.labelDetails.Size = new System.Drawing.Size(240, 72);
            this.labelDetails.TabIndex = 101;
            this.labelDetails.Text = "Payment Details:\r\nAccount number: 123456789 / 1234\r\nVariable symbol: 123456\r\nCons" +
    "tant symbol: 0300";
            // 
            // PaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 383);
            this.Controls.Add(this.labelDetails);
            this.Controls.Add(this.boxPaymentAmmount);
            this.Controls.Add(this.labelPaymentAmmount);
            this.Controls.Add(this.buttonPaymentConfirm);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.boxPaymentCSV);
            this.Controls.Add(this.labelCSV);
            this.Controls.Add(this.boxPaymentCardNumber);
            this.Controls.Add(this.comboPaymentType);
            this.Controls.Add(this.labelCardNumber);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.button1);
            this.Name = "PaymentForm";
            this.Text = "PaymentForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox boxPaymentAmmount;
        private System.Windows.Forms.Label labelPaymentAmmount;
        private System.Windows.Forms.Button buttonPaymentConfirm;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox boxPaymentCSV;
        private System.Windows.Forms.Label labelCSV;
        private System.Windows.Forms.TextBox boxPaymentCardNumber;
        private System.Windows.Forms.ComboBox comboPaymentType;
        private System.Windows.Forms.Label labelCardNumber;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelDetails;
    }
}