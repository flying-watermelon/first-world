using System;
using System.Numerics;
using FirstWorld.Logic;

namespace FirstWorld.Model
{
    public class Animal : IObject, IAgeable, IBreedable
    {
        public Vector3 Position { set; get; }
        public long Age { set; get; }
        public long MaxAge { set; get; }
        public int MaxBreedingNumber { set; get; }
        public long BreedingAge { set; get; }
        public long BreedingPeriod { set; get; }
        public IObject Breed()
        {
            Random rand = new Random();
            Animal child = new Animal();
            child.Position = Position;
            child.Age = 0;
            child.MaxAge = MaxAge * (rand.Next(95,105)/100);
            child.MaxBreedingNumber = MaxBreedingNumber;
            child.BreedingAge = BreedingAge * (rand.Next(95,105)/100);
            child.BreedingPeriod = BreedingPeriod;

            return child;
        }
    }
}
