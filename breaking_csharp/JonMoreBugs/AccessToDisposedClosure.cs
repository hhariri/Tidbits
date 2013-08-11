using System;
using JetBrains.Annotations;
using NUnit.Framework;

namespace JonMoreBugs
{
    [TestFixture]
    public class AccessToDisposedClosure
    {
        private Action action;

        private class DisposableObject : IDisposable
        {
            private bool isDisposed;

            public void DoSomething(int value)
            {
                if (isDisposed)
                    throw new ObjectDisposedException("disposable object");

                Console.WriteLine(value);
            }

            public void Dispose()
            {
                // Cleanup
                isDisposed = true;
            }
        }

        [Test]
        public void AccessingDisposedClosure()
        {
            using (var disposableObject = new DisposableObject())
            {
                // Cannot fix this without rewriting - genuine bug
                SetAction(() => disposableObject.DoSomething(42));
            }
            CallAction();
        }

        [Test]
        public void ImmediatelyHandlingDisposedClosure()
        {
            using (var disposableObject = new DisposableObject())
            {
                // HandleAction can be marked [InstantHandle] to narrow the scope of the analysis
                HandleAction(() => disposableObject.DoSomething(42));
            }
        }

        private void SetAction(Action a)
        {
            action = a;
        }

        private void CallAction()
        {
            action();
        }

        private void HandleAction(/* [InstantHandle] */ Action a)
        {
            a();
        }
    }
}