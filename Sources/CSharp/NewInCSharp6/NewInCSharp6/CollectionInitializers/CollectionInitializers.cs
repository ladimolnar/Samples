using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewInCSharp6.CollectionInitializers
{

    // Pre C# 6, collection initializers could be written in a simple form if
    // a class that implemented IEnumerable also implemented an Add method.
    // With C# 6 the Add method can be an extension method.

    public static class Extensions
    {
        public static void Add(this Payload payload, string text)
        {
            Debug.WriteLine("Executing Payload.Add(string text) extension method");
        }

        public static void Add(this Payload payload, params object[] args)
        {
            Debug.WriteLine("Executing Payload.Add(params object[] args) extension method");
        }
    }

    public class Payload : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public class CollectionInitializersDemo
    {
        public void Demo()
        {
            var payload = new Payload
            {
                { "some text" },
                { 1, 2, 3, "more text" },
            };
        }
    }
}
