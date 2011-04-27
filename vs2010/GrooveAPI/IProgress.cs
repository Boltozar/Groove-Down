using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrooveAPI
{
	public interface IProgress
	{
		void ProgressUpdate(GrooveAPI_Song song, int bytesRead, int totalBytes);
		void DownloadBeginning(GrooveAPI_Song song);
		void DownloadComplete(GrooveAPI_Song song);
	}
}
