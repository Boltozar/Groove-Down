using System;
using System.Net;
using System.ComponentModel;
using System.Text;

namespace GrooveAPI
{
	class GrooveAPI_DownloadWorker : GrooveAPI_Worker
	{
		public GrooveAPI_DownloadWorker(string downloadURL, string streamKey, GrooveAPI_Song song)
		{			
			_downloadURL = "http://" + downloadURL + "/stream.php";
			_streamKey = streamKey;
			_song = song;
			_fileName = Helpers.CalculateFileName(song);
			try
			{
				System.IO.Directory.CreateDirectory(Information.BaseDownloadDirectory + _fileName.Substring(0, _fileName.LastIndexOf('\\') + 1));
			}
			catch (Exception)
			{
				Log(LogType.LT_DOWNLOAD | LogType.LT_ERROR, "Could not download to directory" + Information.BaseDownloadDirectory);				
				Dispose();
			}
		}
		protected override WorkerType GetWorkerType()
		{
			return WorkerType.GAPI_TYPE_DOWNLOAD_WORKER;
		}
		protected override void OnDoWork(DoWorkEventArgs e)
		{
			HttpWebRequest req = (HttpWebRequest)WebRequest.Create(_downloadURL);

			string postKey = "streamKey=" + _streamKey;

			req.Method = "POST";
			req.ContentLength = postKey.Length;
			req.ContentType = "application/x-www-form-urlencoded";

			System.IO.Stream postWriteStream = req.GetRequestStream();

			postWriteStream.Write(Encoding.ASCII.GetBytes(postKey), 0, Encoding.ASCII.GetBytes(postKey).Length);

			postWriteStream.Close();

			HttpWebResponse res = (HttpWebResponse)req.GetResponse();

			System.IO.Stream responseStream = res.GetResponseStream();

			
			string directoryModifier = Information.BaseDownloadDirectory + 
				(_fileName.LastIndexOf('\\') == -1 ? "" : _fileName.Substring(0, _fileName.LastIndexOf('\\') + 1));
			string actualFile = directoryModifier + (_fileName.LastIndexOf('\\') == -1 ? _fileName : _fileName.Substring(_fileName.LastIndexOf('\\')+1));

			System.IO.FileStream fs = new System.IO.FileStream(actualFile,				
				System.IO.FileMode.Create, System.IO.FileAccess.Write);
			System.IO.BinaryWriter writer = new System.IO.BinaryWriter(fs);
			int bytesRead = 0;
			int count = 0;
			byte[] buf = new byte[8192];
			while ((bytesRead = responseStream.Read(buf, 0, buf.Length)) > 0)
			{
				count += bytesRead;
				object[] numbers = new object[2]{count, res.ContentLength};
				OnProgressChanged(new ProgressChangedEventArgs(0, numbers));
				writer.Write(buf, 0, bytesRead);
				if (CancellationPending)
				{
					writer.Close();
					System.IO.File.Delete(actualFile);
					e.Cancel = true;
					break;
				}
			}
			responseStream.Close();
			writer.Close();
			res.Close();									
		}

		public GrooveAPI_Song Song { get { return _song; } }
		private string _downloadURL = "";
		private string _streamKey = "";
		private string _fileName = "";
		private GrooveAPI_Song _song;
	}
}