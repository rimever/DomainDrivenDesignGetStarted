using System;

namespace ValueObject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new FullName("john","smith").Equals(new FullName("john","smith")));
            Console.WriteLine(new FullName("john","smith").Equals(new FullName("thomas","smith")));
            Console.WriteLine(new FullName("john","smith").Equals(new FullName("john","scott")));
        }
    }
}