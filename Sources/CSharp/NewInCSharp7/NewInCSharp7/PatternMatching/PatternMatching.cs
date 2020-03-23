using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace NewInCSharp7.PatternMatching
{
    public class PatternMatching
    {
        // The is pattern expression extends how the old "is" operator can be used.
        public void PatternMatchingForIs(object item)
        {
            if (item is "Hello World")
            {
                Debug.WriteLine("item is Hello World.");
            }
            else if (item is 1 + 2)
            {
                Debug.WriteLine("item is 3.");
            }
            else if (item is 100)
            {
                Debug.WriteLine("item is 100.");
            }
            else if (item is DayOfWeek.Friday)
            {
                Debug.WriteLine("item is Friday.");
            }
            else if (item is int value)
            {
                Debug.WriteLine($"item is int with value {value}.");
            }
            else if (item is null)
            {
                Debug.WriteLine("item is null.");
            }
            else
            {
                Debug.WriteLine("Who knows what item is.");
            }
        }

        // The switch match expression extends how the old "switch" operator can be used.
        public void PatternMatchingSwitch(IEnumerable<object> sequence)
        {
            foreach (object item in sequence)
            {
                switch (item)
                {
                    case int value when value < 0:
                        Debug.WriteLine($"Negative integer: {value}.");
                        break;

                    case int value when (new List<int>() {1, 2, 3, 5, 8, 13}).Contains(value):
                        Debug.WriteLine($"A Fibonacci element: {value}.");
                        break;

                    case int value:
                        Debug.WriteLine($"integer: {value}.");
                        break;

                    case Person person when person.Age < 18:
                        Debug.WriteLine($"A minor person: {person.Name}.");
                        break;

                    case Person person:
                        Debug.WriteLine($"A person: {person.Name}.");
                        break;

                    case null:
                        Debug.WriteLine($"A element with a value of null.");
                        break;

                    default:
                        Debug.WriteLine($"Something else of type: {item.GetType().Name}");
                        break;
                }
            }
        }

        // Starting with C# 7.1 we have pattern matching on generic type parameters.
        public void PatternMatchingGenericForIs<T>(object item)
        {
            if (item is List<T> value)
            {
                Debug.WriteLine($"item is a list of type {typeof(T).Name} with {value.Count} elements.");
            }
            else
            {
                Debug.WriteLine($"item is not a list of type {typeof(T).Name}.");
            }
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
    }
}
