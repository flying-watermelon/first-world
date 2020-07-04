using FirstWorld.Model;

namespace FirstWorld.Logic
{
    public interface ILaw
    {
        bool CanApply(IObject obj, World world);
        void Apply(IObject obj, World world);
    }
}
