using System;
using JetBrains.Annotations;

namespace JonMoreBugs
{
    public class ImplicitlyCapturedClosure
    {
        private class Processor
        {
            public int Value;

            public void Process(byte[] args)
            {
                // Whatever
            }
        }

        public void DoThing()
        {
            var args1 = new byte[] {1, 2, 3};
            var args2 = new byte[] {1, 2, 3};
            var t = new Processor();

            // Both lambdas share a backing class, so the scope of args1 or args2
            // may be wider than you think. Only way to suppress is with an
            // annotation attribute to tell ReSharper that the closure's scope
            // is constrained to the called method only
            DoesSomethingWithAction(() => t.Process(args1));
            DoesSomethingWithAction(() => t.Process(args2));
        }

        private void DoesSomethingWithAction(/* [InstantHandle] */ Action action)
        {
            action();
        }
    }
}