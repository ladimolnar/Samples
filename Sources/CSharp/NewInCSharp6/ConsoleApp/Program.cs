using System;
using System.Globalization;
using NewInCSharp6.CollectionIndexInitializers;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // CollectionInitializersDemo();
            CollectionIndexInitializersDemo();

            //NewInCSharp6.ExpressionBodiedMembers.Person person = new Person("Joe", "Smith", new DateTime(2000, 3, 6));
            //Console.WriteLine(person);

            //Person person = new Person() { Name = "Joe", DateOfBirth = new DateTime(2000, 3, 21) };
            //Console.WriteLine(person);

            //GetAllCultures();
            //Console.ReadLine();
        }

        private static void CollectionIndexInitializersDemo()
        {
            var payload = new Payload
            {
                [0] = "foo",
                [10] = "bar",
                [100] = "baz",
            };
        }

        private static void GetAllCultures()
        {
            foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.AllCultures))
            {
                Console.WriteLine(ci.Name);
            }
        }

        //private static void CollectionInitializersDemo()
        //{
        //    var payload = new Payload
        //    {
        //        { "some text" },
        //        { 1, 2, 3, "more text" },
        //    };
        //}
    }
}
