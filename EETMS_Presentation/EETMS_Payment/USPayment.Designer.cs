namespace EETMS_Presentation.EETMS_Payment
{
    partial class USPayment
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(USPayment));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GGPanelPaymentAndTransactions = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalRevenue = new System.Windows.Forms.Label();
            this.guna2CircleButton1 = new Guna.UI2.WinForms.Guna2CircleButton();
            this.GGPanelDataGridViewEvents = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.GTextBoxSearchThePayment = new Guna.UI2.WinForms.Guna2TextBox();
            this.GDataGridViewCategoriesInformation = new Guna.UI2.WinForms.Guna2DataGridView();
            this.PaymentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookingID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaidAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentMethod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GGPanelPaymentAndTransactions.SuspendLayout();
            this.GGPanelDataGridViewEvents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GDataGridViewCategoriesInformation)).BeginInit();
            this.SuspendLayout();
            // 
            // GGPanelPaymentAndTransactions
            // 
            this.GGPanelPaymentAndTransactions.BackColor = System.Drawing.Color.Transparent;
            this.GGPanelPaymentAndTransactions.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(236)))), ((int)(((byte)(243)))));
            this.GGPanelPaymentAndTransactions.BorderRadius = 10;
            this.GGPanelPaymentAndTransactions.BorderThickness = 1;
            this.GGPanelPaymentAndTransactions.Controls.Add(this.guna2CircleButton1);
            this.GGPanelPaymentAndTransactions.Controls.Add(this.lblTotalRevenue);
            this.GGPanelPaymentAndTransactions.Controls.Add(this.label2);
            this.GGPanelPaymentAndTransactions.FillColor = System.Drawing.Color.White;
            this.GGPanelPaymentAndTransactions.FillColor2 = System.Drawing.Color.White;
            this.GGPanelPaymentAndTransactions.Location = new System.Drawing.Point(25, 106);
            this.GGPanelPaymentAndTransactions.Name = "GGPanelPaymentAndTransactions";
            this.GGPanelPaymentAndTransactions.Size = new System.Drawing.Size(1350, 157);
            this.GGPanelPaymentAndTransactions.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Variable Display", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(439, 44);
            this.label1.TabIndex = 4;
            this.label1.Text = "Payments and Transactions";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(120)))), ((int)(((byte)(143)))));
            this.label2.Location = new System.Drawing.Point(23, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 27);
            this.label2.TabIndex = 1;
            this.label2.Text = "TOTAL REVENUE";
            // 
            // lblTotalRevenue
            // 
            this.lblTotalRevenue.AutoSize = true;
            this.lblTotalRevenue.Font = new System.Drawing.Font("Segoe UI Variable Display", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRevenue.Location = new System.Drawing.Point(21, 71);
            this.lblTotalRevenue.Name = "lblTotalRevenue";
            this.lblTotalRevenue.Size = new System.Drawing.Size(43, 49);
            this.lblTotalRevenue.TabIndex = 4;
            this.lblTotalRevenue.Text = "0";
            // 
            // guna2CircleButton1
            // 
            this.guna2CircleButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2CircleButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2CircleButton1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(243)))), ((int)(((byte)(253)))));
            this.guna2CircleButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2CircleButton1.ForeColor = System.Drawing.Color.White;
            this.guna2CircleButton1.Image = ((System.Drawing.Image)(resources.GetObject("guna2CircleButton1.Image")));
            this.guna2CircleButton1.ImageSize = new System.Drawing.Size(27, 27);
            this.guna2CircleButton1.Location = new System.Drawing.Point(1248, 44);
            this.guna2CircleButton1.Name = "guna2CircleButton1";
            this.guna2CircleButton1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleButton1.Size = new System.Drawing.Size(71, 71);
            this.guna2CircleButton1.TabIndex = 5;
            // 
            // GGPanelDataGridViewEvents
            // 
            this.GGPanelDataGridViewEvents.BackColor = System.Drawing.Color.Transparent;
            this.GGPanelDataGridViewEvents.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.GGPanelDataGridViewEvents.BorderRadius = 10;
            this.GGPanelDataGridViewEvents.BorderThickness = 1;
            this.GGPanelDataGridViewEvents.Controls.Add(this.GTextBoxSearchThePayment);
            this.GGPanelDataGridViewEvents.Controls.Add(this.GDataGridViewCategoriesInformation);
            this.GGPanelDataGridViewEvents.FillColor = System.Drawing.Color.White;
            this.GGPanelDataGridViewEvents.FillColor2 = System.Drawing.Color.White;
            this.GGPanelDataGridViewEvents.Location = new System.Drawing.Point(25, 314);
            this.GGPanelDataGridViewEvents.Name = "GGPanelDataGridViewEvents";
            this.GGPanelDataGridViewEvents.Size = new System.Drawing.Size(1350, 569);
            this.GGPanelDataGridViewEvents.TabIndex = 9;
            // 
            // GTextBoxSearchThePayment
            // 
            this.GTextBoxSearchThePayment.Animated = true;
            this.GTextBoxSearchThePayment.BorderRadius = 8;
            this.GTextBoxSearchThePayment.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.GTextBoxSearchThePayment.DefaultText = "";
            this.GTextBoxSearchThePayment.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.GTextBoxSearchThePayment.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.GTextBoxSearchThePayment.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GTextBoxSearchThePayment.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GTextBoxSearchThePayment.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GTextBoxSearchThePayment.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GTextBoxSearchThePayment.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GTextBoxSearchThePayment.IconLeft = ((System.Drawing.Image)(resources.GetObject("GTextBoxSearchThePayment.IconLeft")));
            this.GTextBoxSearchThePayment.IconLeftOffset = new System.Drawing.Point(10, 0);
            this.GTextBoxSearchThePayment.Location = new System.Drawing.Point(29, 39);
            this.GTextBoxSearchThePayment.Name = "GTextBoxSearchThePayment";
            this.GTextBoxSearchThePayment.PlaceholderText = "Search by Name Category ....";
            this.GTextBoxSearchThePayment.SelectedText = "";
            this.GTextBoxSearchThePayment.Size = new System.Drawing.Size(502, 39);
            this.GTextBoxSearchThePayment.TabIndex = 3;
            this.GTextBoxSearchThePayment.TextChanged += new System.EventHandler(this.GTextBoxSearchTheCategory_TextChanged);
            // 
            // GDataGridViewCategoriesInformation
            // 
            this.GDataGridViewCategoriesInformation.AllowUserToAddRows = false;
            this.GDataGridViewCategoriesInformation.AllowUserToDeleteRows = false;
            this.GDataGridViewCategoriesInformation.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.GDataGridViewCategoriesInformation.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.GDataGridViewCategoriesInformation.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI Variable Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GDataGridViewCategoriesInformation.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.GDataGridViewCategoriesInformation.ColumnHeadersHeight = 66;
            this.GDataGridViewCategoriesInformation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.GDataGridViewCategoriesInformation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PaymentID,
            this.BookingID,
            this.TotalAmount,
            this.PaidAmount,
            this.PaymentMethod,
            this.PaymentDate,
            this.Status});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GDataGridViewCategoriesInformation.DefaultCellStyle = dataGridViewCellStyle7;
            this.GDataGridViewCategoriesInformation.GridColor = System.Drawing.Color.White;
            this.GDataGridViewCategoriesInformation.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.GDataGridViewCategoriesInformation.Location = new System.Drawing.Point(3, 105);
            this.GDataGridViewCategoriesInformation.MultiSelect = false;
            this.GDataGridViewCategoriesInformation.Name = "GDataGridViewCategoriesInformation";
            this.GDataGridViewCategoriesInformation.ReadOnly = true;
            this.GDataGridViewCategoriesInformation.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GDataGridViewCategoriesInformation.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.GDataGridViewCategoriesInformation.RowHeadersVisible = false;
            this.GDataGridViewCategoriesInformation.RowTemplate.Height = 67;
            this.GDataGridViewCategoriesInformation.Size = new System.Drawing.Size(1344, 461);
            this.GDataGridViewCategoriesInformation.TabIndex = 0;
            this.GDataGridViewCategoriesInformation.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.GDataGridViewCategoriesInformation.ThemeStyle.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GDataGridViewCategoriesInformation.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.GDataGridViewCategoriesInformation.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.GDataGridViewCategoriesInformation.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.GDataGridViewCategoriesInformation.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.GDataGridViewCategoriesInformation.ThemeStyle.GridColor = System.Drawing.Color.White;
            this.GDataGridViewCategoriesInformation.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.GDataGridViewCategoriesInformation.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.GDataGridViewCategoriesInformation.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Variable Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GDataGridViewCategoriesInformation.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            this.GDataGridViewCategoriesInformation.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.GDataGridViewCategoriesInformation.ThemeStyle.HeaderStyle.Height = 66;
            this.GDataGridViewCategoriesInformation.ThemeStyle.ReadOnly = true;
            this.GDataGridViewCategoriesInformation.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.GDataGridViewCategoriesInformation.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.GDataGridViewCategoriesInformation.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GDataGridViewCategoriesInformation.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.GDataGridViewCategoriesInformation.ThemeStyle.RowsStyle.Height = 67;
            this.GDataGridViewCategoriesInformation.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.GDataGridViewCategoriesInformation.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            // 
            // PaymentID
            // 
            this.PaymentID.HeaderText = "PaymentID";
            this.PaymentID.Name = "PaymentID";
            this.PaymentID.ReadOnly = true;
            this.PaymentID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PaymentID.Visible = false;
            // 
            // BookingID
            // 
            this.BookingID.FillWeight = 24.56854F;
            this.BookingID.HeaderText = "BOOKING ID";
            this.BookingID.Name = "BookingID";
            this.BookingID.ReadOnly = true;
            // 
            // TotalAmount
            // 
            this.TotalAmount.FillWeight = 59.08629F;
            this.TotalAmount.HeaderText = "TOTAL AMOUNT";
            this.TotalAmount.Name = "TotalAmount";
            this.TotalAmount.ReadOnly = true;
            // 
            // PaidAmount
            // 
            this.PaidAmount.FillWeight = 59.08629F;
            this.PaidAmount.HeaderText = "PAID AMOUNT";
            this.PaidAmount.Name = "PaidAmount";
            this.PaidAmount.ReadOnly = true;
            // 
            // PaymentMethod
            // 
            this.PaymentMethod.FillWeight = 59.08629F;
            this.PaymentMethod.HeaderText = "PAYMENT METHOD";
            this.PaymentMethod.Name = "PaymentMethod";
            this.PaymentMethod.ReadOnly = true;
            // 
            // PaymentDate
            // 
            this.PaymentDate.FillWeight = 89.0863F;
            this.PaymentDate.HeaderText = "PAYMENT DATE";
            this.PaymentDate.Name = "PaymentDate";
            this.PaymentDate.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.FillWeight = 59.08629F;
            this.Status.HeaderText = "STATUS";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // USPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(248)))));
            this.Controls.Add(this.GGPanelDataGridViewEvents);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GGPanelPaymentAndTransactions);
            this.Name = "USPayment";
            this.Size = new System.Drawing.Size(1419, 935);
            this.Load += new System.EventHandler(this.USPayment_Load);
            this.GGPanelPaymentAndTransactions.ResumeLayout(false);
            this.GGPanelPaymentAndTransactions.PerformLayout();
            this.GGPanelDataGridViewEvents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GDataGridViewCategoriesInformation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel GGPanelPaymentAndTransactions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalRevenue;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButton1;
        private Guna.UI2.WinForms.Guna2GradientPanel GGPanelDataGridViewEvents;
        private Guna.UI2.WinForms.Guna2TextBox GTextBoxSearchThePayment;
        private Guna.UI2.WinForms.Guna2DataGridView GDataGridViewCategoriesInformation;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookingID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaidAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentMethod;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
    }
}
