using System.Collections.Generic;

namespace AHKCore
{
	public class CompilerIndexedNode : IndexedNode
	{
		public List<string> Declared = new List<string>();

		public CompilerIndexedNode(IndexedNode indexed)
		{
			this.AutoExecute = indexed.AutoExecute;
			this.Classes = indexed.Classes;
			this.Functions = indexed.Functions;
			this.Variables = indexed.Variables;
			this.Parent = indexed.Parent;
		}
	}
}