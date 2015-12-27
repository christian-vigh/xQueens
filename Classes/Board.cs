/**************************************************************************************************************

    NAME
	Board.cs

    DESCRIPTION
	Implements an x*x matrix like a chessboard. 
	Note that the index of the top-left element is [0,0], unlike a chessboard, where [x,0] is the index of 
	the bottom-left element.

    AUTHOR
	Christian Vigh, 12/2015.

    HISTORY
	[Version : 1.0]		[Date : 2015/12/21]     [Author : CV]
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
	# region CellType enum
	/// <summary>
	/// Chessboard cell state.
	/// </summary>
	public enum CellType : byte
	   {
		/// <summary>
		/// Cell is free.
		/// </summary>
		Free		=  0,
		/// <summary>
		/// Cell is occupied by a tile.
		/// </summary>
		Occupied	=  1,
		/// <summary>
		/// Cell is not occupied but is attacked by a tile in its neighborhood.
		/// </summary>
		Masked		=  2
	    } 
	# endregion

	# region CellPosition class
	/// <summary>
	/// Implements a cell position in the chessboard.
	/// </summary>
	public class  CellPosition
	   {
		// Line and column index, starting from zero
		public int		Line,
					Column ;

		/// <summary>
		/// Creates a cell position object, using the specified string position (eg, "a8", "b2")
		/// </summary>
		public CellPosition ( string  position )
		   { GetPositionFromString ( position, out Line, out Column ) ; }

		/// <summary>
		/// Creates a cell position object using the specified line and column.
		/// </summary>
		public CellPosition ( int  line, int  column )
		   {
			Line		=  line ;
			Column		=  column ;
		    }


		/// <summary>
		/// Given a column name ("a", "ab"), returns its column index.
		/// </summary>
		public static int  GetColumnFromString ( string  column_name )
		   {
			int		c	=  0 ;

			foreach (  char  ch  in  column_name )
				c	=  ( c * 26 ) + ( ( ( int ) ch. ToUpper ( ) ) - ( ( int ) 'a' ) + 1 ) ;

			return ( c - 1 ) ;
		    }


		/// <summary>
		/// Converts a column index to a column name (eg, "a" gives 0, "b" gives 1, "aa" gives 26, etc.).
		/// </summary>
		public static string  GetStringFromColumn ( int  column_index )
		   {
			String		result		=  "" ;

			column_index ++ ;

			while  ( column_index  >  0 )
			   {
				int	rem	=  ( column_index - 1 ) % 26 ;

				result		=   ( ( char ) ( rem + ( int ) 'a' ) ) + result ;
				column_index	=  ( column_index - rem ) / 26 ;
			    }

			return ( result. ToString ( ) ) ;
		    }


		/// <summary>
		/// Retrieves a line/column position from a string of the form : "xy", where "x" is the column name and
		/// "y" the line number.
		/// The coordinate "a1" represents the bottom left cell.
		/// </summary>
		public static bool  GetPositionFromString ( string  coords, out int  line, out int  column )
		   {
			Match	match	=  Regex. Match ( coords, @"(?<column> [a-z]+) (?<line> \d+)", 
						RegexOptions. IgnorePatternWhitespace | RegexOptions. IgnoreCase ) ;

			if  ( match. Success )
			   {
				line	=  int. Parse ( match. Groups [ "line" ]. Value ) ;
				column	=  GetColumnFromString ( match. Groups [ "column" ]. Value ) ;

				return ( true ) ;
			    }

			line	=  column	=  -1 ;

			return ( false ) ;
		    }


		/// <summary>
		/// Returns a string position from a line/column index.
		/// </summary>
		public static string   GetStringFromPosition ( int  line, int  column )
		   {
			return ( GetStringFromColumn ( column + 1 ) + ( line + 1 ). ToString ( ) ) ;
		    }
	    }
	# endregion

	# region CellCoverage class
	/// <summary>
	/// Implements a cell position with the number of cells covered by this position.
	/// This class is mainly used for information retrieval.
	/// </summary>
	public class  CellCoverage	:  CellPosition
	   {
		public int	Coverage ;


		public CellCoverage ( string  position, int  coverage ) : base ( position )
		   { Coverage = coverage ; }
		 
		public CellCoverage ( int  line, int  column, int  coverage ) : base ( line, column )
		   { Coverage = coverage ; }
	    }
	# endregion

	# region Board class
	/// <summary>
	/// Implements a chessboard.
	/// </summary>
	public class Board
	   {
		/// <summary>
		/// Gets the board size.
		/// </summary>
		public int			Size		{ get ; private set ; }
		/// <summary>
		/// Gets the board cells.
		/// </summary>
		public CellType [,]		Cells		{ get ; private set ; }
		/// <summary>
		/// List of moves performed so far.
		/// </summary>
		public List<CellPosition>	Moves		{ get ; private set ; }


		/// <summary>
		/// Creates a chessboard of the specified size.
		/// </summary>
		/// <param name="size"></param>
		public  Board ( int  size = 8 )
		   {
			if  ( size  <  4 )
				throw new ArgumentOutOfRangeException ( "Board size must be at least 4x4" ) ;

			Size		=  size ;
			Cells		=  new CellType [ size, size ] ;
			Reset ( ) ;
		    }


		/// <summary>
		/// Resets the board.
		/// </summary>
		public void  Reset ( )
		   {
			for  ( int  i = 0 ; i  <  Size ; i ++ )
			   {
				for  ( int  j = 0 ; j  <  Size ; j ++ )
					Cells [i,j]	=  CellType. Free ;
			    }

			Moves	=  new List<CellPosition> ( ) ;
		    }


		# region String position <-> line/column position conversion functions
		/// <summary>
		/// Retrieves a column index from a column name.
		/// </summary>
		public int  GetColumnFromString ( string  column_name )
		   { return ( CellPosition. GetColumnFromString ( column_name ) ) ; }


		/// <summary>
		/// Retrieves a column name from a column index.
		/// </summary>
		public string  GetStringFromColumn ( int  column_index )
		   { return ( CellPosition. GetStringFromColumn ( column_index ) ) ; }


		/// <summary>
		/// Retrieves a line/column position from a string.
		/// </summary>
		public bool  GetPositionFromString ( string  coords, out int  line, out int  column )
		   {
			Match	match	=  Regex. Match ( coords, @"(?<column> [a-z]+) (?<line> \d+)", 
						RegexOptions. IgnorePatternWhitespace | RegexOptions. IgnoreCase ) ;

			if  ( match. Success )
			   {
				int	l	=  int. Parse ( match. Groups [ "line" ]. Value ) ;
				int	c	=  CellPosition. GetColumnFromString ( match. Groups [ "column" ]. Value ) ;

				if  ( l  >  0 )
				   { 
					line		=  Size - l ;
					column		=  c ;

					return ( true ) ;
				    }
			    }

			line	=  column	=  -1 ;

			return ( false ) ;
		    }


		/// <summary>
		/// Retrieves a string from a line/column position.
		/// </summary>
		public string  GetStringFromPosition ( int  line, int  column )
		   {
			string		result		=  GetStringFromColumn ( column ) ;

			result	+=  ( line + 1 ). ToString ( ) ;

			return ( result ) ;
		    }
		# endregion

		# region Properties
		/// <summary>
		/// Gets a cell content.
		/// </summary>
		public CellType	this [ int  line, int  column ]
		   {
			get
			   {
				CheckBounds ( line, column ) ;

				return ( Cells [ line, column ] ) ;
			    }
		    }


		/// <summary>
		/// Returns the number of occupied cells.
		/// </summary>
		public int  Occupied
		   {
			   get { return ( SelectCountByType ( CellType. Occupied ) ) ; }
		    }


		/// <summary>
		/// Returns the number of cells attacked by occupied cells.
		/// </summary>
		public int  Masked
		   {
			   get { return ( SelectCountByType ( CellType. Masked ) ) ; }
		    }


		/// <summary>
		/// Returns the number of free cells.
		/// </summary>
		public int  Available
		   {
			   get { return ( SelectCountByType ( CellType. Free ) ) ; }
		    }


		/// <summary>
		/// Returns the number of non-free cells (either occupied or masked).
		/// </summary>
		public int  Unavailable
		   {
			   get { return ( SelectCountByNotType ( CellType. Free ) ) ; }
		    }
		# endregion

		# region Put functions
		/// <summary>
		/// Puts a tile at the specified string position.
		/// </summary>
		public void  Move ( string  position )
		   {
			int	line, column ;


			if  ( GetPositionFromString ( position, out line, out column ) )
				Move ( line, column ) ;
			else
				throw new IndexOutOfRangeException ( "Invalid move '" + position + "'" ) ;
		    }


		/// <summary>
		/// Puts a tile at the specified line/column position.
		/// </summary>
		public void  Move ( int  line, int  column )
		   {
			CheckBounds ( line, column ) ;

			Cells [ line, column ]		=  CellType. Occupied ;

			int	size		=  Size ;

			for  ( int  i = 0 ; i  <  size ; i ++ )
			   {
				for  ( int  j = 0 ; j  <  size ; j ++ )
				   {
					bool	is_free		=  ( Cells [i,j]  ==  CellType. Free ) ;

					if  ( is_free )
					   {
						if  ( i  ==  line )
							Cells [i,j]			=  CellType. Masked ;
						else if  ( j  ==  column )
							Cells [i,j]			=  CellType. Masked ;
						else if  ( i - line  ==  j - column )
							Cells [i,j]			=  CellType. Masked ;
						else if  ( i + j  ==  line + column )
							Cells [i,j]			=  CellType. Masked ;
					    }
				    }
			    }

			Moves. Add ( new CellPosition ( line, column ) ) ;
		    }
		# endregion

		# region Information retrieval functions
		/// <summary>
		/// Returns the list of cells that will be affected by placing a tile at the specified line/column.
		/// </summary>
		public void  GetAffectedCells ( int  line, int  column, out List<CellPosition>  positions )
		   {
			CheckBounds ( line, column ) ;

			int	size		=  Size ;

			positions	=  new List<CellPosition> ( ) ;

			for  ( int  i = 0 ; i  <  size ; i ++ )
			   {
				for  ( int  j = 0 ; j  <  size ; j ++ )
				   {
					bool	select		=  false ;

					if  ( i  ==  line )
						select	=  true ;
					else if  ( j  ==  column )
						select	=  true ;
					else if  ( i - line  ==  j - column )
						select	=  true ;
					else if  ( i + j  ==  line + column )
						select	=  true ;

					if  ( select )
						positions. Add  ( new CellPosition ( i, j ) ) ;
				    }
			    }
		    }


		/// <summary>
		/// Returns the number of cells affected by putting a tile at the specified line/column.
		/// </summary>
		public int  GetCoverage ( int  line, int  column )
		   {
			int	count		=  0 ;
			int	size		=  Size ;

			
			for  ( int  i = 0 ; i  <  size ; i ++ )
			   {
				for  ( int  j = 0 ; j  <  size ; j ++ )
				   {
					if  ( Cells [i,j]  ==  CellType. Free )
					   { 
						if  ( i  ==  line )
							count ++ ;
						else if  ( j  ==  column )
							count ++ ;
						else if  ( i - line  ==  j - column )
							count ++ ;
						else if  ( i + j  ==  line + column )
							count ++ ;
					    }
				    }
			    }
			
			 return ( count ) ;
		    }


		/// <summary>
		/// For every free cell, returns the coordinates of the cells that would be affected by placing
		/// a tile in it.
		/// </summary>
		public List<CellCoverage>  GetCoverages ( )
		   {
			int			size		=  Size ;
			List<CellCoverage>	result		=  new List<CellCoverage> ( ) ;

			
			for  ( int  i = 0 ; i  <  size ; i ++ )
			   {
				for  ( int  j = 0 ; j  <  size ; j ++ )
				   {
					if  ( Cells [i,j]  ==  CellType. Free )
					   { 
						int	coverage	=  GetCoverage ( i, j ) ;

						result. Add ( new CellCoverage ( i, j, coverage ) ) ;
					    }
				    }
			    }

			return ( result ) ;
		    }
		# endregion

		# region Internal utility functions
		/// <summary>
		/// Checks that the specified position falls within the bounds of the chessboard.
		/// </summary>
		private void  CheckBounds ( int  line, int  column )
		   {
			if  ( line  <  0  ||  line  >=  Size )
				throw new ArgumentOutOfRangeException ( "Index  out of range (" + line + ")" ) ;

			if  ( column  <  0  ||  column  >=  Size )
				throw new ArgumentOutOfRangeException ( "Index  out of range (" + column + ")" ) ;
		    }


		/// <summary>
		/// Counts the number of cells having the specified type.
		/// </summary>
		protected  int  SelectCountByType ( CellType  value )
		   {
			int	count	=  0 ;

			for  ( int  i = 0 ; i  <  Size ; i ++ )
			   {
				for  ( int  j = 0 ; j  <  Size ; j ++ )
				   {
					if  ( Cells [i,j]  ==  value )
						count ++ ; 
				    }
			    }

			return ( count ) ;
		    }


		/// <summary>
		/// Counts the number of cells NOT having the specified type.
		/// </summary>
		protected  int  SelectCountByNotType ( CellType  value )
		   {
			int	count	=  0 ;

			for  ( int  i = 0 ; i  <  Size ; i ++ )
			   {
				for  ( int  j = 0 ; j  <  Size ; j ++ )
				   {
					if  ( Cells [i,j]  !=  value )
						count ++ ; 
				    }
			    }

			return ( count ) ;
		    }
		# endregion

		/// <summary>
		/// Returns an ascii chessboard.
		/// </summary>
		public override string  ToString ( )
		   {
			StringBuilder	result	=  new StringBuilder ( ) ;

			for  ( int  i  =  0 ; i  <  Size ; i ++ )
			   {
				for  ( int  j = 0 ; j  <  Size ; j ++ )
				   {
					switch  ( Cells [i,j] )
					   {
						case	CellType. Free		:  result. Append ( " - " ) ; break ;
						case	CellType. Masked	:  result. Append ( " * " ) ; break ;
						case	CellType. Occupied	:  result. Append ( " Q " ) ; break ;
					    }
				    }

				result. Append ( "\r\n" ) ;
			    }

			return ( result. ToString ( ) ) ;
		    }
	    }
	# endregion
    }
