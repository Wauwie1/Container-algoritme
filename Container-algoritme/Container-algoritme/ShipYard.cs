using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Container_algoritme
{
    class ShipYard
    {
        private List<ContainerStack> containerStacks;
        private List<ContainerColumn> containerColumns;
        private Stacker stacker;

        public ShipYard()
        {
            containerStacks = new List<ContainerStack>();
            stacker = new Stacker();
            
        }

        public void CreateStacks(List<Container> toBeStacked)
        {
            containerStacks = stacker.StackContainers(toBeStacked);
        }

        public void CreateColumns(List<Container> toBeStacked)
        {
           // containerColumns;
        }

    }
}
