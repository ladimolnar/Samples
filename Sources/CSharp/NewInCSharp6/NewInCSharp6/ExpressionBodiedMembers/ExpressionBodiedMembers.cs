using System;

namespace NewInCSharp6.ExpressionBodiedMembers
{
    public class Person
    {
        public string FirstName { get; }
        public string LastName { get; }
        public DateTime DateOfBirth { get; }

        // Expression bodied member syntax for a read-only auto-property.
        public string Name => $"{FirstName} {LastName}";

        public Person(string firstName, string lastName, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
        }

        // Expression bodied member syntax for a method.
        public override string ToString() => $"{Name}, DOB: {DateOfBirth:MM/dd/yyyy}";
    }
}
