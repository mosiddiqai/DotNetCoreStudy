using System;

//
using System.Threading.Tasks;
//
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ElevatorSystem
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("==================Elevator System Simulation===================");
            Console.WriteLine($"==Top floor of elevator system = {10}");

            ElevatorCar elevatorCarA = new ElevatorCarPassenger("A", 0);
            ElevatorController.Instance.RegisterElevatorCar(elevatorCarA);
            ElevatorCar elevatorCarB = new ElevatorCarPassenger("B", 0);
            ElevatorController.Instance.RegisterElevatorCar(elevatorCarB);

            FloorButton floorButton = new FloorButton() { CurrentFloorNummber = 0, DestinationFloorNumber = 5 };
            Console.WriteLine($"User at floor : {floorButton.CurrentFloorNummber}, Elevator requested to reach floor level : {floorButton.DestinationFloorNumber}");
            floorButton.AddRequest();

            floorButton = new FloorButton() { CurrentFloorNummber = 10, DestinationFloorNumber = 9 };
            Console.WriteLine($"User at floor : {floorButton.CurrentFloorNummber}, Elevator requested to reach floor level : {floorButton.DestinationFloorNumber}");
            floorButton.AddRequest();

            floorButton = new FloorButton() { CurrentFloorNummber = 6, DestinationFloorNumber = 8 };
            Console.WriteLine($"User at floor : {floorButton.CurrentFloorNummber}, Elevator requested to reach floor level : {floorButton.DestinationFloorNumber}");
            floorButton.AddRequest();

            floorButton = new FloorButton() { CurrentFloorNummber = 4, DestinationFloorNumber = 9 };
            Console.WriteLine($"User at floor : {floorButton.CurrentFloorNummber}, Elevator requested to reach floor level : {floorButton.DestinationFloorNumber}");
            floorButton.AddRequest();

            floorButton = new FloorButton() { CurrentFloorNummber = 3, DestinationFloorNumber = 1 };
            Console.WriteLine($"User at floor : {floorButton.CurrentFloorNummber}, Elevator requested to reach floor level : {floorButton.DestinationFloorNumber}");
            floorButton.AddRequest();

            floorButton = new FloorButton() { CurrentFloorNummber = 6, DestinationFloorNumber = 2 };
            Console.WriteLine($"User at floor : {floorButton.CurrentFloorNummber}, Elevator requested to reach floor level : {floorButton.DestinationFloorNumber}");
            floorButton.AddRequest();

            //Console.WriteLine($"Going on sleep.........................");
            //System.Threading.Thread.Sleep(5000);
            //Console.WriteLine($"Back from  sleep.........................");
            //floorButton = new FloorButton() { CurrentFloorNummber = 1, DestinationFloorNumber = 10 };
            //Console.WriteLine($"User at floor : {floorButton.CurrentFloorNummber}, Elevator requested to reach floor level : {floorButton.DestinationFloorNumber}");
            //floorButton.AddRequest();

            //Call this async without waiting for elevatormovement
            //ElevatorController.Instance.ProcessRequest(ElevatorDirection.Upwards);

            Console.WriteLine("===============================================================");
            Console.ReadLine();
        }
    }
}


