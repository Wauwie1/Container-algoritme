using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Container_algoritme
{
    class Stacker
    {
        private List<ContainerStack> containerStacks;
        private List<Container> toBeStackedContainers;

        public List<ContainerStack> StackContainers(List<Container> containers)
        {
            //Init list
            containerStacks = new List<ContainerStack>();

            //Order toBeStackedContainers
            toBeStackedContainers = containers;
            OrderContainersByWeight();
            //Inital stack
            ContainerStack initialStack = new ContainerStack(toBeStackedContainers[0]);
            containerStacks.Add(initialStack);

            //Remove intial container
            toBeStackedContainers.Remove(toBeStackedContainers[0]);

            CreateStacks();
            return containerStacks;
        }

        private void CreateStacks()
        {
            //Creates stacks for each type
            CreateStacksOfType(Types.ContainerType.cooled);
            CreateStacksOfType(Types.ContainerType.regular);
            CreateStacksOfType(Types.ContainerType.precious);

            //Debug
            LogContainers();

        }

        private void CreateStacksOfType(Types.ContainerType containerType)
        {
            //Gets all the containers of a specific type
            List<Container> ContainersOfType = toBeStackedContainers.FindAll(c => c.type == containerType);

            foreach (var container in ContainersOfType)
            {
                bool containerIsAdded = false;
                //...and tries to place it in a stack...
                for (int i = 0; i < containerStacks.Count && !containerIsAdded; i++)
                {
                    if (containerStacks[i].StackContainer(container))
                    {
                        containerIsAdded = true;
                    }
                    //If it can't be placed onto any stack, create a new stack
                    else if (i == containerStacks.Count - 1)
                    {
                        ContainerStack newStack = new ContainerStack(container);
                        containerStacks.Add(newStack);
                        containerIsAdded = true;
                    }

                }
            }
        }

        private void OrderContainersByWeight()
        {
            //Uses linq to sort by weight
            toBeStackedContainers = toBeStackedContainers.OrderByDescending(c => c.weight).ToList();
        }

        private void LogContainers()
        {
            //Outputs every stack and its containers to the console
            int stack = 0;
            foreach (ContainerStack cs in containerStacks)
            {
                Console.WriteLine(stack);
                Console.WriteLine(string.Format("Contains cooled: {0}. Contains precious: {1}.", cs.IsCooled, cs.IsPrecious));
                stack++;
                foreach (Container c in cs.stackedContainers)
                {
                    Console.WriteLine(string.Format("-----{0} container, {1} tons.", c.type, c.weight));
                }
            }
        }
    }
}