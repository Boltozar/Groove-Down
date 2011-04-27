using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Groove_Down
{
	public sealed class SettingsManager
	{
		public const int	cXorKey = 13;
		public const string cFileName = "settings.dat";
		public const string cVerifyString = "mmkdjszioio939,,,";
		public const bool	cSaveOnDestruct = true;

		private const string cSeperator = "<==>";
		private const string cTerminator = "!\r\n";
		private const string cSerializedSeperator = "<->";
		private const string cSerializedTerminator = "|!";

		private SettingsManager()
		{
			_Load();
		}

		~SettingsManager()
		{
			if(cSaveOnDestruct)
				WriteSaveFile();
		}

		public void SaveSetting(KeyValuePair<string, object> pair)
		{
			_fileBuffer += pair.Key + cSeperator + pair.Value.ToString() + cTerminator;
		}

		public void SaveSetting(KeyValuePair<string, bool> pair)
		{
			_fileBuffer += pair.Key + cSeperator + (pair.Value ? "true" : "false") + cTerminator;
		}

		public void SaveSetting(KeyValuePair<string, ISerializable> pair)
		{
			_fileBuffer += pair.Key + cSeperator;
			Dictionary<string, string> serializedPairs = pair.Value.Serialize();
			foreach (KeyValuePair<string, string> serializedPair in serializedPairs)
				_fileBuffer += serializedPair.Key + cSerializedSeperator + serializedPair.Value + cSerializedTerminator;
			_fileBuffer += cTerminator;
		}

		public void SaveSetting(string key, object value)
		{
			SaveSetting(new KeyValuePair<string, object>(key, value));
		}

		public void SaveSetting(string key, bool value)
		{
			SaveSetting(new KeyValuePair<string, bool>(key, value));
		}

		public void SaveSetting(string key, ISerializable value)
		{
			SaveSetting(new KeyValuePair<string, ISerializable>(key, value));
		}

		public string GetSetting(string key)
		{
			string rtn = "";
			try
			{
				rtn = _settingsData[key];
				return rtn;
			}
			catch (KeyNotFoundException)
			{
				return rtn;
			}
		}

		public Dictionary<string, string> GetSettingSerialized(string key)
		{
			string data = GetSetting(key);
			Dictionary<string, string> ret = new Dictionary<string, string>();
			string[] pairs = data.Split(new string[] { cSerializedTerminator }, StringSplitOptions.None);
			foreach (string pair in pairs)
			{
				string[] kv = pair.Split(new string[] { cSerializedSeperator }, StringSplitOptions.None);
				if (kv.Length != 2)
					continue;
				ret.Add(kv[0], kv[1]);
			}
			return ret;
		}

		public void WriteSaveFile()
		{
			if (_fileBuffer.IndexOf(cVerifyString) != -1)
				return;

			_fileBuffer = _fileBuffer.Insert(0, cVerifyString);
			_fileBuffer = XOR(_fileBuffer);

			FileStream fs = new FileStream(cFileName, FileMode.Open, FileAccess.Write);
			StreamWriter writer = new StreamWriter(fs);
			writer.Write(_fileBuffer);
			writer.Close();
		}

		public bool Reload()
		{
			_settingsData.Clear();
			_hasLoaded = false;
			return _Load();
		}

		private bool _Load()
		{
			if (_hasLoaded)
				return false;

			FileStream fs;
			try
			{
				fs = new FileStream(cFileName, FileMode.Open, FileAccess.Read);
			}
			catch (FileNotFoundException)
			{
				fs = new FileStream(cFileName, FileMode.CreateNew, FileAccess.Write);				
				fs.Close();
				_hasLoaded = true;
				return false;
			}
			StreamReader reader = new StreamReader(fs);
			string encFileText = reader.ReadToEnd();
			reader.Close();

			string decFileText = XOR(encFileText);

			if (!decFileText.StartsWith(cVerifyString))
			{
				_hasLoaded = true;
				return false;
			}
			else
				decFileText = decFileText.Substring(cVerifyString.Length);

			string[] pairs = decFileText.Split(new string[] { cTerminator }, StringSplitOptions.RemoveEmptyEntries);
			foreach (string pair in pairs)
			{
				string[] kv = pair.Split(new string[] { cSeperator }, StringSplitOptions.None);
				if (kv.Length != 2)
					continue;
				_settingsData.Add(kv[0], kv[1]);
			}

			_hasLoaded = true;
			return true;
		}

		private string XOR(string input)
		{
			string rtn = "";
			for (int i = 0; i < input.Length; i++)
				rtn += (char)(input[i] ^ cXorKey);
			return rtn;
		}

		private bool _hasLoaded = false;
		private string _fileBuffer = "";
		private Dictionary<string, string> _settingsData = new Dictionary<string, string>();


		#region Singleton
		public static SettingsManager Instance
		{
			get
			{
				lock (Padlock)
				{
					if (InstanceObj == null)
						InstanceObj = new SettingsManager();
					return InstanceObj;
				}
			}
		}

		private static SettingsManager InstanceObj = null;
		private static readonly object Padlock = new object();
		#endregion
	}
}
