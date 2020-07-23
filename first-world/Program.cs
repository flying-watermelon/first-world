using System;
using System.Diagnostics;
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
            firstPlant.MaxAge = 101;
            firstPlant.MaxBreedingNumber = 2;
            firstPlant.BreedingAge = 50;
            firstPlant.BreedingPeriod = 50;
            firstPlant.ChildSpreadingRadius = 5.0f;
            world.Objects.Add(firstPlant);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            world.Start();

            stopwatch.Stop();
            System.Console.WriteLine(stopwatch.ElapsedMilliseconds);
        }
    }
}
