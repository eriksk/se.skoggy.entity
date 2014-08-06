using EntityExample.Components;
using se.skoggy.entity.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityExample.Systems
{
    public class GravitySystem : EntitySystem
    {
        const float gravity = 0.000098f;

        public override void Update(float dt)
        {
            PositionComponent position = GetComponent<PositionComponent>();

            position.y += gravity * dt;

            base.Update(dt);
        }
    }
}
