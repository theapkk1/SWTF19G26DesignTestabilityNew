namespace NewECS.Legacy
{
    public class ECS
    {
        private int _threshold;
        
        private readonly ITempSensor _tempSensor;
        private readonly IHeater _heater;
        


        //public ECS(int thr)
        //{
        //    SetThreshold(thr);
        //    _tempSensor = new TempSensor();
        //    _heater = new Heater();
        //}

        // We use constructor injection for all dependencies
        public ECS(ITempSensor tempSensor, IHeater heater)
        {
            // Save references to dependencies
            _tempSensor = tempSensor;
            _heater = heater;
            


            // Initialize properties
            //UpperTemperatureThreshold = upperTemperatureThreshold;
            //LowerTemperatureThreshold = lowerTemperatureThreshold;

        }

        public void Regulate()
        {
            var t = _tempSensor.GetTemp();
            if (t < _threshold)
                _heater.TurnOn();
            else
                _heater.TurnOff();
        }

        public void SetThreshold(int thr)
        {
            _threshold = thr;
        }

        public int GetThreshold()
        {
            return _threshold;
        }

        public int GetCurTemp()
        {
            return _tempSensor.GetTemp();
        }

        public bool RunSelfTest()
        {
            return _tempSensor.RunSelfTest() && _heater.RunSelfTest();
        }
    }
}
