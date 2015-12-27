/**************************************************************************************************************

    NAME
	xQueensPlayer.cs

    DESCRIPTION
	A form that allows the user to play with the x Queens problem.

    AUTHOR
	Christian Vigh, 12/2015.

    HISTORY
	[Version : 1.0]		[Date : 2015/12/21]     [Author : CV]
		Initial version.

 **************************************************************************************************************/
using   System ;
using	System. Collections. Generic ;
using	System. ComponentModel ;
using	System. Data ;
using	System. Drawing ;
using	System. Drawing. Drawing2D ;
using	System. Drawing. Imaging ;
using	System. Drawing. Text ;
using	System. Linq ;
using	System. Text ;
using	System. Reflection ;
using	System. Threading. Tasks ;
using	System. Windows. Forms ;

using	ChessBoard ;
using	Thrak. Forms ;


namespace  xQueens
   {
	using  TextBox		=  System. Windows. Forms. TextBox ;

	public partial class  xQueenPlayer : xQueensMdiChild
	   {
		# region Constants and variables
		// Size of a board cell in pixels
		const int		CELL_SIZE			=  28 ;
		// Size of the board header in pixels (height of column headers + width of column number digit)
		const int		BOARD_HEADER_SIZE		=  16 ;

		// Line index of information in the DataList control
		const int		DATA_POSITIONED_CELLS		=  0,
					DATA_FREE_CELLS			=  1,
					DATA_OCCUPIED_CELLS		=  2,
					DATA_VERDICT			=  3 ;

		// Mdi document base title
		string			DocumentTitle ;
		// Mdi document id
		int			DocumentId ;
					
		// Chess board internal structure
		Board			QueenBoard ;
		// Play history 
		History			BoardHistory ;

		// Height of area for column numbers and width of line numbers (which depends on highest line number)
		int			BoardHorizontalHeaderHeight	=  BOARD_HEADER_SIZE + 2,
					BoardVerticalHeaderWidth	=  BOARD_HEADER_SIZE ;

		// Various brushes for painting the chessboard
		Brush			WhiteCellBrush,				// White cells
					BlackCellBrush,				// Black cells
					GrayedWhiteCellBrush,			// Brushes used to gray cells when positioning a queen
					GrayedBlackCellBrush ;

		// Font used to display column and line numbers
		Font			BoardNumbersFont		=  new Font ( "Ms Sans Serif", 9 ) ;

		// Holds the board coordinates of the cell which was last hovered during a drag and drop operation
		// This is needed to avoid unneccessary repaints since the DragOver event can be called several times
		// for the sme position even if the mouse does not move
		CellPosition		DragDropPosition ;
		# endregion


		# region Constructor
		/// <summary>
		/// Initialize a new player window
		/// </summary>
		/// <param name="parent">Mdi container window</param>
		public  xQueenPlayer ( xQueens  parent, int  id, int  default_size = 8 ) : base ( parent )
		   {
			InitializeComponent ( ) ;

			// Create a new board using the default size
			QueenBoard		=  new Board ( default_size ) ;
			BoardHistory		=  new History ( default_size ) ;

			// Set board size textbox to that value
			BoardSizeTextbox. Text	=  default_size. ToString ( ) ;

			// Default form button changes depending on which text box has the focus ; it will be
			// MoveButton for the MoveTextbox control, and ChangeBoardSize button for the BoardSizeTextbox
			// control. For now, say that there is no default button
			AcceptButton		=  null ;

			// Move button is first disabled, since MoveTextbox is empty
			MoveButton. Enabled	=  false ;

			// Create the brushes
			WhiteCellBrush		=  new SolidBrush ( parent. WhiteCellBackgroundColor ) ;
			BlackCellBrush		=  new SolidBrush ( parent. BlackCellBackgroundColor ) ;
			GrayedWhiteCellBrush	=  new HatchBrush ( HatchStyle. Percent50, parent. GrayCellBackgroundColor, parent. WhiteCellBackgroundColor ) ;
			GrayedBlackCellBrush	=  new HatchBrush ( HatchStyle. Percent50, parent. GrayCellBackgroundColor, parent. BlackCellBackgroundColor ) ;

			// If not set, repainting the board causes flickering
			// (needs the Thrak library for that)
			BoardPanel. SetDoubleBuffering ( true ) ;

			// Save initial document caption and current document sequence number
			DocumentTitle		=  Text ;
			DocumentId		=  id ;

			// Update title, which takes into account document id and board size
			SetTitle ( ) ;

			// Initial drawing of the board
			RedrawBoard ( true ) ;
		    }
		# endregion

		# region Form button and key events
		/// <summary>
		/// Positions a new queen onto the board. The queen's position is given by the MoveTextbox control.
		/// </summary>
		private void MoveButton_Click ( object sender, EventArgs e )
		   {
			int	line, column ;
			
			if  ( QueenBoard. GetPositionFromString ( MoveTextbox. Text, out line, out column ) )
			   {
				QueenBoard. Move ( line, column ) ;
				BoardHistory. Add ( line, column ) ;
				RedrawBoard ( ) ;
			    }
			else
				MessageBox. Show ( "Invalid move to '" + MoveTextbox. Text ) ;
		    }


		/// <summary>
		/// Resets board contents.
		/// </summary>
		private void ResetButton_Click ( object sender, EventArgs e )
		   { ResetBoard ( ) ; }


		/// <summary>
		/// Changes the board size.
		/// </summary>
		private void ChangeBoardSizeButton_Click ( object sender, EventArgs e )
		   {
			int	new_size ;

			// Board size must be at least 4x4 - Complain if not
			if  ( ! int. TryParse ( BoardSizeTextbox. Text, out new_size )  ||  new_size  <  4 )
			   {
				MessageBox. Show ( "Invalid board size" ) ;
				BoardSizeTextbox. Focus ( ) ;
			    }
			// Otherwise...
			else
			   {
				QueenBoard	=  new Board ( new_size ) ;	// Create a new board
				RedrawBoard ( true ) ;				// Draw it
				UpdateStatistics ( ) ;				// Update the "Data" tab
				UpdateCoverages ( ) ;				// and the "coverage" tab

				SetTitle ( ) ;					// Update the title (to include new board size)
			    }
		    }


		/// <summary>
		/// Handles key shortcuts.
		/// </summary>
		private void  xQueenPlayer_KeyDown  ( object  sender, KeyEventArgs  e )
		   {
			switch  ( e. KeyCode )
			   {
				// Ctrl+C :
				//	Copies current board to the clipboard.
				case	Keys. C :
					if ( e. Control )
					   {
						CopyBoard ( ) ;
						e. SuppressKeyPress	=  true ;
					    }

					break ;
				
				// Ctrl+R :
				//	Resets the board contents.
				case	Keys. R :
					if ( e. Control )
					   {
						ResetBoard ( ) ;
						e. SuppressKeyPress	=  true ;
					    }

					break ;

				// Ctrl+Z, Alt+Bksp :
				//	Undoes the previous move.
				case	Keys. Z :
					if  ( e. Control )
					   {
						Undo ( ) ;
						e. SuppressKeyPress	=  true ;
					    }

					break ;

				case	Keys. Back :
					if  ( e. Alt )
					   {
						Undo ( ) ;
						e. SuppressKeyPress	=  true ;
					    }

					break ;

				// Ctrl+Y :
				//	Redo the last undone change.
				case	Keys. Y :
					if  ( e. Control )
					   {
						Redo ( ) ;
						e. SuppressKeyPress	=  true ;
					    }

					break ;


				// F3, Shift+3 :
				//	Cycle forward or backward the Data/Coverage/history tabs.
				case	Keys. F3 :
					int	new_index ;

					if  ( e. Shift )
						new_index	=  ( TabPages. SelectedIndex  ==  0 ) ?
										TabPages. TabCount - 1 : TabPages. SelectedIndex - 1 ;
					else
						new_index	=  ( TabPages. SelectedIndex + 1 ) % TabPages. TabCount ;

					TabPages. SelectedIndex		=  new_index ;
					break ;
			    }
		    }
		# endregion

		# region Form events
		/// <summary>
		/// Handles the resize event for this mdi child.
		/// </summary>
		private void xQueenPlayer_Resize ( object sender, EventArgs e )
		   { ResizeForm ( ) ; }
		# endregion

		# region Events related to the move textbox
		/// <summary>
		/// Enables/disables the MoveButton, depending on the move specified by the user.
		/// Move button will be disabled if supplied move is invalid, or forbidden if the supplied
		/// move falls into an already occupied cell.
		/// </summary>
		private void MoveTextbox_TextChanged ( object sender, EventArgs e )
		   {
			int	line, column ;


			if  ( MoveTextbox. Text. Trim ( )  ==  "" )
			   {
				AcceptButton		=  null ;
				MoveButton. Enabled	=  false ;
				MoveButton. ImageKey	=  "move-disabled.gif" ;

				return ;
			    }
			else if  ( QueenBoard. GetPositionFromString ( MoveTextbox. Text, out line, out column ) )
			   { 
				AcceptButton		=  MoveButton ;
				MoveButton. Enabled	=  true ;
				MoveButton. ImageKey	=  "move.gif" ;

				if  ( line  <  QueenBoard. Size  &&  column  <  QueenBoard. Size )
					return ;
			    }

			AcceptButton		=  null ;
			MoveButton. Enabled	=  false ;
			MoveButton. ImageKey	=  "move-illegal.gif" ;
		    }


		/// <summary>
		/// Sets the move button as the default button upon entering the move textbox.
		/// </summary>
		private void MoveTextbox_Enter ( object sender, EventArgs e )
		   { 
			MoveTextbox. SelectAll ( ) ;
			AcceptButton = MoveButton ; 
		    }


		/// <summary>
		/// Behaves as the Enter event, for mouse clicks
		/// </summary>
		private void MoveTextbox_Click ( object sender, EventArgs e )
		   { 
			MoveTextbox. SelectAll ( ) ;
			AcceptButton = MoveButton ; 
		    }


		/// <summary>
		/// When leaving the move textbox, the move button no longer is the default one
		/// </summary>
		private void MoveTextbox_Leave ( object sender, EventArgs e )
		   { AcceptButton = null ; }

		# endregion

		# region Events related to the board size textbox
		/// <summary>
		/// Make the ChangeBoardSizeButton the default one upon entering the board size input field.
		/// </summary>
		private void BoardSizeTextbox_Enter ( object sender, EventArgs e )
		   { 
			BoardSizeTextbox. SelectAll ( ) ;
			AcceptButton = ChangeBoardSizeButton ; 
		    }


		/// <summary>
		/// Make the ChangeBoardSizeButton the default one upon entering the board size input field.
		/// </summary>
		private void BoardSizeTextbox_Click ( object sender, EventArgs e )
		   { 
			BoardSizeTextbox. SelectAll ( ) ;
			AcceptButton = ChangeBoardSizeButton ; 
		    }


		/// <summary>
		/// When leaving the board size field, cancel the default form button
		/// </summary>
		private void BoardSizeTextbox_Leave ( object sender, EventArgs e )
		   { AcceptButton = null ; }

		# endregion 

		# region Events related to the drawing of the chessboard
		/// <summary>
		/// Redraws the board.
		/// </summary>
		private void  ChessPanel_Paint ( object  sender, PaintEventArgs  e )
		   { DrawChessboard ( e. Graphics ) ; }

			
		/// <summary>
		/// Repositions the board after a window resize and redraws it.
		/// </summary>
		private void SplitPanel_SplitterMoved ( object sender, SplitterEventArgs e )
		   { 
			ResizeForm ( ) ; 
			DrawChessboard ( SplitPanel. Panel2. CreateGraphics ( ) ) ; 
		    }
		# endregion

		# region Drag and drop events
		/// <summary>
		/// Once the DoDragDrop() form function has been called, the DragEnter event will be fired
		/// to any control accepting drags. Here, the chessboard panel unconditionnally accepts any
		/// drop request.
		/// </summary>
		private void BoardPanel_DragEnter  ( object  sender, DragEventArgs  e )
		   {
			e. Effect		=  DragDropEffects. Move ;
			DragDropPosition	=  new CellPosition ( -1, -1 ) ;
		    }


		/// <summary>
		/// User entered the chessboard panel after initiating a drag and drop operation,
		/// but left the panel area : reset the situation to the state it had before the
		/// DragEnter event was fired
		/// </summary>
		private void BoardPanel_DragLeave ( object sender, EventArgs e )
		   {
			MoveTextbox. Text	=  "" ;
			MoveTooltip. Visible	=  false ;
			DragDropPosition	=  new CellPosition ( -1, -1 ) ;
		    }


		/// <summary>
		/// After provoking a DragEnter event followed by several DragOver events, the user finally
		/// released the mouse button to "drop" the queen to a cell.
		/// </summary>
		private void BoardPanel_DragDrop ( object sender, DragEventArgs e )
		   {
			int	line, column ;

			// Verify that the position is ok
			if  ( CheckIfDroppable ( e, out line, out column ) )
			   {
				QueenBoard. Move ( line, column ) ;	// Drop the queen to that position
				BoardHistory. Add ( line, column ) ;
				RedrawBoard ( ) ;			// Redraw the board
				UpdateStatistics ( ) ;			// Update statistics (data) and coverage tabs
				UpdateCoverages ( ) ;
			    }

			// Reset the situation to the state it was before the DragEnter event was fired
			MoveTextbox. Text	=  "" ;			
			MoveTooltip. Visible	=  false ;
			DragDropPosition	=  new CellPosition ( -1, -1 ) ;
		    }


		/// <summary>
		/// Update UI to reflect current state after a drag and drop operation has been initiated by the user
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BoardPanel_DragOver ( object sender, DragEventArgs e )
		   {
			int	line, column ;

			// Position is valid : update the move textbox and perform some highlighting operations
			if  ( CheckIfDroppable ( e, out line, out column ) )
			   {
				MoveTextbox. Text		=  QueenBoard. GetStringFromColumn ( column ) + 
									( QueenBoard. Size - line ). ToString ( ) ;
				MoveTextbox. SelectionStart	=  MoveTextbox. Text. Length ;
				MoveTextbox. SelectionLength	=  0 ;

				HighlightPosition ( line, column, e. X, e. Y ) ;
			    }
			// Invalid position
			else
			   {
				MoveTextbox. Text	=  "" ;
				MoveTooltip. Visible	=  false ;
			    }
		    }


		/// <summary>
		/// Drag and drop really starts when clicking on the queen picture on the right of the chessboard.
		/// After that, the BoardPanel_* events above handle move/enter/leave events
		/// </summary>
		private void QueenDragger_MouseDown ( object sender, MouseEventArgs e )
		   {
			DoDragDrop ( Properties. Resources. queen_24x24_white, DragDropEffects. Move ) ;
			AcceptButton	=  null ;
		    }


		/// <summary>
		/// When the user positions the mouse over a chessboard cell after a drag and drop operation
		/// has been initiated, a tooltip is displayed that gives the cell coordinates and the number
		/// of other cells covered by the current position.
		/// This timer is here to close the tooltip after a certain period of time (typically 2 seconds)
		/// so that the user will not be uncommodated by a continuous tooltip display.
		/// </summary>
		private void TooltipTimer_Tick ( object sender, EventArgs e )
		   { 
			MoveTooltip. Visible	=  false ; 
			TooltipTimer. Enabled	=  false ;
		    }
		# endregion


		# region Support functions
		/// <summary>
		/// Checks if the drag position, specified by <paramref name="e"/>, corresponds to a valid
		/// chessboard cell.
		/// </summary>
		/// <param name="e">Drag event arguments</param>
		/// <param name="line">Will be set to the line number of the cell over which the mouse is positioned</param>
		/// <param name="column">Will be set to the column number of the cell over which the mouse is positioned</param>
		/// <returns>True if the current position is over a chessboard cell, false otherwise.</returns>
		private bool  CheckIfDroppable ( DragEventArgs  e, out int  line, out int  column )
		   {
			// First, convert mouse (screen) coordinates to chessboard control coordinates
			Point		pt		=  BoardPanel. PointToClient ( new Point ( e. X, e. Y ) ) ;
			int		board_size	=  QueenBoard. Size * CELL_SIZE ;
			// This rectangle covers the chessboard without its line and column numbers
			Rectangle	board_rect	=  new Rectangle
							     (
								BoardVerticalHeaderWidth,
								BoardHorizontalHeaderHeight,
								board_size, board_size 
							      ) ;

			line = column = -1 ;

			// Current mouse position is within the chessboard part of the control
			if  ( board_rect. Contains ( pt ) )
			   { 
				// Retrieve cell column & line position given the mouse coordinates
				column		=  ( pt. X - BoardVerticalHeaderWidth ) / CELL_SIZE ;
				line		=  ( pt. Y - BoardHorizontalHeaderHeight ) / CELL_SIZE ;

				// This cell is already occupied : don't allow to drop anything here
				if  ( QueenBoard [ line, column ]  !=  CellType. Free )
				   {
					e. Effect	=  DragDropEffects. None ;

					return ( false ) ;
				    }
				// This cell is free : the user can drop a queen here
				else
				   { 
					e. Effect	=  DragDropEffects. Move ;

					return ( true ) ;
				    }
			    }
			// Mouse position is within line or column headers : we cannot drop anything here
			else
			   {
				e. Effect	=  DragDropEffects. None ;

				return ( false ) ;
			    }
		    }


		/// <summary>
		/// Copies the currently displayed chessboard to the clipboard
		/// </summary>
		private void  CopyBoard ( )
		   {
			Bitmap		bmp	=  new Bitmap ( BoardPanel. Width, BoardPanel. Height ) ;

			BoardPanel. DrawToBitmap ( bmp, new Rectangle ( new Point ( 0, 0 ), BoardPanel. Size ) ) ;
		
			Clipboard. SetImage ( bmp ) ;
		    }


		/// <summary>
		/// Draws/redraws the chessboard
		/// </summary>
		/// <param name="g">Graphic context</param>
		private void  DrawChessboard ( Graphics  g )
		   {
			int		board_size	=  QueenBoard. Size ;
			int		count ;
			StringFormat	align_fmt	=  new StringFormat ( ) ;
					
			// Right alignment is used for line numbers
			align_fmt. Alignment	=  StringAlignment. Far ;


			// Loop through lines and columns
			for  ( int  i = 0 ;  i  <  board_size ; i ++ )
			   {
				// 'count' is here to say if the current cell will be white or black
				// If the current line number is odd, the first cell will be white, otherwise black
				count	=  ( i % 2 ) ;

				for  ( int  j = 0 ; j  <  board_size ; j ++ )		// Here we are looping through columns
				   {
					// Get the correct brush for painting this cell
					Brush		br ;

					if  ( QueenBoard [ i, j ]  ==  CellType. Masked )	// Cell is masked
						br	=  ( ( count % 2 )  ==  0 ) ?  GrayedWhiteCellBrush : GrayedBlackCellBrush ;
					else							// Cell is free or has a queen in it
						br	=  ( ( count % 2 )  ==  0 ) ?  WhiteCellBrush : BlackCellBrush ;

					// Position of the upper-left corner of the current cell
					Point	pt	=  new Point ( ( j * CELL_SIZE ) + BoardVerticalHeaderWidth, 
								       ( i * CELL_SIZE ) + BoardHorizontalHeaderHeight ) ;

					// Draw the current cell
					g. FillRectangle ( br, pt. X, pt. Y, CELL_SIZE, CELL_SIZE ) ;

					// Check if we need to display a queen in this cell
					if  ( QueenBoard [ i, j ]  ==  CellType. Occupied )
					   {
						Bitmap		img		=  Properties. Resources. queen_24x24_white ;
						
						pt. X	+=  ( CELL_SIZE - img. Width  ) / 2 ;
						pt. Y	+=  ( CELL_SIZE - img. Height ) / 2 ;
						
						g. InterpolationMode	=  InterpolationMode. HighQualityBicubic ;

						Rectangle	imgrect		=  new Rectangle ( pt. X, pt. Y, img. Width, img. Height) ;
						
						g. DrawImage ( img, imgrect ) ;
					    }

					count ++ ;
				    }

				// Draw the left- and right- vertical header showing the line numbers
				// Line numbers are right-aligned
				RectangleF	rect	=  new RectangleF
							     (
								0, ( i * CELL_SIZE ) + CELL_SIZE - 6,
								BoardVerticalHeaderWidth - 2, 
								BoardHorizontalHeaderHeight
							      ) ;

				g. DrawString ( ( board_size - i ). ToString ( ), BoardNumbersFont, Brushes. Black, rect, align_fmt ) ;

				rect.	X	=  BoardVerticalHeaderWidth + ( board_size * CELL_SIZE ) ;

				g. DrawString ( ( board_size - i ). ToString ( ), BoardNumbersFont, Brushes. Black, rect, align_fmt ) ;
			    }

			// Now draw the horizontal column names
			align_fmt. Alignment	=  StringAlignment. Center ;

			for  ( int  i = 0 ; i  <  board_size ; i ++ )
			   {
				RectangleF	rect	=  new RectangleF
							     (
								BoardVerticalHeaderWidth + ( i * CELL_SIZE ), 0,
								CELL_SIZE, 
								BoardHorizontalHeaderHeight
							      ) ;
				
				g. DrawString ( QueenBoard. GetStringFromColumn ( i ), 
							BoardNumbersFont, Brushes. Black, rect, align_fmt ) ;

				rect.	Y	=  BoardHorizontalHeaderHeight + ( board_size * CELL_SIZE ) ;

				g. DrawString ( QueenBoard. GetStringFromColumn ( i ), 
							BoardNumbersFont, Brushes. Black, rect, align_fmt ) ;
			    }
		    }


		/// <summary>
		/// Used to highlight the current position. For the moment, only display a tooltip text.
		/// </summary>
		/// <param name="line">Chessboard line</param>
		/// <param name="column">Chessboard column</param>
		/// <param name="mouse_x">Mouse X position in the screen</param>
		/// <param name="mouse_y">Mouse Y position in the screen</param>
		private void  HighlightPosition ( int  line, int  column, int  mouse_x, int  mouse_y )
		   {
			// This function is called by the DragOver event handler. Since this event is fired
			// periodically several times per second, we have to check that the current chessboard
			// cell has changed since the last call ; otherwise, do nothing
			if  ( line  ==  DragDropPosition. Line   &&  column  ==  DragDropPosition. Column )
				return ;

			// Cancel any previously started tooltip timer
			TooltipTimer. Enabled	=  false ;

			// We will have to display a tooltip giving information on the current cell
			// First, build its top-left location into the chessboard
			Point			pt			=  ContainerPanel. PointToClient ( 
										new Point ( mouse_x - 20, mouse_y - 16 ) ) ;

			// Get the list of cells affected by the current queen position  and count those not
			// already covered by another queen
			List<CellPosition>	affected_cells ;
			int			available_cells		=  0 ;

			QueenBoard. GetAffectedCells ( line, column, out affected_cells ) ;

			foreach ( CellPosition  position  in  affected_cells )
			   {
				if (  QueenBoard [ position. Line, position. Column ]  ==  CellType. Free )
					available_cells	++ ;
			    }

			// Build the tooltip text from current position information and make it visible at user-friendly location
			MoveTooltip. Text	=  QueenBoard. GetStringFromPosition ( QueenBoard. Size - line - 1, column ) + " : " +
								available_cells. ToString ( ) + "/" + 
								affected_cells. Count. ToString ( ) ;
			MoveTooltip. Location	=  pt ;
			MoveTooltip. Visible	=  true ;

			// Start the timer that will hide the tooltip before it become too pregnant to the user
			TooltipTimer. Enabled	=  true ;

			// Remember this cell position for the next call 
			DragDropPosition	=  new CellPosition ( line, column ) ;

		    }


		/// <summary>
		/// Redo the previous move.
		/// </summary>
		private void  Redo ( )
		   {
			Board	b	=  BoardHistory. Redo ( ) ;

			if  ( b  !=  null )
			   { 
				QueenBoard	=  b ;
				RedrawBoard ( ) ;
			    }
		    }


		/// <summary>
		/// Redraws the chessboard and updates statistics ('Data' and 'Coverage' tabs)
		/// </summary>
		/// <param name="resize">When true, also repositions the chessboard according to the current mdi form size</param>
		private void  RedrawBoard ( bool  resize = false )
		   {
			if  ( resize )
				ResizeForm ( ) ;

			BoardPanel. Invalidate ( ) ;
			UpdateStatistics ( ) ;
			UpdateCoverages ( ) ;
		    }


		/// <summary>
		/// Resets the board (clears every move that occurred)
		/// </summary>
		private void  ResetBoard ( )
		   {
			QueenBoard. Reset ( ) ;
			BoardHistory. Clear ( ) ;
			RedrawBoard ( ) ;
		    }


		/// <summary>
		/// Centers the chessboard once its container has been resized.
		/// </summary>
		private void  ResizeForm ( )
		   {
			int		board_size		=  QueenBoard. Size * CELL_SIZE ;
			
			// Vertical headers (line numbers) have a width which depends on the highest line number
			BoardVerticalHeaderWidth	=  BOARD_HEADER_SIZE * ( QueenBoard. Size. ToString ( ). Length ) ;

			// Recompute the size/position of the panel containing the chessboard, taking the board size into account
			BoardPanel. Width		=  board_size + ( BoardVerticalHeaderWidth * 2 ) ;
			BoardPanel. Height		=  board_size + ( BoardHorizontalHeaderHeight * 2 ) ;
			BoardPanel. Left		=  ( ContainerPanel. Width  - BoardPanel. Width ) / 2 ;
			BoardPanel. Top			=  Math.Max ( 0, ( ContainerPanel. Height - BoardPanel. Height ) / 2 ) ;

			// Group of buttons to the right of the chessboard
			BoardRightPanel. Left		=  BoardPanel. Right + 8 ;
			BoardRightPanel. Top		=  BoardPanel. Top + BoardHorizontalHeaderHeight ;

			// Recompute the right panel width (the right panel contains the chessboard whose size has been
			// recomputed above)
			SplitPanel.Panel2MinSize	=  BoardPanel. Width + BoardRightPanel. Width + 8 ;

			// Redefine the minimum size of this Mdi child
			MinimumSize			=  new Size ( SplitPanel. Panel1MinSize + SplitPanel. Panel2MinSize, 
									SplitPanel. Height + TopPanel. Height + 20 ) ;
		    }


		/// <summary>
		/// Undoes the previous move.
		/// </summary>
		private void  Undo ( )
		   {
			Board	b	=  BoardHistory. Undo ( ) ;

			if  ( b  !=  null )
			   { 
				QueenBoard	=  b ;
				RedrawBoard ( ) ;
			    }
		    }


		/// <summary>
		/// Updates the mdi child title according to its initial title (Text property of the Mdi form),
		/// the current chessboard size and the child sequence id.
		/// </summary>
		private void  SetTitle ( )
		   {
			Text	=  DocumentTitle + " " + 
					QueenBoard. Size. ToString ( ) + "x" + QueenBoard. Size. ToString ( ) + " (" +
					DocumentId. ToString ( ) + ")" ;
		    }


		/// <summary>
		/// Updates the content of the Coverage tab.
		/// </summary>
		private void  UpdateCoverages ( )
		   {
			List<CellCoverage>	coverages	=  QueenBoard. GetCoverages ( ) ;
		
			CoverageList. Items. Clear ( ) ;

			// No more cell covered : clear the list, add the verdict and return
			if  ( coverages. Count  ==  0 )
			   { 
				Font				font		=  new Font ( "Consolas", 10, FontStyle. Bold ) ;
				ListViewItem			item		=  new ListViewItem ( "" ) ;
				ListViewItem. ListViewSubItem	subitem	=  new ListViewItem. ListViewSubItem ( item, 
												DataList. Items [DATA_VERDICT]. SubItems [1]. Text ) ;

				item. Font		=  font ;
				item. ForeColor		=  DataList. Items [DATA_VERDICT]. SubItems [1]. ForeColor ;
				item. SubItems. Add ( subitem ) ;

				CoverageList. Items. Add ( item ) ;

				CoverageLabel. Visible	=  false ;
				CoverageCount. Visible	=  false ;

				return ;
			    }

			// Covered cell have been found
			CoverageList. LockWindowUpdate ( true ) ;
			CoverageLabel. Visible	=  true ;
			CoverageCount. Visible	=  true ;
			    
			// Sort the coverage results by : 1) coverage, 2) column, 3) line
			coverages. Sort 
			   ( 
				( a, b ) => 
				   {
					int	coverage_cmp	=  a. Coverage - b. Coverage ;

					if  ( coverage_cmp  ==  0 )
					   {
						int	column_cmp	=  a. Column - b. Column ;

						if  ( column_cmp  ==  0 )
							return ( a. Line - b. Line ) ;
						else
							return ( column_cmp ) ;
					    }
					else
						return ( coverage_cmp ) ;
				    }
			    ) ;

			// Group consecutive covered cells
			int	start_column	=  coverages [0]. Column,
				start_line	=  coverages [0]. Line,
				end_line	=  coverages [0]. Line ;
			int	count		=  coverages [0]. Coverage ;
			int	coverage_count	=  coverages. Count ;


			for ( int  i = 1 ; i  < coverage_count ; i ++ )
			   {
				CellCoverage	coverage	=  coverages [i] ;

				// If :
				// - The current coverage is different from the previous one OR
				// - The current column differs from the starting column OR
				// - The current line is not consecutive to the previous one
				// Then add a line in the coverage listbox using current statistics (coverage and
				// start/end line numbers). Column will be the same, since it was a sort criteria above
				if  ( coverage. Coverage  !=  count  ||  
						coverage. Column  !=  start_column  ||  
						coverage. Line  >  end_line + 1 )
				   {
					__add_range ( count, start_column, start_line, end_line ) ;

					// Once added, start with a new coverage/column/line
					start_column	=  coverage. Column ;
					start_line	=
					end_line	=  coverage. Line ;
					count		=  coverage. Coverage ;
					
				    }
				// No rupture : just collect this line
				else 
					end_line ++ ;
			    }

			// Remaining line range to be added to the coverage list
			__add_range ( count, start_column, start_line, end_line ) ;

			CoverageCount.	Text	=  coverages. Count. ToString ( ) ;
			CoverageList. LockWindowUpdate ( false ) ;
		    }

		// Used by UpdateCoverages() to add a line in the coverage listbox.
		// The first column will be the number of cells covered by the cell [line, column].
		// The second column will be the human-readable cell address ; either a single cell ("a2")
		// or a range ("a1-a8")
		private void  __add_range ( int  count, int  column, int  start_line, int  end_line )
		   {
			string		range	=  QueenBoard. GetStringFromPosition ( QueenBoard. Size - start_line - 1, column ) ;


			if  ( start_line  !=  end_line )
				range	=  QueenBoard. GetStringFromPosition ( QueenBoard. Size - end_line - 1, column ) + "-" + range ;

			Font				font		=  new Font ( "Consolas", 10 ) ;
			ListViewItem			item		=  new ListViewItem ( count. ToString ( ) ) ;
			ListViewItem. ListViewSubItem	subitems	=  new ListViewItem.ListViewSubItem ( item, range ) ;

			item. Font		=  font ;
			item. SubItems. Add ( subitems ) ;

			CoverageList. Items. Add ( item ) ;
		    }


		/// <summary>
		/// Updates the statistics in the Data tab.
		/// </summary>
		private void  UpdateStatistics ( )
		   {
			int		occupied	=  QueenBoard. Occupied,
					available	=  QueenBoard. Available,
					unavailable	=  QueenBoard. Unavailable ;
			int		board_size	=  QueenBoard. Size ;

			DataList. LockWindowUpdate ( true ) ;

			// Statistics
			DataList. Items [ DATA_POSITIONED_CELLS ]. SubItems [1]. Text	=  occupied   . ToString ( ) ;
			DataList. Items [ DATA_FREE_CELLS	]. SubItems [1]. Text	=  available  . ToString ( ) ;
			DataList. Items [ DATA_OCCUPIED_CELLS	]. SubItems [1]. Text	=  unavailable. ToString ( ) ;

			// Verdict : "success" means that all x queens in an x*x chessboard have been positioned ;
			// "failed" means that less than x queens have been position. "There is a bug" exists but
			// should never occur... unless there is a bug in this project's code
			if  ( available  >  0 )
				DataList. Items [DATA_VERDICT]. SubItems [1]. Text		=  "" ;
			else if  ( occupied  ==  board_size )
			   {
				DataList. Items [DATA_VERDICT]. SubItems [1]. Text	=  "Success" ;
				DataList. Items [DATA_VERDICT]. SubItems [1]. ForeColor	=  Color. ForestGreen ;
			    }
			else if  ( unavailable  ==  board_size * board_size )
			   {
				DataList. Items [DATA_VERDICT]. SubItems [1]. Text	=  "Failed" ;
				DataList. Items [DATA_VERDICT]. SubItems [1]. ForeColor	=  Color. DarkRed ;
			    }
			else
			   {
				DataList. Items [DATA_VERDICT]. SubItems [1]. Text	=  "There is a bug..." ;
				DataList. Items [DATA_VERDICT]. SubItems [1]. ForeColor	=  Color. Red ;
			    }

			DataList. LockWindowUpdate ( false ) ;
		    }
		# endregion
	    }
    }
