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
        public float ChildSpreadingRadius { set; get; }
        public IObject Breed()
        {
            Animal child = new Animal();
            child.Position = Position;
            child.Age = 0;
            child.MaxAge = MaxAge;
            child.MaxBreedingNumber = MaxBreedingNumber;
            child.BreedingAge = BreedingAge;
            child.BreedingPeriod = BreedingPeriod;
            child.ChildSpreadingRadius = ChildSpreadingRadius;

            return child;
        }
    }
}
