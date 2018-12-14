using System;
using System.Collections.Generic;
using System.Linq;

namespace Container_algoritme
{
    class Ship
    {
        public int MaxWeight { get;  private set; }
        private int CurrentWeight { get; set; }
        public ContainerColumn[] ColumnGrid { get; private set; }
        public int RowsAmount { get; private set; }
        public int ColumnsAmount { get; private set; }
        private List<ContainerColumn> ToBePlacedColumns { get; set; }

        //Constructor
        public Ship(int rows, int columns, int maxWeight)
        {
            //Init
            CurrentWeight = 0;
            this.RowsAmount = rows;
            this.ColumnsAmount = columns;
            ColumnGrid = new ContainerColumn[columns];
            this.MaxWeight = maxWeight;
        }

        public void PlaceColumns(List<ContainerColumn> containerColumns)
        {
            ToBePlacedColumns = containerColumns.OrderByDescending(col => col.ContainsPrecious == true).ToList();
            PlacePreciousColumns();
            PlaceRemainingColumns();
            
        }

        private void PlacePreciousColumns()
        {
            //Find last index
            int lastEntry = ColumnGrid.Length - 1;

            //Try to place precious columns
            try
            {
                PlaceColumnInGrid(ToBePlacedColumns[0], 0);
                PlaceColumnInGrid(ToBePlacedColumns[1], lastEntry);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Precious column(s) cant be placed: " + ex.Message);
            }
        }

        private void PlaceRemainingColumns()
        {
            //Plaats overige kolommen in lege posities 
            foreach(ContainerColumn cc in ColumnGrid)
            {
                //Als de positie leeg is...
                if(cc == null)
                {
                    //...probeer te plaatsen...
                    try
                    {
                        var index = Array.FindIndex(ColumnGrid, col => col == cc);
                        ColumnGrid[index] = ToBePlacedColumns[0];
                        ToBePlacedColumns.RemoveAt(0);
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
            if(ColumnGrid[position] == null && containerColumn.TotalWeight + CurrentWeight <= MaxWeight)
            {
                ColumnGrid[position] = containerColumn;
                ToBePlacedColumns.Remove(containerColumn);
            }
            else
            {
                if(ColumnGrid[position] != null)
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
