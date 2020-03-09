using System.Collections.Generic;
using NewInCSharp6.Utils;

// Organizing extension methods. Eliminates namespace pollution by limiting what methods are visible.
// From all extension methods defined in namespace System.Linq only those from System.Linq.Enumerable are available.
using static System.Linq.Enumerable;

namespace NewInCSharp6.UsingStatic
{
    public class UsingStatic3
    {
        public void Foo(IEnumerable<Person> people)
        {
            Person firstAdult = people.FirstOrDefault(p => p.Age >= 18);
        }
    }
}
