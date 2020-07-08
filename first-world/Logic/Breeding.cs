using System;
using System.Numerics;
using FirstWorld.Model;

namespace FirstWorld.Logic
{
    public class Breeding : ILaw
    {
        public bool CanApply(IObject obj, World world)
        {
             return (obj is Plant plant)
                 && plant.Age>=plant.BreedingAge 
                 && (plant.Age-plant.BreedingAge)%plant.BreedingPeriod ==0;
        }

        public void Apply(IObject obj, World world)
        {
            if(obj is Plant plant)
            {
                var rand=new Random();
                float randomValue=Convert.ToSingle(rand.NextDouble());
                float breedMaxValue=(plant.Age-plant.BreedingAge)/plant.BreedingPeriod+1;
                var randBreed=new Random();
                int breedValue=randBreed.Next(0, (int)(plant.BreedingFactor*breedMaxValue));
                for (int i=0; i<breedValue; i++)
                {
                    Plant childPlant=new Plant();
                    childPlant.Age=0;
                    childPlant.Position=new Vector3((float)(plant.Position.X+Math.Sin(randomValue)*plant.SeedSpreadingRadius),
                                                     (float)(plant.Position.Y+Math.Cos(randomValue)*plant.SeedSpreadingRadius),
                                                     0.0f);
                    world.Objects.Add(childPlant);
                }
            }
        }
    }
}
