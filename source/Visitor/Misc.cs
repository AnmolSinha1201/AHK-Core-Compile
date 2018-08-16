using static AHKCore.Nodes;

namespace AHKCore
{
	partial class CompilerVisitor
	{
		public override INTClass INT(INTClass context)
		{
			context.extraInfo = context.INT;
			return context;
		}
	}
}