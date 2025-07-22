using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Problems.Solid
{
    internal abstract class GogenBluePrint : IGogenBluePrint
    {
        public int Count2()
        {
            return 0;
        }
        public abstract int Count();
        public abstract int Count3();
    }
    public interface IGogenBluePrint
    {
        int Count3();
        int Count2();
        int Count();
    }
}
