using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;

namespace GrooveAPI
{		
	public class GrooveAPI
	{
		public GrooveAPI()
		{
			_ResetWorkers();
		}
		public void StartConnect()
		{
			_ResetWorkers();
			_connector.RunWorkerAsync();
		}
		public void StartSearch(string searchString)
		{
			_ResetWorkers();
			_searcher.RunWorkerAsync(searchString);
		}
		public void StartDownload(GrooveAPI_Song song)
		{
			_ResetWorkers();
			_downloader.Songs.Add(song);
			_downloader.RunWorkerAsync();			
		}
		public void StartDownload(List<GrooveAPI_Song> songs)
		{
			_ResetWorkers();
			_downloader.Songs.AddRange(songs);
			_downloader.RunWorkerAsync();
		}
		public void CancelDownload()
		{
			_downloader.CancelAsync();
		}
		public bool AreDownloadsRunning
		{
			get
			{
				return _downloader.IsBusy;
			}
		}

		void _ResetWorkers()
		{
			if (_connector != null)			
				_connector.Dispose();			
			if (_downloader != null)			
				_downloader.Dispose();			
			if (_searcher != null)		
				_searcher.Dispose();			
			_connector = new GrooveAPI_Connect();
			_connector.APIWorkerCompleted += new APIWorkerCompletedEventHandler(_OnWorkerCompleted);			
			_downloader = new GrooveAPI_Download();
			_downloader.APIWorkerCompleted += new APIWorkerCompletedEventHandler(_OnWorkerCompleted);			
			_searcher = new GrooveAPI_Search();
			_searcher.APIWorkerCompleted += new APIWorkerCompletedEventHandler(_OnWorkerCompleted);
		}

		void _OnWorkerCompleted(object sender, APIWorkerCompletedEventArgs e)
		{
			if (WorkerCompleted != null)
				WorkerCompleted(sender, e);
		}
		
		public event APIWorkerCompletedEventHandler WorkerCompleted;
		GrooveAPI_Connect _connector = null;
		GrooveAPI_Download _downloader = null;
		GrooveAPI_Search _searcher = null;
	}
}
