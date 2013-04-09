using System;
using NUnit.Framework;

namespace JonMoreBugs
{
    [TestFixture]
    public class EventsAndAnonymousDelegates
    {
        public class HasEvent
        {
            public event EventHandler MyEvent;

            public void InvokeEvent()
            {
                var onFired = MyEvent;
                if (onFired != null)
                    onFired(this, EventArgs.Empty);
            }
        }

        [Test]
        public void UnsubscribingAnonymousEventHandlerIsMeaningless()
        {
            int counter = 0;
            var hasEvent = new HasEvent();

            hasEvent.MyEvent += (s, e) => { counter++; };

            hasEvent.InvokeEvent();

            hasEvent.MyEvent -= (s, e) => { counter++; };

            hasEvent.InvokeEvent();

            Assert.AreEqual(1, counter);
        }

        [Test]
        public void UnsubscribeViaVariable()
        {
            int counter = 0;
            var hasEvent = new HasEvent();

            EventHandler handler = (s, e) => { counter++; };
            hasEvent.MyEvent += handler;

            hasEvent.InvokeEvent();

            hasEvent.MyEvent -= handler;

            hasEvent.InvokeEvent();

            Assert.AreEqual(1, counter);
        }
    }
}