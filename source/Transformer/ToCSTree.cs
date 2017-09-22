using System;
using System.Collections.Generic;
using System.Linq;
using static AHKCore.Nodes;
using static AHKCore.Query;

namespace AHKCoreCompile
{
	public partial class Transformer
	{
		List<object> addVariableDeclarations(List<object> AHKTree)
		{
			var functionBlocks = AHKTree.OfType<functionDeclarationClass>();

			foreach (var functionBlock in functionBlocks)
			{
				var variables = functionBlock.functionBody.OfTypeRecursive<variableClass>();
				var variableDeclarations = variables.Select(v => new variableDeclarationClass(v, variableDeclarationClass.scope.SCOPE_LOCAL));
				functionBlock.functionBody.InsertRange(0, variableDeclarations);
			}

			return AHKTree;
		}

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
