namespace AHKCore
{
	public class Compiler
	{
		public CompilerIndexedNode Compile(string code)
		{
			var parserInstance = new Parser();
			var AHKNodes = parserInstance.parse(code);

			var indexer = new NodeIndexer();
			var indexedNodes = new CompilerIndexedNode(indexer.IndexNodes(AHKNodes));

			return Compile(indexedNodes);
		}

		CompilerIndexedNode Compile(CompilerIndexedNode indexedNodes)
		{
			var visitor = new CompilerVisitor();
			var traverser = new AHKCore.NodeTraverser(visitor);

			visitor.indexed = indexedNodes;
			visitor.traverser = traverser;

			//classes
			foreach (var o in indexedNodes.Classes.AllClasses())
				Compile(new CompilerIndexedNode(o));
			
			// functions
			foreach (var o in indexedNodes.Functions.AllFunctions())
				traverser.objectDispatcher(o);
			// autoexec at last
			foreach (var o in indexedNodes.AutoExecute)
				traverser.objectDispatcher(o);

			return indexedNodes;
		}
	}
}