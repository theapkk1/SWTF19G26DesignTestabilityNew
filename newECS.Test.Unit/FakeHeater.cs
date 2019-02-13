using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewECS.Legacy;

namespace newECS.Test.Unit
{
    public class FakeHeater : IHeater
    {
        private int TurnOnCount = 0;
        private int TurnOffCount = 0;

        public void TurnOn()
        {
            for (int i = 0; i < 100; i++)
            {
                TurnOnCount = i;
            }
        }

        public void TurnOff()
        {
            for (int i = 0; i < 100; i++)
            {
                TurnOffCount = i;
            }
        }

        public bool RunSelfTest()
        {
            return true;
        }

        public int GetOnCount()
        {
            return TurnOnCount;
            
        }

        public int GetOffCount()
        {
          return TurnOffCount;
        }
    }
}
