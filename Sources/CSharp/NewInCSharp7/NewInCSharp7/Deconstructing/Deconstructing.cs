
namespace NewInCSharp7.Deconstructing
{
    public class Deconstructing
    {
        public void DeconstructDemo(Person person)
        {
            (string name, int age) = person;
        }
    }

    public class Person
    {
        public string Name { get; }
        public int Age { get; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void Deconstruct(out string name, out int age)
        {
            name = Name;
            age = Age;
        }
    }
}
