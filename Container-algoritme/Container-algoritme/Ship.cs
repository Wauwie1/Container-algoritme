using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Container_algoritme
{
    class Ship
    {
        public int MaxWeight { get;  private set; }
        private ContainerStack[,] StackGrid;

        public Ship(decimal rows, decimal columns, int maxWeight)
        {
            StackGrid = new ContainerStack[(int)rows, (int)columns];
            this.MaxWeight = maxWeight;
        }
    }
}
