using System;

namespace InterfaceListRoutineTest
{
    public class Cat : IAnimal,ICloneable
    {
        public int ID { get; set; }

        public Cat Child { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}