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
            //Init
            containerStacks = new List<ContainerStack>();
            ContainsPrecious = false;
            totalWeight = 0;
            this.maxRows = maxrows;
        }
        public void AddStack(ContainerStack containerStack)
        {
            //Checks max rows dont get exceeded
            if(containerStacks.Count - 1 >= maxRows)
            {
                throw new Exception("Max stacks reached");
            }

            //Sets the column to precious
            if(containerStack.IsPrecious == true)
            {
                ContainsPrecious = true;
            }

            //Adds the stack to the column and adds its weight
            containerStacks.Add(containerStack);
            totalWeight += containerStack.GetTotalWeight();
        }
    }
}
