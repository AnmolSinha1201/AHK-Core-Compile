using System;
using System.Collections.Generic;
using System.Linq;
using static AHKCore.BaseVisitor;
using static AHKCore.listExtension;

namespace AHKCoreCompile
{
	public partial class Transformer
	{
        public void Test(List<object> AHKTree)
        {
            Console.WriteLine(transformTopography(AHKTree)?.FlattenAsChain("\n"));
        }
	}
}
