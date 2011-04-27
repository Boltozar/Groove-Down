using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Groove_Down
{
	public interface ISerializable
	{
		Dictionary<string, string> Serialize();
		void Unserialize(Dictionary<string, string> dict);
	}
}
