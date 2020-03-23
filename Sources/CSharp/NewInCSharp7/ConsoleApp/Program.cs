using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewInCSharp7.BetterLiterals;
using NewInCSharp7.Deconstructing;
using NewInCSharp7.LocalFunctions;
using NewInCSharp7.PatternMatching;
using NewInCSharp7.RefReturns;
using NewInCSharp7.Tuples;
using Person = NewInCSharp7.PatternMatching.Person;

namespace ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            // RefReturnDemo();
            // TupleDemo();
            // await DiscardAsStandalone();
            // BetterLiteralsDemo();
            // DeconstructingDemo();
            PatternMatchingDemo();
            // PatternMatchingDemo2();
            // LocalFunctionsDemo();
        }

        //static async Task<int> Main(string[] args)
        //{
        //    await Task.Delay(1000);
        //    return 0;
        //}

        private static void RefReturnDemo()
        {
            RefReturns refReturns = new RefReturns();
            refReturns.RefReturnsDemo();
        }

        private static void TupleDemo()
        {
            Tuples tuples = new Tuples();
            tuples.TuplesDemo();
        }

        public static async Task DiscardAsStandalone()
        {
            // Trigger a task and do not await it. 
            _ = DoSomething("A", 10);

            // Await the task but ignore its return.
            _ = await DoSomething("B", 5);
        }

        private static async Task<int> DoSomething(string label, int delay)
        {
            Console.WriteLine($"Starting {label}");
            for (int i = 0; i < delay; i++)
            {
                Console.WriteLine($"Working on {label}");
                await Task.Delay(1000);
            }

            Console.WriteLine($"Done with {label}");
            return 10;
        }


        private static void BetterLiteralsDemo()
        {
            Console.WriteLine(BetterLiterals.TwoFiftySixBinary);
            Console.WriteLine(BetterLiterals.TwoFiftySixHex);
            Console.WriteLine(BetterLiterals.BigNumber);
            Console.WriteLine(BetterLiterals.BigDecimal);
        }

        private static void DeconstructingDemo()
        {
            Deconstructing deconstructing = new Deconstructing();
            deconstructing.DeconstructDemo(new NewInCSharp7.Deconstructing.Person("Tom", 20));
        }

        private static void LocalFunctionsDemo()
        {
            LocalFunctions localFunctions = new LocalFunctions();
            Console.WriteLine("Step 1.");

            // IEnumerable<int> sum = localFunctions.LocalFunctionsDemo(new[] {10, 20, 30}, new[] {1, 2, 3});
            IEnumerable<int> sum = localFunctions.LocalFunctionsDemo(new[] { 10, 20, 30 }, null);
            Console.WriteLine("Step 2.");

            Console.WriteLine(string.Join(",", sum));
            Console.WriteLine("Step 3.");
        }

        private static void PatternMatchingDemo()
        {
            PatternMatching patternMatching = new PatternMatching();
            // patternMatching.PatternMatchingForIs(DayOfWeek.Friday);

            var value = new List<DayOfWeek>() { DayOfWeek.Monday, DayOfWeek.Friday };
            // var value = new List<int>() { 1, 2, 3 };
            patternMatching.PatternMatchingGenericForIs<DayOfWeek>(value);
        }

        private static void PatternMatchingDemo2()
        {
            PatternMatching patternMatching = new PatternMatching();
            patternMatching.PatternMatchingSwitch(new List<object>()
            {
                10,
                -1,
                5,
                new Person("Tom", 40),
                "abc",
                new Person("Joe", 10),
                null,
            });
        }
    }
}
