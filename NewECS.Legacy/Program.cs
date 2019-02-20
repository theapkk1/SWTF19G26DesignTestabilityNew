using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewECS.Legacy
{
    class Program
    {
        public static void Main(string[] args)
        {
            IHeater heater = new Heater();
            ITempSensor tempSensor = new TempSensor();
            
            var ecs = new ECS(tempSensor,heater);

            ecs.Regulate();

            ecs.SetThreshold(20);

            ecs.Regulate();
        }
    }
}
