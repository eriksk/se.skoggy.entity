using EntityExample.Components;
using EntityExample.Systems;
using se.skoggy.entity.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new EntityEngine();

            var entity = engine.CreateEntity();

            entity.AddComponent(new PositionComponent());
            entity.AddSystem(new GravitySystem());
            entity.AddSystem(new PositionLoggerSystem());
            entity.AddSystem(new DestroyAfterSystem(100f));

            engine.Start();

            for (int i = 0; i < 100; i++)
            {
                engine.Update(16f);          
            }

            Console.WriteLine("Entities: " + engine.EntityCount);
            entity.Destroy();
            Console.WriteLine("Entities: " + engine.EntityCount);

            Console.ReadKey();
        }
    }
}
