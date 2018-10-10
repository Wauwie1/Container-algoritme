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

        //Constructor
        public Ship(int rows, int columns, int maxWeight)
        {
            //Init
            currentWeight = 0;
            this.RowsAmount = rows;
            columnGrid = new ContainerColumn[columns];
            this.MaxWeight = maxWeight;
        }

        public void PlaceColumns(List<ContainerColumn> containerColumns)
        {
            //
            toBePlacedColumns = containerColumns.OrderByDescending(col => col.ContainsPrecious == true).ToList();
            PlacePreciousColumns();
            PlaceRemainingColumns();
            
        }

        private void PlacePreciousColumns()
        {
            //Find last index
            int lastEntry = columnGrid.Length - 1;

            //Try to place precious columns
            try
            {
                PlaceColumnInGrid(toBePlacedColumns[0], 0);
                PlaceColumnInGrid(toBePlacedColumns[1], lastEntry);
            }
            catch (Exception)
            {
                Console.WriteLine("Precious column(s) cant be placed.");
            }
        }

        private void PlaceRemainingColumns()
        {
            //Plaats overige kolommen in lege posities 
            foreach(ContainerColumn cc in columnGrid)
            {
                //Als de positie leeg is...
                if(cc == null)
                {
                    //...probeer te plaatsen...
                    try
                    {
                        var index = Array.FindIndex(columnGrid, col => col == cc);
                        columnGrid[index] = toBePlacedColumns[0];
                        toBePlacedColumns.RemoveAt(0);
                    }
                    //...als dat niet kan (plek is bezet/te zwaar), probeer volgende plek
                    //   in de grid.
                    catch (Exception)
                    {
                        return;
                    }
                }
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
