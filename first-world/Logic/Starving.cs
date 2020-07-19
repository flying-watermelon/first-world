using System;
using FirstWorld.Model;

namespace FirstWorld.Logic
{
    public class Starving : ILaw
    {
        public bool CanApply(IObject obj, World world)
        {
            return obj is IStarvable;
        }

        public void Apply(IObject obj, World world)
        {
            IStarvable starvable = obj as IStarvable;
            starvable.FoodStorage -= starvable.FoodConsumption;

            if (starvable.FoodStorage < 0)
            {
                world.Objects.Remove(obj);
            }
        }
    }
}
