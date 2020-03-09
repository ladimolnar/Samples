using System;
using NewInCSharp6.Utils;

namespace NewInCSharp6.NullConditional
{
    public class NullConditional
    {
        public event EventHandler<SomethingHappenedEventArg> SomethingHappened;

        public void Demo(Person person)
        {
            // Simplest use.
            string name = person?.Name;

            // Can be chained. The first null will break the chain.
            string zipCode = person?.Address.ZipCode ?? "";

            // Works nicely with the null-coalescing operator.
            string zipCode2 = person?.Address?.ZipCode ?? "00000";

            // An example with a nullable type. Person.Age is an int.
            int? age1 = person?.Age;
            int age2 = (person?.Age).GetValueOrDefault();

            // Works with invoking methods. Here Level is an enum.
            Level level = (person?.GetLevel()).GetValueOrDefault(Level.Unknown);

            // Great to guard when an event has no subscribers.
            SomethingHappened?.Invoke(this, new SomethingHappenedEventArg());
        }
    }
}

/*
Other names
	Null conditional operator – the official name.
	Conditional null operator.
	Elvis operator (because “?.” Resembles Elvis’ hair).
	Null propagating operator.
	Null safety referencing operator.
	Safe navigation operator.
*/


