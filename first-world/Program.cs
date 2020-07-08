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

            Growing aging = new Growing();
            Breeding breeding = new Breeding();
            world.Laws.Add(aging);
            //world.Laws.Add(breeding);  TODO error

            firstPlant.Age = 0;
            firstPlant.BreedingAge = 50;
            firstPlant.BreedingPeriod = 5;
            firstPlant.LifeMax = 1000;
            firstPlant.BreedingFactor = 1;
            world.Objects.Add(firstPlant);

            world.Start();
            Console.WriteLine(firstPlant.Age);
            Console.WriteLine(world.Objects.Count);
        }
    }
}
