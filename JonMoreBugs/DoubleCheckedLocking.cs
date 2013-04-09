using System.Threading;

namespace JonMoreBugs
{
    public class DoubleCheckedLocking
    {
        private static readonly object Padlock = new object();
        private static DoubleCheckedLocking instance = null;

        public static DoubleCheckedLocking Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (Padlock)
                    {
                        if (instance == null)
                        {
                            // Possible incorrect implementaton of Double-Check Locking.
                            // Checked field must be volatile or assigned from local variable
                            // after 'Thread.MemoryBarrier()' call
                            // http://confluence.jetbrains.com/display/ReSharper/Possible+multiple+write+access+in+double-checked+locking
                            instance = new DoubleCheckedLocking();

                            // Possible incorrect implementation of Double-Check Locking.
                            // Read access to checked field
                            // http://confluence.jetbrains.com/display/ReSharper/Read+access+in+double+checked+locking
                            instance.Initialise();

                            // Explanations for both are on the ReSharper codewiki:
                            // alt+enter -> suppress -> Why is ReSharper suggesting this?
                            // Or see http://csharpindepth.com/Articles/General/Singleton.aspx for more :)
                        }
                    }
                }
                return instance;
            }
        }

        private void Initialise()
        {
            // Do something
        }
    }
}
