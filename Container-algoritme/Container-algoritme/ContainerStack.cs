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

        public bool IsPrecious { get; private set; }
        public bool IsCooled { get; private set; }

        public int GetTotalWeight()
        {
            return CalculateTotalWeight();
        }
        //Constructor
        public ContainerStack(Container InitialContainer)
        {
            //Initializes fields
            stackedContainers = new List<Container>();
            IsPrecious = false;
            IsCooled = false;
            //Add initialcontainer
            stackedContainers.Add(InitialContainer);
            SetStackTypes(InitialContainer);
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

                SetStackTypes(container);

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


            return bottomAndNewWeight > 120;
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

        private int CalculateTotalWeight()
        {
            int result = 0;

            foreach(Container c in stackedContainers)
            {
                result += c.weight;
            }

            return result;
        }

        private void SetStackTypes(Container container)
        {
            if (container.type == Types.ContainerType.cooled)
            {
                IsCooled = true;
            }
            if (container.type == Types.ContainerType.precious)
            {
                IsPrecious = true;
            }
        }

        public string GetContentsAsString()
        {
            string contents = "Contents: " + "\n";

            foreach (var container in stackedContainers)
            {
                contents += container + "\n";
            }

            return contents;
        }
        public override string ToString()
        {
            return "Stack";
        }

    }
}
