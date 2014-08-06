using EntityExample.Components;
using se.skoggy.entity.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityExample.Systems
{
    public class PositionLoggerSystem : EntitySystem
    {
        public override void Update(float dt)
        {
            PositionComponent position = GetComponent<PositionComponent>();

            Console.WriteLine(String.Format("Position: x: '{0}', y: '{1}'", position.x, position.y));

            base.Update(dt);
        }
    }
}
