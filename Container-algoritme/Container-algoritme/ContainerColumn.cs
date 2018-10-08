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

        private int maxRows { get; set; }

        public ContainerColumn(int maxrows)
        {
            containerStacks = new List<ContainerStack>();
            ContainsPrecious = false;
            totalWeight = 0;
            this.maxRows = maxrows;
        }
        public void AddStack(ContainerStack containerStack)
        {
            if(containerStacks.Count - 1 >= maxRows)
            {
                throw new Exception("Max stacks reached");
            }

            if(containerStack.IsPrecious == true)
            {
                ContainsPrecious = true;
            }
            containerStacks.Add(containerStack);
            totalWeight += containerStack.GetTotalWeight();
        }
    }
}
