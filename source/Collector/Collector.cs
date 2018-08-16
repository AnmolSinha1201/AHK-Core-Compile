using static AHKCore.Nodes;
using System.Text;
using System.Linq;

namespace AHKCore
{
	class Collector
	{
		public static string Collect(IndexedNode indexed)
		{
			var collected = new StringBuilder();

			if (indexed.AutoExecute.Count > 0)
				collected.Append(collectAutoExec(indexed));
			if (indexed.Functions.AllFunctions().Count > 0)
				collected.Append(collectFunctions(indexed));
			if (indexed.Classes.AllClasses().Count > 0)
				collected.Append(collectClasses(indexed));

			if (indexed.AutoExecute.Count == 0 && indexed.Functions.AllFunctions().Count == 0 && indexed.Classes.AllClasses().Count > 0)
				return collected.ToString();
			return $"public class {(indexed.Name == null? "Program" : indexed.Name)}\n{{\n{collected.ToString().Indent()}\n}}";
		}

		static string collectAutoExec(IndexedNode indexed)
		{
			var collected = new StringBuilder();

			if (indexed.Name == null)
				collected.Append("public static void Main()\n{\n");
			else
				collected.Append($"public void {indexed.Name}()\n{{\n");

			collected.Append(indexed.AutoExecute.Select(i=> i.extraInfo).ToList()
				.Flatten("\n").Indent());
			collected.Append("\n}");

			return collected.ToString();
		}

		static string collectFunctions(IndexedNode indexed)
		{
			var collected  = new StringBuilder();

			collected.Append("\n");
			collected.Append(indexed.Functions.AllFunctions().Select(i=> i.extraInfo).ToList()
				.Flatten("\n"));

			return collected.ToString();
		}

		static string collectClasses(IndexedNode indexed)
		{
			var collected = new StringBuilder();

			if (indexed.Classes.AllClasses().Count > 0)
				collected.Append("\n");
			collected.Append(indexed.Classes.AllClasses().Select(i=> Collect(i)).ToList()
				.Flatten("\n"));

			return collected.ToString();
		}
	}
}