using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Container_algoritme
{
    public class Container
    {
        private int weight { get; set; }

        public int Weight {
            get
            {
                return this.weight;
            }
        }

        public Container(int weight)
        {
            this.weight = weight;
        }
    }
}
