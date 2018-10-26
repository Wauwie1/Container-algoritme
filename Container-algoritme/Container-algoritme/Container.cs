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
        public Types.ContainerType type { get; private set; }



        //Constructor
        public Container(int weight, Types.ContainerType type)
        {
            //Initializes fields
            this.weight = weight;
            this.type = type;
        }

        public override string ToString()
        {

            return $"{Convert.ToString(type)} {weight} ton container.";
        }

    }
}
