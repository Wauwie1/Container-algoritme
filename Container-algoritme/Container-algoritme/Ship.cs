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
        private int currentWeight { get; set; }
        private ContainerColumn[] columnGrid { get; set; }
        public int RowsAmount { get; private set; }
        public int ColumnsAmount { get; private set; }
        private List<ContainerColumn> toBePlacedColumns { get; set; }

        public Ship(int rows, int columns, int maxWeight)
        {
            currentWeight = 0;
            this.RowsAmount = rows;
            columnGrid = new ContainerColumn[columns];
            this.MaxWeight = maxWeight;
        }

        public void PlaceColumns(List<ContainerColumn> containerColumns)
        {
            toBePlacedColumns = containerColumns.OrderByDescending(col => col.ContainsPrecious == true).ToList();
            PlacePreciousColumns();
            
        }

        private void PlacePreciousColumns()
        {
            int lastEntry = columnGrid.Length - 1;
            try
            {
                PlaceColumnInGrid(toBePlacedColumns[0], 0);
                PlaceColumnInGrid(toBePlacedColumns[1], lastEntry);
            }
            catch (Exception)
            {
                Console.WriteLine("Precious columns cant be placed.");
            }
        }

        private void PlaceColumnInGrid(ContainerColumn containerColumn, int position)
        {
            if(columnGrid[position] == null && containerColumn.totalWeight + currentWeight <= MaxWeight)
            {
                columnGrid[position] = containerColumn;
                toBePlacedColumns.Remove(containerColumn);
            }
            else
            {
                if(columnGrid[position] != null)
                {
                    throw new Exception("Position already occupied.");
                }
                else
                {
                    throw new Exception("Exceeding max weight.");
                }
            }
        }
    }
}
