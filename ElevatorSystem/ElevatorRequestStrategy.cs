using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSystem
{
    public interface IElevatorRequestStrategy
    {
        void AddRequestToPipeline();
    }

    public class ElevatorRequestSimpleAlgorithm : IElevatorRequestStrategy
    {
        public void AddRequestToPipeline()
        {
            throw new NotImplementedException();
        }
    }
}
