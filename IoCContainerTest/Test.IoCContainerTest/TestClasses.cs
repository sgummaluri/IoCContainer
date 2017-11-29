using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.IoCContainerTest
{
    interface IA : IB { }
    interface IB { }
    interface IC { }
    interface IE { }

    class B : IB
    { }

    class A : B, IA
    { }

    class E : IE
    { }

    class C : IC
    {
        public C(IB a, IA e)
        {
        }

        public C(IA b, IB e)
        {
        }
    }
}
