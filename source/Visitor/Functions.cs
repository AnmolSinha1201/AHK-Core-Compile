using static AHKCore.Nodes;
using System.Linq;

namespace AHKCore
{
	partial class CompilerVisitor
	{
		public override functionDeclarationClass functionDeclaration(functionDeclarationClass context)
		{
			context.extraInfo =
				$"public static {context.functionHead.functionName}()" + "\n"
				+ "{" + "\n"
				+ context.functionBody.Select(i => i.extraInfo).ToList()
					.Flatten("\n").Indent() + "\n"
				+ "}";

			return context;
		}
	}
}