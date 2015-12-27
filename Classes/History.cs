/**************************************************************************************************************

    NAME
	History.cs

    DESCRIPTION
	Implements a chessboard move history.

    AUTHOR
	Christian Vigh, 12/2015.

    HISTORY
	[Version : 1.0]		[Date : 2015/12/25]     [Author : CV]
		Initial version.

 **************************************************************************************************************/
using	System ;
using	System. Collections. Generic ;
using	System. Linq ;
using	System. Text ;
using	System. Text. RegularExpressions ;
using	System. Threading. Tasks ;

using	Thrak. Types ;


namespace ChessBoard
   {
	public class History
	   {
		// List of moves
		private	List<CellPosition>	List		=  new List<CellPosition> ( ) ;
		// List top - may be < list size if undos have been made without adding new moves
		private int			ListTop		=  0 ;
		// Board size for this history
		private int			BoardSize ;


		/// <summary>
		/// Creates a history for a board of the specified size.
		/// </summary>
		public History ( int  board_size )
		   { 
			BoardSize	=  board_size ;
		    }


		/// <summary>
		/// Adds a move (cell position) to the history.
		/// </summary>
		public void  Add  ( CellPosition  position )
		   {
			if  ( ListTop  <  List. Count )
				List. RemoveRange ( ListTop, List. Count - ListTop ) ;

			List. Add ( position ) ;
			ListTop ++ ;
		    }


		/// <summary>
		/// Adds a move (line/column) to the history.
		/// </summary>
		public void  Add ( int  line, int  column )
		   {
			Add ( new CellPosition ( line, column ) ) ;
		    }


		/// <summary>
		/// Clears history content.
		/// </summary>
		public void  Clear ( )
		   {
			List. Clear ( ) ;
		    }


		/// <summary>
		/// Undoes the previous move.
		/// The undone move can be recovered using Redo() if no new history entries have been added.
		/// </summary>
		public Board  Undo ( )
		   {
			if  ( ListTop  >  0 )
			   {
				ListTop -- ;

				return  ( ToChessboard ( ) ) ;
			    }
			else
				return ( null ) ;
		    }


		/// <summary>
		/// Undoes an undone move...
		/// </summary>
		public Board  Redo ( )
		   {
			if  ( ListTop  <  List. Count )
			   {
				ListTop ++ ;

				return  ( ToChessboard ( ) ) ;
			    }
			else
				return ( null ) ;
		    }


		/// <summary>
		/// Retrieves a chessboard built from the moves performed until the current list top
		/// (which may be less than the number of history entries).
		/// </summary>
		public Board  ToChessboard ( )
		   {
			Board	board	=  new Board ( BoardSize ) ;

			for  ( int  i = 0 ; i  < ListTop ; i ++ )
				board. Move ( List [i]. Line, List [i]. Column ) ;

			return ( board ) ;
		    }
	    }
    }
