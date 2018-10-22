using System;

namespace hello
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            if (args.Length > 0)
            {
                Console.WriteLine("Parameter received : " + args[0]);
                Console.WriteLine($"Parameter without concatenation {args[0]}");
            }

            Console.WriteLine("Display using object !");
            var person = Tuple.Create(1, "Md Hasnen", "Siddique");
            Console.WriteLine($" Id : {person.Item1}, First name : {person.Item2}, Lastname : {person.Item3}");

            Console.WriteLine("Display using function !");
            DisplayTupleData(person);

            //ValueTuple => different ways for initializing 

            //Using ValueTuple type
            ValueTuple<int, string> fruits = (120, "Apple");

            //Without using ValueTuple type
            (int, string) fruits2 = (130, "Rasberry");

            //Named property ValueTuple type
            (int price, string name) fruits3 = (140, "Mango");

            //Name property ValueType with Function
            (int price, string name) fruits4 = GetFruits();

            Console.WriteLine($"Fruit name : {fruits.Item2}, Price :  {fruits.Item1} ");
            Console.WriteLine($"Fruit name : {fruits2.Item2}, Price :  {fruits2.Item1} ");
            Console.WriteLine($"Fruit name : {fruits3.name}, Price :  {fruits3.price} ");
            Console.WriteLine($"Fruit name : {fruits4.name}, Price :  {fruits4.price} ");

        }

        static (int price, string name) GetFruits()
        {
            return (price: 150, name: "Pineapple");
        }

        static void DisplayTupleData(Tuple<int, string, string> person) => Console.WriteLine($" Id : {person.Item1}, First name : {person.Item2}, Lastname : {person.Item3}");
    }
}
