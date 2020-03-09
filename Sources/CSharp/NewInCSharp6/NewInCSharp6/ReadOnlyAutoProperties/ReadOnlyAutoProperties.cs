
// Making it easier to implement immutable classes.

namespace NewInCSharp6.ReadOnlyAutoProperties
{
    // For a pre C# 6 see ReadOnlyProperties.cs
    public class Person
    {
        public string Name { get; }
        public int Age { get; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}
