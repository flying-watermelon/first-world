using System.Numerics;
using FirstWorld.Logic;

namespace FirstWorld.Model
{
    public class Animal : IObject, IGrowable, IDieable
    {
        public Vector3 Position { set; get; }
        public long Age { set; get; }
        public long MaxAge { set; get; }
        public float BreedingFactor { set; get; }
        public long BreedingAge { set; get; }
        public long BreedingPeriod { set; get; }
    }
}
