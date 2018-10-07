using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Container_algoritme
{
    class ColumnCreator
    {
        private int maxRows;
        private List<ContainerStack> containerStacks;
        private List<ContainerColumn> containerColumns;
        public ColumnCreator(int maxRows, List<ContainerStack> containerStacks)
        {
            this.maxRows = maxRows;
            this.containerStacks = containerStacks;
        }

        public void CreateColumns()
        {
            List<ContainerStack> cooledStacks = containerStacks.FindAll(cs => cs.IsCooled == true).ToList();

            foreach (ContainerStack cs in cooledStacks)
            {
                ContainerColumn cooledColumn = new ContainerColumn();
                cooledColumn.AddStack(cs);
            }
        }
    }
}
