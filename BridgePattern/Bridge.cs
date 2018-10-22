using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern
{
    public abstract class WebApplication
    {
        public abstract void CreatePayload();
    }
    public class Blog : WebApplication
    {
        public override void CreatePayload()
        {
            Console.WriteLine("Simple Blog without any ");
        }
    }
}
