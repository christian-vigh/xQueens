/**************************************************************************************************************

    NAME
	Board.cs

    DESCRIPTION
	Implements an x*x matrix.

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


namespace xQueens
   {
	public class Board
	   {
		public enum Cell : byte
		   {
			Free		=  0,
			Occupied	=  1,
			Masked		=  2
		    } 

		public int		Size		{ get ; private set ; }
		public Cell [,]		Cells		{ get ; private set ; }


		public  Board ( int  size = 8 )
		   {
			if  ( size  <  4 )
				throw new ArgumentOutOfRangeException ( "Board size must be at least 4x4" ) ;

			Size		=  size ;
			Cells		=  new Cell [ size, size ] ;
		    }


		private void  CheckBounds ( int  line, int  column )
		   {
			if  ( line  <  0  ||  line  >=  Size )
				throw new ArgumentOutOfRangeException ( "Index  out of range (" + line + ")" ) ;

			if  ( column  <  0  ||  column  >=  Size )
				throw new ArgumentOutOfRangeException ( "Index  out of range (" + column + ")" ) ;
		    }


		public int  GetColumnFromString ( string  column_name )
		   {
			int		c	=  0 ;

			foreach (  char  ch  in  column_name )
				c	=  ( c * 26 ) + ( ( ( int ) ch. ToUpper ( ) ) - ( ( int ) 'A' ) + 1 ) ;

			return ( c - 1 ) ;
		    }


		public string  GetStringFromColumn ( int  column_index )
		   {
			String		result		=  "" ;

			while  ( column_index  >  0 )
			   {
				int	rem	=  ( column_index - 1 ) % 26 ;

				result		=   ( ( char ) ( rem + ( int ) 'A' ) ) + result ;
				column_index	=  ( column_index - rem ) / 26 ;
			    }

			return ( result. ToString ( ) ) ;
		    }


		public bool  GetPositionFromString ( string  coords, out int  line, out int  column )
		   {
			Match	match	=  Regex. Match ( coords, @"(?<column> [a-z]+) (?<line> \d+)", 
						RegexOptions. IgnorePatternWhitespace | RegexOptions. IgnoreCase ) ;

			if  ( match. Success )
			   {
				int	l	=  int. Parse ( match. Groups [ "line" ]. Value ) ;
				int	c	=  GetColumnFromString ( match. Groups [ "column" ]. Value ) ;

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


		public Cell	this [ int  line, int  column ]
		   {
			get
			   {
				CheckBounds ( line, column ) ;

				return ( Cells [ line, column ] ) ;
			    }
		    }



		public void  Put ( string  position )
		   {
			int	line, column ;


			if  ( GetPositionFromString ( position, out line, out column ) )
				Put ( line, column ) ;
			else
				throw new IndexOutOfRangeException ( "Invalid move '" + position + "'" ) ;
		    }


		public void  Put ( int  line, int  column )
		   {
			CheckBounds ( line, column ) ;

			Cells [ line, column ]		=  Cell. Occupied ;

			int	size		=  Size ;
			int	pivot_x_size	=  Math. Min ( column + column, size ),
				pivot_y_size	=  Math. Min ( line + line, size ) ;

			for  ( int  i = 0 ; i  <  size ; i ++ )
			   {
				for  ( int  j = 0 ; j  <  size ; j ++ )
				   {
					bool	is_free		=  ( Cells [i,j]  ==  Cell. Free ) ;

					if  ( is_free )
					   {
						if  ( i  ==  line )
							Cells [i,j]			=  Cell. Masked ;
						else if  ( j  ==  column )
							Cells [i,j]			=  Cell. Masked ;
						else if  ( i - line  ==  j - column )
							Cells [i,j]			=  Cell. Masked ;
						else if  ( i + j  ==  line + column )
							Cells [i,j]			=  Cell. Masked ;
					    }
				    }
			    }
		    }


		public void  Reset ( )
		   {
			for  ( int  i = 0 ; i  <  Size ; i ++ )
			   {
				for  ( int  j = 0 ; j  <  Size ; j ++ )
					Cells [i,j]	=  0 ;
			    }
		    }


		public override string  ToString ( )
		   {
			StringBuilder	result	=  new StringBuilder ( ) ;

			for  ( int  i  =  0 ; i  <  Size ; i ++ )
			   {
				for  ( int  j = 0 ; j  <  Size ; j ++ )
				   {
					switch  ( Cells [i,j] )
					   {
						case	Cell. Free	:  result. Append ( " - " ) ; break ;
						case	Cell. Masked	:  result. Append ( " * " ) ; break ;
						case	Cell. Occupied	:  result. Append ( " Q " ) ; break ;
					    }
				    }

				result. Append ( "\r\n" ) ;
			    }

			return ( result. ToString ( ) ) ;
		    }
	    }
    }
