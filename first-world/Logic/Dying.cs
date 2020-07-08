using System;
using System.Numerics;
using FirstWorld.Model;

namespace FirstWorld.Logic
{
    public class Dying : ILaw
    {
        public bool CanApply(IObject obj, World world)
        {
            return (obj is Plant plant) && (plant.Age > plant.MaxAge);
        }

        public void Apply(IObject obj, World world)
        {
            if (obj is Plant plant)
            {
                world.Objects.Remove(plant);
            }
        }
    }
}
