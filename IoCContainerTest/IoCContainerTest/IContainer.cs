using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoCContainerTest
{
    public interface IContainer
    {
        void Register<AbstractType, ConcreteType>() where ConcreteType : class;

        void Register<AbstractType, ConcreteType>(LifeCycle lifeCycle);

        void Register<AbstractType, ConcreteType>(LifeCycle lifeCycle, string entryName);

        AbstractType Resolve<AbstractType>();

        object Resolve(Type AbstractType);
    }
}
