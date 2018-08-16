using System;
using AHKCore;

namespace source
{
	class Program
	{
		static void Main(string[] args)
		{
			var compilerInstance = new Compiler();
			var indexed = compilerInstance.Compile("class asd{\nvar := 123\nfunction(){var2:=456\nvar2:=123}}");

			Console.WriteLine(Collector.Collect(indexed));
		}
	}
}
