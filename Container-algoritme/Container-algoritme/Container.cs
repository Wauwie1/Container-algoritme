using System;

namespace Container_algoritme
{
    public class Container
    {
        public int Weight { get; private set; }
        public Types.ContainerType Type { get; private set; }



        //Constructor
        public Container(int weight, Types.ContainerType type)
        {
            //Initializes fields
            Weight = weight;
            Type = type;
        }

        public override string ToString()
        {

            return $"{Convert.ToString(Type)} {Weight} ton container.";
        }

    }
}
