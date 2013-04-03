using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace JonBugs
{
    [TestFixture]
    public class OddComparison
    {
        public static bool ReturnsTrue(int x)
        {
            return x == x;
        }

        public static bool MightReturnFalse(double x)
        {
            return x == x;
        }

        public static bool AlwaysReturnsFalse()
        {
            return double.NaN == double.NaN;
        }

        [Test]
        public void CallMethods()
        {
            Console.WriteLine(ReturnsTrue(10));
            Console.WriteLine(MightReturnFalse(5.1));
            Console.WriteLine(MightReturnFalse(double.NaN));
            Console.WriteLine(AlwaysReturnsFalse());
        }
    }
}
