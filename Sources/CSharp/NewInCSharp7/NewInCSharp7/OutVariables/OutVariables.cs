using System;
using System.Collections.Generic;
using System.Text;

namespace NewInCSharp7.OutVariables
{
    public class OutVariables
    {

        public void Demo1()
        {
            GetInfo(out string name, out int age, out DateTime dateOfBirth);
        }

        public void Demo2()
        {
            GetInfo(out string name, out int _, out DateTime _);
        }

        private void GetInfo(out string name, out int age)
        {
            name = "Tom";
            age = 48;
        }

        private void GetInfo(out string name, out int age, out DateTime dateOfBirth)
        {
            name = "Tom";
            age = 48;
            dateOfBirth = new DateTime(2001, 1, 21);
        }
    }
}
