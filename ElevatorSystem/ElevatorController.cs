using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSystem
{
    public class ElevatorController
    {
        static readonly object _object = new object();
        public readonly int MIN_FLOOR;
        public readonly int MAX_FLOOR;
        public ElevatorCar elevatorCar;
        public List<ElevatorCar> ElevatorCarList = new List<ElevatorCar>();

        private bool IsHaltForMaintenance = false;

        public ElevatorRequestPipeline ElevatorRequestPipeline { get; set; }
        private IElevatorAllocationStrategy elevatorAllocationStrategy;

        #region Singleton
        private ElevatorController(IElevatorAllocationStrategy elevatorAllocationStrategy)
        {
            ElevatorRequestPipeline = new ElevatorRequestPipeline();
            this.elevatorAllocationStrategy = elevatorAllocationStrategy;
            MIN_FLOOR = 0;
            MAX_FLOOR = 10;
        }

        private static ElevatorController _instance;
        public static ElevatorController Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ElevatorController(new ElevatorAllocationDispatchDestinationStrategy());
                }
                return _instance;
            }
        }

        #endregion


        public void StopSystemForMaintenance()
        {
            IsHaltForMaintenance = true;
        }

        public string AllocateElevator(ElevatorDirection direction)
        {
            return this.elevatorAllocationStrategy.AllocateElevator(direction);
        }

        public void RegisterElevatorCar(ElevatorCar elevatorCar)
        {
            if (!this.ElevatorCarList.Any(e => e.Name.Equals(elevatorCar.Name)))
            {
                this.ElevatorCarList.Add(elevatorCar);
            }
        }

        public async Task<string> ProcessRequest(ElevatorDirection elevatorDirection)
        {
            //Todo -- Re-think on the algorithm to process the requests??

            //ToDo -- why did we added this line multiple time
            //this.elevatorAllocationStrategy.AllocateElevator(elevatorDirection);

            Task<int> result = Task.Run(() => ProcessTriggerElevatorAction());

            //do
            //{
            //    string x = await ProcessTriggerElevatorAction();
            //} while (Instance.ElevatorRequestPipeline.ServiceRequestPipeLine.Any() 
            //            && Instance.ElevatorRequestPipeline.ServiceRequestPipeLine.Count > 0);
            //do
            //{
            //    ProcessTriggerElevatorAction();
            //} while (Instance.ElevatorRequestPipeline.ServiceRequestPipeLine.Any());
            //ProcessTriggerElevatorAction();

            return string.Empty;
        }
        private async Task<int> ProcessTriggerElevatorAction()
        {
            //Todo - get the list of elevator only if its alloted with service request
            //Todo - run this code async

            this.ElevatorCarList.Where(e => e.Status == ElevatorCarStatus.Idle)
                                .ToList<ElevatorCar>()
                                .ForEach(e => e.ProcessRequestWorker());

            return Instance.ElevatorRequestPipeline.ServiceRequestPipeLine.Any()
                        && Instance.ElevatorRequestPipeline.ServiceRequestPipeLine.Count > 0 ? 1 : 0;
        }

        internal void ServiceRequestedCompleted(string name, int destinationFloor)
        {
            lock (this.ElevatorRequestPipeline.ServiceRequestPipeLine)
            {
                //Todo - why we have situation where ElevatorServiceRequest comes as null

                var result = this.ElevatorRequestPipeline.ServiceRequestPipeLine
                                    .FirstOrDefault
                                        (
                                                esr => esr.Value.ElevatorName.Equals(name)
                                                && esr.Value.DeistinationFloor.Equals(destinationFloor)
                                        );

                if (result.Key != null)
                {
                    this.ElevatorRequestPipeline.ServiceRequestPipeLine.Remove(result.Key);
                }

                //Checking servicerequest with both source & destination floor since Elevator will hault at both Source (to pick-up) & Destination (to drop)
                if (this.ElevatorCarList.FirstOrDefault(c => c.Name.Equals(name)).CurrentServiceRequestInProgress != null)
                {
                    this.ElevatorCarList.FirstOrDefault(c => c.Name.Equals(name)).RemoveCurrentNodefromList();
                }
            }
        }

        internal void ReportCurrentServiceRequestPipelineCompletion(string elevatorName)
        {
            //rerun to ensure if there is any request pending in another direction
            ProcessRequest(ElevatorDirection.Upwards);
        }

    }
}
