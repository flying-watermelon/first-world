using FirstWorld.Model;

namespace FirstWorld.Logic
{
    public interface ILaw
    {
        bool CanApply(IObject model);
        void Apply(IObject model);
    }
}
