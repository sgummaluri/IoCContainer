using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoCContainerTest
{
    public class RegisteredEntry
    {        
        public RegisteredEntry(Type AbstractType, Type ConcreteType, LifeCycle lifecycle, string entryName)
        {
            this.AbstractType = AbstractType;
            this.ConcreteType = ConcreteType;
            this.lifecycle = lifecycle;
            this.EntryName = entryName;
        }

        public Type AbstractType { get; private set; }
        public Type ConcreteType { get; private set; }
        public LifeCycle lifecycle { get; private set; }
        public object Instance { get; private set; }

        public string EntryName { get; private set; }
        public void CreateInstance(object[] args)
        {
            this.Instance = Activator.CreateInstance(this.ConcreteType, args);
        }
    }
}
