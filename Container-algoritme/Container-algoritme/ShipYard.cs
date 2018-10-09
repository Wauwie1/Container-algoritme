using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Container_algoritme
{
    class ShipYard
    {
        private Ship ship;

        private List<ContainerStack> containerStacks;
        public List<ContainerColumn> containerColumns;
        private Stacker stacker;
        private ColumnCreator columnCreator;
        

        public ShipYard(Ship ship)
        {
            this.ship = ship;
            containerStacks = new List<ContainerStack>();
            stacker = new Stacker();
            columnCreator = new ColumnCreator(ship.RowsAmount);

            
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
