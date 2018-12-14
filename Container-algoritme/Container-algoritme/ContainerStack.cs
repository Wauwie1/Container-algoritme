using System.Collections.Generic;

namespace Container_algoritme
{
    public class ContainerStack
    {

        public List<Container> StackedContainers { get; private set; }
        private int StackedWeightBottom { get; set; }
        private int TotalWeight { get; set; }

        public bool IsPrecious { get; private set; }
        public bool IsCooled { get; private set; }

        public int GetTotalWeight()
        {
            return CalculateTotalWeight();
        }
        //Constructor
        public ContainerStack(Container initialContainer)
        {
            //Initializes fields
            StackedContainers = new List<Container>();
            IsPrecious = false;
            IsCooled = false;
            //Add initialcontainer
            StackedContainers.Add(initialContainer);
            SetStackTypes(initialContainer);
            StackedWeightBottom = 0;
            TotalWeight = 0;
        }

        public bool StackContainer(Container container)
        {
            //Checks if a container can be stacked without exceeding the weight limit
            if (!IsTooHeavy(container) && !IsTopPrecious())
            {
                StackedContainers.Add(container);
                StackedWeightBottom += container.Weight;

                SetStackTypes(container);

                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsTooHeavy(Container container)
        {
            //Checks if the added weight exceeds the total weight of 120
            int bottomAndNewWeight = StackedWeightBottom + container.Weight;


            return bottomAndNewWeight > 120;
        }

        public bool IsTopPrecious()
        {
            int lastContainer = StackedContainers.Count - 1;

            return StackedContainers[lastContainer].Type == Types.ContainerType.Precious;
        }

        private int CalculateTotalWeight()
        {
            int result = 0;

            foreach(Container c in StackedContainers)
            {
                result += c.Weight;
            }

            return result;
        }

        private void SetStackTypes(Container container)
        {
            switch (container.Type)
            {
                case Types.ContainerType.Cooled:
                    IsCooled = true;
                    break;
                case Types.ContainerType.Precious:
                    IsPrecious = true;
                    break;
            }
        }

        public string GetContentsAsString()
        {
            string contents = "Contents: " + "\n";

            foreach (var container in StackedContainers)
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
