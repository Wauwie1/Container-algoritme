﻿using System;
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
        private List<ContainerStack> unplaceableStacks;
        public ColumnCreator(int maxRows)
        {
            containerColumns = new List<ContainerColumn>();
            unplaceableStacks = new List<ContainerStack>();
            this.maxRows = maxRows;

        }

        public List<ContainerColumn> CreateColumns(List<ContainerStack> containerStacks)
        {
            CreateCooledColumns(containerStacks);
            CreatePreciousColumns(containerStacks);

            LogColumns();
            return containerColumns;
        }

        private void CreateCooledColumns(List<ContainerStack> containerStacks)
        {
            //Creates new columns for each cooled stack
            List<ContainerStack> cooledStacks = containerStacks.FindAll(cs => cs.IsCooled == true).ToList();

            foreach (ContainerStack cs in cooledStacks)
            {
                ContainerColumn cooledColumn = new ContainerColumn(maxRows);
                cooledColumn.AddStack(cs);
                containerColumns.Add(cooledColumn);
            }
        }

        private void CreatePreciousColumns(List<ContainerStack> containerStacks)
        {

            List<ContainerStack> preciousStacks = containerStacks.FindAll(cs => cs.IsPrecious == true).ToList();
            int preciousStacksAmount = preciousStacks.Count;


            //Creates at least two columns
            while (containerColumns.Count < 2)
            {
                ContainerColumn cc = new ContainerColumn(maxRows);
                containerColumns.Add(cc);
            }

            containerColumns = containerColumns.OrderByDescending(cc => cc.totalWeight).ToList();
            ContainerColumn heaviest1 = containerColumns[0];
            ContainerColumn heaviest2 = containerColumns[1];

            foreach (ContainerStack cs in preciousStacks)
            {
                if (heaviest1.totalWeight > heaviest2.totalWeight)
                {
                    try
                    {
                        heaviest2.AddStack(cs);
                    }
                    catch (Exception)
                    {
                        try
                        {
                            heaviest1.AddStack(cs);
                        }
                        catch
                        {
                            unplaceableStacks.Add(cs);
                        }
                    }
                }
                else
                {
                    try
                    {
                        heaviest1.AddStack(cs);
                    }
                    catch (Exception)
                    {
                        try
                        {
                            heaviest2.AddStack(cs);
                        }
                        catch
                        {
                            unplaceableStacks.Add(cs);
                        }
                    }
                }

            }
        }

        private void LogColumns()
        {
            int column = 0;
            foreach (var cc in containerColumns)
            {
                int stack = 0;
                Console.WriteLine("");
                Console.WriteLine(string.Format("COLUMN: {0}. Weight: {1}", column, cc.totalWeight));
                column++;
                foreach (var cs in cc.containerStacks)
                {
                    Console.WriteLine(string.Format("STACK: {0}", stack));
                    stack++;
                    foreach (var container in cs.stackedContainers)
                    {
                        Console.WriteLine(string.Format("--- {0}", container.ToString()));
                    }
                }
            }
        }
    }
}
