using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Net;
using System.Threading;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using CodeTitans.JSon;

namespace GrooveAPI
{
	class GrooveAPI_Connect : GrooveAPI_Worker
	{
		public GrooveAPI_Connect() : base()
		{
			WorkerSupportsCancellation = false;
		}
		protected override WorkerType GetWorkerType()
		{
			return WorkerType.GAPI_TYPE_CONNECTOR;
		}
		protected override void OnDoWork(DoWorkEventArgs e)
		{
			if (_GetSessionID() && _GetToken())
			{
				Information.Connected = true;
				Log(LogType.LT_CONNECT | LogType.LT_INFO, "Connected to Grooveshark.");
			}
			else
			{
				Information.Connected = false;
				Log(LogType.LT_CONNECT | LogType.LT_ERROR, "Could not connect to grooveshark.");
			}
		}
		private bool _GetSessionID()
		{
			try
			{
				HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://listen.grooveshark.com");
				HttpWebResponse res = (HttpWebResponse)req.GetResponse();
				string cookieHeader = res.Headers.GetValues("Set-Cookie")[0];
				Information.SessionID = Regex.Match(cookieHeader, "PHPSESSID=(\\w+);").Groups[1].Value;
				res.Close();				
			}
			catch (Exception)
			{
				return false;
			}
			return true;
		}
		private bool _GetToken()
		{
			try
			{
				GrooveJSON JSONHandler = new GrooveJSON();
				JSONHandler.WriteHeader();
				JSONHandler.WriteMethod("getCommunicationToken");

				Dictionary<string, object> myParams = new Dictionary<string, object>();
				myParams.Add("secretKey", Helpers.Hash(Information.SessionID, new MD5CryptoServiceProvider()));
				JSONHandler.WriteParameters(myParams);

				JSONHandler.WriteFinish();

				
				byte[] jsonData = Encoding.ASCII.GetBytes(JSONHandler.ToString());

				HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://grooveshark.com/more.php");

				req.Method = "POST";
				req.ContentLength = jsonData.Length;
				req.ContentType = "application/json";

				System.IO.Stream ostream = req.GetRequestStream();
				ostream.Write(jsonData, 0, jsonData.Length);
				ostream.Close();

				HttpWebResponse res = (HttpWebResponse)req.GetResponse();

				System.IO.Stream istream = res.GetResponseStream();
				byte[] buf = new byte[res.ContentLength == -1 ? 8192 : res.ContentLength];
				StringBuilder response = new StringBuilder();
				
				while (istream.Read(buf, 0, buf.Length) != 0)
					response.Append(Encoding.ASCII.GetString(buf, 0, buf.Length));				

				Information.Token = JSONHandler.Read(response.ToString(), "result");
				res.Close();
			}
			catch (Exception)
			{
				return false;
			}
			return true;
		}			
	}
}
