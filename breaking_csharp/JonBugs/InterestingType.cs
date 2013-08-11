using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace JonBugs
{
    [TestFixture]
    public class InterestingType
    {
        [Test]
        public void Crazy()
        {
            var x = 10;
            x = "hello";
            Assert.IsNull(x);
        }

        private class var
        {
            public static implicit operator var(string text)
            {
                return null;
            }

            public static implicit operator var(int number)
            {
                return null;
            }
        }
    }
}
