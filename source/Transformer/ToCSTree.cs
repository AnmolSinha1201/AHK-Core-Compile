using System;
using System.Collections.Generic;
using System.Linq;
using static AHKCore.BaseVisitor;

namespace AHKCoreCompile
{
	public partial class Transformer
	{
		// List<object> toCSTree(List<object> AHKTree)
		// {
			
		// }

		/*
			- get everything other than classes and functions, put them in the Main() function
			- now put everything inside a Program class.
		 */
		List<object> transformTopography(List<object> AHKTree)
		{
			var mainBlocks = AHKTree.Where(o => !(o is classDeclarationClass) && !(o is functionDeclarationClass)).ToList();

			var mainFunctionHead = new functionHeadClass("main", new List<parameterInfoClass>());
			var mainFunction = new functionDeclarationClass(mainFunctionHead, mainBlocks);

			var others = AHKTree.Where(o => o is classDeclarationClass || o is functionDeclarationClass).ToList();

			others.Add(mainFunction);
			return others;
		}
	}
}
