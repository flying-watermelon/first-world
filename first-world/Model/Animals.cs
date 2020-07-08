using System.Numerics;

namespace FirstWorld.Model
{
    public class Animal : IObject
    {
        public Vector3 Position { set; get; }
        public ulong Age { set; get; }
        public ulong LifeMax { set; get; }
        public float BreedingFactor { set; get; }
        public ulong BreedingAge { set; get; }
        public ulong BreedingPeriod { set; get; }
    }
}
