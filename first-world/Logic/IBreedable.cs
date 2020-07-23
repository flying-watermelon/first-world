using System;
using System.Numerics;
using FirstWorld.Model;

// using IObject;

namespace FirstWorld.Logic
{
    public interface IBreedable
    {
        int Age { get; }
        int MaxBreedingNumber { get; }
        int BreedingAge { get; }
        int BreedingPeriod { get; }
        Vector3 Position { get; }
        float ChildSpreadingRadius { get; }
        IObject Breed();
    }
}
