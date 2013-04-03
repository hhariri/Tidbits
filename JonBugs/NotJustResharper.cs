using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace JonBugs
{
    [TestFixture]
    public class NotJustResharper
    {
        [Test]
        public void ClrFun()
        {
            int[] x = new int[10];
            if (x is uint[])
            {
                Console.WriteLine("x is a uint[]");
            }
            object y = x;
            Assert.AreSame(x, y);
            if (y is uint[])
            {
                Console.WriteLine("y is a uint[]");
            }
        }
    }
}
