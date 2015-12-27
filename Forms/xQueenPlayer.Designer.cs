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
			System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new System.Windows.Forms.ListViewItem.ListViewSubItem[] {
            new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "Queens :"),
            new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "0", System.Drawing.SystemColors.WindowText, System.Drawing.SystemColors.Window, new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))))}, -1);
			System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new System.Windows.Forms.ListViewItem.ListViewSubItem[] {
            new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "Free cells :"),
            new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "x/y", System.Drawing.SystemColors.WindowText, System.Drawing.SystemColors.Window, new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))))}, -1);
			System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new System.Windows.Forms.ListViewItem.ListViewSubItem[] {
            new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "Occupied cells :"),
            new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "x/y", System.Drawing.SystemColors.WindowText, System.Drawing.SystemColors.Window, new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))))}, -1);
			System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem(new System.Windows.Forms.ListViewItem.ListViewSubItem[] {
            new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "", System.Drawing.SystemColors.WindowText, System.Drawing.SystemColors.Window, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)))),
            new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "", System.Drawing.SystemColors.WindowText, System.Drawing.SystemColors.Window, new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))))}, -1);
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
			this.SplitPanel = new System.Windows.Forms.SplitContainer();
			this.TabPages = new System.Windows.Forms.TabControl();
			this.DataPage = new System.Windows.Forms.TabPage();
			this.DataList = new System.Windows.Forms.ListView();
			this.Label = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Coverage = new System.Windows.Forms.TabPage();
			this.CoverageCount = new System.Windows.Forms.Label();
			this.CoverageLabel = new System.Windows.Forms.Label();
			this.CoverageList = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.HistoryPage = new System.Windows.Forms.TabPage();
			this.ContainerPanel = new System.Windows.Forms.Panel();
			this.MoveTooltip = new System.Windows.Forms.Label();
			this.BoardRightPanel = new System.Windows.Forms.Panel();
			this.BoardPanel = new System.Windows.Forms.Panel();
			this.TooltipTimer = new System.Windows.Forms.Timer(this.components);
			this.TopPanel.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.QueenDragger)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.SplitPanel)).BeginInit();
			this.SplitPanel.Panel1.SuspendLayout();
			this.SplitPanel.Panel2.SuspendLayout();
			this.SplitPanel.SuspendLayout();
			this.TabPages.SuspendLayout();
			this.DataPage.SuspendLayout();
			this.Coverage.SuspendLayout();
			this.ContainerPanel.SuspendLayout();
			this.BoardRightPanel.SuspendLayout();
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
			this.TopPanel.Size = new System.Drawing.Size(784, 33);
			this.TopPanel.TabIndex = 0;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.label2);
			this.panel2.Controls.Add(this.ChangeBoardSizeButton);
			this.panel2.Controls.Add(this.BoardSizeTextbox);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel2.Location = new System.Drawing.Point(652, 0);
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
			this.BoardSizeTextbox.Leave += new System.EventHandler(this.BoardSizeTextbox_Leave);
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
			this.MoveTextbox.Leave += new System.EventHandler(this.MoveTextbox_Leave);
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
			this.QueenDragger.Location = new System.Drawing.Point(0, 0);
			this.QueenDragger.Name = "QueenDragger";
			this.QueenDragger.Size = new System.Drawing.Size(24, 24);
			this.QueenDragger.TabIndex = 3;
			this.QueenDragger.TabStop = false;
			this.TooltipControl.SetToolTip(this.QueenDragger, "Drag this image onto the board to add a new queen");
			this.QueenDragger.MouseDown += new System.Windows.Forms.MouseEventHandler(this.QueenDragger_MouseDown);
			// 
			// SplitPanel
			// 
			this.SplitPanel.BackColor = System.Drawing.Color.Gainsboro;
			this.SplitPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SplitPanel.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.SplitPanel.Location = new System.Drawing.Point(0, 33);
			this.SplitPanel.Name = "SplitPanel";
			// 
			// SplitPanel.Panel1
			// 
			this.SplitPanel.Panel1.BackColor = System.Drawing.SystemColors.Control;
			this.SplitPanel.Panel1.Controls.Add(this.TabPages);
			this.SplitPanel.Panel1MinSize = 224;
			// 
			// SplitPanel.Panel2
			// 
			this.SplitPanel.Panel2.Controls.Add(this.ContainerPanel);
			this.SplitPanel.Size = new System.Drawing.Size(784, 569);
			this.SplitPanel.SplitterDistance = 224;
			this.SplitPanel.TabIndex = 3;
			this.SplitPanel.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.SplitPanel_SplitterMoved);
			// 
			// TabPages
			// 
			this.TabPages.Controls.Add(this.DataPage);
			this.TabPages.Controls.Add(this.Coverage);
			this.TabPages.Controls.Add(this.HistoryPage);
			this.TabPages.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TabPages.Location = new System.Drawing.Point(0, 0);
			this.TabPages.Name = "TabPages";
			this.TabPages.SelectedIndex = 0;
			this.TabPages.Size = new System.Drawing.Size(224, 569);
			this.TabPages.TabIndex = 0;
			// 
			// DataPage
			// 
			this.DataPage.BackColor = System.Drawing.SystemColors.Control;
			this.DataPage.Controls.Add(this.DataList);
			this.DataPage.Location = new System.Drawing.Point(4, 22);
			this.DataPage.Name = "DataPage";
			this.DataPage.Padding = new System.Windows.Forms.Padding(3);
			this.DataPage.Size = new System.Drawing.Size(216, 543);
			this.DataPage.TabIndex = 0;
			this.DataPage.Text = "Data";
			// 
			// DataList
			// 
			this.DataList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Label,
            this.Value});
			this.DataList.Dock = System.Windows.Forms.DockStyle.Fill;
			listViewItem1.UseItemStyleForSubItems = false;
			listViewItem2.UseItemStyleForSubItems = false;
			listViewItem3.UseItemStyleForSubItems = false;
			listViewItem4.UseItemStyleForSubItems = false;
			this.DataList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4});
			this.DataList.Location = new System.Drawing.Point(3, 3);
			this.DataList.Name = "DataList";
			this.DataList.Size = new System.Drawing.Size(210, 537);
			this.DataList.TabIndex = 0;
			this.DataList.UseCompatibleStateImageBehavior = false;
			this.DataList.View = System.Windows.Forms.View.Details;
			// 
			// Label
			// 
			this.Label.Text = "Item";
			this.Label.Width = 84;
			// 
			// Value
			// 
			this.Value.Text = "Value";
			this.Value.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.Value.Width = 120;
			// 
			// Coverage
			// 
			this.Coverage.BackColor = System.Drawing.SystemColors.Control;
			this.Coverage.Controls.Add(this.CoverageCount);
			this.Coverage.Controls.Add(this.CoverageLabel);
			this.Coverage.Controls.Add(this.CoverageList);
			this.Coverage.Location = new System.Drawing.Point(4, 22);
			this.Coverage.Name = "Coverage";
			this.Coverage.Size = new System.Drawing.Size(216, 543);
			this.Coverage.TabIndex = 2;
			this.Coverage.Text = "Coverage";
			// 
			// CoverageCount
			// 
			this.CoverageCount.AutoSize = true;
			this.CoverageCount.Location = new System.Drawing.Point(50, 245);
			this.CoverageCount.Name = "CoverageCount";
			this.CoverageCount.Size = new System.Drawing.Size(35, 13);
			this.CoverageCount.TabIndex = 2;
			this.CoverageCount.Text = "label4";
			// 
			// CoverageLabel
			// 
			this.CoverageLabel.AutoSize = true;
			this.CoverageLabel.Location = new System.Drawing.Point(0, 245);
			this.CoverageLabel.Name = "CoverageLabel";
			this.CoverageLabel.Size = new System.Drawing.Size(37, 13);
			this.CoverageLabel.TabIndex = 1;
			this.CoverageLabel.Text = "Total :";
			// 
			// CoverageList
			// 
			this.CoverageList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
			this.CoverageList.Dock = System.Windows.Forms.DockStyle.Top;
			this.CoverageList.Location = new System.Drawing.Point(0, 0);
			this.CoverageList.Name = "CoverageList";
			this.CoverageList.Size = new System.Drawing.Size(216, 235);
			this.CoverageList.TabIndex = 0;
			this.CoverageList.UseCompatibleStateImageBehavior = false;
			this.CoverageList.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Count";
			this.columnHeader1.Width = 41;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Remaining positions";
			this.columnHeader2.Width = 140;
			// 
			// HistoryPage
			// 
			this.HistoryPage.Location = new System.Drawing.Point(4, 22);
			this.HistoryPage.Name = "HistoryPage";
			this.HistoryPage.Padding = new System.Windows.Forms.Padding(3);
			this.HistoryPage.Size = new System.Drawing.Size(216, 543);
			this.HistoryPage.TabIndex = 1;
			this.HistoryPage.Text = "History";
			this.HistoryPage.UseVisualStyleBackColor = true;
			// 
			// ContainerPanel
			// 
			this.ContainerPanel.AutoScroll = true;
			this.ContainerPanel.BackColor = System.Drawing.SystemColors.Control;
			this.ContainerPanel.Controls.Add(this.MoveTooltip);
			this.ContainerPanel.Controls.Add(this.BoardRightPanel);
			this.ContainerPanel.Controls.Add(this.BoardPanel);
			this.ContainerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ContainerPanel.Location = new System.Drawing.Point(0, 0);
			this.ContainerPanel.Name = "ContainerPanel";
			this.ContainerPanel.Size = new System.Drawing.Size(556, 569);
			this.ContainerPanel.TabIndex = 3;
			// 
			// MoveTooltip
			// 
			this.MoveTooltip.AutoSize = true;
			this.MoveTooltip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.MoveTooltip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.MoveTooltip.Location = new System.Drawing.Point(111, 134);
			this.MoveTooltip.Name = "MoveTooltip";
			this.MoveTooltip.Size = new System.Drawing.Size(37, 15);
			this.MoveTooltip.TabIndex = 5;
			this.MoveTooltip.Text = "label3";
			this.MoveTooltip.Visible = false;
			// 
			// BoardRightPanel
			// 
			this.BoardRightPanel.AutoSize = true;
			this.BoardRightPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BoardRightPanel.Controls.Add(this.QueenDragger);
			this.BoardRightPanel.Location = new System.Drawing.Point(152, 35);
			this.BoardRightPanel.Name = "BoardRightPanel";
			this.BoardRightPanel.Size = new System.Drawing.Size(27, 27);
			this.BoardRightPanel.TabIndex = 4;
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
			// TooltipTimer
			// 
			this.TooltipTimer.Interval = 2000;
			this.TooltipTimer.Tick += new System.EventHandler(this.TooltipTimer_Tick);
			// 
			// xQueenPlayer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 602);
			this.Controls.Add(this.SplitPanel);
			this.Controls.Add(this.TopPanel);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Name = "xQueenPlayer";
			this.Text = "xQueens player";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.xQueenPlayer_KeyDown);
			this.Resize += new System.EventHandler(this.xQueenPlayer_Resize);
			this.TopPanel.ResumeLayout(false);
			this.TopPanel.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.QueenDragger)).EndInit();
			this.SplitPanel.Panel1.ResumeLayout(false);
			this.SplitPanel.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.SplitPanel)).EndInit();
			this.SplitPanel.ResumeLayout(false);
			this.TabPages.ResumeLayout(false);
			this.DataPage.ResumeLayout(false);
			this.Coverage.ResumeLayout(false);
			this.Coverage.PerformLayout();
			this.ContainerPanel.ResumeLayout(false);
			this.ContainerPanel.PerformLayout();
			this.BoardRightPanel.ResumeLayout(false);
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
		private System. Windows. Forms. SplitContainer SplitPanel;
		private System. Windows. Forms. Panel ContainerPanel;
		private System. Windows. Forms. PictureBox QueenDragger;
		private System. Windows. Forms. Panel BoardPanel;
		private System. Windows. Forms. Panel BoardRightPanel;
		private System. Windows. Forms. TabControl TabPages;
		private System. Windows. Forms. TabPage DataPage;
		private System. Windows. Forms. TabPage HistoryPage;
		private System. Windows. Forms. ListView DataList;
		private System. Windows. Forms. ColumnHeader Label;
		private System. Windows. Forms. ColumnHeader Value;
		private System. Windows. Forms. Label MoveTooltip;
		private System. Windows. Forms. Timer TooltipTimer;
		private System. Windows. Forms. TabPage Coverage;
		private System. Windows. Forms. ListView CoverageList;
		private System. Windows. Forms. ColumnHeader columnHeader1;
		private System. Windows. Forms. ColumnHeader columnHeader2;
		private System. Windows. Forms. Label CoverageLabel;
		private System. Windows. Forms. Label CoverageCount;
	}
}