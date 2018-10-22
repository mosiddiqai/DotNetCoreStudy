using System;


namespace AdapterPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            IAdapter adapter = new Adapter();
            var employees = adapter.GetEmployees();
            foreach (var item in employees)
            {
                Console.WriteLine($"Firstname : {item.FirstName}, Last name : {item.LastName}");
            }

            Console.ReadLine();
        }
    }
}
