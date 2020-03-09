using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Initializers
namespace NewInCSharp6.AutoPropertyInitializers
{
    public class Person
    {
        // A read-only auto property.
        private List<Person> Friends { get; } = new List<Person>();

        // A read-write auto property.
        private int Age { get; set; } = 0;
    }
}
