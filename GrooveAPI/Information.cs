using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrooveAPI
{	

	static class Information
	{
		// Variables in this block are used by the internal API and should not be set otherwise
		static public bool		Connected { get; set; }
		static public string	SessionID { get; set; }
		static public string	Token { get; set; }		

		// Variables in this block are user settings and can be set by anyone and SHOULD BE SET BEFORE USING API
		static public uint		MaxConcurrentDownloads { get; set; }
		static public string	DownloadFileNameFormat { get; set; }
		static public string	BaseDownloadDirectory { get; set; }

		// Variables in this block are interfaces used by the api and must be set before use		
		static public ILog		Logger { get; set; }
		static public IResults	Results { get; set; }
		static public IProgress Progress { get; set; }		

		// Initialization function every parameter must be set before API use
		static public void Initialize(uint maxConcurrentDownloads, string downloadFileNameFormat, string baseDownloadDirectory, ILog logger, IResults results,
			IProgress progress)
		{
			MaxConcurrentDownloads = maxConcurrentDownloads;
			DownloadFileNameFormat = downloadFileNameFormat;
			BaseDownloadDirectory = baseDownloadDirectory;
			Logger = logger;
			Results = results;
			Progress = progress;			
		}

		// CurrentResults is a dictionary of KT: SongID VT: Song Info that can be used by anyone
		static public Dictionary<int, GrooveAPI_Song> CurrentResults { get { return _currentResults; } }


		// Variables in this block are used to communicate with Grooveshark and should not be modified
    static public string GrooveAPISalt { get { return "backToTheScienceLab"; } }
    static public string GrooveAPISaltDownload { get { return "bewareOfBearsharktopus"; } }
		static public string UUID { get { return "260F9811-6DAB-464B-A1F9-23C3E3D5D511"; } }
    static public string ClientRevision { get { return "20110606"; } }		

		// Private initialization
		static private Dictionary<int, GrooveAPI_Song> _currentResults = new Dictionary<int, GrooveAPI_Song>();		
	}
}
