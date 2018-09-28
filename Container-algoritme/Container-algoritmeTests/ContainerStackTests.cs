using Microsoft.VisualStudio.TestTools.UnitTesting;
using Container_algoritme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Container_algoritme.Tests
{
    [TestClass()]
    public class ContainerStackTests
    {
        private List<Container> stackedContainers { get; set; }
        private int stackedWeightBottom { get; set; }

        [TestMethod()]
        public void StackContainerTest()
        {
            stackedContainers = new List<Container>();
            stackedWeightBottom = 0;
            Container container = new Container(120);
            bool test = StackContainer(container);

            Assert.AreEqual(true, test);

        }
        private bool StackContainer(Container container)
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
            if (stackedWeightBottom + container.weight > 120)
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