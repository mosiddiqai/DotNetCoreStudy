using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSystem
{
    public class ElevatorRequestPipeline
    {
        public SortedList<string, ElevatorServiceRequest> ServiceRequestPipeLine = new SortedList<string, ElevatorServiceRequest>();

        private string GetElevatorName(bool Upwards)
        {
            var elevatorList = ElevatorController.Instance.ElevatorCarList;
            string elevatorName = elevatorList
                                            .FirstOrDefault
                                            (
                                                e => e.ElevatorDirection.Equals(Upwards)
                                                || e.Status.Equals(ElevatorCarStatus.Idle)
                                            ).Name;
            return elevatorName;
        }

        private bool ValidateRequest()
        {
            return true;
        }

        public string AddRequestToPipeline(Button button)
        {

            if (!ValidateRequest())
            {
                //Todo : logic to validate user service request considering current floor
                return "";
            }

            //var elevatorName = ElevatorController.Instance.elevatorRequestPipeline
            //                                                .AddRequestToPipeline(button.CurrentFloorNummber, button.DestinationFloorNumber);

            int requestorCurrentFloor = button.CurrentFloorNummber;
            int requestedDestinationFloor = button.DestinationFloorNumber;

            ElevatorDirection direction = (requestorCurrentFloor - requestedDestinationFloor) > 0 ? ElevatorDirection.Downwards : ElevatorDirection.Upwards;

            var serviceRequest = new ElevatorServiceRequest()
            {
                ServiceRequestId = Guid.NewGuid(),
                DeistinationFloor = requestedDestinationFloor,
                SourceFloor = requestorCurrentFloor,
                ServiceRequestDirection = direction
            };

            Console.WriteLine($"Request : {serviceRequest.SourceFloor} to : {serviceRequest.DeistinationFloor}, direction : {serviceRequest.ServiceRequestDirection}");

            this.ServiceRequestPipeLine.Add(serviceRequest.ServiceRequestId.ToString(), serviceRequest);

            //Update ElevatorController to process
            this.AllocateElevatorAndProcessRequest(direction);
            return "";
        }

        private async void AllocateElevatorAndProcessRequest(ElevatorDirection direction)
        {
            string elevatorName = string.Empty;

            elevatorName = ElevatorController.Instance.AllocateElevator(direction);

            //ToDo - can we run async without waiting
            //button.DisplayDetails()

            //Call this async without waiting for elevatormovement
            Task.Run(() => ElevatorController.Instance.ProcessRequest(direction));

            //return elevatorName;
        }

        public int GetImmediateDestinationFloorToService(ElevatorCar elevatorCar)
        {
            var elevatorSR = this.ServiceRequestPipeLine.Values.Cast<ElevatorServiceRequest>()
                        .Where(e => e.ElevatorName.Equals(elevatorCar.Name))
                        .ToList<ElevatorServiceRequest>();

            bool bMoveUpwards = true;
            bMoveUpwards = elevatorSR.FirstOrDefault().ServiceRequestDirection == ElevatorDirection.Downwards ? false : true;

            return bMoveUpwards ? elevatorSR.Min(sr => sr.DeistinationFloor) : elevatorSR.Max(sr => sr.DeistinationFloor);
        }
    }
}
