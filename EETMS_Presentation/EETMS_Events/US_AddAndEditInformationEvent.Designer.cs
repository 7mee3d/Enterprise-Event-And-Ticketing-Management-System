namespace EETMS_Presentation.EETMS_Events
{
    partial class US_AddAndEditInformationEvent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(US_AddAndEditInformationEvent));
            this.GButtonBackTheEvents = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // GButtonBackTheEvents
            // 
            this.GButtonBackTheEvents.BorderColor = System.Drawing.Color.Transparent;
            this.GButtonBackTheEvents.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.GButtonBackTheEvents.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.GButtonBackTheEvents.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.GButtonBackTheEvents.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.GButtonBackTheEvents.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(248)))));
            this.GButtonBackTheEvents.Font = new System.Drawing.Font("Segoe UI Variable Small", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GButtonBackTheEvents.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(141)))), ((int)(((byte)(238)))));
            this.GButtonBackTheEvents.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(248)))));
            this.GButtonBackTheEvents.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(141)))), ((int)(((byte)(238)))));
            this.GButtonBackTheEvents.Image = ((System.Drawing.Image)(resources.GetObject("GButtonBackTheEvents.Image")));
            this.GButtonBackTheEvents.ImageOffset = new System.Drawing.Point(-5, 0);
            this.GButtonBackTheEvents.Location = new System.Drawing.Point(26, 45);
            this.GButtonBackTheEvents.Name = "GButtonBackTheEvents";
            this.GButtonBackTheEvents.PressedColor = System.Drawing.Color.White;
            this.GButtonBackTheEvents.Size = new System.Drawing.Size(233, 25);
            this.GButtonBackTheEvents.TabIndex = 0;
            this.GButtonBackTheEvents.Text = "Back to Events";
            this.GButtonBackTheEvents.Click += new System.EventHandler(this.GButtonBackTheEvents_Click);
            // 
            // US_AddAndEditInformationEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(248)))));
            this.Controls.Add(this.GButtonBackTheEvents);
            this.Name = "US_AddAndEditInformationEvent";
            this.Size = new System.Drawing.Size(1419, 935);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button GButtonBackTheEvents;
    }
}
