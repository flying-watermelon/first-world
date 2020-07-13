using System.Numerics;

namespace FirstWorld.Model
{
    public interface IObject
    {
        public long Age { set; get; }
        public long MaxAge { set; get; }
        public Vector3 Position { set; get; }
        public long BreedingAge { set; get; }
        public long BreedingPeriod { set; get; }
        public int MaxBreedingNumber { set; get; }
    }
}
