using System;
using System.Numerics;
using FirstWorld.Logic;

namespace FirstWorld.Model
{
    public class Plant : IObject, IAgeable, IBreedable
    {
        public Vector3 Position { set; get; }
        public long Age { set; get; }
        public long MaxAge { set; get; }
        public int MaxBreedingNumber { set; get; }
        public long BreedingAge { set; get; }
        public long BreedingPeriod { set; get; }
        public float ChildSpreadingRadius { set; get; }
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
            child.MaxAge = MaxAge * (rand.Next(95,105)/100);
            child.MaxBreedingNumber = MaxBreedingNumber;
            child.BreedingAge = BreedingAge * (rand.Next(95,105)/100);
            child.BreedingPeriod = BreedingPeriod;
            child.ChildSpreadingRadius = ChildSpreadingRadius;

            return child;
        }
    }
}
