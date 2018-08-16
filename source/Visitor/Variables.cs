using static AHKCore.Nodes;

namespace AHKCore
{
	public partial class CompilerVisitor
	{
		public override variableAssignClass variableAssign(variableAssignClass context)
		{
			context.extraInfo = $"{context.complexVariable.extraInfo} {context.op} {context.expression.extraInfo}";
			return context;
		}

		public override variableClass variable(variableClass context)
		{
			context.extraInfo = (indexed.Declared.Contains(context.variableName)? "": "dynamic ")
				+ context.variableName;
			indexed.Declared.Add(context.variableName);
			
			return context;
		}

		public override complexVariableClass complexVariable(complexVariableClass context)
		{
			context.extraInfo = context.variable.extraInfo;
			return context;
		}
	}
}