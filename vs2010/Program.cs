using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Groove_Down
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{			
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);			
			Application.Run(new frmMain());				
		}

		static public GrooveAPI.GrooveAPI API;
		static public string Version = "1.2";
		static public string ServerVersion = "";				
		static public bool DownloadsCancelled;
	}
}
