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
            for (int i = 0; i < 500; i++)
            {
                System.Console.WriteLine("Current time: " + i);
                System.Console.WriteLine("Current object count: " + Objects.Count);

                List<IObject> objectsSnapshot = new List<IObject>(Objects);
                foreach (IObject obj in objectsSnapshot)
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
