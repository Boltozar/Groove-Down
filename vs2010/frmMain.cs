using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Groove_Down
{
	public partial class frmMain : Form
	{		
		public frmMain()
		{						
			InitializeComponent();
			InitializeSettings();
			tbQuery.Text = "Connecting...";
			tbQuery.Enabled = false;

			logger.AddLog(GrooveAPI.LogType.LT_INFO, "Groove Down v. " + Program.Version + (IntPtr.Size == 8 ? " 64 bit" : " 32 bit"));
			AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

			_serverChecker = new Thread(serverCheckThread);
			_serverChecker.Start();

			GrooveAPI.Information.Logger = logger;
			GrooveAPI.Information.Results = results;
			GrooveAPI.Information.Progress = dq;

			Program.API = new GrooveAPI.GrooveAPI();
			Program.API.WorkerCompleted += new GrooveAPI.APIWorkerCompletedEventHandler(API_RunWorkerCompleted);			
			Program.API.StartConnect();						
		}		

		void serverCheckThread()
		{
			try
			{
				Server.ServerCheck checker = new Server.ServerCheck();
			}
			catch (Server.ServerException)
			{
				logger.Invoke(new MethodInvoker(()=>
				{
					logger.AddLog(GrooveAPI.LogType.LT_ERROR, "Could not check for updates");
				}));
				return;
			}

			if (Convert.ToDouble(Program.ServerVersion) > Convert.ToDouble(Program.Version))
			{
				logger.Invoke(new MethodInvoker(() =>
				{
					logger.AddLog(GrooveAPI.LogType.LT_INFO, "There is a new version available. (Your version: " + Program.Version + " Server version: " + Program.ServerVersion + ")");											
				}));
			}			
		}

		void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			Exception excp = (Exception)e.ExceptionObject;
			logger.AddLog(GrooveAPI.LogType.LT_ERROR, excp.Message);			
		}

		void API_RunWorkerCompleted(object sender, GrooveAPI.APIWorkerCompletedEventArgs e)
		{
			if (e.Type == GrooveAPI.WorkerType.GAPI_TYPE_DOWNLOADER)
			{
				btnDownloadQueue.Text = "Download";
				dq.ProgressReset();
			}
			else if (e.Type == GrooveAPI.WorkerType.GAPI_TYPE_SEARCHER && GrooveAPI.Information.CurrentResults.Count > 0)
			{
				results.Focus();
			}
			else if (e.Type == GrooveAPI.WorkerType.GAPI_TYPE_CONNECTOR)
			{								
				tbQuery.Enabled = true;
				tbQuery.Text = "";
				tbQuery.Focus();
			}
		}

		private void InitializeSettings()
		{
			uint connects = SettingsManager.Instance.GetSetting("MaxConcurrentDownloads") == "" ? 1 :
				Convert.ToUInt32(SettingsManager.Instance.GetSetting("MaxConcurrentDownloads"));
			string downloadFileNameFormat = SettingsManager.Instance.GetSetting("DownloadFileNameFormat") == "" ? "%artist% - %song%" :
				SettingsManager.Instance.GetSetting("DownloadFileNameFormat");
			string baseDownloadDirectory = SettingsManager.Instance.GetSetting("BaseDownloadDirectory") == "" ? System.IO.Directory.GetCurrentDirectory() :
				SettingsManager.Instance.GetSetting("BaseDownloadDirectory");

			GrooveAPI.Information.MaxConcurrentDownloads	=	connects;
			GrooveAPI.Information.DownloadFileNameFormat	=	downloadFileNameFormat;
			GrooveAPI.Information.BaseDownloadDirectory		=	baseDownloadDirectory;			
		}

		private void tbQuery_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)			
				Search();			
		}

		private void Search()
		{
			if (tbQuery.Text == "")
			{
				logger.AddLog(GrooveAPI.LogType.LT_WARNING | GrooveAPI.LogType.LT_SEARCH, "Nothing to search for");
				return;
			}
			logger.AddLog(GrooveAPI.LogType.LT_INFO, "Searching for " + tbQuery.Text);
			Program.API.StartSearch(tbQuery.Text);
		}

		private void btnSettings_Click(object sender, EventArgs e)
		{
			frmSettingsDialog settings = new frmSettingsDialog();
			settings.ShowDialog(this);			
		}

		private void btnDownloadQueue_Click(object sender, EventArgs e)
		{
			if (dq.RetrieveSongsList().Count == 0)
			{
				logger.AddLog(GrooveAPI.LogType.LT_WARNING | GrooveAPI.LogType.LT_DOWNLOAD, "Nothing to download");
				return;
			}
			if (btnDownloadQueue.Text == "Cancel")
			{				
				Program.API.CancelDownload();
				Program.DownloadsCancelled = true;
				dq.DownloadComplete(new GrooveAPI.GrooveAPI_Song());	
				btnDownloadQueue.Text = "Download";
			}
			else
			{
				Program.DownloadsCancelled = false;
				Program.API.StartDownload(dq.RetrieveSongsList());
				btnDownloadQueue.Text = "Cancel";
			}
		}

		private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
		{
			SettingsManager.Instance.SaveSetting("MaxConcurrentDownloads", GrooveAPI.Information.MaxConcurrentDownloads.ToString());
			SettingsManager.Instance.SaveSetting("DownloadFileNameFormat", GrooveAPI.Information.DownloadFileNameFormat);
			SettingsManager.Instance.SaveSetting("BaseDownloadDirectory", GrooveAPI.Information.BaseDownloadDirectory);			
		}

		private void results_SongChange(object sender, ChangeType type, GrooveAPI.GrooveAPI_Song song)
		{
			dq.AddSong(song);
		}

		private void dq_SongChange(object sender, ChangeType type, GrooveAPI.GrooveAPI_Song song)
		{
			results.AddSong(song);
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			Search();
		}		

		private void searcher_FormClosed(object sender, FormClosedEventArgs e)
		{
			GrooveAPI.Information.Logger = logger;
			GrooveAPI.Information.Results = results;
			GrooveAPI.Information.Progress = dq;
		}

		private void searcher_SelectionAdd(string[] queries)
		{
			foreach (string query in queries)			
				Program.API.StartSearch(query);			
		}

		private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (Program.API.AreDownloadsRunning)
			{
				if (MessageBox.Show(this, "Exiting now will stop all downloads. Continue?", "Warning", MessageBoxButtons.YesNo,
					MessageBoxIcon.Warning) == DialogResult.No)				
					e.Cancel = true;				
			}
		}

		private Thread _serverChecker;
	}
}
