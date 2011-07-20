using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Groove_Down.Server
{
	class ServerException : Exception
	{
		public ServerException(string message) : base(message) { }
	}
}
