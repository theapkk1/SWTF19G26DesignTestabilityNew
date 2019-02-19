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

            _uut = new ECS(_tempSensor, _heater, 20);
        }

        [Test]
        public void Regulate_LastTempCorrect()
        {

            int A = _tempSensor.GetTemp(); // Act
            _uut.GetCurTemp();
            Assert.That(_uut.GetCurTemp(), Is.EqualTo(A));
        }
    }
}



