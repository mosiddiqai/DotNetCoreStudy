using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSystem
{
    public abstract class ElevatorCar
    {
        public Button button;

        private int _currentFloor;
        public int CurrentFloor
        {
            get { return _currentFloor; }
            set
            {
                _currentFloor = value;
                //ToDo : Async call to display function
            }
        }
        public int DestinationFloor { get; set; }

        public ElevatorDirection ElevatorDirection = new ElevatorDirection();

        public LinkedList<int> ServiceRequestListUpwards = new LinkedList<int>();
        public LinkedList<int> ServiceRequestListDownwards = new LinkedList<int>();

        public LinkedList<int> ServiceRequestList
        {
            get
            {
                switch (this.ElevatorDirection)
                {
                    case ElevatorDirection.Upwards:
                        return ServiceRequestListUpwards;
                    case ElevatorDirection.Downwards:
                        //Todo - pending to sort descending order
                        return ServiceRequestListDownwards;
                }
                return new LinkedList<int>();
            }
        }

        public LinkedListNode<int> CurrentServiceRequestInProgress;

        public ElevatorCarStatus Status;

        public string Name { get; set; }

        public ElevatorCar(string name, int currentFloor, Button button)
        {
            this.Name = name;
            this.CurrentFloor = currentFloor;
            this.button = button;
            this.Status = ElevatorCarStatus.Idle;
        }

        public void ResetElevatorCar()
        {
            if (ElevatorDirection == ElevatorDirection.Upwards) ServiceRequestListUpwards = null;
            if (ElevatorDirection == ElevatorDirection.Downwards) ServiceRequestListDownwards = null;

            this.CurrentFloor = 0;
            this.Status = ElevatorCarStatus.Idle;
            this.ElevatorDirection = ElevatorDirection.None;
            Console.WriteLine($"All service request of Elevator : {this.Name} completed, status : {this.Status}!");
            
        }

        public void OpenDoor()
        {
            //Console.WriteLine($"Elevator : {this.Name}, Current floor # : {this.DestinationFloor}, Door opened");
            System.Threading.Thread.Sleep(1000);
            CloseDoor();
        }
        public void CloseDoor()
        {
            Console.WriteLine($"Elevator : {this.Name}, Current floor # : {this.DestinationFloor}, Door closed, Thread ID : {System.Threading.Thread.CurrentThread.ManagedThreadId}");
        }

        private bool CheckCurrentRequestCompletion(int destinationFloor)
        {
            if (this.CurrentFloor == this.DestinationFloor)
            {
                CurrentRequestCompleted();
                return true;
            }
            return false;
        }

        private void CurrentRequestCompleted()
        {
            ElevatorController.Instance.ServiceRequestedCompleted(this.Name, this.DestinationFloor);
            this.OpenDoor();
        }

        private void VerifyCurrentNodeAndCarPosition()
        {
            int _carCurrentFloorValue = this.CurrentFloor;
            int _currentNodeValue = CurrentServiceRequestInProgress.Value;

            //Elevator is at starting point
            if (_carCurrentFloorValue == ElevatorController.Instance.MAX_FLOOR || _carCurrentFloorValue == ElevatorController.Instance.MAX_FLOOR)
            {
                CurrentServiceRequestInProgress = ServiceRequestList.First;
                return;
            }

            //in case if any new servicerequest node is inserted in between 
            if (CurrentServiceRequestInProgress.List.Any(ll => ll > _carCurrentFloorValue && ll < _currentNodeValue))
            {
                int newValue = CurrentServiceRequestInProgress
                                                        .List
                                                        .First(ll => ll > _carCurrentFloorValue && ll < _currentNodeValue);

                CurrentServiceRequestInProgress = CurrentServiceRequestInProgress
                                                        .List
                                                        .Find(newValue);
            }
        }

        private bool GetNextDestinationFloorToService(out int destinationFloor)
        {
            bool IsRequestPending = false;
            destinationFloor = 0;

            if (ServiceRequestList.Any() && ServiceRequestList.Count > 0)
            {
                if (CurrentServiceRequestInProgress == null)
                {
                    CurrentServiceRequestInProgress = ServiceRequestList.First;
                }
                else if (CurrentServiceRequestInProgress != null)
                {
                    VerifyCurrentNodeAndCarPosition();

                }
                destinationFloor = CurrentServiceRequestInProgress.Value;
                IsRequestPending = true;
            }

            return IsRequestPending;
        }

        /// <summary>
        /// 
        /// 
        /// 
        /// Alogrithm => To Set Elevator car movement
        ///     Check if Car is already moving
        ///         If No
        ///             Then read the next immediate destination floor
        ///             Begin Move
        ///         Else If Yes (car busy)
        ///             Then verify if next immediate destination is to be updated??
        /// </summary>
        public void ProcessRequestWorker()
        {
            //setup elevator direction
            if (ElevatorController.Instance.ElevatorRequestPipeline.ServiceRequestPipeLine.Any(sr=>sr.Value.ElevatorName.Equals(this.Name)))
            {
                var direction = ElevatorController.Instance.ElevatorRequestPipeline
                                                    .ServiceRequestPipeLine
                                                    .Values
                                                    .FirstOrDefault(sr => sr.ElevatorName.Equals(this.Name))
                                                    .ServiceRequestDirection;

                this.ElevatorDirection = direction;
                ProcessWorkerByDirection(direction);

                this.ElevatorDirection = direction == ElevatorDirection.Upwards ? ElevatorDirection.Downwards : ElevatorDirection.Upwards;
                ProcessWorkerByDirection(direction); 
            }
        }
        private void ProcessWorkerByDirection(ElevatorDirection direction)
        {

            bool IsPendingServiceRequest = false;
            int _destinationFloor;
            IsPendingServiceRequest = GetNextDestinationFloorToService(out _destinationFloor) ? true : false;

            //Step #1.1.3 => Begin working
            //Step #1.2.3 => Begin working
            while ((this.Status == ElevatorCarStatus.Idle || this.ServiceRequestList.Any()) && IsPendingServiceRequest)
            {
                this.DestinationFloor = _destinationFloor;

                ProcessRequestCurrent();

                IsPendingServiceRequest = GetNextDestinationFloorToService(out _destinationFloor) ? true : false;
            }
            if (!this.ServiceRequestList.Any() || this.ServiceRequestList.Count == 0)
            {
                ResetElevatorCar();
            }
        }

        private void ProcessRequestCurrent()
        {
            //Checking at start to ensure scenarios when Elevator current level is equal to requestor current/destination floor
            if (CheckCurrentRequestCompletion(this.DestinationFloor))
            {
                return;
            }

            while (this.CurrentFloor != this.DestinationFloor)
            {
                this.Status = ElevatorCarStatus.Busy;
                if (this.CurrentFloor - this.DestinationFloor > 0)
                {
                    MoveDown();
                }
                else
                {
                    MoveUp();
                }
            }

            //Checking at start to ensure scenarios when Elevator current level is equal to requestor current/destination floor
            CheckCurrentRequestCompletion(this.DestinationFloor);
        }

        private void MovingState()
        {
            this.Status = ElevatorCarStatus.Busy;
            System.Threading.Thread.Sleep(1500);
        }

        private void MoveUp()
        {
            MovingState();
            if (CurrentFloor < ElevatorController.Instance.MAX_FLOOR)
            {
                this.CurrentFloor++;
            }
        }
        private void MoveDown()
        {
            MovingState();
            if (CurrentFloor > ElevatorController.Instance.MIN_FLOOR)
            {
                this.CurrentFloor--;
            }
        }

        internal void AddNewServiceRequest(int floorNumber, ElevatorDirection elevatorDirection)
        {
            switch (elevatorDirection)
            {
                case ElevatorDirection.Upwards:
                    AddServiceRequestInUpwardList(floorNumber);
                    break;
                case ElevatorDirection.Downwards:
                    AddServiceRequestInDownwardList(floorNumber);
                    break;
            }
        }

        private bool AddServiceRequestInUpwardList(int floorRequested)
        {
            lock (ServiceRequestListUpwards)
            {
                //Check if its a first node
                if (!ServiceRequestListUpwards.Any())
                {
                    ServiceRequestListUpwards.AddFirst(floorRequested);
                    return true;
                }

                //Check if its should a last node
                int lastNodeValue = ServiceRequestListUpwards.Last.Value;
                if (floorRequested > lastNodeValue)
                {
                    ServiceRequestListUpwards.AddLast(floorRequested);
                    return true;
                }

                //check if its should a middle node
                //Todo - implement BinarySearch
                int currentValue = this.CurrentFloor;
                if (floorRequested > currentValue && floorRequested < lastNodeValue)
                {
                    if (ServiceRequestListUpwards.Any(ll => ll > currentValue))
                    {
                        LinkedListNode<int> currentNode = ServiceRequestListUpwards.First;
                        int newValue = 0;
                        while (currentNode != null && currentNode.Value < floorRequested)
                        {
                            newValue = currentNode.Value;
                            currentNode = currentNode.Next;
                        }
                        LinkedListNode<int> nodeAfter = ServiceRequestListUpwards.Find(newValue);
                        ServiceRequestListUpwards.AddAfter(nodeAfter, floorRequested);

                        return true;
                    }
                }
            }

            return false;
        }

        private bool AddServiceRequestInDownwardList(int floorRequested)
        {
            lock (ServiceRequestListDownwards)
            {
                //Check if its a first node
                if (!ServiceRequestListDownwards.Any())
                {
                    ServiceRequestListDownwards.AddFirst(floorRequested);
                    return true;
                }

                //Check if its should a last node
                int lastNodeValue = ServiceRequestListDownwards.Last.Value;
                if (floorRequested < lastNodeValue)
                {
                    ServiceRequestListDownwards.AddLast(floorRequested);
                    return true;
                }

                //check if its should a middle node
                int currentValue = this.CurrentFloor;
                if (floorRequested < currentValue && floorRequested > lastNodeValue)
                {
                    if (ServiceRequestListDownwards.Any(ll => ll < currentValue))
                    {
                        //Todo ; check if its working
                        int newValue = ServiceRequestListDownwards
                                            .Last(ll => ll < currentValue && ll > floorRequested);

                        LinkedListNode<int> nodeAfter = ServiceRequestListDownwards.Find(newValue);
                        ServiceRequestListDownwards.AddAfter(nodeAfter, floorRequested);

                        return true;
                    }
                }

            }

            return false;
        }

        internal bool RemoveCurrentNodefromList()
        {
            int currentNodeValue = CurrentServiceRequestInProgress.Value;
            LinkedListNode<int> temp = CurrentServiceRequestInProgress.Next;
            ServiceRequestList.Remove(currentNodeValue);
            CurrentServiceRequestInProgress = temp;

            return true;
        }

    }
    public class ElevatorCarPassenger : ElevatorCar
    {
        public ElevatorCarPassenger(string name, int currentFloor) : base(name, currentFloor, new ElevatorButton())
        {
        }
    }

    public class ElevatorServiceRequestLinkedListHelper
    {
        protected void AddNewServiceRequest(int floorNumber, ElevatorDirection elevatorDirection)
        {

        }
    }

}
