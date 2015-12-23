namespace xQueens
{
	partial class xQueenPlayer
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(xQueenPlayer));
			this.TopPanel = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.ChangeBoardSizeButton = new System.Windows.Forms.Button();
			this.ImageList = new System.Windows.Forms.ImageList(this.components);
			this.BoardSizeTextbox = new System.Windows.Forms.TextBox();
			this.ResetButton = new System.Windows.Forms.Button();
			this.MoveButton = new System.Windows.Forms.Button();
			this.MoveTextbox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.TooltipControl = new System.Windows.Forms.ToolTip(this.components);
			this.QueenDragger = new System.Windows.Forms.PictureBox();
			this.ContainerPanel = new System.Windows.Forms.Panel();
			this.BoardPanel = new System.Windows.Forms.Panel();
			this.TopPanel.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.QueenDragger)).BeginInit();
			this.ContainerPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// TopPanel
			// 
			this.TopPanel.Controls.Add(this.panel2);
			this.TopPanel.Controls.Add(this.ResetButton);
			this.TopPanel.Controls.Add(this.MoveButton);
			this.TopPanel.Controls.Add(this.MoveTextbox);
			this.TopPanel.Controls.Add(this.label1);
			this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.TopPanel.Location = new System.Drawing.Point(0, 0);
			this.TopPanel.Name = "TopPanel";
			this.TopPanel.Size = new System.Drawing.Size(573, 33);
			this.TopPanel.TabIndex = 0;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.label2);
			this.panel2.Controls.Add(this.ChangeBoardSizeButton);
			this.panel2.Controls.Add(this.BoardSizeTextbox);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel2.Location = new System.Drawing.Point(441, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(132, 33);
			this.panel2.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(1, 11);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(62, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Board size :";
			// 
			// ChangeBoardSizeButton
			// 
			this.ChangeBoardSizeButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.ChangeBoardSizeButton.ImageKey = "execute.gif";
			this.ChangeBoardSizeButton.ImageList = this.ImageList;
			this.ChangeBoardSizeButton.Location = new System.Drawing.Point(103, 6);
			this.ChangeBoardSizeButton.Name = "ChangeBoardSizeButton";
			this.ChangeBoardSizeButton.Size = new System.Drawing.Size(23, 23);
			this.ChangeBoardSizeButton.TabIndex = 1;
			this.TooltipControl.SetToolTip(this.ChangeBoardSizeButton, "Change board size");
			this.ChangeBoardSizeButton.UseVisualStyleBackColor = true;
			this.ChangeBoardSizeButton.Click += new System.EventHandler(this.ChangeBoardSizeButton_Click);
			// 
			// ImageList
			// 
			this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
			this.ImageList.TransparentColor = System.Drawing.Color.Transparent;
			this.ImageList.Images.SetKeyName(0, "cell-black.png");
			this.ImageList.Images.SetKeyName(1, "cell-white.png");
			this.ImageList.Images.SetKeyName(2, "move.gif");
			this.ImageList.Images.SetKeyName(3, "move-disabled.gif");
			this.ImageList.Images.SetKeyName(4, "move-illegal.gif");
			this.ImageList.Images.SetKeyName(5, "reset.png");
			this.ImageList.Images.SetKeyName(6, "execute.gif");
			// 
			// BoardSizeTextbox
			// 
			this.BoardSizeTextbox.Location = new System.Drawing.Point(67, 8);
			this.BoardSizeTextbox.Name = "BoardSizeTextbox";
			this.BoardSizeTextbox.Size = new System.Drawing.Size(35, 20);
			this.BoardSizeTextbox.TabIndex = 0;
			this.BoardSizeTextbox.Click += new System.EventHandler(this.BoardSizeTextbox_Click);
			this.BoardSizeTextbox.Enter += new System.EventHandler(this.BoardSizeTextbox_Enter);
			// 
			// ResetButton
			// 
			this.ResetButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.ResetButton.ImageKey = "reset.png";
			this.ResetButton.ImageList = this.ImageList;
			this.ResetButton.Location = new System.Drawing.Point(107, 6);
			this.ResetButton.Name = "ResetButton";
			this.ResetButton.Size = new System.Drawing.Size(23, 23);
			this.ResetButton.TabIndex = 3;
			this.TooltipControl.SetToolTip(this.ResetButton, "Resets the board");
			this.ResetButton.UseVisualStyleBackColor = true;
			this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
			// 
			// MoveButton
			// 
			this.MoveButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.MoveButton.ImageKey = "move-disabled.gif";
			this.MoveButton.ImageList = this.ImageList;
			this.MoveButton.Location = new System.Drawing.Point(85, 6);
			this.MoveButton.Name = "MoveButton";
			this.MoveButton.Size = new System.Drawing.Size(23, 23);
			this.MoveButton.TabIndex = 2;
			this.TooltipControl.SetToolTip(this.MoveButton, "Positions a queen to the specified coordinates");
			this.MoveButton.UseVisualStyleBackColor = true;
			this.MoveButton.Click += new System.EventHandler(this.MoveButton_Click);
			// 
			// MoveTextbox
			// 
			this.MoveTextbox.Location = new System.Drawing.Point(48, 8);
			this.MoveTextbox.Name = "MoveTextbox";
			this.MoveTextbox.Size = new System.Drawing.Size(37, 20);
			this.MoveTextbox.TabIndex = 1;
			this.MoveTextbox.Click += new System.EventHandler(this.MoveTextbox_Click);
			this.MoveTextbox.TextChanged += new System.EventHandler(this.MoveTextbox_TextChanged);
			this.MoveTextbox.Enter += new System.EventHandler(this.MoveTextbox_Enter);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(4, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Move :";
			// 
			// QueenDragger
			// 
			this.QueenDragger.Cursor = System.Windows.Forms.Cursors.Hand;
			this.QueenDragger.Image = global::xQueens.Properties.Resources.queen_24x24_white;
			this.QueenDragger.Location = new System.Drawing.Point(154, 18);
			this.QueenDragger.Name = "QueenDragger";
			this.QueenDragger.Size = new System.Drawing.Size(24, 24);
			this.QueenDragger.TabIndex = 3;
			this.QueenDragger.TabStop = false;
			this.TooltipControl.SetToolTip(this.QueenDragger, "Drag this image onto the board to add a new queen");
			this.QueenDragger.MouseDown += new System.Windows.Forms.MouseEventHandler(this.QueenDragger_MouseDown);
			// 
			// ContainerPanel
			// 
			this.ContainerPanel.AutoScroll = true;
			this.ContainerPanel.Controls.Add(this.QueenDragger);
			this.ContainerPanel.Controls.Add(this.BoardPanel);
			this.ContainerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ContainerPanel.Location = new System.Drawing.Point(0, 33);
			this.ContainerPanel.Name = "ContainerPanel";
			this.ContainerPanel.Size = new System.Drawing.Size(573, 290);
			this.ContainerPanel.TabIndex = 2;
			// 
			// BoardPanel
			// 
			this.BoardPanel.AllowDrop = true;
			this.BoardPanel.Location = new System.Drawing.Point(68, 18);
			this.BoardPanel.Name = "BoardPanel";
			this.BoardPanel.Size = new System.Drawing.Size(64, 64);
			this.BoardPanel.TabIndex = 2;
			this.BoardPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.BoardPanel_DragDrop);
			this.BoardPanel.DragEnter += new System.Windows.Forms.DragEventHandler(this.BoardPanel_DragEnter);
			this.BoardPanel.DragOver += new System.Windows.Forms.DragEventHandler(this.BoardPanel_DragOver);
			this.BoardPanel.DragLeave += new System.EventHandler(this.BoardPanel_DragLeave);
			this.BoardPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.ChessPanel_Paint);
			// 
			// xQueenPlayer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(573, 323);
			this.Controls.Add(this.ContainerPanel);
			this.Controls.Add(this.TopPanel);
			this.Name = "xQueenPlayer";
			this.Text = "xQueens player";
			this.Resize += new System.EventHandler(this.xQueenPlayer_Resize);
			this.TopPanel.ResumeLayout(false);
			this.TopPanel.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.QueenDragger)).EndInit();
			this.ContainerPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System. Windows. Forms. Panel TopPanel;
		private System. Windows. Forms. Button ResetButton;
		private System. Windows. Forms. ImageList ImageList;
		private System. Windows. Forms. ToolTip TooltipControl;
		private System. Windows. Forms. Button MoveButton;
		private System. Windows. Forms. TextBox MoveTextbox;
		private System. Windows. Forms. Label label1;
		private System. Windows. Forms. Panel panel2;
		private System. Windows. Forms. Label label2;
		private System. Windows. Forms. Button ChangeBoardSizeButton;
		private System. Windows. Forms. TextBox BoardSizeTextbox;
		private System. Windows. Forms. Panel ContainerPanel;
		private System. Windows. Forms. Panel BoardPanel;
		private System. Windows. Forms. PictureBox QueenDragger;
	}
}