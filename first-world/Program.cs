using System;
using System.Numerics;
using FirstWorld.Logic;
using FirstWorld.Model;

namespace FirstWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            World world = new World();

            Aging aging = new Aging();
            Breeding breeding = new Breeding();
            world.Laws.Add(aging);
            world.Laws.Add(breeding);

            Plant firstPlant = new Plant();
            firstPlant.Position = new Vector3(0.0f, 0.0f, 0.0f);
            firstPlant.Age = 0;
            firstPlant.BreedingAge = 50;
            firstPlant.BreedingPeriod = 25;
            firstPlant.MaxAge = 101;
            firstPlant.MaxBreedingNumber = 2;
            world.Objects.Add(firstPlant);

            world.Start();
            Console.WriteLine(firstPlant.Age);
            Console.WriteLine(world.Objects.Count);
        }
    }
}
