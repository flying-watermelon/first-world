using FirstWorld.Model;

namespace FirstWorld.Logic
{
    public class Growing : ILaw
    {
        public bool CanApply(IObject obj, World world)
        {
            return obj is IGrowable;
        }

        public void Apply(IObject obj, World world)
        {
            IGrowable growable = obj as IGrowable;
            growable.Age++;
        }
    }
}
