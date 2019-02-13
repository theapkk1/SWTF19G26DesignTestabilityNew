using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewECS.Legacy;
using NUnit.Framework;

namespace newECS.Test.Unit
{
    [TestFixture]
    class newECSUnitTest
    {
        private ECS _uut;
        private FakeHeater _fakeHeater;
        private FakeTempSensor _fakeTempSensor;
        

        [SetUp]
        public void SetUp()
        {
            _uut = new ECS(20);
            _fakeTempSensor = new FakeTempSensor();
            _fakeHeater = new FakeHeater();
        }

        [Test]
        public void Regulate_LastTempCorrect()
        {
            _fakeTempSensor.Temp = 50; // Act

            _uut.Regulate();
            Assert.That(_uut.GetCurTemp(), Is.EqualTo(50));
        }
    }
}
