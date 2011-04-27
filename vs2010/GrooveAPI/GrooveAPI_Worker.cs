using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace GrooveAPI
{
	public enum WorkerType { GAPI_TYPE_CONNECTOR, GAPI_TYPE_SEARCHER, GAPI_TYPE_DOWNLOADER, GAPI_TYPE_DOWNLOAD_WORKER };

	public class APIWorkerCompletedEventArgs
	{
		public WorkerType Type;
		public RunWorkerCompletedEventArgs Args;
	}

	public delegate void APIWorkerCompletedEventHandler(object sender, APIWorkerCompletedEventArgs e);	

	abstract class GrooveAPI_Worker : BackgroundWorker
	{
		public GrooveAPI_Worker()
		{
			WorkerSupportsCancellation = true;							
		}

		protected void Log(int type, string text)
		{
			Helpers.ThreadNeutralAction(InterfaceType.IT_LOG, new MethodInvoker(delegate { Information.Logger.AddLog(type, text); }));
		}				

		protected abstract WorkerType GetWorkerType();

		protected override void  OnRunWorkerCompleted(RunWorkerCompletedEventArgs e)
		{			
			if (e.Error != null)
			{
				switch (GetWorkerType())
				{
					case WorkerType.GAPI_TYPE_CONNECTOR:
						Log(LogType.LT_CONNECT | LogType.LT_ERROR, e.Error.Message);
						break;
					case WorkerType.GAPI_TYPE_DOWNLOAD_WORKER:
					case WorkerType.GAPI_TYPE_DOWNLOADER:
						Log(LogType.LT_DOWNLOAD | LogType.LT_ERROR, e.Error.Message);
						break;
					case WorkerType.GAPI_TYPE_SEARCHER:
						Log(LogType.LT_SEARCH | LogType.LT_ERROR, e.Error.Message);
						break;
				}
			}
			if (e.Cancelled)
			{
				switch (GetWorkerType())
				{
					case WorkerType.GAPI_TYPE_CONNECTOR:
						Log(LogType.LT_CONNECT | LogType.LT_WARNING, "Connect cancelled.");
						break;					
					case WorkerType.GAPI_TYPE_DOWNLOADER:
						Log(LogType.LT_DOWNLOAD | LogType.LT_WARNING, "Download cancelled.");						
						break;
					case WorkerType.GAPI_TYPE_SEARCHER:
						Log(LogType.LT_SEARCH | LogType.LT_ERROR, "Search cancelled.");
						break;
				}
			}

			if (APIWorkerCompleted != null)
				APIWorkerCompleted(this, new APIWorkerCompletedEventArgs { Args = e, Type = GetWorkerType() });

			base.OnRunWorkerCompleted(e);
		}


		public event APIWorkerCompletedEventHandler APIWorkerCompleted;
	}
}
