namespace EETMS_Presentation.EETMS_Customers
{
    partial class USCustomers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(USCustomers));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PanelHeaderEvents = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.GGButtonCreateNewEvent = new Guna.UI2.WinForms.Guna2GradientButton();
            this.GTextBoxSearchTheEvent = new Guna.UI2.WinForms.Guna2TextBox();
            this.GGPanelDataGridViewEvents = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.GDataGridViewCustomerInformation = new Guna.UI2.WinForms.Guna2DataGridView();
            this.CustomerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmailCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhoneCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NationalID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PanelHeaderEvents.SuspendLayout();
            this.GGPanelDataGridViewEvents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GDataGridViewCustomerInformation)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelHeaderEvents
            // 
            this.PanelHeaderEvents.Controls.Add(this.GTextBoxSearchTheEvent);
            this.PanelHeaderEvents.Controls.Add(this.GGButtonCreateNewEvent);
            this.PanelHeaderEvents.Controls.Add(this.label2);
            this.PanelHeaderEvents.Controls.Add(this.label3);
            this.PanelHeaderEvents.Location = new System.Drawing.Point(27, 34);
            this.PanelHeaderEvents.Name = "PanelHeaderEvents";
            this.PanelHeaderEvents.Size = new System.Drawing.Size(1361, 203);
            this.PanelHeaderEvents.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Variable Text", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            this.label2.Location = new System.Drawing.Point(10, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(287, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Manage your event attendees, and their history.\n";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Variable Display", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(400, 53);
            this.label3.TabIndex = 0;
            this.label3.Text = "Customer Directory";
            // 
            // GGButtonCreateNewEvent
            // 
            this.GGButtonCreateNewEvent.Animated = true;
            this.GGButtonCreateNewEvent.AnimatedGIF = true;
            this.GGButtonCreateNewEvent.BorderRadius = 5;
            this.GGButtonCreateNewEvent.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.GGButtonCreateNewEvent.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.GGButtonCreateNewEvent.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.GGButtonCreateNewEvent.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.GGButtonCreateNewEvent.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.GGButtonCreateNewEvent.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(83)))), ((int)(((byte)(227)))));
            this.GGButtonCreateNewEvent.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(83)))), ((int)(((byte)(227)))));
            this.GGButtonCreateNewEvent.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GGButtonCreateNewEvent.ForeColor = System.Drawing.Color.White;
            this.GGButtonCreateNewEvent.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(175)))));
            this.GGButtonCreateNewEvent.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(175)))));
            this.GGButtonCreateNewEvent.Image = ((System.Drawing.Image)(resources.GetObject("GGButtonCreateNewEvent.Image")));
            this.GGButtonCreateNewEvent.ImageOffset = new System.Drawing.Point(-5, 0);
            this.GGButtonCreateNewEvent.Location = new System.Drawing.Point(1123, 46);
            this.GGButtonCreateNewEvent.Name = "GGButtonCreateNewEvent";
            this.GGButtonCreateNewEvent.PressedColor = System.Drawing.Color.White;
            this.GGButtonCreateNewEvent.Size = new System.Drawing.Size(215, 47);
            this.GGButtonCreateNewEvent.TabIndex = 2;
            this.GGButtonCreateNewEvent.Text = "Add New Customer";
            // 
            // GTextBoxSearchTheEvent
            // 
            this.GTextBoxSearchTheEvent.BorderRadius = 8;
            this.GTextBoxSearchTheEvent.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.GTextBoxSearchTheEvent.DefaultText = "";
            this.GTextBoxSearchTheEvent.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.GTextBoxSearchTheEvent.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.GTextBoxSearchTheEvent.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GTextBoxSearchTheEvent.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GTextBoxSearchTheEvent.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GTextBoxSearchTheEvent.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GTextBoxSearchTheEvent.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GTextBoxSearchTheEvent.IconLeft = ((System.Drawing.Image)(resources.GetObject("GTextBoxSearchTheEvent.IconLeft")));
            this.GTextBoxSearchTheEvent.IconLeftOffset = new System.Drawing.Point(10, 0);
            this.GTextBoxSearchTheEvent.Location = new System.Drawing.Point(13, 131);
            this.GTextBoxSearchTheEvent.Name = "GTextBoxSearchTheEvent";
            this.GTextBoxSearchTheEvent.PlaceholderText = "Search by name, email, or National ID...";
            this.GTextBoxSearchTheEvent.SelectedText = "";
            this.GTextBoxSearchTheEvent.Size = new System.Drawing.Size(782, 44);
            this.GTextBoxSearchTheEvent.TabIndex = 3;
            // 
            // GGPanelDataGridViewEvents
            // 
            this.GGPanelDataGridViewEvents.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.GGPanelDataGridViewEvents.BorderRadius = 10;
            this.GGPanelDataGridViewEvents.BorderThickness = 2;
            this.GGPanelDataGridViewEvents.Controls.Add(this.GDataGridViewCustomerInformation);
            this.GGPanelDataGridViewEvents.Location = new System.Drawing.Point(27, 326);
            this.GGPanelDataGridViewEvents.Name = "GGPanelDataGridViewEvents";
            this.GGPanelDataGridViewEvents.Size = new System.Drawing.Size(1361, 535);
            this.GGPanelDataGridViewEvents.TabIndex = 7;
            // 
            // GDataGridViewCustomerInformation
            // 
            this.GDataGridViewCustomerInformation.AllowUserToAddRows = false;
            this.GDataGridViewCustomerInformation.AllowUserToDeleteRows = false;
            this.GDataGridViewCustomerInformation.AllowUserToResizeRows = false;
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.Color.Black;
            this.GDataGridViewCustomerInformation.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle21;
            this.GDataGridViewCustomerInformation.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Segoe UI Variable Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GDataGridViewCustomerInformation.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.GDataGridViewCustomerInformation.ColumnHeadersHeight = 64;
            this.GDataGridViewCustomerInformation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.GDataGridViewCustomerInformation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomerID,
            this.CustomerName,
            this.EmailCustomer,
            this.PhoneCustomer,
            this.NationalID});
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GDataGridViewCustomerInformation.DefaultCellStyle = dataGridViewCellStyle23;
            this.GDataGridViewCustomerInformation.GridColor = System.Drawing.Color.White;
            this.GDataGridViewCustomerInformation.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.GDataGridViewCustomerInformation.Location = new System.Drawing.Point(5, 6);
            this.GDataGridViewCustomerInformation.MultiSelect = false;
            this.GDataGridViewCustomerInformation.Name = "GDataGridViewCustomerInformation";
            this.GDataGridViewCustomerInformation.ReadOnly = true;
            this.GDataGridViewCustomerInformation.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GDataGridViewCustomerInformation.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
            this.GDataGridViewCustomerInformation.RowHeadersVisible = false;
            this.GDataGridViewCustomerInformation.RowTemplate.Height = 67;
            this.GDataGridViewCustomerInformation.Size = new System.Drawing.Size(1353, 523);
            this.GDataGridViewCustomerInformation.TabIndex = 0;
            this.GDataGridViewCustomerInformation.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.GDataGridViewCustomerInformation.ThemeStyle.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GDataGridViewCustomerInformation.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.GDataGridViewCustomerInformation.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.GDataGridViewCustomerInformation.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.GDataGridViewCustomerInformation.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.GDataGridViewCustomerInformation.ThemeStyle.GridColor = System.Drawing.Color.White;
            this.GDataGridViewCustomerInformation.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.GDataGridViewCustomerInformation.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.GDataGridViewCustomerInformation.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Variable Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GDataGridViewCustomerInformation.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            this.GDataGridViewCustomerInformation.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.GDataGridViewCustomerInformation.ThemeStyle.HeaderStyle.Height = 64;
            this.GDataGridViewCustomerInformation.ThemeStyle.ReadOnly = true;
            this.GDataGridViewCustomerInformation.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.GDataGridViewCustomerInformation.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.GDataGridViewCustomerInformation.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GDataGridViewCustomerInformation.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.GDataGridViewCustomerInformation.ThemeStyle.RowsStyle.Height = 67;
            this.GDataGridViewCustomerInformation.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.GDataGridViewCustomerInformation.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            // 
            // CustomerID
            // 
            this.CustomerID.HeaderText = "CustomerID";
            this.CustomerID.Name = "CustomerID";
            this.CustomerID.ReadOnly = true;
            this.CustomerID.Visible = false;
            // 
            // CustomerName
            // 
            this.CustomerName.HeaderText = "CustomerName";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            // 
            // EmailCustomer
            // 
            this.EmailCustomer.HeaderText = "Email";
            this.EmailCustomer.Name = "EmailCustomer";
            this.EmailCustomer.ReadOnly = true;
            // 
            // PhoneCustomer
            // 
            this.PhoneCustomer.HeaderText = "Phone";
            this.PhoneCustomer.Name = "PhoneCustomer";
            this.PhoneCustomer.ReadOnly = true;
            // 
            // NationalID
            // 
            this.NationalID.HeaderText = "National ID";
            this.NationalID.Name = "NationalID";
            this.NationalID.ReadOnly = true;
            // 
            // USCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(248)))));
            this.Controls.Add(this.GGPanelDataGridViewEvents);
            this.Controls.Add(this.PanelHeaderEvents);
            this.Name = "USCustomers";
            this.Size = new System.Drawing.Size(1419, 935);
            this.Load += new System.EventHandler(this.USCustomers_Load);
            this.PanelHeaderEvents.ResumeLayout(false);
            this.PanelHeaderEvents.PerformLayout();
            this.GGPanelDataGridViewEvents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GDataGridViewCustomerInformation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelHeaderEvents;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2GradientButton GGButtonCreateNewEvent;
        private Guna.UI2.WinForms.Guna2TextBox GTextBoxSearchTheEvent;
        private Guna.UI2.WinForms.Guna2GradientPanel GGPanelDataGridViewEvents;
        private Guna.UI2.WinForms.Guna2DataGridView GDataGridViewCustomerInformation;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmailCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhoneCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn NationalID;
    }
}
