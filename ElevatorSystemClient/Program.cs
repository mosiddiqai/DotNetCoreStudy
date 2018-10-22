using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElevatorSystem;

namespace ElevatorSystemClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("building linked list");

            LinkedList<int> lnkLstServiceRequests = new LinkedList<int>();
            if (lnkLstServiceRequests.Count == 0)
            {
                lnkLstServiceRequests.AddFirst(0);
            }
            lnkLstServiceRequests.AddLast(5);
            lnkLstServiceRequests.AddLast(3);
            lnkLstServiceRequests.AddLast(7);

            if (1 == 0)
            {
                //Lesser than currenNode value - Do nothing keep it as is
            }
            if (lnkLstServiceRequests.Any(ll => ll > 4))
            {
                int nextValue = lnkLstServiceRequests.First(ll => ll > 4);
                LinkedListNode<int> addBeforeNode = lnkLstServiceRequests.Find(nextValue);
                lnkLstServiceRequests.AddBefore(addBeforeNode, 4);
            }

            LinkedListNode<int> currentNode = lnkLstServiceRequests.First;
            do
            {
                Console.WriteLine($"current node value : {currentNode.Value}");

                currentNode = currentNode.Next;
            } while (currentNode != null);

            Console.ReadLine();

        }
    }
}
