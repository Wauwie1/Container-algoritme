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
        private int totalWeight { get; set; }

        [TestMethod()]
        public void StackContainerTest()
        {
            stackedContainers = new List<Container>();
            stackedWeightBottom = 0;
            totalWeight = 0;
            Container container = new Container(120, Types.ContainerType.regular);
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

        [TestMethod()]
        public void IsTopPreciousTest1()
        {
            stackedContainers = new List<Container>();
            
            bool test = false;

            Container cont1 = new Container(90, Types.ContainerType.regular);
            Container cont2 = new Container(90, Types.ContainerType.regular);
            Container cont3 = new Container(90, Types.ContainerType.precious);

            stackedContainers.Add(cont1);
            stackedContainers.Add(cont2);
            stackedContainers.Add(cont3);
            int lastContainer = stackedContainers.Count - 1;


            if (stackedContainers[lastContainer].type == Types.ContainerType.precious)
            {
                test = true;
            }
            else
            {
                test = false;
            }
            Assert.AreEqual(true, test);
        }

        [TestMethod()]
        public void IsTopPreciousTest2()
        {
            stackedContainers = new List<Container>();

            bool test = false;

            Container cont1 = new Container(90, Types.ContainerType.regular);
            Container cont2 = new Container(90, Types.ContainerType.regular);
            Container cont3 = new Container(90, Types.ContainerType.cooled);

            stackedContainers.Add(cont1);
            stackedContainers.Add(cont2);
            stackedContainers.Add(cont3);
            int lastContainer = stackedContainers.Count - 1;


            if (stackedContainers[lastContainer].type == Types.ContainerType.precious)
            {
                test = true;
            }
            else
            {
                test = false;
            }
            Assert.AreEqual(false, test);
        }
    }
}