namespace EETMS_Presentation.EETMS_Category
{
    partial class UC_Category
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Category));
            this.label1 = new System.Windows.Forms.Label();
            this.GGPanelAuickAddCategory = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GGPanelDataGridViewEvents = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.GDataGridViewCategoriesInformation = new Guna.UI2.WinForms.Guna2DataGridView();
            this.CategoryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountEventForCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescriptionCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContextMenuStripCategory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.GTextBoxSearchTheCategory = new Guna.UI2.WinForms.Guna2TextBox();
            this.editEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteEventToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.GGButtonAddNewCategory = new Guna.UI2.WinForms.Guna2GradientButton();
            this.GTextBoxCategoryDescripation = new Guna.UI2.WinForms.Guna2TextBox();
            this.GTextBoxCategoryName = new Guna.UI2.WinForms.Guna2TextBox();
            this.GGPanelAuickAddCategory.SuspendLayout();
            this.GGPanelDataGridViewEvents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GDataGridViewCategoriesInformation)).BeginInit();
            this.ContextMenuStripCategory.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Variable Display", 39.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label1.Location = new System.Drawing.Point(27, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 70);
            this.label1.TabIndex = 1;
            this.label1.Text = "Categories";
            // 
            // GGPanelAuickAddCategory
            // 
            this.GGPanelAuickAddCategory.BackColor = System.Drawing.Color.Transparent;
            this.GGPanelAuickAddCategory.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(236)))), ((int)(((byte)(243)))));
            this.GGPanelAuickAddCategory.BorderRadius = 10;
            this.GGPanelAuickAddCategory.BorderThickness = 1;
            this.GGPanelAuickAddCategory.Controls.Add(this.GGButtonAddNewCategory);
            this.GGPanelAuickAddCategory.Controls.Add(this.GTextBoxCategoryDescripation);
            this.GGPanelAuickAddCategory.Controls.Add(this.label4);
            this.GGPanelAuickAddCategory.Controls.Add(this.GTextBoxCategoryName);
            this.GGPanelAuickAddCategory.Controls.Add(this.label3);
            this.GGPanelAuickAddCategory.Controls.Add(this.label2);
            this.GGPanelAuickAddCategory.FillColor = System.Drawing.Color.White;
            this.GGPanelAuickAddCategory.FillColor2 = System.Drawing.Color.White;
            this.GGPanelAuickAddCategory.Location = new System.Drawing.Point(40, 114);
            this.GGPanelAuickAddCategory.Name = "GGPanelAuickAddCategory";
            this.GGPanelAuickAddCategory.Size = new System.Drawing.Size(1350, 207);
            this.GGPanelAuickAddCategory.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.label4.Location = new System.Drawing.Point(497, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Category Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.label3.Location = new System.Drawing.Point(29, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "New Category Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(120)))), ((int)(((byte)(143)))));
            this.label2.Location = new System.Drawing.Point(23, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(225, 31);
            this.label2.TabIndex = 0;
            this.label2.Text = "Quick Add Category";
            // 
            // GGPanelDataGridViewEvents
            // 
            this.GGPanelDataGridViewEvents.BackColor = System.Drawing.Color.Transparent;
            this.GGPanelDataGridViewEvents.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.GGPanelDataGridViewEvents.BorderRadius = 10;
            this.GGPanelDataGridViewEvents.BorderThickness = 1;
            this.GGPanelDataGridViewEvents.Controls.Add(this.GTextBoxSearchTheCategory);
            this.GGPanelDataGridViewEvents.Controls.Add(this.GDataGridViewCategoriesInformation);
            this.GGPanelDataGridViewEvents.FillColor = System.Drawing.Color.White;
            this.GGPanelDataGridViewEvents.FillColor2 = System.Drawing.Color.White;
            this.GGPanelDataGridViewEvents.Location = new System.Drawing.Point(40, 337);
            this.GGPanelDataGridViewEvents.Name = "GGPanelDataGridViewEvents";
            this.GGPanelDataGridViewEvents.Size = new System.Drawing.Size(1350, 569);
            this.GGPanelDataGridViewEvents.TabIndex = 8;
            // 
            // GDataGridViewCategoriesInformation
            // 
            this.GDataGridViewCategoriesInformation.AllowUserToAddRows = false;
            this.GDataGridViewCategoriesInformation.AllowUserToDeleteRows = false;
            this.GDataGridViewCategoriesInformation.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.GDataGridViewCategoriesInformation.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Variable Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GDataGridViewCategoriesInformation.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.GDataGridViewCategoriesInformation.ColumnHeadersHeight = 64;
            this.GDataGridViewCategoriesInformation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.GDataGridViewCategoriesInformation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CategoryID,
            this.CategoryName,
            this.CountEventForCategory,
            this.DescriptionCategory});
            this.GDataGridViewCategoriesInformation.ContextMenuStrip = this.ContextMenuStripCategory;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GDataGridViewCategoriesInformation.DefaultCellStyle = dataGridViewCellStyle3;
            this.GDataGridViewCategoriesInformation.GridColor = System.Drawing.Color.White;
            this.GDataGridViewCategoriesInformation.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.GDataGridViewCategoriesInformation.Location = new System.Drawing.Point(3, 105);
            this.GDataGridViewCategoriesInformation.MultiSelect = false;
            this.GDataGridViewCategoriesInformation.Name = "GDataGridViewCategoriesInformation";
            this.GDataGridViewCategoriesInformation.ReadOnly = true;
            this.GDataGridViewCategoriesInformation.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GDataGridViewCategoriesInformation.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
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
            this.GDataGridViewCategoriesInformation.ThemeStyle.HeaderStyle.Height = 64;
            this.GDataGridViewCategoriesInformation.ThemeStyle.ReadOnly = true;
            this.GDataGridViewCategoriesInformation.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.GDataGridViewCategoriesInformation.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.GDataGridViewCategoriesInformation.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GDataGridViewCategoriesInformation.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.GDataGridViewCategoriesInformation.ThemeStyle.RowsStyle.Height = 67;
            this.GDataGridViewCategoriesInformation.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.GDataGridViewCategoriesInformation.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            // 
            // CategoryID
            // 
            this.CategoryID.FillWeight = 10.52925F;
            this.CategoryID.HeaderText = "CATEGORY ID";
            this.CategoryID.Name = "CategoryID";
            this.CategoryID.ReadOnly = true;
            // 
            // CategoryName
            // 
            this.CategoryName.FillWeight = 55.02309F;
            this.CategoryName.HeaderText = "CATEGORY NAME";
            this.CategoryName.Name = "CategoryName";
            this.CategoryName.ReadOnly = true;
            // 
            // CountEventForCategory
            // 
            this.CountEventForCategory.FillWeight = 15.91879F;
            this.CountEventForCategory.HeaderText = "EVENTS COUNT";
            this.CountEventForCategory.Name = "CountEventForCategory";
            this.CountEventForCategory.ReadOnly = true;
            // 
            // DescriptionCategory
            // 
            this.DescriptionCategory.FillWeight = 58.52887F;
            this.DescriptionCategory.HeaderText = "DESCRIPATION CATEGORY ";
            this.DescriptionCategory.Name = "DescriptionCategory";
            this.DescriptionCategory.ReadOnly = true;
            // 
            // ContextMenuStripCategory
            // 
            this.ContextMenuStripCategory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editEventToolStripMenuItem,
            this.toolStripSeparator2,
            this.deleteEventToolStripMenuItem1});
            this.ContextMenuStripCategory.Name = "contextMenuStrip1";
            this.ContextMenuStripCategory.Size = new System.Drawing.Size(205, 86);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(201, 6);
            // 
            // GTextBoxSearchTheCategory
            // 
            this.GTextBoxSearchTheCategory.BorderRadius = 8;
            this.GTextBoxSearchTheCategory.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.GTextBoxSearchTheCategory.DefaultText = "";
            this.GTextBoxSearchTheCategory.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.GTextBoxSearchTheCategory.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.GTextBoxSearchTheCategory.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GTextBoxSearchTheCategory.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GTextBoxSearchTheCategory.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GTextBoxSearchTheCategory.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GTextBoxSearchTheCategory.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GTextBoxSearchTheCategory.IconLeft = ((System.Drawing.Image)(resources.GetObject("GTextBoxSearchTheCategory.IconLeft")));
            this.GTextBoxSearchTheCategory.IconLeftOffset = new System.Drawing.Point(10, 0);
            this.GTextBoxSearchTheCategory.Location = new System.Drawing.Point(29, 39);
            this.GTextBoxSearchTheCategory.Name = "GTextBoxSearchTheCategory";
            this.GTextBoxSearchTheCategory.PlaceholderText = "Search by Name Category ....";
            this.GTextBoxSearchTheCategory.SelectedText = "";
            this.GTextBoxSearchTheCategory.Size = new System.Drawing.Size(502, 39);
            this.GTextBoxSearchTheCategory.TabIndex = 3;
            this.GTextBoxSearchTheCategory.TextChanged += new System.EventHandler(this.GTextBoxSearchTheCategory_TextChanged);
            // 
            // editEventToolStripMenuItem
            // 
            this.editEventToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Variable Text", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editEventToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(83)))), ((int)(((byte)(227)))));
            this.editEventToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("editEventToolStripMenuItem.Image")));
            this.editEventToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.editEventToolStripMenuItem.Name = "editEventToolStripMenuItem";
            this.editEventToolStripMenuItem.Size = new System.Drawing.Size(204, 38);
            this.editEventToolStripMenuItem.Text = "Edit Category";
            this.editEventToolStripMenuItem.Click += new System.EventHandler(this.editEventToolStripMenuItem_Click);
            // 
            // deleteEventToolStripMenuItem1
            // 
            this.deleteEventToolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI Variable Text", 11.25F, System.Drawing.FontStyle.Bold);
            this.deleteEventToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(83)))), ((int)(((byte)(227)))));
            this.deleteEventToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("deleteEventToolStripMenuItem1.Image")));
            this.deleteEventToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deleteEventToolStripMenuItem1.Name = "deleteEventToolStripMenuItem1";
            this.deleteEventToolStripMenuItem1.Size = new System.Drawing.Size(204, 38);
            this.deleteEventToolStripMenuItem1.Text = "Delete Category";
            this.deleteEventToolStripMenuItem1.Click += new System.EventHandler(this.deleteEventToolStripMenuItem1_Click);
            // 
            // GGButtonAddNewCategory
            // 
            this.GGButtonAddNewCategory.Animated = true;
            this.GGButtonAddNewCategory.AnimatedGIF = true;
            this.GGButtonAddNewCategory.BorderRadius = 5;
            this.GGButtonAddNewCategory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GGButtonAddNewCategory.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.GGButtonAddNewCategory.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.GGButtonAddNewCategory.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.GGButtonAddNewCategory.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.GGButtonAddNewCategory.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.GGButtonAddNewCategory.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.GGButtonAddNewCategory.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.GGButtonAddNewCategory.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GGButtonAddNewCategory.ForeColor = System.Drawing.Color.White;
            this.GGButtonAddNewCategory.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.GGButtonAddNewCategory.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.GGButtonAddNewCategory.HoverState.Image = global::EETMS_Presentation.Properties.Resources.Add_Icon_EETMS;
            this.GGButtonAddNewCategory.Image = global::EETMS_Presentation.Properties.Resources.Add_Icon_EETMS;
            this.GGButtonAddNewCategory.ImageOffset = new System.Drawing.Point(-2, 0);
            this.GGButtonAddNewCategory.Location = new System.Drawing.Point(1088, 116);
            this.GGButtonAddNewCategory.Name = "GGButtonAddNewCategory";
            this.GGButtonAddNewCategory.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.GGButtonAddNewCategory.Size = new System.Drawing.Size(224, 47);
            this.GGButtonAddNewCategory.TabIndex = 3;
            this.GGButtonAddNewCategory.Text = "Add New Category";
            this.GGButtonAddNewCategory.Click += new System.EventHandler(this.GGButtonAddNewCategory_Click);
            // 
            // GTextBoxCategoryDescripation
            // 
            this.GTextBoxCategoryDescripation.Animated = true;
            this.GTextBoxCategoryDescripation.BorderRadius = 8;
            this.GTextBoxCategoryDescripation.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.GTextBoxCategoryDescripation.DefaultText = "";
            this.GTextBoxCategoryDescripation.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.GTextBoxCategoryDescripation.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.GTextBoxCategoryDescripation.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GTextBoxCategoryDescripation.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GTextBoxCategoryDescripation.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.GTextBoxCategoryDescripation.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GTextBoxCategoryDescripation.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GTextBoxCategoryDescripation.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GTextBoxCategoryDescripation.IconLeft = global::EETMS_Presentation.Properties.Resources.Description_Icon_EETMS;
            this.GTextBoxCategoryDescripation.IconLeftOffset = new System.Drawing.Point(5, 0);
            this.GTextBoxCategoryDescripation.Location = new System.Drawing.Point(500, 116);
            this.GTextBoxCategoryDescripation.Name = "GTextBoxCategoryDescripation";
            this.GTextBoxCategoryDescripation.PlaceholderText = "Brief description of event types in this category...";
            this.GTextBoxCategoryDescripation.SelectedText = "";
            this.GTextBoxCategoryDescripation.Size = new System.Drawing.Size(569, 45);
            this.GTextBoxCategoryDescripation.TabIndex = 7;
            // 
            // GTextBoxCategoryName
            // 
            this.GTextBoxCategoryName.Animated = true;
            this.GTextBoxCategoryName.BorderRadius = 8;
            this.GTextBoxCategoryName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.GTextBoxCategoryName.DefaultText = "";
            this.GTextBoxCategoryName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.GTextBoxCategoryName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.GTextBoxCategoryName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GTextBoxCategoryName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GTextBoxCategoryName.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.GTextBoxCategoryName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GTextBoxCategoryName.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GTextBoxCategoryName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GTextBoxCategoryName.IconLeft = ((System.Drawing.Image)(resources.GetObject("GTextBoxCategoryName.IconLeft")));
            this.GTextBoxCategoryName.IconLeftOffset = new System.Drawing.Point(5, 0);
            this.GTextBoxCategoryName.Location = new System.Drawing.Point(32, 116);
            this.GTextBoxCategoryName.Name = "GTextBoxCategoryName";
            this.GTextBoxCategoryName.PlaceholderText = "e.g. Festivals";
            this.GTextBoxCategoryName.SelectedText = "";
            this.GTextBoxCategoryName.Size = new System.Drawing.Size(424, 45);
            this.GTextBoxCategoryName.TabIndex = 7;
            this.GTextBoxCategoryName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GTextBoxCategoryName_KeyPress);
            // 
            // UC_Category
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(248)))));
            this.Controls.Add(this.GGPanelDataGridViewEvents);
            this.Controls.Add(this.GGPanelAuickAddCategory);
            this.Controls.Add(this.label1);
            this.Name = "UC_Category";
            this.Size = new System.Drawing.Size(1419, 935);
            this.Load += new System.EventHandler(this.USCategory_Load);
            this.Click += new System.EventHandler(this.USCategory_Click);
            this.GGPanelAuickAddCategory.ResumeLayout(false);
            this.GGPanelAuickAddCategory.PerformLayout();
            this.GGPanelDataGridViewEvents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GDataGridViewCategoriesInformation)).EndInit();
            this.ContextMenuStripCategory.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2GradientPanel GGPanelAuickAddCategory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox GTextBoxCategoryName;
        private Guna.UI2.WinForms.Guna2TextBox GTextBoxCategoryDescripation;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2GradientButton GGButtonAddNewCategory;
        private Guna.UI2.WinForms.Guna2GradientPanel GGPanelDataGridViewEvents;
        private Guna.UI2.WinForms.Guna2TextBox GTextBoxSearchTheCategory;
        private Guna.UI2.WinForms.Guna2DataGridView GDataGridViewCategoriesInformation;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountEventForCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescriptionCategory;
        private System.Windows.Forms.ContextMenuStrip ContextMenuStripCategory;
        private System.Windows.Forms.ToolStripMenuItem editEventToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem deleteEventToolStripMenuItem1;
    }
}
