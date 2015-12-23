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
using	System. Linq ;
using	System. Text ;
using	System. Threading. Tasks ;
using	System. Windows. Forms ;


namespace  xQueens
   {
	public partial class  xQueenPlayer : xQueensMdiChild
	   {
		const int		CellSize			=  28,
					BoardHeaderSize			=  16 ;

		// Chess board
		Board			QueenBoard ;
		int			BoardHorizontalHeaderHeight	=  BoardHeaderSize + 2,
					BoardVerticalHeaderWidth	=  BoardHeaderSize ;
		Brush			WhiteCellBrush,
					BlackCellBrush,
					GrayedWhiteCellBrush,
					GrayedBlackCellBrush ;
		Font			BoardNumbersFont	=  new Font ( "Ms Sans Serif", 9 ) ;


		/// <summary>
		/// Initialize a new player window
		/// </summary>
		/// <param name="parent">Mdi container window</param>
		public  xQueenPlayer ( xQueens  parent, int  default_size = 8 ) : base ( parent )
		   {
			InitializeComponent ( ) ;

			QueenBoard		=  new Board ( default_size ) ;
			BoardSizeTextbox. Text	=  default_size. ToString ( ) ;
			AcceptButton		=  null ;
			MoveButton. Enabled	=  false ;

			WhiteCellBrush		=  new SolidBrush ( parent. WhiteCellBackgroundColor ) ;
			BlackCellBrush		=  new SolidBrush ( parent. BlackCellBackgroundColor ) ;
			GrayedWhiteCellBrush	=  new HatchBrush ( HatchStyle. Percent50, parent. GrayCellBackgroundColor, parent. WhiteCellBackgroundColor ) ;
			GrayedBlackCellBrush	=  new HatchBrush ( HatchStyle. Percent50, parent. GrayCellBackgroundColor, parent. BlackCellBackgroundColor ) ;

			ResizeForm ( ) ;
		    }


		/// <summary>
		/// 
		/// </summary>
		private void MoveButton_Click ( object sender, EventArgs e )
		   {
			int	line, column ;
			
			if  ( QueenBoard. GetPositionFromString ( MoveTextbox. Text, out line, out column ) )
			   {
				QueenBoard. Put ( line, column ) ;
				BoardPanel. Invalidate ( ) ;
			    }
			else
				MessageBox. Show ( "Invalid move to '" + MoveTextbox. Text ) ;
		    }


		private void ResetButton_Click ( object sender, EventArgs e )
		   { 
			QueenBoard. Reset ( ) ; 
			BoardPanel. Invalidate ( ) ;
		    }


		private void ChangeBoardSizeButton_Click ( object sender, EventArgs e )
		   {
			int	new_size ;

			if  ( ! int. TryParse ( BoardSizeTextbox. Text, out new_size )  ||  new_size  <  4 )
			   {
				MessageBox. Show ( "Invalid board size" ) ;
				BoardSizeTextbox. Focus ( ) ;
			    }
			else
			   {
				QueenBoard	=  new Board ( new_size ) ;
				ResizeForm ( ) ;
				BoardPanel. Invalidate ( ) ;
			    }
		    }


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

		
		private void  ChessPanel_Paint ( object  sender, PaintEventArgs  e )
		   {
			base. OnPaint ( e ) ;
			DrawChessboard ( e. Graphics ) ;
		    }


		private void xQueenPlayer_Resize ( object sender, EventArgs e )
		   { ResizeForm ( ) ; }


		private void MoveTextbox_Enter ( object sender, EventArgs e )
		   { 
			SelectText ( ( TextBox ) sender ) ; 
			AcceptButton = MoveButton ; 
		    }

		private void BoardSizeTextbox_Enter ( object sender, EventArgs e )
		   { 
			SelectText ( ( TextBox ) sender ) ; 
			AcceptButton = ChangeBoardSizeButton ; 
		    }

		private void MoveTextbox_Click ( object sender, EventArgs e )
		   { 
			SelectText ( ( TextBox ) sender ) ; 
			AcceptButton = MoveButton ; 
		    }

		private void BoardSizeTextbox_Click ( object sender, EventArgs e )
		   { 
			SelectText ( ( TextBox ) sender ) ; 
			AcceptButton = ChangeBoardSizeButton ; 
		    }
		

		private void BoardPanel_DragDrop ( object sender, DragEventArgs e )
		   {
			int	line, column ;

			if  ( CheckIfDroppable ( e, out line, out column ) )
			   {
				QueenBoard. Put ( line, column ) ;
				BoardPanel. Invalidate ( ) ;
			    }

			MoveTextbox. Text	=  "" ;			
		    }

		private void BoardPanel_DragEnter ( object sender, DragEventArgs e )
		   {
			e. Effect	=  DragDropEffects. Move ;
		    }


		private void BoardPanel_DragLeave ( object sender, EventArgs e )
		   {
			MoveTextbox. Text	=  "" ;
		    }


		private void BoardPanel_DragOver ( object sender, DragEventArgs e )
		   {
			int	line, column ;


			if  ( CheckIfDroppable ( e, out line, out column ) )
				MoveTextbox. Text	=  QueenBoard. GetStringFromColumn ( column + 1 ). ToLower ( ) + 
								( QueenBoard. Size - line ). ToString ( ) ;
			else
				MoveTextbox. Text	=  "" ;
		    }


		private void QueenDragger_MouseDown ( object sender, MouseEventArgs e )
		   {
			DoDragDrop ( Properties. Resources. queen_24x24_white, DragDropEffects. Move ) ;
		    }



		private bool  CheckIfDroppable ( DragEventArgs  e, out int  line, out int  column )
		   {
			Point		pt		=  BoardPanel. PointToClient ( new Point ( e. X, e. Y ) ) ;
			int		board_size	=  QueenBoard. Size * CellSize ;
			Rectangle	board_rect	=  new Rectangle
							     (
								BoardVerticalHeaderWidth,
								BoardHorizontalHeaderHeight,
								board_size, board_size 
							      ) ;

			line = column = -1 ;

			if  ( board_rect. Contains ( pt ) )
			   { 
				column		=  ( pt. X - BoardVerticalHeaderWidth ) / CellSize ;
				line		=  ( pt. Y - BoardHorizontalHeaderHeight ) / CellSize ;

				if  ( QueenBoard [ line, column ]  !=  Board. Cell. Free )
				   {
					e. Effect	=  DragDropEffects. None ;

					return ( false ) ;
				    }
				else
				   { 
					e. Effect	=  DragDropEffects. Move ;

					return ( true ) ;
				    }
			    }
			else
			   {
				e. Effect	=  DragDropEffects. None ;

				return ( false ) ;
			    }
		    }


		private void  DrawChessboard ( Graphics  g )
		   {
			int		board_size	=  QueenBoard. Size ;
			int		count ;
			StringFormat	align_fmt	=  new StringFormat ( ) ;
					

			align_fmt. Alignment	=  StringAlignment. Far ;


			for  ( int  i = 0 ;  i  <  board_size ; i ++ )
			   {
				count	=  ( i % 2 ) ;

				for  ( int  j = 0 ; j  <  board_size ; j ++ )
				   {
					Brush		br ;

					if  ( QueenBoard [ i, j ]  ==  Board. Cell. Masked )
						br	=  ( ( count % 2 )  ==  0 ) ?  GrayedWhiteCellBrush : GrayedBlackCellBrush ;
					else
						br	=  ( ( count % 2 )  ==  0 ) ?  WhiteCellBrush : BlackCellBrush ;

					Point	pt	=  new Point ( ( j * CellSize ) + BoardVerticalHeaderWidth, 
								       ( i * CellSize ) + BoardHorizontalHeaderHeight ) ;

					g. FillRectangle ( br, pt. X, pt. Y, CellSize, CellSize ) ;

					if  ( QueenBoard [ i, j ]  ==  Board. Cell. Occupied )
					   {
						Bitmap		img		=  Properties. Resources. queen_24x24_white ;
						
						pt. X	+=  ( CellSize - img. Width  ) / 2 ;
						pt. Y	+=  ( CellSize - img. Height ) / 2 ;
						
						g. InterpolationMode	=  InterpolationMode. HighQualityBicubic ;

						Rectangle	imgrect		=  new Rectangle ( pt. X, pt. Y, img. Width, img. Height) ;
						
						g. DrawImage ( img, imgrect ) ;
					    }

					count ++ ;
				    }

				RectangleF	rect	=  new RectangleF
							     (
								0, ( i * CellSize ) + CellSize - 6,
								BoardVerticalHeaderWidth - 2, 
								BoardHorizontalHeaderHeight
							      ) ;

				g. DrawString ( ( board_size - i ). ToString ( ), BoardNumbersFont, Brushes. Black, rect, align_fmt ) ;

				rect.	X	=  BoardVerticalHeaderWidth + ( board_size * CellSize ) ;

				g. DrawString ( ( board_size - i ). ToString ( ), BoardNumbersFont, Brushes. Black, rect, align_fmt ) ;
			    }

			align_fmt. Alignment	=  StringAlignment. Center ;

			for  ( int  i = 0 ; i  <  board_size ; i ++ )
			   {
				RectangleF	rect	=  new RectangleF
							     (
								BoardVerticalHeaderWidth + ( i * CellSize ), 0,
								CellSize, 
								BoardHorizontalHeaderHeight
							      ) ;
				
				g. DrawString ( QueenBoard. GetStringFromColumn ( i + 1 ). ToLower ( ), 
							BoardNumbersFont, Brushes. Black, rect, align_fmt ) ;

				rect.	Y	=  BoardHorizontalHeaderHeight + ( board_size * CellSize ) ;

				g. DrawString ( QueenBoard. GetStringFromColumn ( i + 1 ). ToLower ( ), 
							BoardNumbersFont, Brushes. Black, rect, align_fmt ) ;
			    }
		    }


		private void  ResizeForm ( )
		   {
			int		board_size		=  QueenBoard. Size * CellSize ;
			
			
			BoardVerticalHeaderWidth	=  BoardHeaderSize * ( QueenBoard. Size. ToString ( ). Length ) ;

			BoardPanel. Width	=  board_size + ( BoardVerticalHeaderWidth * 2 ) ;
			BoardPanel. Height	=  board_size + ( BoardHorizontalHeaderHeight * 2 ) ;
			BoardPanel. Left	=  ( ContainerPanel. Width  - BoardPanel. Width ) / 2 ;
			BoardPanel. Top		=  Math.Max ( 0, ( ContainerPanel. Height - BoardPanel. Height ) / 2 ) ;

			QueenDragger. Left	=  BoardPanel. Right + 8 ;
			QueenDragger. Top	=  BoardPanel. Top + BoardHorizontalHeaderHeight ;

			MinimumSize		=  new Size ( Math. Max ( 540, board_size ), ContainerPanel. Height + TopPanel. Height + 20 ) ;
		    }


		private void  SelectText ( TextBox  box )
		   { box. SelectAll ( ) ; }

	    }
    }
