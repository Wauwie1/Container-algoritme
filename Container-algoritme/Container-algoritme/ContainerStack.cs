using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Container_algoritme
{
    public class ContainerStack
    {
        private List<Container> stackedContainers { get; set; }
        private int stackedWeightBottom { get; set; }

        //Constructor
        public ContainerStack(Container InitialContainer)
        {
            //Initializes fields
            stackedContainers = new List<Container>();
            //Add initialcontainer
            stackedContainers.Add(InitialContainer);
            stackedWeightBottom = 0;
        }

        public bool StackContainer(Container container)
        {
            //Checks if a container can be stacked without exceeding the weight limit
            if (!IsTooHeavy(container) && !IsTopPrecious())
            {
                stackedContainers.Add(container);
                return true;
            }
            else
            {
                throw new Exception("Weightlimit exceeded");
            }
        }

        private bool IsTooHeavy(Container container)
        {
            //Checks if the added weight exceeds the total weight of 120
            if(stackedWeightBottom + container.weight > 120)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsTopPrecious()
        {
            int lastContainer = stackedContainers.Count;

            if(stackedContainers[lastContainer].type == Types.ContainerType.precious)
            {
                return true;
            }else
            {
                return false;
            }
        }
    }
}
