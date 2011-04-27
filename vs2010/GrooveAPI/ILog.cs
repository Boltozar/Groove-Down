using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrooveAPI
{
	public class LogType
	{
		public const int LT_INFO		= 1;
		public const int LT_WARNING		= 2;
		public const int LT_ERROR		= 4;
		public const int LT_SEARCH		= 8;
		public const int LT_DOWNLOAD	= 16;
		public const int LT_CONNECT		= 32;

		public static bool HasFlag(int val, int flag)
		{
			return (val & flag) != 0;
		}
	};	

	public interface ILog
	{		
		void AddLog(int type, string text);
	}
}
