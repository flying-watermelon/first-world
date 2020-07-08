using FirstWorld.Model;

namespace FirstWorld.Logic
{
    public class Growing : ILaw
    {
        public bool CanApply(IObject obj, World world)
        {
            return obj is Plant;
        }

        public void Apply(IObject obj, World world)
        {
            if (obj is Plant plant)
            {
                plant.Age++;
            }
        }
    }
}
