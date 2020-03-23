using System.Diagnostics;

namespace NewInCSharp7.ExpressionBodiedMembers
{
    // C# 6 introduced expression-bodied members. C# 7 allows them in more cases.
    public class ExpressionBodiedMembers
    {
        private string _name;
        public string Name
        {
            get => _name ?? "default name";
            set => _name = value;
        }

        public ExpressionBodiedMembers(string name) => Name = name;

        ~ExpressionBodiedMembers() => Debug.WriteLine("Just for demo purposes, I don't need a finalizer.");

        public string this[int index]
        {
            get => string.Empty;
            set => Debug.WriteLine($"set_Item({index}, {value})");
        }
    }
}
