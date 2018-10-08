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
        private ColumnCreator columnCreator;

        public ShipYard()
        {
            containerStacks = new List<ContainerStack>();
            stacker = new Stacker();
            columnCreator = new ColumnCreator(5);
            
        }

        public void CreateStacks(List<Container> toBeStacked)
        {
            containerStacks = stacker.StackContainers(toBeStacked);
        }

        public void CreateColumns()
        {
            containerColumns = columnCreator.CreateColumns(containerStacks);
        }

    }
}
