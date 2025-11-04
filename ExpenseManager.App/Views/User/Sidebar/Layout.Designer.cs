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
            sidebarPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            sidebarPanel.Name = "sidebarPanel";
            sidebarPanel.Size = new System.Drawing.Size(312, 691);
            sidebarPanel.TabIndex = 0;
            // 
            // headerPanel
            // 
            headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            headerPanel.Location = new System.Drawing.Point(312, 0);
            headerPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new System.Drawing.Size(1166, 80);
            headerPanel.TabIndex = 1;
            // 
            // contentPanel
            // 
            contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            contentPanel.Location = new System.Drawing.Point(312, 80);
            contentPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            contentPanel.Name = "contentPanel";
            contentPanel.Size = new System.Drawing.Size(1166, 611);
            contentPanel.TabIndex = 2;
            // 
            // Layout
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1478, 691);
            Controls.Add(contentPanel);
            Controls.Add(headerPanel);
            Controls.Add(sidebarPanel);
            Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            Name = "Layout";
            Text = "Form1";
            Load += Layout_Load;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel sidebarPanel;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Panel contentPanel;
    }
}