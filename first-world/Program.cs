using System;
using FirstWorld.Logic;
using FirstWorld.Model;

namespace FirstWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            IObject exampleObj = new Plant();
            (exampleObj as Plant).Age = 0;

            ILaw exampleLaw = new Aging();
            if (exampleLaw.CanApply(exampleObj))
            {
                exampleLaw.Apply(exampleObj);
            }

            Console.WriteLine((exampleObj as Plant).Age);
        }
    }
}
