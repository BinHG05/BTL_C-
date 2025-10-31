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
            mainPanel = new System.Windows.Forms.Panel();
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
            // mainPanel
            // 
            mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            mainPanel.Location = new System.Drawing.Point(250, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new System.Drawing.Size(932, 553);
            mainPanel.TabIndex = 1;
            // 
            // Layout
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1182, 553);
            Controls.Add(mainPanel);
            Controls.Add(sidebarPanel);
            Name = "Layout";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel sidebarPanel;
        private System.Windows.Forms.Panel mainPanel;
    }
}