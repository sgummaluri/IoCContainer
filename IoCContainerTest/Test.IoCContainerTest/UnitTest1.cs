using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IoCContainerTest;

namespace Test.IoCContainerTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var test1 = new test1();
            //var test2 = new test2(test1, test1);
            Assert.IsNotNull(test1);
        }

        [TestMethod]
        public void Should_resolve_correct_constructor()
        {
            Container container = new Container();
            container.Register<IA, A>();
            //container.Register<IB, A>();
            container.Register<IB, B>();
            container.Register<IC, C>();
            container.Register<IE, E>();

            var c = container.Resolve<IC>();

            Assert.IsNotNull(c);
        }
    }
}
