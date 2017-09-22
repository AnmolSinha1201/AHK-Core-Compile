using System;
using AHKCore;

namespace source
{
	class Program
	{
		static void Main(string[] args)
		{
			var parserInstance = new Parser();
			var AHKTree = parserInstance.parse("var1=456\nclass asd{var=123\nvar2=890}\nvar2=321");
			
			var asd = new AHKCoreCompile.Transformer();
			asd.Test(AHKTree);
		}
	}
}
