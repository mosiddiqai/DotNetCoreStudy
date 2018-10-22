using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSystem
{
    public interface IElevatorAllocationStrategy
    {
        string AllocateElevator(ElevatorDirection elevatorDirection);
    }

    public class ElevatorAllocationDispatchDestinationStrategy : IElevatorAllocationStrategy
    {
        public string AllocateElevator(ElevatorDirection elevatorDirection)
        {
            var unAllottedServiceRequest = ElevatorController.Instance.ElevatorRequestPipeline
                                                    .ServiceRequestPipeLine
                                                    .Where(sr => string.IsNullOrEmpty(sr.Value.ElevatorName) == true);

            string elevatorName = string.Empty;
            foreach (var srequest in unAllottedServiceRequest)
            {
                elevatorName = AssignElevatorCar(elevatorDirection, srequest);
            }

            return elevatorName;
        }

        private string AssignElevatorCar(ElevatorDirection elevatorDirection, KeyValuePair<string, ElevatorServiceRequest> srequest)
        {
            var serviceRequest = srequest.Value;

            bool IsUpwards = elevatorDirection == ElevatorDirection.Upwards ? true : false;
            var elevatorCar = ElevatorController.Instance
                                    .ElevatorCarList
                                        .Where(e => e.ElevatorDirection.Equals(serviceRequest.ServiceRequestDirection))
                                        .OrderBy(e => e.ServiceRequestList.Count)
                                        .Take(1)
                                        .FirstOrDefault() as ElevatorCar;
            if (elevatorCar == null)
            {
                elevatorCar = ElevatorController.Instance
                                    .ElevatorCarList
                                        .Where(e => e.Status.Equals(ElevatorCarStatus.Idle) 
                                                    || e.ElevatorDirection.Equals(serviceRequest.ServiceRequestDirection))
                                        .OrderBy(e => e.ServiceRequestList.Count)
                                        .Take(1)
                                        .FirstOrDefault() as ElevatorCar;
            }

            ElevatorController.Instance.ElevatorRequestPipeline
                                       .ServiceRequestPipeLine[srequest.Key.ToString()].ElevatorName = elevatorCar.Name;
            //Updating Elevator Direction as per ServiceRequest direction
            if (ElevatorController.Instance.ElevatorCarList.Any(e => e.Name.Equals(elevatorCar.Name)))
            {
                ElevatorController.Instance.ElevatorCarList.First(e => e.Name.Equals(elevatorCar.Name)).ElevatorDirection = srequest.Value.ServiceRequestDirection;

                ElevatorController.Instance.ElevatorCarList.First(e => e.Name.Equals(elevatorCar.Name)).AddNewServiceRequest(srequest.Value.SourceFloor, srequest.Value.ServiceRequestDirection);
                ElevatorController.Instance.ElevatorCarList.First(e => e.Name.Equals(elevatorCar.Name)).AddNewServiceRequest(srequest.Value.DeistinationFloor, srequest.Value.ServiceRequestDirection);
            }

            return elevatorCar.Name;
        }
    }
}
