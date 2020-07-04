using FirstWorld.Model;

namespace FirstWorld.Logic
{
    public class Aging : ILaw
    {
        public bool CanApply(IObject obj)
        {
            return obj is Plant;
        }

        public void Apply(IObject obj)
        {
            if (obj is Plant plant)
            {
                plant.Age++;
            }
        }
    }
}
