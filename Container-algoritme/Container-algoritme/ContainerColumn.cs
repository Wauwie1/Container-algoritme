using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Container_algoritme
{
    class ContainerColumn
    {
        //TODO make private
        public List<ContainerStack> containerStacks;
        public bool ContainsPrecious { get; set; }

        public ContainerColumn()
        {
            containerStacks = new List<ContainerStack>();
            ContainsPrecious = false;
        }
        public void AddStack(ContainerStack containerStack)
        {
            containerStacks.Add(containerStack);
        }
    }
}
