using System;
using NUnit.Framework;

namespace JonMoreBugs
{
    [TestFixture]
    public class VirtualCallInConstructor
    {
        public class Base
        {
            public Base()
            {
                Initialise();
            }

            protected virtual void Initialise()
            {
                Console.WriteLine("Base: Initialise");
            }
        }

        public class Derived : Base
        {
            private readonly int importantField;

            public Derived()
            {
                Console.WriteLine("Derived: Setting field");
                importantField = 42;
            }

            protected override void Initialise()
            {
                Console.WriteLine("Derived: Initialise");
                Assert.AreEqual(42, importantField);
            }
        }

        [Test]
        public void Thing()
        {
            Console.WriteLine("Creating base");
            var @base = new Base();
            Assert.NotNull(@base);

            Console.WriteLine("Creating derived");
            var derived = new Derived();
            Assert.NotNull(derived);
        }
    }
}