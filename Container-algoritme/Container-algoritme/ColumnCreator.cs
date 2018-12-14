using System;
using System.Collections.Generic;
using System.Linq;

namespace Container_algoritme
{
    class ColumnCreator
    {
        private int _maxRows;
        public List<ContainerColumn> ContainerColumns { get; private set; }
        private readonly List<ContainerStack> _unplaceableStacks;
        private List<ContainerStack> _toBePlacedStacks;
        public ColumnCreator(int maxRows)
        {
            ContainerColumns = new List<ContainerColumn>();
            _unplaceableStacks = new List<ContainerStack>();
            _maxRows = maxRows;

        }

        public List<ContainerColumn> CreateColumns(List<ContainerStack> toBePlacedStacks)
        {
            _toBePlacedStacks = toBePlacedStacks;
            CreateCooledColumns();
            CreatePreciousColumns();
            //TrimUnplacedPreciousStacks();
            CreateRegularColumns();

            LogColumns();
            return ContainerColumns;
        }

        private void CreateCooledColumns()
        {
            //Creates new columns for each cooled stack
            List<ContainerStack> cooledStacks   = _toBePlacedStacks.FindAll(cs => cs.IsCooled).ToList();

            foreach (ContainerStack cs in cooledStacks)
            {
                ContainerColumn cooledColumn = new ContainerColumn(_maxRows);
                cooledColumn.AddStack(cs);
                _toBePlacedStacks.Remove(cs);
                ContainerColumns.Add(cooledColumn);
            }
        }

        private void CreatePreciousColumns()
        {

            List<ContainerStack> preciousStacks = _toBePlacedStacks.FindAll(cs => cs.IsPrecious).ToList();
            int preciousStacksAmount = preciousStacks.Count;


            //Creates at least two columns
            while (ContainerColumns.Count < 2)
            {
                ContainerColumn cc = new ContainerColumn(_maxRows);
                ContainerColumns.Add(cc);
            }

            ContainerColumns = ContainerColumns.OrderByDescending(cc => cc.TotalWeight).ToList();
            ContainerColumn heaviest1 = ContainerColumns[0];
            ContainerColumn heaviest2 = ContainerColumns[1];

            foreach (ContainerStack cs in preciousStacks)
            {
                if (heaviest1.TotalWeight > heaviest2.TotalWeight)
                {
                    try
                    {
                        heaviest2.AddStack(cs);
                        _toBePlacedStacks.Remove(cs);
                    }
                    catch (Exception)
                    {
                        try
                        {
                            heaviest1.AddStack(cs);
                            _toBePlacedStacks.Remove(cs);
                        }
                        catch
                        {
                            _unplaceableStacks.Add(cs);
                            _toBePlacedStacks.Remove(cs);
                        }
                    }
                }
                else
                {
                    try
                    {
                        heaviest1.AddStack(cs);
                        _toBePlacedStacks.Remove(cs);
                    }
                    catch (Exception)
                    {
                        try
                        {
                            heaviest2.AddStack(cs);
                            _toBePlacedStacks.Remove(cs);
                        }
                        catch
                        {
                            _unplaceableStacks.Add(cs);
                            _toBePlacedStacks.Remove(cs);
                        }
                    }
                }

            }
        } 

        private void CreateRegularColumns()
        {
            foreach(ContainerStack cs in _toBePlacedStacks)
            {
                bool stackIsAdded = false;
                
                for (int i = 0; i < ContainerColumns.Count && !stackIsAdded; i++)
                {
                    try
                    {
                        ContainerColumns[i].AddStack(cs);
                        stackIsAdded = true;
                    }catch
                    {
                        //If it can't be placed in any column, create a new column
                        if (i == ContainerColumns.Count - 1)
                        {
                            ContainerColumn newColumn = new ContainerColumn(_maxRows);
                            newColumn.AddStack(cs);
                            ContainerColumns.Add(newColumn);
                            stackIsAdded = true;
                        }
                    }
                   

                }
            }
        }

        private void TrimUnplacedPreciousStacks()
        {
            List<ContainerStack> trimmedList = new List<ContainerStack>(_unplaceableStacks);

           //Removes last entry in stack, which is precious
           foreach(ContainerStack cs in trimmedList)
            {
                _unplaceableStacks.Remove(cs);
                cs.StackedContainers.Remove(cs.StackedContainers[cs.StackedContainers.Count - 1]);
                if (cs.StackedContainers.Count != 0)
                {
                    //Add trimmed list to unplaced stacks
                    _toBePlacedStacks.Add(cs);
                }
                
            }

        }
        private void LogColumns()
        {
            int column = 0;
            foreach (var cc in ContainerColumns)
            {
                int stack = 0;
                Console.WriteLine("");
                Console.WriteLine($"COLUMN: {column}. Weight: {cc.TotalWeight}");
                column++;
                foreach (var cs in cc.ContainerStacks)
                {
                    Console.WriteLine($"STACK: {stack}");
                    stack++;
                    foreach (var container in cs.StackedContainers)
                    {
                        Console.WriteLine($"--- {container.ToString()}");
                    }
                }
            }
        }
    }
}
