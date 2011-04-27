using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using GrooveAPI;

namespace Groove_Down
{
	public partial class Logger : UserControl, GrooveAPI.ILog
	{
		public Logger()
		{
			InitializeComponent();			
		}

		public void AddLog(int type, string text)
		{			
			string prefix = "";
			Color color = Color.Black;
			if (LogType.HasFlag(type, LogType.LT_WARNING))
			{
				prefix = "Warning: ";
				color = Color.Goldenrod;
			}
			else if (LogType.HasFlag(type, LogType.LT_ERROR))
			{
				prefix = "Error: ";
				color = Color.OrangeRed;
			}
			else if (LogType.HasFlag(type, LogType.LT_INFO))
			{
				prefix = "Info: ";
				color = Color.DarkGray;
			}
			lblLog.Text = prefix + text;
			lblLog.ForeColor = color;		
		}
	}
}
