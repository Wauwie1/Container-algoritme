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
        private List<ContainerColumn> containerColumns;
        public ColumnCreator(int maxRows)
        {
            containerColumns = new List<ContainerColumn>();
            this.maxRows = maxRows;
            
        }

        public List<ContainerColumn> CreateColumns(List<ContainerStack> containerStacks)
        {
            List<ContainerStack> cooledStacks = containerStacks.FindAll(cs => cs.IsCooled == true).ToList();

            foreach (ContainerStack cs in cooledStacks)
            {
                ContainerColumn cooledColumn = new ContainerColumn();
                cooledColumn.AddStack(cs);
                containerColumns.Add(cooledColumn);
            }

            LogColumns();
            return containerColumns;
        }

        private void LogColumns()
        {
            int column = 0;
            foreach(var cc in containerColumns)
            {
                int stack = 0;
                Console.WriteLine(string.Format("COLUMN: {0}", column));
                column++;
                foreach(var cs in cc.containerStacks)
                {
                    Console.WriteLine(string.Format("STACK: {0}", stack));
                    stack++;
                    foreach(var container in cs.stackedContainers)
                    {
                        Console.WriteLine(string.Format("--- {0}", container.ToString()));
                    }
                }
            }
        }
    }
}
