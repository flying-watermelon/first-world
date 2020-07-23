using System;
using System.Numerics;
using FirstWorld.Model;

// using IObject;

namespace FirstWorld.Logic
{
    public interface IBreedable
    {
        long Age { get; }
        int MaxBreedingNumber { get; }
        long BreedingAge { get; }
        long BreedingPeriod { get; }
        IObject Breed();
    }
}
