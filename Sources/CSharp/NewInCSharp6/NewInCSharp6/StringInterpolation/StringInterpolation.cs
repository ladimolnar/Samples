using System;
using System.Globalization;

namespace NewInCSharp6.StringInterpolation
{
    public class Person
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }


        // String Interpolation with formatting.
        public override string ToString()
        {
            return $"{Name}, DOB: {DateOfBirth:MM/dd/yyyy}";
        }

        //// String Interpolation with formatting and culture information.
        //public override string ToString()
        //{
        //    FormattableString message = $"{Name}, DOB: {DateOfBirth}";
        //    return message.ToString(new CultureInfo("fr-FR"));
        //}

        //// A more concise form with string Interpolation with formatting and culture info
        //public override string ToString()
        //{
        //    return ((FormattableString)$"{Name}, DOB: {DateOfBirth}").ToString(new CultureInfo("fr-FR"));
        //}
    }
}
