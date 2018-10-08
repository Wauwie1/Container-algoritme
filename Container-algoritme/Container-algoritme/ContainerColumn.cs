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

        public int totalWeight { get; set; }

        public ContainerColumn()
        {
            containerStacks = new List<ContainerStack>();
            ContainsPrecious = false;
            totalWeight = 0;
        }
        public void AddStack(ContainerStack containerStack)
        {
            containerStacks.Add(containerStack);
            totalWeight += containerStack.GetTotalWeight();
        }
    }
}
