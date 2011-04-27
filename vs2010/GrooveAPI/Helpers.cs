using System;
using System.Text;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GrooveAPI
{
	enum InterfaceType { IT_LOG, IT_PROGRESS, IT_RESULTS };

	static class Helpers
	{
		static public string Hash<T>(string plaintext, T hasher) where T : HashAlgorithm
		{
			string hash = BitConverter.ToString(hasher.ComputeHash(Encoding.ASCII.GetBytes(plaintext))).ToLower();

			string noDashes = "";

			foreach (char ch in hash)
				if (ch != '-')
					noDashes += ch;

			return noDashes;
		}

		static public string CalculateFileName(GrooveAPI_Song song)
		{
			Regex matchData = new Regex("%(song|album|artist|track|year)%", RegexOptions.IgnoreCase);

			return matchData.Replace(Information.DownloadFileNameFormat.ToLower(), new MatchEvaluator((match) =>
			{
				string rtn = "";
				switch (match.Groups[1].Value)
				{
					case "song":
						if (FSValid(song.Name.Song))
							rtn = song.Name.Song.Replace("/", "").Replace("\\", "");
						else
							rtn = "invalid-song-title";
						break;
					case "album":
						if (FSValid(song.Name.Album))
							rtn = song.Name.Album.Replace("/", "").Replace("\\", "");
						else
							rtn = "invalid-album-title";
						break;
					case "artist":
						if (FSValid(song.Name.Artist))
							rtn = song.Name.Artist.Replace("/", "").Replace("\\", "");
						else
							rtn = "invalid-artist-title";
						break;
					case "track":
						rtn = song.Misc.TrackNum.ToString();
						break;
					case "year":
						rtn = song.Misc.Year.ToString();
						break;
				}
				return rtn;
			})).Replace('/', '\\') + ".mp3";	
		}

		static public bool FSValid(string str)
		{
			foreach (char ch in str)
				if (ch == '\0' || ch == ':' || ch == '*' || ch == '?' || ch == '\"' || ch == '<' || ch == '>' || ch == '|')
					return false;
			return true;
		}

		static public void ThreadNeutralAction(InterfaceType itype, MethodInvoker invoke)
		{
			object objRef = new object();			
			switch (itype)
			{
				case InterfaceType.IT_LOG:
					objRef = Information.Logger;					
					break;
				case InterfaceType.IT_PROGRESS:
					objRef = Information.Progress;					
					break;
				case InterfaceType.IT_RESULTS:
					objRef = Information.Results;
					break;
			}
			Type type = objRef.GetType();
			if (type.IsSubclassOf(typeof(Control)))
			{
				Control control = (Control)objRef;
				control.Invoke(invoke);
			}
			else
				invoke();
		}
	}
}
