using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoCContainerTest
{
    public class test
    {
    }

    public class test1 : test
    {

    }

    public class test2
    {
        public test2(test t, test1 t1)
        {

        }

        public test2(test1 t1, test t)
        {

        }
    }    
}
