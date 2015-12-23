namespace xQueens
{
	partial class xQueens
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System. ComponentModel. IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose ( bool disposing )
		{
			if ( disposing && ( components != null ) )
			{
				components. Dispose ( );
			}
			base. Dispose ( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent ( )
		{
			this.MainMenu = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.MainMenuPlayItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.MainMenuExitItem = new System.Windows.Forms.ToolStripMenuItem();
			this.MainMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// MainMenu
			// 
			this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
			this.MainMenu.Location = new System.Drawing.Point(0, 0);
			this.MainMenu.Name = "MainMenu";
			this.MainMenu.Size = new System.Drawing.Size(1184, 24);
			this.MainMenu.TabIndex = 1;
			this.MainMenu.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainMenuPlayItem,
            this.toolStripMenuItem1,
            this.MainMenuExitItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// MainMenuPlayItem
			// 
			this.MainMenuPlayItem.Name = "MainMenuPlayItem";
			this.MainMenuPlayItem.Size = new System.Drawing.Size(130, 22);
			this.MainMenuPlayItem.Text = "&Play";
			this.MainMenuPlayItem.Click += new System.EventHandler(this.MainMenuPlayItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(127, 6);
			// 
			// MainMenuExitItem
			// 
			this.MainMenuExitItem.Name = "MainMenuExitItem";
			this.MainMenuExitItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
			this.MainMenuExitItem.Size = new System.Drawing.Size(130, 22);
			this.MainMenuExitItem.Text = "E&xit";
			this.MainMenuExitItem.Click += new System.EventHandler(this.MainMenuExitItem_Click);
			// 
			// xQueens
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1184, 437);
			this.Controls.Add(this.MainMenu);
			this.IsMdiContainer = true;
			this.MainMenuStrip = this.MainMenu;
			this.Name = "xQueens";
			this.Text = "xQueens V1.0";
			this.MainMenu.ResumeLayout(false);
			this.MainMenu.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System. Windows. Forms. MenuStrip MainMenu;
		private System. Windows. Forms. ToolStripMenuItem fileToolStripMenuItem;
		private System. Windows. Forms. ToolStripMenuItem MainMenuPlayItem;
		private System. Windows. Forms. ToolStripSeparator toolStripMenuItem1;
		private System. Windows. Forms. ToolStripMenuItem MainMenuExitItem;
	}
}

