using System;
using FirstWorld.Model;

namespace FirstWorld.Logic
{
    public class Breeding : ILaw
    {
        public bool CanApply(IObject obj, World world)
        {
            return (obj is IBreedable breedable)
                && breedable.Age >= breedable.BreedingAge
                && (breedable.Age - breedable.BreedingAge) % breedable.BreedingPeriod == 0;
        }

        public void Apply(IObject obj, World world)
        {
            IBreedable breedable = obj as IBreedable;

            Random rand = new Random();
            int breedNumber = rand.Next(1, breedable.MaxBreedingNumber + 1);

            for (int i = 0; i < breedNumber; i++)
            {
                world.Objects.Add(breedable.Breed());
            }
        }
    }
}
