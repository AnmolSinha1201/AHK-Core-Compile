using System;
using System.Collections.Generic;
using System.Text;
using static AHKCore.Nodes;

namespace AHKCoreCompile
{
	public static class Misc
	{
		/*
			- To be used as extraInfo (as an alternative ToString()). Using method so it can recurse into sub objects at runtime.
		 */
		public delegate string extraInfoDelegate ();
		
		/*
			- Append extraInfo (as a method), if available.
			- Otherwise use ToString() method.
		 */
		public static string FlattenExtraInfo<T>(this List<T> l, string delimiter = null)
		{
			StringBuilder sb = new StringBuilder();
			foreach (var v in l)
			{
				string s = null;
				if (v is IExtraInfo && ((IExtraInfo)v).extraInfo != null)
					s = ((extraInfoDelegate)((IExtraInfo)v).extraInfo)();
					
				if (s != null)
					sb.Append(sb.Length == 0 ? s : delimiter + s);
				else
					sb.Append(sb.Length == 0 ? v.ToString() : delimiter + v.ToString());
			}
			
			return sb.ToString();
		}
	}
}