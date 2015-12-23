/**************************************************************************************************************

    NAME
	Program.cs

    DESCRIPTION
	Main program.

    AUTHOR
	Christian Vigh, 12/2015.

    HISTORY
	[Version : 1.0]		[Date : 2015/12/21]     [Author : CV]
		Initial version.

 **************************************************************************************************************/
using	System ;
using	System. Collections. Generic ;
using	System. Linq ;
using	System. Threading. Tasks ;
using	System. Windows. Forms ;


namespace xQueens
   {
	static class Program
	   {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main ( )
		   {
			Application. EnableVisualStyles ( ) ;
			Application. SetCompatibleTextRenderingDefault ( false ) ;
			Application. Run ( new xQueens ( ) ) ;
		    }
	    }
    }
