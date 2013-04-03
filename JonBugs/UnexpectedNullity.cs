using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace JonBugs
{
    [TestFixture]
    public class UnexpectedNullity
    {
        public void ShouldBeSilent()
        {
            if (this == null)
            {
                Console.WriteLine("What was I called on?");
            }
        }

        [Test]
        public void NotSoSilent()
        {
            var method = typeof(UnexpectedNullity).GetMethod("ShouldBeSilent");
            var openDelegate = (Action<UnexpectedNullity>) Delegate.CreateDelegate(typeof(Action<UnexpectedNullity>), method);
            openDelegate(null);
        }
    }
}
