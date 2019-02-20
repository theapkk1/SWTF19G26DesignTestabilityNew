using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewECS.Legacy;
using NSubstitute;
using NUnit.Framework;

namespace Test.Unit.NSubstitute
{
    [TestFixture]
    public class Class1
    {
        private ECS _uut;
        private ITempSensor _tempSensor;
        private IHeater _heater;


        [SetUp]
        public void SetUp()
        {
            _heater = Substitute.For<IHeater>();
            _tempSensor = Substitute.For<ITempSensor>();

            _uut = new ECS(_tempSensor, _heater);
            _uut.SetThreshold(20);
        }

        [Test]
        public void Regulate_LastTempCorrect() // statebased test 
        {

            int A = _tempSensor.GetTemp(); // Act
            _uut.GetCurTemp();
            Assert.That(_uut.GetCurTemp(), Is.EqualTo(A));
        }

        [Test]
        public void Regulate_TempBelowThreshold_HeaterTurnOn() // adfærdstest
        {
            _tempSensor.GetTemp().Returns(_uut.GetThreshold() - 10); // denne returnere det der står inde i parameteren. Dvs. getTemp bliver lig med GetThreshold()-10.
            _uut.Regulate();
            _heater.Received(1).TurnOn();
        }

        [Test]
        public void Regulate_TempAboveThreshold_HeaterTurnOff() // adfærdstest
        {
            _tempSensor.GetTemp().Returns(_uut.GetThreshold() + 10); 
            _uut.Regulate();
            _heater.Received(1).TurnOff();
        }
    }
}



