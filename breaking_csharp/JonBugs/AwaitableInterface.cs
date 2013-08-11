using NUnit.Framework;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace JonBugs
{
    [TestFixture]
    class AwaitableInterface
    {
        public interface IAwaitable
        {
            IAwaiter GetAwaiter();
        }

        public interface IAwaiter : INotifyCompletion
        {
            bool IsCompleted { get; }
            void GetResult();
        }

        public class Awaitable : IAwaitable
        {
            public IAwaiter GetAwaiter()
            {
 	            return new Awaiter();
            }
        }

        public class Awaiter : IAwaiter
        {
            public bool IsCompleted
            {
	            get { return true; }
            }

            public void GetResult()
            {
            }

            public void OnCompleted(Action continuation)
            {
 	            throw new NotImplementedException();
            }
        }

        [Test]
        public async Task AwaitAwaitable()
        {
            IAwaitable awaitable = new Awaitable();
            await awaitable;
        }
    }
}
