using System.Collections.Generic;

namespace Container_algoritme
{
    class ShipYard
    {
        private Ship _ship;

        private List<ContainerStack> _containerStacks;
        public List<ContainerColumn> ContainerColumns;
        private readonly Stacker _stacker;
        private readonly ColumnCreator _columnCreator;
        

        public ShipYard(Ship ship)
        {
            this._ship = ship;
            _containerStacks = new List<ContainerStack>();
            _stacker = new Stacker();
            _columnCreator = new ColumnCreator(ship.RowsAmount);

            
        }

        public void CreateStacks(List<Container> toBeStacked)
        {
            _containerStacks = _stacker.StackContainers(toBeStacked);
        }

        public void CreateColumns()
        {
            ContainerColumns = _columnCreator.CreateColumns(_containerStacks);
        }

    }
}
