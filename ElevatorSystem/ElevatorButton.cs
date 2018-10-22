using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSystem
{
    public abstract class Button
    {
        public string ServiceElevatorName { get; set; }
        public abstract void DisplayDetails();
        public int CurrentFloorNummber { get; set; }
        public int DestinationFloorNumber { get; set; }

        public abstract void AddRequest();
    }
    public class ElevatorButton : Button
    {
        public override void DisplayDetails()
        {
            throw new NotImplementedException();
        }

        public override void AddRequest()
        {
        }
    }

    public class FloorButton : Button
    {
        public bool MoveUpward { get; set; }
        public override void DisplayDetails()
        {
            Console.WriteLine($"Elevator : {this.ServiceElevatorName} will service your destination : {this.DestinationFloorNumber}!!!");
        }



        public override void AddRequest()
        {
            //Todo - can we run this asyn without waiting for others
            ElevatorController.Instance.ElevatorRequestPipeline.AddRequestToPipeline(this);
        }
    }
}
