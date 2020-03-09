using System.Collections.Generic;
using System.Diagnostics;
using NewInCSharp6.Utils;

namespace NewInCSharp6.CollectionIndexInitializers
{
    // Classes that have an indexer defined can now be initialized with a more convenient syntax.

    public class Payload
    {
        public string this[int index]
        {
            get { Debug.WriteLine($"get_Item({index})"); return string.Empty; }
            set { Debug.WriteLine($"set_Item({index}, {value})"); }
        }
    }

    public class CollectionIndexInitializersDemo
    {
        public void Demo()
        {
            Payload payload = new Payload()
            {
                [0] = "foo",
                [10] = "bar",
                [20] = "baz",
            };
        }

        public void Demo2()
        {
            // This rule also allows us to initialize dictionaries in a new way:

            Dictionary<int, string> myCollection = new Dictionary<int, string>()
            {
                [100] = "Joe",
                [200] = "Tom",
                [300] = "Jane",
            };
        }
    }
}
