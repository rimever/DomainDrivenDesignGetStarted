using System;
using System.ComponentModel.Design;

namespace ValueObject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new ModelNumber("pc", "777", "1"));
            Check(null, "test");
            Check("test", null);
            Check("@John", "Smith");
            Check("John", "@Smith");
            Console.WriteLine(
                new FullName(new Name("john"), new Name("smith")).Equals(new FullName(new Name("john"),
                    new Name("smith"))));
            Console.WriteLine(
                new FullName(new Name("john"), new Name("smith")).Equals(new FullName(new Name("thomas"),
                    new Name("smith"))));
            Console.WriteLine(
                new FullName(new Name("john"), new Name("smith")).Equals(new FullName(new Name("john"),
                    new Name("scott"))));

            var user = new User(new UserId("id"), new UserName("naruse"), new UserMailAddress("test@t.com"));
            var userService = new UserService(new UserRepository());
            var duplicatedResult = userService.Exists(user);
            Console.WriteLine($"duplicatedResult={duplicatedResult}");

            var myMoney = new Money(1000, "JPY");
            var allowance = new Money(3000, "JPY");
            var result = myMoney.Add(allowance);
        }

        private static void Check(string firstName, string lastName)
        {
            try
            {
                var fullName = new FullName(new Name(firstName), new Name(lastName));
                Console.WriteLine("OK!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}