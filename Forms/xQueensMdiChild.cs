/**************************************************************************************************************

    NAME
	xQueensMdiChild.cs

    DESCRIPTION
	Parent class for all Mdi chid windows.

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
using	System. Linq ;
using	System. Text ;
using	System. Threading. Tasks ;
using	System. Windows. Forms ;


namespace xQueens
   {
	public class xQueensMdiChild	:  Form
	   {
		// A constructor with no argument is required by the Designer.
		public  xQueensMdiChild ( )
		   { }

		public  xQueensMdiChild ( xQueens  parent )
		   {
			MdiParent	=  parent ;
		    }
	    }
    }
