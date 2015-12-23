/**************************************************************************************************************

    NAME
	xQueens.cs

    DESCRIPTION
	xQueens main window.

    AUTHOR
	Christian Vigh, 12/2015.

    HISTORY
	[Version : 1.0]		[Date : 2015/12/21]     [Author : CV]
		Initial version.

 **************************************************************************************************************/
using	System ;
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
	public partial class  xQueens	:  Form
	    {
		private	List<Form>	ChildForms			=  new List<Form> ( ) ;
		private int		NextChildId			=  1 ;

		internal Color		WhiteCellBackgroundColor	=  Color. FromArgb ( 0xFF, 0xCE, 0x9E ) ;
		internal Color		BlackCellBackgroundColor	=  Color. FromArgb ( 0xD1, 0x8B, 0x47 ) ;
		internal Color		GrayCellBackgroundColor		=  Color. FromArgb ( 0xDD, 0xDD, 0xDD ) ;


		public xQueens ( )
		   {
			InitializeComponent ( ) ;
		    }


		/// <summary>
		/// Closes the application.
		/// </summary>
		private void  MainMenuExitItem_Click  ( object  sender, EventArgs  e )
		   {
			Close ( ) ;
		    }


		/// <summary>
		/// Creates an xQueenPlayer form
		/// </summary>
		private void  MainMenuPlayItem_Click  ( object  sender, EventArgs  e )
		   {
			xQueenPlayer  form		=  new xQueenPlayer ( this ) ;

			ChildForms. Add ( form ) ;
			form. Show ( ) ;
		    }
	    }
    }
