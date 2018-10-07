using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Container_algoritme
{
    public class ContainerStack
    {

        //TODO: Make private
        public List<Container> stackedContainers { get; set; }
        private int stackedWeightBottom { get; set; }
        private int totalWeight { get; set; }

        //Constructor
        public ContainerStack(Container InitialContainer)
        {
            //Initializes fields
            stackedContainers = new List<Container>();
            //Add initialcontainer
            stackedContainers.Add(InitialContainer);
            stackedWeightBottom = 0;
            totalWeight = 0;
        }

        public bool StackContainer(Container container)
        {
            //Checks if a container can be stacked without exceeding the weight limit
            if (!IsTooHeavy(container) && !IsTopPrecious())
            {
                stackedContainers.Add(container);
                stackedWeightBottom += container.weight;
                return true;
            }
            else
            {
                return false;
                throw new Exception("Weightlimit exceeded or precious");
            }
        }

        private bool IsTooHeavy(Container container)
        {
            //Checks if the added weight exceeds the total weight of 120
            int bottomAndNewWeight = stackedWeightBottom + container.weight;


            if (bottomAndNewWeight > 120)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsTopPrecious()
        {
            int lastContainer = stackedContainers.Count - 1;

            if(stackedContainers[lastContainer].type == Types.ContainerType.precious)
            {
                return true;
            }else
            {
                return false;
            }
        }

        private void CalculateTotalWeight()
        {
            foreach(Container c in stackedContainers)
            {
                totalWeight += c.weight;
            }
        }
        
    }
}
