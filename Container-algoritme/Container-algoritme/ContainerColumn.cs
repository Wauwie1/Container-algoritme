using System;
using System.Collections.Generic;

namespace Container_algoritme
{
    class ContainerColumn
    {
        public List<ContainerStack> ContainerStacks { get; private set; }
        public bool ContainsPrecious { get; set; }

        public int TotalWeight { get; set; }

        private int MaxRows { get; set; }

        public ContainerColumn(int maxrows)
        {
            //Init
            ContainerStacks = new List<ContainerStack>();
            ContainsPrecious = false;
            TotalWeight = 0;
            MaxRows = maxrows;
        }
        public void AddStack(ContainerStack containerStack)
        {
            //Checks max rows dont get exceeded
            if(ContainerStacks.Count - 1 >= MaxRows)
            {
                throw new Exception("Max stacks reached");
            }

            //Sets the column to precious
            if(containerStack.IsPrecious == true)
            {
                ContainsPrecious = true;
            }

            //Adds the stack to the column and adds its weight
            ContainerStacks.Add(containerStack);
            TotalWeight += containerStack.GetTotalWeight();
        }
    }
}
