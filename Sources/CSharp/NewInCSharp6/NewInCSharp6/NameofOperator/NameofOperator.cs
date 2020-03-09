using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewInCSharp6.NameofOperator
{
    public class Person
    {
        public string Name { get; }

        public Person(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            Name = name;
        }
    }
}
