using FirstWorld.Model;

namespace FirstWorld.Logic
{
    public class Breeding : ILaw
    {
        public bool CanApply(IObject obj, World world)
        {
            return true;
        }

        public void Apply(IObject obj, World world)
        {
        }
    }
}
