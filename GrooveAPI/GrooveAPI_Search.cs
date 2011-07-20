using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.ComponentModel;
using System.Windows.Forms;

namespace GrooveAPI
{
	class GrooveAPI_Search : GrooveAPI_Worker
	{
		public GrooveAPI_Search() : base()
		{
			WorkerSupportsCancellation = false;
		}
		protected override WorkerType GetWorkerType()
		{
			return WorkerType.GAPI_TYPE_SEARCHER;
		}
		protected override void OnDoWork(DoWorkEventArgs e)
		{			
			if (!Information.Connected)
				Log(LogType.LT_ERROR | LogType.LT_SEARCH, "Not connected to Grooveshark");
			else
			{
				_searchString = e.Argument.ToString();
				int found = 0;
				if ((found = _Search()) == -1)
					Log(LogType.LT_ERROR | LogType.LT_SEARCH, "Could not search for " + _searchString);
				else
				{
					if (found == 0)				
						Log(LogType.LT_WARNING | LogType.LT_SEARCH, "Found no results for " + _searchString);					
					else if (found == 1)
						Log(LogType.LT_INFO | LogType.LT_SEARCH, "Found 1 result for " + _searchString);
					else
						Log(LogType.LT_INFO | LogType.LT_SEARCH, "Found " + found.ToString() + " results for " + _searchString);
					Helpers.ThreadNeutralAction(InterfaceType.IT_RESULTS,
						new MethodInvoker(() => { Information.Results.ResultUpdateNotification(); }));
				}
			}			
		}
		private int _Search()
		{
			try
			{
				GrooveJSON JSON = new GrooveJSON();

				JSON.WriteHeader("getSearchResultsEx");

				Dictionary<string, object> searchParams = new Dictionary<string, object>();

				searchParams.Add("query", _searchString);
				searchParams.Add("type", "Songs");
        searchParams.Add("guts", 0);
        searchParams.Add("ppOverride", false);

				JSON.WriteParameters(searchParams);
				JSON.WriteMethod("getSearchResultsEx");
				JSON.WriteFinish();

				string postJSON = JSON.ToString();

				HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://cowbell.grooveshark.com/more.php?getSearchResultsEx");

				req.Method = "POST";
				req.ContentLength = postJSON.Length;
				req.ContentType = "application/json";
				req.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate");

				System.IO.Stream postWriteStream = req.GetRequestStream();

				byte[] writeBuf = Encoding.ASCII.GetBytes(postJSON);

				postWriteStream.Write(writeBuf, 0, writeBuf.Length);

				postWriteStream.Close();

				HttpWebResponse res = (HttpWebResponse)req.GetResponse();

				System.IO.Compression.GZipStream decompress =
					new System.IO.Compression.GZipStream(res.GetResponseStream(), System.IO.Compression.CompressionMode.Decompress);

				string responseJSON = "";

				System.IO.StreamReader decompressRead = new System.IO.StreamReader(decompress, Encoding.ASCII);

				responseJSON = decompressRead.ReadToEnd();
				
				decompressRead.Close();
				decompress.Close();
				res.Close();

				Dictionary<string, object> ResponseDictionary = JSON.Read(responseJSON);

				return _ParseResponse(ResponseDictionary);				
			}
			catch (Exception)
			{
				return -1;
			}			
		}
		private int _ParseResponse(Dictionary<string, object> res)
		{
			if (res.ContainsKey("result"))
			{
				Dictionary<string, object> resultSubdict = (Dictionary<string, object>)res["result"];
				if (resultSubdict.ContainsKey("result"))
				{
					Information.CurrentResults.Clear();
					int count = 0;
					object[] songs = (object[])resultSubdict["result"];
					foreach (object song in songs)
					{
						Dictionary<string, object> songDict = (Dictionary<string, object>)song;
						GrooveAPI_Song songData;
						songData.ID.Song = Convert.ToInt32(songDict["SongID"]);
						songData.ID.Album = Convert.ToInt32(songDict["AlbumID"]);
						songData.ID.Artist = Convert.ToInt32(songDict["ArtistID"]);							
						songData.Name.Song = songDict["SongName"].ToString();
						songData.Name.Album = songDict["AlbumName"].ToString();
						songData.Name.Artist = songDict["ArtistName"].ToString();
						songData.Popularity.Song = Convert.ToDouble(songDict["Popularity"]);
						songData.Popularity.Album = Convert.ToDouble(songDict["AlbumPopularity"]);
						songData.Popularity.Artist = Convert.ToDouble(songDict["ArtistPopularity"]);
						songData.Verification.General = Convert.ToInt32(songDict["IsVerified"]) == 1 ? true : false;
            // These no longer exist...
            songData.Verification.Song = false;
            songData.Verification.Album = false;
            songData.Verification.Artist = false;
            // ------------------------
						songData.Misc.CoverArtFileName = songDict["CoverArtFilename"].ToString();
						
						string tracknum = songDict["TrackNum"].ToString() == "" ? "0" : songDict["TrackNum"].ToString();
						string year = songDict["Year"].ToString() == "" ? "0" : songDict["Year"].ToString();

						songData.Misc.TrackNum = Convert.ToInt32(tracknum);
						songData.Misc.Year = Convert.ToInt32(year);
						Information.CurrentResults.Add(songData.ID.Song, songData);
						count++;										
					}	
					return count;
				}
				else
					return -1;
			}
			else
				return -1;
		}

		private string _searchString;
	}
}
