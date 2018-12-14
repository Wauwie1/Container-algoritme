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
        private List<Container> StackedContainers { get; set; }
        private int StackedWeightBottom { get; set; }
        private int TotalWeight { get; set; }

        [TestMethod()]
        public void StackContainerTest()
        {
            StackedContainers = new List<Container>();
            StackedWeightBottom = 0;
            TotalWeight = 0;
            Container container = new Container(120, Types.ContainerType.Regular);
            bool test = StackContainer(container);

            Assert.AreEqual(true, test);

        }
        private bool StackContainer(Container container)
        {
            if (!IsTooHeavy(container))
            {
                StackedContainers.Add(container);
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsTooHeavy(Container container)
        {
            if (StackedWeightBottom + container.Weight > 120)
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
            StackedContainers = new List<Container>();
            
            bool test = false;

            Container cont1 = new Container(90, Types.ContainerType.Regular);
            Container cont2 = new Container(90, Types.ContainerType.Regular);
            Container cont3 = new Container(90, Types.ContainerType.Precious);

            StackedContainers.Add(cont1);
            StackedContainers.Add(cont2);
            StackedContainers.Add(cont3);
            int lastContainer = StackedContainers.Count - 1;


            if (StackedContainers[lastContainer].Type == Types.ContainerType.Precious)
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
            StackedContainers = new List<Container>();

            bool test = false;

            Container cont1 = new Container(90, Types.ContainerType.Regular);
            Container cont2 = new Container(90, Types.ContainerType.Regular);
            Container cont3 = new Container(90, Types.ContainerType.Cooled);

            StackedContainers.Add(cont1);
            StackedContainers.Add(cont2);
            StackedContainers.Add(cont3);
            int lastContainer = StackedContainers.Count - 1;


            if (StackedContainers[lastContainer].Type == Types.ContainerType.Precious)
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