using System.Collections.Generic;
using FirstWorld.Logic;
using FirstWorld.Model;

namespace FirstWorld
{
    public class World
    {
        public ICollection<IObject> Objects { get; private set; }
        public ICollection<ILaw> Laws { get; private set; }

        public World()
        {
            Objects = new LinkedList<IObject>();
            Laws = new List<ILaw>();

        }

        public void Start()
        {
            for (int i = 0; i < 750; i++)
            {
                foreach (IObject obj in new List<IObject>(Objects))
                {
                    foreach (ILaw law in Laws)
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
