using se.skoggy.entity.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityExample.Systems
{
    public class DestroyAfterSystem : EntitySystem
    {
        float time;

        public DestroyAfterSystem(float time)
        {
            this.time = time;
        }

        public override void Update(float dt)
        {
            time -= dt;
            if (time <= 0f) 
            {
                Entity.Destroy();
            }
            base.Update(dt);
        }
    }
}
