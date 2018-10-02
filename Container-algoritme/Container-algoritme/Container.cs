using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Container_algoritme
{
    public class Container
    {
        public int weight { get; private set; }
        private Types.ContainerType type { get;}



        //Constructor
        public Container(int weight, Types.ContainerType type)
        {
            //Initializes fields
            this.weight = weight;
            this.type = type;
        }

        public override string ToString()
        {

            return string.Format("{0} {1} ton container.", Convert.ToString(type), weight);
        }

    }
}
