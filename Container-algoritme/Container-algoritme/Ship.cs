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
        public int Rows { get; private set; }
        public int Columns { get; private set; }
        public Ship(int rows, int columns, int maxWeight)
        {
            StackGrid = new ContainerStack[(int)rows, (int)columns];
            this.MaxWeight = maxWeight;
        }
    }
}
