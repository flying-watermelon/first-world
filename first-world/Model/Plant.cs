using System;
using System.Numerics;
using FirstWorld.Logic;

namespace FirstWorld.Model
{
    public class Plant : IObject, IAgeable, IBreedable
    {
        public Vector3 Position { set; get; }
        public int Age { set; get; }
        public int MaxAge { set; get; }
        public int MaxBreedingNumber { set; get; }
        public int BreedingAge { set; get; }
        public int BreedingPeriod { set; get; }
        public float ChildSpreadingRadius { set; get; }
        public int BreedingAgeVariation { set; get; }
        public int MaxAgeVariation { set; get; }
        public IObject Breed()
        {
            Random rand = new Random();
            float positionAngle = Convert.ToSingle(rand.NextDouble() * Math.PI);
            float positionRadius = Convert.ToSingle(rand.NextDouble());

            Plant child = new Plant();
            child.Position = new Vector3(
                (float)(Position.X + Math.Sin(positionAngle) * ChildSpreadingRadius * positionRadius),
                (float)(Position.Y + Math.Cos(positionAngle) * ChildSpreadingRadius * positionRadius),
                0.0f);
            child.Age = 0;
            child.MaxAge = rand.Next((int)MaxAge - MaxAgeVariation, (int)MaxAge + MaxAgeVariation) ;
            child.MaxBreedingNumber = MaxBreedingNumber;
            child.BreedingAge = rand.Next((int)BreedingAge - BreedingAgeVariation, (int)BreedingAge + BreedingAgeVariation);
            child.BreedingPeriod = BreedingPeriod;
            child.ChildSpreadingRadius = ChildSpreadingRadius;

            return child;
        }
    }
}
