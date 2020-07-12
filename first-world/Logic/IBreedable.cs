using System.Numerics;
namespace FirstWorld.Logic
{
    public interface IBreedable
    {
        long Age { get; }
        int MaxBreedingNumber { get; }
        long BreedingAge { get; }
        long BreedingPeriod { get; }
        Vector3 Position { get; }
        float ChildSpreadingRadius { get; }
    }
}
