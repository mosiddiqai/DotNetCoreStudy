using System;
using System.Collections.Generic;
using System.Linq;
//
using System.Threading.Tasks;

namespace ElevatorSystem
{
    public enum ElevatorDirection
    {
        Upwards = 0,
        Downwards = 1,
        None = 3
    };

    public class ElevatorServiceRequest
    {
        public Guid ServiceRequestId { get; set; }
        public int DeistinationFloor { get; set; }
        public int SourceFloor { get; set; }
        public string ElevatorName { get; set; }
        public ElevatorDirection ServiceRequestDirection { get; set; }
    }
    
    public enum ElevatorCarStatus
    {
        Idle = 0,
        Busy = 1,
        Waiting = 2
    }

    

    
}
