using static AHKCore.Nodes;
using System.Linq;

namespace AHKCore
{
	partial class CompilerVisitor
	{
		public override classDeclarationClass classDeclaration(classDeclarationClass context)
		{
			return context;
		}
	}
}