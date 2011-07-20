using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace GrooveAPI
{
	class GrooveAPI_Download : GrooveAPI_Worker
	{
		protected override WorkerType GetWorkerType()
		{
			return WorkerType.GAPI_TYPE_DOWNLOADER;
		}
		protected override void OnDoWork(DoWorkEventArgs e)
		{
			if (!Information.Connected)			
				Log(LogType.LT_DOWNLOAD | LogType.LT_ERROR, "Not connected to Grooveshark");			
			else
			{
				int i = 0;
				foreach (GrooveAPI_Song song in Songs)
				{
					if (!_RetrieveDownloadURL(song))
						Log(LogType.LT_DOWNLOAD | LogType.LT_ERROR,
							"Could not retrieve download location for: " + Helpers.CalculateFileName(song));
					else if(i++ < Information.MaxConcurrentDownloads)
						StartNextDownload();
				}												
				while (!_finished)
				{
					if (CancellationPending)
					{
						foreach (GrooveAPI_DownloadWorker worker in _downloaders)
							worker.CancelAsync();
						e.Cancel = true;
						break;
					}
					Thread.Sleep(100);
				}
			}
		}
		private void StartNextDownload()
		{
			if (_downloadIndex >= Songs.Count || _downloadIndex > _streamKeys.Count)			
				_finished = true;							
			else
				RunNewDownloadWorker(_streamServers[_downloadIndex], _streamKeys[_downloadIndex], Songs[_downloadIndex++]);
		}
		private void RunNewDownloadWorker(string server, string streamkey, GrooveAPI_Song song)
		{
			GrooveAPI_DownloadWorker worker = new GrooveAPI_DownloadWorker(server, streamkey, song);
			worker.ProgressChanged += new ProgressChangedEventHandler(_WorkerProgressChanged);
			worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_WorkerCompleted);
			worker.RunWorkerAsync();
			Helpers.ThreadNeutralAction(InterfaceType.IT_PROGRESS,
				new MethodInvoker(() => { Information.Progress.DownloadBeginning(song); }));
			Log(LogType.LT_DOWNLOAD | LogType.LT_INFO, "Downloading " + Helpers.CalculateFileName(song));
			_downloaders.Add(worker);
		}
		void _WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (CancellationPending)
				return;
			GrooveAPI_DownloadWorker worker = (GrooveAPI_DownloadWorker)sender;
			GrooveAPI_Song song = worker.Song;
			if (!e.Cancelled)
			{
				Log(LogType.LT_DOWNLOAD | LogType.LT_INFO, "Download " + Helpers.CalculateFileName(song) + " completed");				
				StartNextDownload();
			}
			Helpers.ThreadNeutralAction(InterfaceType.IT_PROGRESS,
					new MethodInvoker(() => { Information.Progress.DownloadComplete(song); }));
		}
		void _WorkerProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			GrooveAPI_DownloadWorker worker = (GrooveAPI_DownloadWorker)sender;
			object[] numbers = (object[])e.UserState;
			Helpers.ThreadNeutralAction(InterfaceType.IT_PROGRESS,
				new MethodInvoker(() => { Information.Progress.ProgressUpdate(worker.Song, Convert.ToInt32(numbers[0]), Convert.ToInt32(numbers[1])); }));
		}
		private bool _RetrieveDownloadURL(GrooveAPI_Song song)
		{
			GrooveJSON JSON = new GrooveJSON();

			JSON.WriteHeader("getStreamKeyFromSongIDEx", true);

			Dictionary<string, object> dlParams = new Dictionary<string, object>();

			dlParams.Add("prefetch", false);
			dlParams.Add("songID", song.ID.Song);
			dlParams.Add("country", null);
			dlParams.Add("mobile", false);

			JSON.WriteParameters(dlParams);
			JSON.WriteMethod("getStreamKeyFromSongIDEx");
			JSON.WriteFinish();

			string postJSON = JSON.ToString();

			HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://cowbell.grooveshark.com/more.php?getStreamKeyFromSongIDEx");

			req.Method = "POST";
			req.ContentLength = postJSON.Length;
			req.ContentType = "application/json";


			System.IO.Stream postWriteStream = req.GetRequestStream();

			byte[] writeBuf = Encoding.ASCII.GetBytes(postJSON);

			postWriteStream.Write(writeBuf, 0, writeBuf.Length);

			postWriteStream.Close();

			HttpWebResponse res = (HttpWebResponse)req.GetResponse();

			System.IO.Stream readStream = res.GetResponseStream();

			string responseJSON = "";

			System.IO.StreamReader streamReader = new System.IO.StreamReader(readStream);

			responseJSON = streamReader.ReadToEnd();

			streamReader.Close();
			res.Close();			

			Dictionary<string, object> ResponseDictionary = JSON.Read(responseJSON);
			Dictionary<string, object> ResultsDictionary = new Dictionary<string, object>();
			try
			{
				ResultsDictionary = (Dictionary<string, object>)ResponseDictionary["result"];
			}
			catch (Exception)
			{
				return false;
			}
			try
			{
				_streamKeys.Add(ResultsDictionary["streamKey"].ToString());
				_streamServers.Add(ResultsDictionary["ip"].ToString());
			}
			catch (Exception)
			{
				return false;
			}
			
			if (_streamServers.Last() == "" || _streamKeys.Last() == "")
				return false;

			return true;
		}		

		public List<GrooveAPI_Song> Songs { get { return _songs; } }

		private bool _finished = false;
		private int _downloadIndex = 0;		
		private List<GrooveAPI_DownloadWorker> _downloaders = new List<GrooveAPI_DownloadWorker>();		
		private List<GrooveAPI_Song> _songs = new List<GrooveAPI_Song>();
		private List<string> _streamKeys = new List<string>();
		private List<string> _streamServers = new List<string>();
	}
}
