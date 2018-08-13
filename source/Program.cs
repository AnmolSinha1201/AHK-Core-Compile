using System;
using AHKCore;

namespace source
{
	class Program
	{
		static void Main(string[] args)
		{
			var parserInstance = new Parser();
			var AHKTree = parserInstance.parse("var:=123\n");
		}
	}
}
