using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoCContainerTest
{
    public class Container : IContainer
    {
        public List<RegisteredEntry> registeredEntries = new List<RegisteredEntry>();
        public void Register<AbstractType, ConcreteType>() where ConcreteType : class
        {
            Register<AbstractType, ConcreteType>(LifeCycle.Transient); //changed this to Transient from Singleton
        }

        public void Register<AbstractType, ConcreteType>(LifeCycle lifeCycle)
        {
            registeredEntries.Add(new RegisteredEntry(typeof(AbstractType), typeof(ConcreteType), lifeCycle, string.Empty));
        }

        public void Register<AbstractType, ConcreteType>(LifeCycle lifeCycle, string entryName)
        {
            registeredEntries.Add(new RegisteredEntry(typeof(AbstractType), typeof(ConcreteType), lifeCycle, entryName));
        }

        public AbstractType Resolve<AbstractType>()
        {
            return (AbstractType)ResolveObject(typeof(AbstractType));
        }

        private object ResolveObject(Type AbstractType)
        {
            var obj = registeredEntries.FirstOrDefault( x => (x.AbstractType == AbstractType));
            if (obj == null)
                throw new ApplicationException("Unregistered Type");
            else
                return GetInstance(obj);
        }

        private object GetInstance(RegisteredEntry obj)
        {
            if(obj.Instance == null || obj.lifecycle == LifeCycle.Transient)
            {
                var ctorParams = GetCTorParameters(obj);
                var sanitizedCtorParams = (ctorParams == null || ctorParams.Count() == 0) ? null : ctorParams.ToArray();
                obj.CreateInstance(sanitizedCtorParams);
            }

            return obj.Instance;
        }

        private IEnumerable<object> GetCTorParameters(RegisteredEntry obj)
        {
            var ctors = obj.ConcreteType.GetConstructors(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Static).First();

            foreach(var param in ctors.GetParameters())
            {
                yield return ResolveObject(param.ParameterType);
            }            
        }

        public object Resolve(Type AbstractType)
        {
            return ResolveObject(AbstractType);
        }
    }
}
