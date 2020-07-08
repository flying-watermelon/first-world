using System.Numerics;

namespace FirstWorld.Model
{
    public class Plant : IObject
    {
        public Vector3 Position { set; get; }
        public long Age { set; get; }
        public long MaxAge { set; get; }
        public int MaxBreedingNumber { set; get; }
        public long BreedingAge { set; get; }
        public long BreedingPeriod { set; get; }
        public float SeedSpreadingRadius { set; get; }
    }
}
