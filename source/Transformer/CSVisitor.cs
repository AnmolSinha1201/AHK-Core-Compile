using System;
using static AHKCore.Nodes;
using static AHKCoreCompile.Misc;
using static AHKCore.Query;

namespace AHKCoreCompile
{
	partial class CSVisitor : AHKCore.BaseVisitor
	{
		public override variableDeclarationClass variableDeclaration(variableDeclarationClass context)
		{
			context.extraInfo = new extraInfoDelegate(() => $"dynamic {context.variableName};");
			return context;
		}

		public override functionDeclarationClass functionDeclaration(functionDeclarationClass context)
		{
			context.extraInfo = new extraInfoDelegate(() => 
			$"{(context.returnType == null ? "void" : context.returnType)} {context.functionHead}\n{{\n\t{context.functionBody.FlattenExtraInfo("\n").Indent<string>()}\n}}");
			return context;
		}

		public override classDeclarationClass classDeclaration(classDeclarationClass context)
		{
			context.extraInfo = new extraInfoDelegate(() => 
			$"class {context.className}\n{{\n\t{context.classBody.FlattenExtraInfo("\n").Indent<string>()}\n}}");
			return context;
		}

		public override variableAssignClass variableAssign(variableAssignClass context)
		{
			context.extraInfo = new extraInfoDelegate(() => context.ToString() + ";");
			return context;
		}
	}
}