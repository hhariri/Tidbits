using System.Text;

namespace JonBugs
{
    class PointlessRef
    {
        public void Foo(ref StringBuilder builder)
        {
            builder.Append("Would work regardless of ref");
        }

        public void Swap(string first, string second)
        {
            string tmp = first;
            first = second;
            second = tmp;
        }
    }
}
