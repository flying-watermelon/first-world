using System.Security.AccessControl;
using System;
using System.Numerics;
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
            var rand = new Random();
            int breedNumber = rand.Next(1, breedable.MaxBreedingNumber + 1);

            for (int i = 0; i < breedNumber; i++)
            {
                IObject childObject = breedable.Breed();
                world.Objects.Add(childObject);

                float childPositionAngle = Convert.ToSingle(rand.NextDouble());
                childObject.Age = 0;
                childObject.Position = new Vector3(
                    (float)(breedable.Position.X + Math.Sin(childPositionAngle) * breedable.ChildSpreadingRadius),
                    (float)(breedable.Position.Y + Math.Cos(childPositionAngle) * breedable.ChildSpreadingRadius),
                    0.0f);
                childObject.BreedingAge = 50;
                childObject.BreedingPeriod = 25;
                childObject.MaxAge = 101;
                childObject.MaxBreedingNumber = 2;
                world.Objects.Add(childObject);
            }
        }
    }
}
