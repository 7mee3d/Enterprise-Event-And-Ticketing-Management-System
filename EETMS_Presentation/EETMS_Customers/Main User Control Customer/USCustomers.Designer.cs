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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(USCustomers));
            this.PanelHeaderEvents = new System.Windows.Forms.Panel();
            this.lblTotalCustomer = new System.Windows.Forms.Label();
            this.GTextBoxSearchTheCustomer = new Guna.UI2.WinForms.Guna2TextBox();
            this.GGButtonCreateNewEvent = new Guna.UI2.WinForms.Guna2GradientButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.GGPanelDataGridViewEvents = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.GDataGridViewCustomerInformation = new Guna.UI2.WinForms.Guna2DataGridView();
            this.CustomerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmailCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhoneCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NationalID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GContextMenuStripOperationCustomer = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.DeleteCustomerlStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guna2GradientPanel2 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.guna2GradientButton2 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.label4 = new System.Windows.Forms.Label();
            this.PanelHeaderEvents.SuspendLayout();
            this.GGPanelDataGridViewEvents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GDataGridViewCustomerInformation)).BeginInit();
            this.GContextMenuStripOperationCustomer.SuspendLayout();
            this.guna2GradientPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelHeaderEvents
            // 
            this.PanelHeaderEvents.Controls.Add(this.guna2GradientPanel2);
            this.PanelHeaderEvents.Location = new System.Drawing.Point(27, 25);
            this.PanelHeaderEvents.Name = "PanelHeaderEvents";
            this.PanelHeaderEvents.Size = new System.Drawing.Size(1361, 194);
            this.PanelHeaderEvents.TabIndex = 6;
            // 
            // lblTotalCustomer
            // 
            this.lblTotalCustomer.AutoSize = true;
            this.lblTotalCustomer.BackColor = System.Drawing.Color.White;
            this.lblTotalCustomer.Font = new System.Drawing.Font("Segoe UI Variable Display", 20.25F, System.Drawing.FontStyle.Bold);
            this.lblTotalCustomer.Location = new System.Drawing.Point(22, 77);
            this.lblTotalCustomer.Name = "lblTotalCustomer";
            this.lblTotalCustomer.Size = new System.Drawing.Size(31, 36);
            this.lblTotalCustomer.TabIndex = 0;
            this.lblTotalCustomer.Text = "0";
            // 
            // GTextBoxSearchTheCustomer
            // 
            this.GTextBoxSearchTheCustomer.BorderRadius = 8;
            this.GTextBoxSearchTheCustomer.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.GTextBoxSearchTheCustomer.DefaultText = "";
            this.GTextBoxSearchTheCustomer.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.GTextBoxSearchTheCustomer.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.GTextBoxSearchTheCustomer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GTextBoxSearchTheCustomer.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GTextBoxSearchTheCustomer.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GTextBoxSearchTheCustomer.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GTextBoxSearchTheCustomer.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GTextBoxSearchTheCustomer.IconLeft = ((System.Drawing.Image)(resources.GetObject("GTextBoxSearchTheCustomer.IconLeft")));
            this.GTextBoxSearchTheCustomer.IconLeftOffset = new System.Drawing.Point(10, 0);
            this.GTextBoxSearchTheCustomer.Location = new System.Drawing.Point(646, 33);
            this.GTextBoxSearchTheCustomer.Name = "GTextBoxSearchTheCustomer";
            this.GTextBoxSearchTheCustomer.PlaceholderText = "Search by name, National ID...";
            this.GTextBoxSearchTheCustomer.SelectedText = "";
            this.GTextBoxSearchTheCustomer.Size = new System.Drawing.Size(496, 44);
            this.GTextBoxSearchTheCustomer.TabIndex = 3;
            this.GTextBoxSearchTheCustomer.TextChanged += new System.EventHandler(this.GTextBoxSearchTheEvent_TextChanged);
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
            this.GGButtonCreateNewEvent.Location = new System.Drawing.Point(1148, 33);
            this.GGButtonCreateNewEvent.Name = "GGButtonCreateNewEvent";
            this.GGButtonCreateNewEvent.PressedColor = System.Drawing.Color.White;
            this.GGButtonCreateNewEvent.Size = new System.Drawing.Size(192, 44);
            this.GGButtonCreateNewEvent.TabIndex = 2;
            this.GGButtonCreateNewEvent.Text = "Add New Customer";
            this.GGButtonCreateNewEvent.Click += new System.EventHandler(this.GGButtonCreateNewEvent_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Variable Text", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            this.label2.Location = new System.Drawing.Point(10, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(287, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Manage your event attendees, and their history.\n";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Variable Display", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(400, 53);
            this.label3.TabIndex = 0;
            this.label3.Text = "Customer Directory";
            // 
            // GGPanelDataGridViewEvents
            // 
            this.GGPanelDataGridViewEvents.BackColor = System.Drawing.Color.White;
            this.GGPanelDataGridViewEvents.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.GGPanelDataGridViewEvents.BorderRadius = 10;
            this.GGPanelDataGridViewEvents.BorderThickness = 1;
            this.GGPanelDataGridViewEvents.Controls.Add(this.GGButtonCreateNewEvent);
            this.GGPanelDataGridViewEvents.Controls.Add(this.GTextBoxSearchTheCustomer);
            this.GGPanelDataGridViewEvents.Controls.Add(this.GDataGridViewCustomerInformation);
            this.GGPanelDataGridViewEvents.Controls.Add(this.label3);
            this.GGPanelDataGridViewEvents.Controls.Add(this.label2);
            this.GGPanelDataGridViewEvents.Location = new System.Drawing.Point(27, 239);
            this.GGPanelDataGridViewEvents.Name = "GGPanelDataGridViewEvents";
            this.GGPanelDataGridViewEvents.Size = new System.Drawing.Size(1361, 647);
            this.GGPanelDataGridViewEvents.TabIndex = 7;
            // 
            // GDataGridViewCustomerInformation
            // 
            this.GDataGridViewCustomerInformation.AllowUserToAddRows = false;
            this.GDataGridViewCustomerInformation.AllowUserToDeleteRows = false;
            this.GDataGridViewCustomerInformation.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.GDataGridViewCustomerInformation.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Variable Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GDataGridViewCustomerInformation.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.GDataGridViewCustomerInformation.ColumnHeadersHeight = 64;
            this.GDataGridViewCustomerInformation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.GDataGridViewCustomerInformation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomerID,
            this.CustomerName,
            this.EmailCustomer,
            this.PhoneCustomer,
            this.NationalID});
            this.GDataGridViewCustomerInformation.ContextMenuStrip = this.GContextMenuStripOperationCustomer;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GDataGridViewCustomerInformation.DefaultCellStyle = dataGridViewCellStyle3;
            this.GDataGridViewCustomerInformation.GridColor = System.Drawing.Color.White;
            this.GDataGridViewCustomerInformation.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.GDataGridViewCustomerInformation.Location = new System.Drawing.Point(3, 117);
            this.GDataGridViewCustomerInformation.MultiSelect = false;
            this.GDataGridViewCustomerInformation.Name = "GDataGridViewCustomerInformation";
            this.GDataGridViewCustomerInformation.ReadOnly = true;
            this.GDataGridViewCustomerInformation.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GDataGridViewCustomerInformation.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.GDataGridViewCustomerInformation.RowHeadersVisible = false;
            this.GDataGridViewCustomerInformation.RowTemplate.Height = 67;
            this.GDataGridViewCustomerInformation.Size = new System.Drawing.Size(1355, 527);
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
            this.CustomerName.HeaderText = "CUSTOMER NAME";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            // 
            // EmailCustomer
            // 
            this.EmailCustomer.HeaderText = "EMAIL";
            this.EmailCustomer.Name = "EmailCustomer";
            this.EmailCustomer.ReadOnly = true;
            // 
            // PhoneCustomer
            // 
            this.PhoneCustomer.HeaderText = "PHONE";
            this.PhoneCustomer.Name = "PhoneCustomer";
            this.PhoneCustomer.ReadOnly = true;
            // 
            // NationalID
            // 
            this.NationalID.HeaderText = "NATIONAL ID";
            this.NationalID.Name = "NationalID";
            this.NationalID.ReadOnly = true;
            // 
            // GContextMenuStripOperationCustomer
            // 
            this.GContextMenuStripOperationCustomer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1,
            this.toolStripSeparator1,
            this.DeleteCustomerlStripMenuItem,
            this.updateCustomerToolStripMenuItem});
            this.GContextMenuStripOperationCustomer.Name = "GContextMenuStripOperationCustomer";
            this.GContextMenuStripOperationCustomer.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.GContextMenuStripOperationCustomer.RenderStyle.BorderColor = System.Drawing.Color.Gainsboro;
            this.GContextMenuStripOperationCustomer.RenderStyle.ColorTable = null;
            this.GContextMenuStripOperationCustomer.RenderStyle.RoundedEdges = true;
            this.GContextMenuStripOperationCustomer.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
            this.GContextMenuStripOperationCustomer.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.GContextMenuStripOperationCustomer.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.GContextMenuStripOperationCustomer.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
            this.GContextMenuStripOperationCustomer.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.GContextMenuStripOperationCustomer.Size = new System.Drawing.Size(167, 72);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.BackColor = System.Drawing.Color.White;
            this.toolStripTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.toolStripTextBox1.Enabled = false;
            this.toolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 16);
            this.toolStripTextBox1.Text = "Operation";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(163, 6);
            // 
            // DeleteCustomerlStripMenuItem
            // 
            this.DeleteCustomerlStripMenuItem.BackColor = System.Drawing.Color.White;
            this.DeleteCustomerlStripMenuItem.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteCustomerlStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.DeleteCustomerlStripMenuItem.Name = "DeleteCustomerlStripMenuItem";
            this.DeleteCustomerlStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.DeleteCustomerlStripMenuItem.Text = "Delete Customer";
            this.DeleteCustomerlStripMenuItem.Click += new System.EventHandler(this.DeleteCustomerlStripMenuItem_Click);
            // 
            // updateCustomerToolStripMenuItem
            // 
            this.updateCustomerToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.updateCustomerToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateCustomerToolStripMenuItem.Name = "updateCustomerToolStripMenuItem";
            this.updateCustomerToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.updateCustomerToolStripMenuItem.Text = "Update Customer";
            this.updateCustomerToolStripMenuItem.Click += new System.EventHandler(this.updateCustomerToolStripMenuItem_Click);
            // 
            // guna2GradientPanel2
            // 
            this.guna2GradientPanel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.guna2GradientPanel2.BorderRadius = 10;
            this.guna2GradientPanel2.BorderThickness = 1;
            this.guna2GradientPanel2.Controls.Add(this.guna2GradientButton2);
            this.guna2GradientPanel2.Controls.Add(this.lblTotalCustomer);
            this.guna2GradientPanel2.Controls.Add(this.label4);
            this.guna2GradientPanel2.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.guna2GradientPanel2.CustomBorderThickness = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.guna2GradientPanel2.FillColor = System.Drawing.Color.White;
            this.guna2GradientPanel2.FillColor2 = System.Drawing.Color.White;
            this.guna2GradientPanel2.Location = new System.Drawing.Point(29, 36);
            this.guna2GradientPanel2.Name = "guna2GradientPanel2";
            this.guna2GradientPanel2.Size = new System.Drawing.Size(300, 144);
            this.guna2GradientPanel2.TabIndex = 13;
            // 
            // guna2GradientButton2
            // 
            this.guna2GradientButton2.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientButton2.BorderRadius = 8;
            this.guna2GradientButton2.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.guna2GradientButton2.DisabledState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.guna2GradientButton2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.guna2GradientButton2.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.guna2GradientButton2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(240)))), ((int)(((byte)(254)))));
            this.guna2GradientButton2.DisabledState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.guna2GradientButton2.Enabled = false;
            this.guna2GradientButton2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.guna2GradientButton2.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.guna2GradientButton2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GradientButton2.ForeColor = System.Drawing.Color.White;
            this.guna2GradientButton2.Image = ((System.Drawing.Image)(resources.GetObject("guna2GradientButton2.Image")));
            this.guna2GradientButton2.ImageSize = new System.Drawing.Size(25, 25);
            this.guna2GradientButton2.Location = new System.Drawing.Point(213, 45);
            this.guna2GradientButton2.Name = "guna2GradientButton2";
            this.guna2GradientButton2.Size = new System.Drawing.Size(54, 52);
            this.guna2GradientButton2.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Segoe UI Variable Small", 14.25F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(118)))), ((int)(((byte)(140)))));
            this.label4.Location = new System.Drawing.Point(23, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 26);
            this.label4.TabIndex = 1;
            this.label4.Text = "Total Customers";
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
            this.GGPanelDataGridViewEvents.ResumeLayout(false);
            this.GGPanelDataGridViewEvents.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GDataGridViewCustomerInformation)).EndInit();
            this.GContextMenuStripOperationCustomer.ResumeLayout(false);
            this.GContextMenuStripOperationCustomer.PerformLayout();
            this.guna2GradientPanel2.ResumeLayout(false);
            this.guna2GradientPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelHeaderEvents;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2GradientButton GGButtonCreateNewEvent;
        private Guna.UI2.WinForms.Guna2TextBox GTextBoxSearchTheCustomer;
        private Guna.UI2.WinForms.Guna2GradientPanel GGPanelDataGridViewEvents;
        private Guna.UI2.WinForms.Guna2DataGridView GDataGridViewCustomerInformation;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip GContextMenuStripOperationCustomer;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem DeleteCustomerlStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateCustomerToolStripMenuItem;
        private System.Windows.Forms.Label lblTotalCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmailCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhoneCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn NationalID;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel2;
        private Guna.UI2.WinForms.Guna2GradientButton guna2GradientButton2;
        private System.Windows.Forms.Label label4;
    }
}
