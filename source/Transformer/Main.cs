using System;
using System.Collections.Generic;
using System.Linq;
using static AHKCore.BaseVisitor;
using static AHKCore.Query;

namespace AHKCoreCompile
{
	public partial class Transformer
	{
		public void Test(List<object> AHKTree)
		{
			var CSAST = transformTopography(AHKTree);

			var traverser = new AHKCore.NodeTraverser(new CSVisitor());
			Console.WriteLine(traverser.TraverseNodes(CSAST)?.FlattenExtraInfo("\n"));
		}
	}
}
