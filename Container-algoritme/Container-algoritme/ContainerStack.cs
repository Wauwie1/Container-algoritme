﻿using System;
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

        public ContainerStack()
        {
            stackedWeightBottom = 0;
        }

        public bool StackContainer(Container container)
        {
            if (!IsTooHeavy(container))
            {
                stackedContainers.Add(container);
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsTooHeavy(Container container)
        {
            if(stackedWeightBottom + container.Weight > 120)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
