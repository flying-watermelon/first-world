using System.Numerics;
using FirstWorld.Logic;

namespace FirstWorld.Model
{
    public class Animal : IObject, IGrowable, IDieable, IBreedable
    {
        public Vector3 Position { set; get; }
        public long Age { set; get; }
        public long MaxAge { set; get; }
        public int MaxBreedingNumber { set; get; }
        public long BreedingAge { set; get; }
        public long BreedingPeriod { set; get; }
        public float ChildSpreadingRadius { set; get; }
    }
}
