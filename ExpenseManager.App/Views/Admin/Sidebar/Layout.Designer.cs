namespace ExpenseManager.App.Views
{
    partial class Layout
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
            sidebarPanel = new System.Windows.Forms.Panel();
            headerPanel = new System.Windows.Forms.Panel();
            contentPanel = new System.Windows.Forms.Panel();
            SuspendLayout();
            // 
            // sidebarPanel
            // 
            sidebarPanel.Dock = System.Windows.Forms.DockStyle.Left;
            sidebarPanel.Location = new System.Drawing.Point(0, 0);
            sidebarPanel.Name = "sidebarPanel";
            sidebarPanel.Size = new System.Drawing.Size(250, 553);
            sidebarPanel.TabIndex = 0;
            // 
            // headerPanel
            // 
            headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            headerPanel.Location = new System.Drawing.Point(250, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new System.Drawing.Size(932, 64);
            headerPanel.TabIndex = 1;
            // 
            // contentPanel
            // 
            contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            contentPanel.Location = new System.Drawing.Point(250, 64);
            contentPanel.Name = "contentPanel";
            contentPanel.Size = new System.Drawing.Size(932, 489);
            contentPanel.TabIndex = 2;
            //contentPanel.Paint += this.contentPanel_Paint;
            // 
            // Layout
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1182, 553);
            Controls.Add(contentPanel);
            Controls.Add(headerPanel);
            Controls.Add(sidebarPanel);
            Name = "Layout";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel sidebarPanel;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Panel contentPanel;
    }
}