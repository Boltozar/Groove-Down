using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using CodeTitans.JSon;

namespace GrooveAPI
{
	class GrooveJSON
	{
		public void WriteHeader(string methodForToken = null, bool downloading = false)
		{
			_writer.WriteObjectBegin();
			_writer.WriteMember("header");
			_writer.WriteObjectBegin();
			if (!downloading)
				_writer.WriteMember("client", "htmlshark");
			else
				_writer.WriteMember("client", "jsqueue");
			if (methodForToken != null)
			{
				_writer.WriteMember("token", GenerateToken(methodForToken));
			}
			_writer.WriteMember("uuid", Information.UUID);
			_writer.WriteMember("clientRevision", Information.ClientRevision);
			_writer.WriteMember("session", Information.SessionID);
			_writer.WriteMember("privacy", 0);			
			WriteCountry();
			_writer.WriteObjectEnd();			
		}

		public void WriteMethod(string methodName)
		{
			_writer.WriteMember("method", methodName);
		}

		public void WriteParameters(Dictionary<string, object> parameters)
		{
			_writer.WriteMember("parameters");
			_writer.WriteObjectBegin();
			foreach (KeyValuePair<string, object> pair in parameters)
			{
				if (pair.Key == "country")									
					WriteCountry();
				else
					_writer.WriteMember(pair.Key, pair.Value.ToString());
			}
			_writer.WriteObjectEnd();
		}

		public void WriteFinish()
		{
			_writer.WriteObjectEnd();
		}

		public void WriteCountry()
		{
			_writer.WriteMember("country");
			_writer.WriteObjectBegin();
			_writer.WriteMember("CC3", "0");
			_writer.WriteMember("CC2", "0");
			_writer.WriteMember("ID", "223");
			_writer.WriteMember("CC1", "0");
			_writer.WriteMember("CC4", "1073741824");
			_writer.WriteObjectEnd();
		}

		public override string ToString()
		{
			return _writer.ToString();
		}		

		public void Reset()
		{
			_writer.Dispose();
			_writer = new JSonWriter();
		}

		public string Read(string jsonData, string key)
		{
			try
			{
				Dictionary<string, object> dict = (Dictionary<string, object>)_reader.Read(jsonData);
				return dict[key].ToString();
			}
			catch (JSonReaderException)
			{
				return "";
			}
		}

		public Dictionary<string, object> Read(string jsonData)
		{
			try
			{
				return (Dictionary<string, object>)_reader.Read(jsonData);
			}
			catch (JSonReaderException)
			{
				return new Dictionary<string, object>();
			}
		}

		private string GenerateToken(string method)
		{
			const string salt = "1dec25";

			StringBuilder enc = new StringBuilder(salt);

			enc.Append(Helpers.Hash(method + ":" + Information.Token + ":" + Information.GrooveAPISalt + ":" + salt, new SHA1CryptoServiceProvider()));
			
			return enc.ToString();		
		}


		private JSonWriter _writer = new JSonWriter();
		private JSonReader _reader = new JSonReader();
	}
}
