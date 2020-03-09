namespace NewInCSharp6.Utils
{
    public class Person
    {
        public Address Address { get; set; }
        public string Name { get; set; }

        public int Age { get; set; }
        public Level Level { get; set; }

        public Level GetLevel()
        {
            throw new System.NotImplementedException();
        }
    }
}