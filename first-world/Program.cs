using System;
using FirstWorld.Logic;
using FirstWorld.Model;

namespace FirstWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            World world = new World();
            Plant firstPlant = new Plant();
            firstPlant.Age = 0;
            firstPlant.LifeMax=1000;
            world.Objects.Add(firstPlant);

            Aging aging = new Aging();
            world.Laws.Add(aging);

            world.Start();
            Console.WriteLine(firstPlant.Age);
        }
    }
}
