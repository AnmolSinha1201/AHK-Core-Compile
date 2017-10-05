using System;
using System.Collections.Generic;
using System.Linq;
using static AHKCore.Nodes;
using static AHKCore.Query;

namespace AHKCoreCompile
{
	public partial class Transformer
	{
		/*
			- get everything other than classes and functions, put them in the Main() function
			- get all variableDeclarations of non-Main, and put them inside the function (for emulating their local scope)
			- get all variableDeclarations of Main, and put them outside main (for emulating their global scope).
			- now put everything inside a Program class.
		 */
		List<object> transformTopography(List<object> AHKTree)
		{
			var mainBlocks = AHKTree.Where(o => !(o is classDeclarationClass) && !(o is functionDeclarationClass)).ToList();

			var mainFunctionHead = new functionHeadClass("main", new List<parameterInfoClass>());
			var mainFunction = new functionDeclarationClass(mainFunctionHead, mainBlocks);

			var others = AHKTree.Where(o => o is classDeclarationClass || o is functionDeclarationClass).ToList();

			transformFunctions(AHKTree);
			transformClasses(AHKTree);

			var mainVariables = mainBlocks.OfTypeRecursive<variableClass>().Select(v => 
				new variableDeclarationClass(v, variableDeclarationClass.scope.SCOPE_GLOBAL));
			

			others.Add(mainFunction);
			others.AddRange(mainVariables);
			return others;
		}
		
		/*
			- only modifies root level functions, not functions inside other structures like classes.
		 */
		void transformFunctions(List<object> tree)
		{
			foreach (functionDeclarationClass functions in tree.Where(o => o is functionDeclarationClass))
			{
				var variables = functions.functionBody.OfTypeRecursive<variableClass>();
				var variableDeclarations = variables.Select(v => new variableDeclarationClass(v, variableDeclarationClass.scope.SCOPE_LOCAL));
				functions.functionBody.InsertRange(0, variableDeclarations);
			}
		}

		void transformClasses(List<object> tree)
		{
		}
	}
}
