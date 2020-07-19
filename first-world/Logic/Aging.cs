using FirstWorld.Model;

namespace FirstWorld.Logic
{
    public class Aging : ILaw
    {
        public bool CanApply(IObject obj, World world)
        {
            return obj is IAgeable;
        }

        public void Apply(IObject obj, World world)
        {
            IAgeable ageable = obj as IAgeable;
            ageable.Age++;

            if (ageable.Age > ageable.MaxAge)
            {
                world.Objects.Remove(obj);
            }
        }
    }
}
