using System;
using System.Collections.Generic;

namespace NewInCSharp7.ThrowExpression
{
    public class ThrowExpressionDemo
    {
        // Throw can be used as an expression in conjunction with the conditional operator.
        public void ShowFirstNumber(List<int> numbers)
        {
            int firstNumber = numbers.Count > 0 ?
            numbers[0] :
                throw new ArgumentException("At least one number must be provided.", nameof(numbers));

            Console.WriteLine(firstNumber);
        }

        // Throw can be used in an expression bodied member.
        public override int GetHashCode() => throw new NotSupportedException();

        public void Foo()
        {
            NewMath newMath = new NewMath(
                addition: (a, b) => a + b,
                multiplication: (a, b) => throw new NotSupportedException("Multiplication is not supported"));
        }
    }


    public class NewMath
    {
        public NewMath(Func<int, int, int> addition, Func<int, int, int> multiplication)
        { }
    }


    public class Person
    {
        public string Name { get; }

        // Throw can be used as an expression in conjunction with the null-coalescing operator.
        public Person(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
