using System;
using System.Diagnostics;

namespace NewInCSharp7.Tuples
{
    public class Tuples
    {
        public void TuplesDemo()
        {
            (string name, int age, DateTime dateOfBirth) person = GetInfo();
            Debug.WriteLine(person.name);

            var person2 = GetInfo();
            Debug.WriteLine(person2.name);

            (string, int, DateTime) person3 = GetInfo();
            Debug.WriteLine(person3.Item1);

            // This is called deconstructing the tuple.
            (string name, int age, DateTime dateOfBirth) = GetInfo();
            Debug.WriteLine(name);

            // Tuples support == and != since C# 7.3. See [here](https://docs.microsoft.com/en-us/dotnet/csharp/tuples#equality-and-tuples)
            var p1 = GetInfo();
            var p2 = GetInfo();
            Debug.WriteLine(p1 == p2);
        }

        public void TuplesDemo2()
        {
            // The discard variable can also be used.
            (string name, int _, DateTime _) = GetInfo();
            Debug.WriteLine(name);
        }

        private (string name, int age, DateTime dateOfBirth) GetInfo()
        {
            return ("Tom", 41, new DateTime(2001, 3, 21));
        }
    }
}
