using System.Collections.Generic;
using FirstWorld.Logic;
using FirstWorld.Model;

namespace FirstWorld
{
    public class World
    {
        public IList<IObject> Objects { get; private set; }
        public IList<ILaw> Laws { get; private set; }

        public World()
        {
            Objects = new List<IObject>();
            Laws = new List<ILaw>();
        }

        public void Start()
        {
            for (int i = 0; i < 1000; i++)
            {
                foreach (var obj in Objects)
                {
                    foreach (var law in Laws)
                    {
                        if (law.CanApply(obj, this))
                        {
                            law.Apply(obj, this);
                        }
                    }
                }
            }
        }
    }
}
