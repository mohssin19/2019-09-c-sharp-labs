using NUnit.Framework;
using test_me_out;
using justdoit;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        //[TestCase(10,100)]
        //[TestCase(10, 10000)]
        //[TestCase(9, 81)]
      [Test]
      public void Test()
        {
            Assert.AreEqual ( 1,1);
        }
        //public void Test1()
        //{
            //var expected = 100;
            //var actual = TestMeSomething.RunThisTestNow(10);
            //Assert.AreEqual(expected, actual);
        //}
        [TestCase(1000, 15)]
        public void TestRabbitExplosion(int populationLimit, int expectedYears)
        {
            //arrange

            //act
            var actualYears = just_do_it_11_rabbit_explosion.Rabbit_Exponential_Growth(populationLimit);

            Assert.AreEqual(expectedYears, actualYears);
        }

    }
}