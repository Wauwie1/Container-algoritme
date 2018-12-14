using System;
using System.Collections.Generic;
using System.Linq;

namespace Container_algoritme
{
    class Stacker
    {
        private List<ContainerStack> _containerStacks;
        private List<Container> _toBeStackedContainers;

        public List<ContainerStack> StackContainers(List<Container> containers)
        {
            //Init list
            _containerStacks = new List<ContainerStack>();

            //Order toBeStackedContainers
            _toBeStackedContainers = containers;
            OrderContainersByWeight();
            //Inital stack
            ContainerStack initialStack = new ContainerStack(_toBeStackedContainers[0]);
            _containerStacks.Add(initialStack);

            //Remove intial container
            _toBeStackedContainers.Remove(_toBeStackedContainers[0]);

            CreateStacks();
            return _containerStacks;
        }

        private void CreateStacks()
        {
            //Creates stacks for each type
            CreateStacksOfType(Types.ContainerType.Cooled);
            CreateStacksOfType(Types.ContainerType.Regular);
            CreateStacksOfType(Types.ContainerType.Precious);

            //Debug
            LogContainers();

        }

        private void CreateStacksOfType(Types.ContainerType containerType)
        {
            //Gets all the containers of a specific type
            List<Container> containersOfType = _toBeStackedContainers.FindAll(c => c.Type == containerType);

            foreach (var container in containersOfType)
            {
                bool containerIsAdded = false;
                //...and tries to place it in a stack...
                for (int i = 0; i < _containerStacks.Count && !containerIsAdded; i++)
                {
                    if (_containerStacks[i].StackContainer(container))
                    {
                        containerIsAdded = true;
                    }
                    //If it can't be placed onto any stack, create a new stack
                    else if (i == _containerStacks.Count - 1)
                    {
                        ContainerStack newStack = new ContainerStack(container);
                        _containerStacks.Add(newStack);
                        containerIsAdded = true;
                    }

                }
            }
        }

        private void OrderContainersByWeight()
        {
            //Uses linq to sort by weight
            _toBeStackedContainers = _toBeStackedContainers.OrderByDescending(c => c.Weight).ToList();
        }

        private void LogContainers()
        {
            //Outputs every stack and its containers to the console
            int stack = 0;
            foreach (ContainerStack cs in _containerStacks)
            {
                Console.WriteLine(stack);
                Console.WriteLine($"Contains cooled: {cs.IsCooled}. Contains precious: {cs.IsPrecious}.");
                stack++;
                foreach (Container c in cs.StackedContainers)
                {
                    Console.WriteLine($"-----{c.Type} container, {c.Weight} tons.");
                }
            }
        }
    }
}