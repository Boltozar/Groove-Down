using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;

namespace Groove_Down.Server
{
	class ServerCheck
	{		
		public ServerCheck()
		{
			HttpWebRequest req = null;
			HttpWebResponse res = null;
			try
			{
				req = (HttpWebRequest)WebRequest.Create(location);
			}
			catch (UriFormatException excp)
			{
				throw new ServerException(excp.Message);
			}

			try
			{
				res = (HttpWebResponse)req.GetResponse();
			}
			catch (WebException excp)
			{
				throw new ServerException(excp.Message);
			}
			XmlTextReader reader = new XmlTextReader(res.GetResponseStream());
			while (reader.Read())
			{				
				switch (reader.NodeType)
				{
					case XmlNodeType.Element:
						if (reader.Name == "version")
						{
							Program.ServerVersion = reader.ReadElementContentAsString();							
						}
						break;
				}
			}
			reader.Close();
			res.Close();
		}

		const string location = "http://www.imperish.com/gd/files/program.xml";
	}
}
