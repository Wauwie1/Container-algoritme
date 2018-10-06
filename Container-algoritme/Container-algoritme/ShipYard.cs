using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Container_algoritme
{
    class ShipYard
    {
        private List<ContainerStack> containerStacks;
        private List<Container> toBeStackedContainers;

        public ShipYard(List<Container> toBePlaced)
        {
            //Init list
            containerStacks = new List<ContainerStack>();

            //Order toBeStackedContainers
            toBeStackedContainers = toBePlaced;
            OrderContainersByWeight();
            //Inital stack
            ContainerStack initialStack = new ContainerStack(toBeStackedContainers[0]);
            containerStacks.Add(initialStack);

            //Remove intial container
            toBeStackedContainers.Remove(toBeStackedContainers[0]);
        }

        public void CreateStacks()
        {
            CreateCooledStacks();
        }

        private void CreateCooledStacks()
        {
            List<Container> cooledContainers = toBeStackedContainers.FindAll(c => c.type == Types.ContainerType.cooled);

            foreach (var container in cooledContainers)
            {
                bool containerIsAdded = false;
                for (int i = 0; i < containerStacks.Count && !containerIsAdded; i++)
                {
                    if (containerStacks[i].StackContainer(container))
                    {
                        containerIsAdded = true;
                    }
                    else if (i == containerStacks.Count - 1)
                    {
                        ContainerStack newStack = new ContainerStack(container);
                        containerStacks.Add(newStack);
                        containerStacks[i + 1].StackContainer(container);
                        containerIsAdded = true;
                    }

                }
            }
        }

        private void OrderContainersByWeight()
        {
            toBeStackedContainers = toBeStackedContainers.OrderByDescending(c => c.weight).ToList();
        }
    }
}
