using FirstWorld.Model;

namespace FirstWorld.Logic
{
    public class Dying : ILaw
    {
        public bool CanApply(IObject obj, World world)
        {
            return (obj is IDieable dieable) && (dieable.Age > dieable.MaxAge);
        }

        public void Apply(IObject obj, World world)
        {
            world.Objects.Remove(obj);
        }
    }
}
