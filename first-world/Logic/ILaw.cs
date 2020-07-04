using FirstWorld.Model;

namespace FirstWorld.Logic
{
    public interface ILaw
    {
        bool CanApply(IObject obj);
        void Apply(IObject obj);
    }
}
